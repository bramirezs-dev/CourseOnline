using System;
using FluentValidation;

namespace CourseOnline.Application.Features.Courses.Commands.UpdateCourse
{
	public class UpdateCourseValidator : AbstractValidator<UpdateCourseCommand>
	{
		public UpdateCourseValidator()
		{
			RuleFor(course => course.CourseId).NotNull().NotEmpty().WithMessage("CourseId is required");

            RuleFor(course => course.Description).NotNull().NotEmpty().WithMessage("Description is required");

            RuleFor(course => course.Title).NotNull().NotEmpty().WithMessage("Title is required");

			RuleFor(course => course.Instructors).NotNull().NotEmpty().WithMessage("Instructors is required");
        }
	}
}

