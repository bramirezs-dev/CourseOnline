using System;
using FluentValidation;

namespace CourseOnline.Application.Features.Instructors.Command.UpdateInstructor
{
	public class UpdateInstructorValidator : AbstractValidator<UpdateInstructorCommand>
	{
		public UpdateInstructorValidator()
		{
            RuleFor(instructor => instructor.Name).NotNull().NotEmpty().WithMessage("it's required name");
            RuleFor(instructor => instructor.LastName).NotNull().NotEmpty().WithMessage("it's required lastname");
            RuleFor(instructor => instructor.Grade).NotNull().NotEmpty().WithMessage("it's required grade");
            RuleFor(instructor => instructor.InstructorId).NotNull().NotEmpty().WithMessage("it's required instructor id");
        }
	}
}

