using System;
using CourseOnline.Domain.Entities;

namespace CourseOnline.Application.Interfaces
{
	public interface IJwtGenerator
	{
		string CreateToken(User user, List<string> roles);
	}
}

