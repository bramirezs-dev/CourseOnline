using System;
using System.Linq;
using AutoMapper;
using CourseOnline.Application.DTOs.Login;
using CourseOnline.Application.Exceptions;
using CourseOnline.Application.Interfaces;
using CourseOnline.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CourseOnline.Application.Features.Security.Commands.Register
{
	public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, UserDTO>
	{
        private readonly IUserRepositoryAsync _userRepository;
        private readonly UserManager<User> _userManager;
        private readonly IJwtGenerator _jwtGenerator;
        private readonly IMapper _mapper;

        public RegisterUserCommandHandler( IUserRepositoryAsync userRepository,UserManager<User> userManager, IJwtGenerator jwtGenerator, IMapper mapper)
		{
            _userRepository = userRepository;
            _userManager = userManager;
            _jwtGenerator = jwtGenerator;
            _mapper = mapper;
        }

        public async Task<UserDTO> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var existEmail = await _userRepository.ExistEmail(request.Email);
            if (existEmail)
            {
                throw new CustomException<object>
                {
                    Response = new { message = "Email ready exist" },
                    StatusCode = System.Net.HttpStatusCode.BadGateway
                };
            }

            var existUserName = await _userRepository.ExistUserName(request.UserName);


            if (existUserName)
            {
                throw new CustomException<object>
                {
                    Response = new { message = "UserName ready exist" },
                    StatusCode = System.Net.HttpStatusCode.BadGateway
                };
            }

            var user = new User
            {
                Email = request.Email,
                NameComplete = $"{request.Name} {request.LastName}",
                UserName = request.UserName
            };

           var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                var sendUser = _mapper.Map<UserDTO>(user);
                sendUser.Token = _jwtGenerator.CreateToken(user,null);

                return sendUser;
            }

            throw new Exception("Can`t enter user");

        }
    }
}

