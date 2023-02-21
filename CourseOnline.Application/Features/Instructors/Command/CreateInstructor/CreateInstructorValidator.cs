using System;
using FluentValidation;

namespace CourseOnline.Application.Features.Instructors.Command.CreateInstructor
{
	public class CreateInstructorValidator : AbstractValidator<CreateInstructorCommand>
	{
		public CreateInstructorValidator()
		{
			RuleFor(instructor => instructor.Name).NotNull().NotEmpty().WithMessage("it's required name");
            RuleFor(instructor => instructor.LastName).NotNull().NotEmpty().WithMessage("it's required lastname");
            RuleFor(instructor => instructor.Grade).NotNull().NotEmpty().WithMessage("it's required grade");
        }
	}
}

