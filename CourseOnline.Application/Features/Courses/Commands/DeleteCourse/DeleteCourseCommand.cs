using System;
using MediatR;

namespace CourseOnline.Application.Features.Courses.Commands.DeleteCourse
{
	public class DeleteCourseCommand : IRequest
	{
		public Guid CourseId { get; set; }
	}
}

