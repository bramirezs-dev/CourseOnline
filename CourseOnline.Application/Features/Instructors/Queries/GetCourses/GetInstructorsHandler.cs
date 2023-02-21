using System;
using CourseOnline.Application.Interfaces.Instructors;
using CourseOnline.Domain.DapperEntities;
using MediatR;

namespace CourseOnline.Application.Features.Instructors.Queries.GetCourses
{
	public class GetInstructorsHandler :IRequestHandler<GetInstructorsQuery, IEnumerable<InstructorModel>>
	{
        private readonly IInstructorRepositoryAsync _instructorRepository;

        public GetInstructorsHandler(IInstructorRepositoryAsync instructorRepository)
		{
            _instructorRepository = instructorRepository;
        }

        public async Task<IEnumerable<InstructorModel>> Handle(GetInstructorsQuery request, CancellationToken cancellationToken)
        {
            return await _instructorRepository.Getinstructors();
        }
    }
}

