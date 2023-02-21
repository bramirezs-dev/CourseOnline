using System;
using System.Net;
using CourseOnline.Application.Exceptions;
using CourseOnline.Application.Interfaces.Instructors;
using CourseOnline.Domain.DapperEntities;
using MediatR;

namespace CourseOnline.Application.Features.Instructors.Queries.GetInstructor
{
	public class GetInstructorHandler : IRequestHandler<GetInstructorQuery, InstructorModel>
	{
        private readonly IInstructorRepositoryAsync _instructorRepository;

        public GetInstructorHandler(IInstructorRepositoryAsync instructorRepository)
		{
            _instructorRepository = instructorRepository;
        }

        public async Task<InstructorModel> Handle(GetInstructorQuery request, CancellationToken cancellationToken)
        {
            var result =  await _instructorRepository.GetinstructorById(request.InstructorId);
            if (result == null)
            {
                throw new CustomException<object>
                {
                    Response = new { message= "Not exist user" },
                    StatusCode = HttpStatusCode.NotFound
                };
            }

            return result;
        }
    }
}

