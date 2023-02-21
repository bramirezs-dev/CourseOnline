using CourseOnline.Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CourseOnline.Application.Features.Security.Commands.NewRol
{
    public class NewRolHandler : IRequestHandler<NewRolCommand>
    {
        private readonly RoleManager<IdentityRole> _identityRole;
        public NewRolHandler(RoleManager<IdentityRole> identityRole)
        {
            _identityRole = identityRole;
        }
        public async Task<Unit> Handle(NewRolCommand request, CancellationToken cancellationToken)
        {
            var role = await _identityRole.FindByNameAsync(request.Name);
            if (role != null)
            {
                throw new CustomException<object>{
                    Response = new { message = "already exist rol"},
                    StatusCode = System.Net.HttpStatusCode.BadRequest
                };
            }

            var result = await _identityRole.CreateAsync(new IdentityRole(request.Name));
            if (result.Succeeded)
            {
                return Unit.Value;
            }

            throw new Exception("Can't save rol");

        }
    }
}