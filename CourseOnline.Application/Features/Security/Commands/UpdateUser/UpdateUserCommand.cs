using CourseOnline.Application.DTOs.Login;
using MediatR;

namespace CourseOnline.Application.Features.Security.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<UserDTO>
    {
        public string CompleteName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Username { get; set; }
    }
}