using CourseOnline.Application.DTOs.Login;
using CourseOnline.Application.Exceptions;
using CourseOnline.Application.Interfaces;
using CourseOnline.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CourseOnline.Application.Features.Security.Commands.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UserDTO>
    {
         private readonly UserManager<User> _userManager;
         private readonly IJwtGenerator _jwtGenerator;

         private readonly IUserRepositoryAsync _userRepository;

         private readonly IPasswordHasher<User> _passwordHasher;
        public UpdateUserHandler(UserManager<User> userManager, IJwtGenerator jwtGenerator, IUserRepositoryAsync userRepository,IPasswordHasher<User> passwordHasher)
        {
            _jwtGenerator = jwtGenerator;
            _userManager = userManager;
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }
        public async Task<UserDTO> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.Username);
            if (user == null)
            {
                 throw new CustomException<object>{
                    Response = new { message = "not exist user"},
                    StatusCode = System.Net.HttpStatusCode.NotFound
                };
            }

            var existEmail = await _userRepository.ExistEmailAndUsername(request.Email, request.Username);

             if (existEmail)
            {
                 throw new CustomException<object>{
                    Response = new { message = "email belongs to another user "},
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            }

            user.NameComplete = $"{request.Name} {request.LastName}";
            user.PasswordHash = _passwordHasher.HashPassword(user,request.Password);
            user.Email = request.Email;

            var resultUpdate = await _userManager.UpdateAsync(user);

            var roles = await _userManager.GetRolesAsync(user);
            if (resultUpdate.Succeeded)
            {
                return new UserDTO {
                    NameComplete = user.NameComplete,
                    UserName = user.UserName,
                    Email = user.Email,
                    Token = _jwtGenerator.CreateToken(user,roles.ToList())
                };
            }
            throw new Exception("Can't be update user");
        }
    }
}