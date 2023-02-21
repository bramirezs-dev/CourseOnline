using CourseOnline.Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CourseOnline.Application.Features.Security.Commands.DeleteRol
{
    public class DeleteRolHandler : IRequestHandler<DeleteRolCommand>
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public DeleteRolHandler(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<Unit> Handle(DeleteRolCommand request, CancellationToken cancellationToken)
        {
            var role = await _roleManager.FindByNameAsync(request.Name);

            if (role == null)
            {
                 throw new CustomException<object>{
                    Response = new { message = "not exist rol"},
                    StatusCode = System.Net.HttpStatusCode.BadRequest
                };
            }

            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return Unit.Value;
            }
            throw new Exception("role cannot be deleted");
        }
    }
}