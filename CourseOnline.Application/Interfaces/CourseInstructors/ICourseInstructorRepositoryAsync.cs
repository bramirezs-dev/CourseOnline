using System;
using CourseOnline.Domain.Entities;

namespace CourseOnline.Application.Interfaces.CourseInstructors
{
	public interface ICourseInstructorRepositoryAsync : IGenericRepositoryAsync<CourseInstructor>
    {
		public Task<List<CourseInstructor>> GetCourseInstructorByCourseAsync(Guid course);
	}
}

