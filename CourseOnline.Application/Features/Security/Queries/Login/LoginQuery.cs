using System;
using CourseOnline.Application.DTOs.Login;
using CourseOnline.Domain.Entities;
using MediatR;

namespace CourseOnline.Application.Features.Security.Queries.Login
{
	public class LoginQuery :IRequest<UserDTO>
	{
		public string Email { get; set; }

        public string Password { get; set; }
    }
}

