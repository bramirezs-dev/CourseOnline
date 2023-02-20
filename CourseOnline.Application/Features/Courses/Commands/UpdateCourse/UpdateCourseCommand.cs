using System;
using MediatR;

namespace CourseOnline.Application.Features.Courses.Commands.UpdateCourse
{
	public class UpdateCourseCommand : IRequest
	{
		public Guid CourseId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? PublishDate { get; set; }

        public List<Guid> Instructors { get; set; }

        public decimal? Price { get; set; }

        public decimal? Promotion { get; set; }


    }
}

