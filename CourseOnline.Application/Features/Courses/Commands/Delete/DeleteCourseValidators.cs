using System;
using FluentValidation;

namespace CourseOnline.Application.Features.Courses.Commands.DeleteCourse
{
	public class DeleteCourseValidators :AbstractValidator<DeleteCourseCommand>
	{
		public DeleteCourseValidators()
		{
			RuleFor(course => course.CourseId).NotNull().NotEmpty().WithMessage("CourseId is required");
		}
	}
}

