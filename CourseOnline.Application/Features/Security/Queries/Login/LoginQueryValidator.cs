using System;
using FluentValidation;

namespace CourseOnline.Application.Features.Security.Queries.Login
{
	public class LoginQueryValidator : AbstractValidator<LoginQuery>
	{
		public LoginQueryValidator()
		{
			RuleFor(login => login.Email).NotEmpty().NotNull().WithMessage("It's necesary Email");
            RuleFor(login => login.Password).NotEmpty().NotNull().WithMessage("It's necesary Email");

        }
	}
}

