using System;
using MediatR;

namespace CourseOnline.Application.Features.Instructors.Command.CreateInstructor
{
	public class CreateInstructorCommand : IRequest
	{
		public string Name { get; set; }

		public string  LastName { get; set; }

		public string Grade { get; set; }

	}
}

