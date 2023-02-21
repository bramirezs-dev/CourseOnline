using System;
using FluentValidation;

namespace CourseOnline.Application.Features.Instructors.Queries.GetInstructor
{
	public class GetInstructorValidator: AbstractValidator<GetInstructorQuery>
	{
		public GetInstructorValidator()
		{
		}
	}
}

