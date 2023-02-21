using MediatR;

namespace CourseOnline.Application.Features.Security.Commands.AddUserRole
{
    public class AddUserRoleCommand : IRequest
    {
        public string Username { get; set; }

        public string Rolname { get; set; }
    }
}