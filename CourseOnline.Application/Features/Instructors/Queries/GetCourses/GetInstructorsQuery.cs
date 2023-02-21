using System;
using CourseOnline.Domain.DapperEntities;
using MediatR;

namespace CourseOnline.Application.Features.Instructors.Queries.GetCourses
{
	public class GetInstructorsQuery : IRequest<IEnumerable<InstructorModel>>
	{
			
	}
}

