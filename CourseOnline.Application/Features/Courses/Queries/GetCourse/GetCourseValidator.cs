using System;
using FluentValidation;

namespace CourseOnline.Application.Features.Courses.Queries.GetCourse
{
	public class GetCourseValidator :AbstractValidator<GetCourseQuery>
	{
		public GetCourseValidator()
		{
			RuleFor(course => course.Id).NotNull().NotEmpty().WithMessage("Id is required");
		}
	}
}

