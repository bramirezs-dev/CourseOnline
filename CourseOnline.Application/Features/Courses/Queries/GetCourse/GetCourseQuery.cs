using System;
using CourseOnline.Application.DTOs.Courses;
using MediatR;

namespace CourseOnline.Application.Features.Courses.Queries.GetCourse
{
	public class GetCourseQuery :IRequest<CourseDTO>
	{
		public Guid Id { get; set; }
	}
}

