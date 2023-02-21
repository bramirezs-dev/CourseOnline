using System;
using MediatR;

namespace CourseOnline.Application.Features.Instructors.Command.UpdateInstructor
{
	public class UpdateInstructorCommand :IRequest
	{
        public Guid InstructorId { get; set; }
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Grade { get; set; }
    }
}

