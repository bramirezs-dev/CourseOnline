using System;
using CourseOnline.Application.DTOs.Login;
using MediatR;

namespace CourseOnline.Application.Features.Security.Commands.Register
{
	public class RegisterUserCommand : IRequest<UserDTO>
	{
		public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string  UserName { get; set; }
    }
}

