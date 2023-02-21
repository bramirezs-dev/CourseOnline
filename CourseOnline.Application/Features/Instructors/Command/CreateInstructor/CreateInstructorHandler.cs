using System;
using CourseOnline.Application.Interfaces.Instructors;
using CourseOnline.Domain.DapperEntities;
using MediatR;

namespace CourseOnline.Application.Features.Instructors.Command.CreateInstructor
{
	public class CreateInstructorHandler :IRequestHandler<CreateInstructorCommand>
	{
        private readonly IInstructorRepositoryAsync _instructorRepository;

        public CreateInstructorHandler(IInstructorRepositoryAsync instructorRepository)
		{
            _instructorRepository = instructorRepository;
        }

        public async Task<Unit> Handle(CreateInstructorCommand request, CancellationToken cancellationToken)
        {
            var instructor = new InstructorModel
            {
                Grade = request.Grade,
                Name = request.Name,
                LastName = request.LastName
            };
            var result = await _instructorRepository.AddAsync(instructor);

            if (result > 0)
            {
                return Unit.Value;
            }

            throw new Exception("Can't insert instructor"); 
        }
    }
}

