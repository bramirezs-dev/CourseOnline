using System;
using CourseOnline.Application.Interfaces.Instructors;
using CourseOnline.Domain.DapperEntities;
using MediatR;

namespace CourseOnline.Application.Features.Instructors.Command.UpdateInstructor
{
	public class UpdateInstructorHandler : IRequestHandler<UpdateInstructorCommand>
	{
        private readonly IInstructorRepositoryAsync _instructorRepository;

        public UpdateInstructorHandler(IInstructorRepositoryAsync instructorRepository)
		{
            _instructorRepository = instructorRepository;
        }

        public async Task<Unit> Handle(UpdateInstructorCommand request, CancellationToken cancellationToken)
        {
            var instructorUpdate = new InstructorModel
            {
                InstructorId = request.InstructorId,
                Name = request.Name,
                LastName = request.LastName,
                Grade = request.Grade
            };
            var result = await _instructorRepository.UpdateAsyn(instructorUpdate);

            if (result > 0)
            {
                return Unit.Value;
            }

            throw new Exception("Can't posible update instructor");
        }
    }
}

