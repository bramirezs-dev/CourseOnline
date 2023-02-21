using CourseOnline.Application.Exceptions;
using CourseOnline.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CourseOnline.Application.Features.Security.Queries.GetRolesByUser
{
    public class GetRolesByUserHandler : IRequestHandler<GetRolesByUserQuery, List<string>>
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager; 

        public GetRolesByUserHandler(UserManager<User> userManager, RoleManager<IdentityRole> roleManager )
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<List<string>> Handle(GetRolesByUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.Username);
            if (user == null)
            {
                 throw new CustomException<object>{
                    Response = new { message = "not exist user"},
                    StatusCode = System.Net.HttpStatusCode.NotFound
                };
            }

            var roles = await _userManager.GetRolesAsync(user);

            return roles.ToList();

        }
    }
}