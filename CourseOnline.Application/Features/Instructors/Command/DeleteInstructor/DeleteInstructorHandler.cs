using System;
using CourseOnline.Application.Interfaces.Instructors;
using MediatR;

namespace CourseOnline.Application.Features.Instructors.Command.DeleteInstructor
{
	public class DeleteInstructorHandler : IRequestHandler<DeleteInstructorCommand>
	{
        private readonly IInstructorRepositoryAsync _repositoryAsync;

        public DeleteInstructorHandler(IInstructorRepositoryAsync repositoryAsync)
		{
            _repositoryAsync = repositoryAsync;
        }

        public async Task<Unit> Handle(DeleteInstructorCommand request, CancellationToken cancellationToken)
        {
            var result = await _repositoryAsync.DeleteAsync(request.InstructorId);
            if (result > 0)
            {
                return Unit.Value;
            }
            throw new Exception("Can't delete instructor");
        }
    }
}

