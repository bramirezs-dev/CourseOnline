using System;
using MediatR;

namespace CourseOnline.Application.Features.Instructors.Command.DeleteInstructor
{
	public class DeleteInstructorCommand :IRequest
	{
		public Guid InstructorId { get; set; }
	}
}

