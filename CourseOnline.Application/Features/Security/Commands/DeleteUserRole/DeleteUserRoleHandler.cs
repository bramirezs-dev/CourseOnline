using CourseOnline.Application.Exceptions;
using CourseOnline.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CourseOnline.Application.Features.Security.Commands.DeleteUserRole
{
    public class DeleteUserRoleHandler : IRequestHandler<DeleteUserRoleCommand>
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager; 
        public DeleteUserRoleHandler(UserManager<User> userManager, RoleManager<IdentityRole> roleManager )
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<Unit> Handle(DeleteUserRoleCommand request, CancellationToken cancellationToken)
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

            var result = await _userManager.RemoveFromRoleAsync(user,request.Rolname);

            if (result.Succeeded)
            {
                return Unit.Value;
            }

            throw new Exception("role cannot be delete a user");

        }
    }
}