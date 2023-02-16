using System;
using FluentValidation;

namespace CourseOnline.Application.Features.Security.Commands.Register
{
	public class RegisterUserCommandValdiator : AbstractValidator<RegisterUserCommand>
	{
		public RegisterUserCommandValdiator()
		{
			RuleFor(prop => prop.Email).NotNull().NotEqual(String.Empty).WithMessage("Email is required");

            RuleFor(prop => prop.Password).NotNull().NotEqual(String.Empty).WithMessage("Password is required");

            RuleFor(prop => prop.Name).NotNull().NotEqual(String.Empty).WithMessage("Name is required");

            RuleFor(prop => prop.LastName).NotNull().NotEqual(String.Empty).WithMessage("LastName is required");

            RuleFor(prop => prop.UserName).NotNull().NotEqual(String.Empty).WithMessage("UserName is required");
        }
	}
}

