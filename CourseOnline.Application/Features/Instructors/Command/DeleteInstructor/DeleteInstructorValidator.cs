using System;
using FluentValidation;

namespace CourseOnline.Application.Features.Instructors.Command.DeleteInstructor
{
	public class DeleteInstructorValidator : AbstractValidator<DeleteInstructorCommand>
	{
		public DeleteInstructorValidator()
		{
		}
	}
}

