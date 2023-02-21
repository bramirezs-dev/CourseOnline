using System;
using CourseOnline.Domain.DapperEntities;
using MediatR;

namespace CourseOnline.Application.Features.Instructors.Queries.GetInstructor
{
	public class GetInstructorQuery : IRequest<InstructorModel>
	{
		public Guid InstructorId { get; set; }
	}
}

