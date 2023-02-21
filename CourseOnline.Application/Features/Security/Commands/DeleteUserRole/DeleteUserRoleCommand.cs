using MediatR;

namespace CourseOnline.Application.Features.Security.Commands.DeleteUserRole
{
    public class DeleteUserRoleCommand : IRequest
    {
        public string Username { get; set; }

        public string Rolname { get; set; }
    }
}