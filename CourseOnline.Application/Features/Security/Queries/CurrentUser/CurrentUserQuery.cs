using System;
using CourseOnline.Application.DTOs.Login;
using CourseOnline.Domain.Entities;
using MediatR;

namespace CourseOnline.Application.Features.Security.Queries.CurrentUser
{
	public class CurrentUserQuery : IRequest<UserDTO>
	{


	}
}

