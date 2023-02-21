using CourseOnline.Application.Exceptions;
using CourseOnline.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CourseOnline.Application.Features.Security.Commands.AddUserRole
{
    public class AddUserRoleHandler : IRequestHandler<AddUserRoleCommand>
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager; 
        public AddUserRoleHandler(UserManager<User> userManager, RoleManager<IdentityRole> roleManager )
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<Unit> Handle(AddUserRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await _roleManager.FindByNameAsync(request.Rolname);
            if (role == null)
            {
                 throw new CustomException<object>{
                    Response = new { message = "not exist rol"},
                    StatusCode = System.Net.HttpStatusCode.NotFound
                };
            }
            var user = await _userManager.FindByNameAsync(request.Username);
            if (user == null)
            {
                 throw new CustomException<object>{
                    Response = new { message = "not exist user"},
                    StatusCode = System.Net.HttpStatusCode.NotFound
                };
            }

            var result = await _userManager.AddToRoleAsync(user,request.Rolname);

            if (result.Succeeded)
            {
                return Unit.Value;
            }

            throw new Exception("role cannot be Added a user");


            
        }
    }
}