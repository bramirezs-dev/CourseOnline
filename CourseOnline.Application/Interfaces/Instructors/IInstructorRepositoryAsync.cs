using System;
using CourseOnline.Domain.DapperEntities;

namespace CourseOnline.Application.Interfaces.Instructors
{
	public interface IInstructorRepositoryAsync
	{
        Task<IEnumerable<InstructorModel>> Getinstructors();

        Task<InstructorModel> GetinstructorById(Guid id);

        Task<int> AddAsync(InstructorModel instructor);

        Task<int> UpdateAsyn(InstructorModel instructor);

        Task<int> DeleteAsync(Guid id);
    }
}

