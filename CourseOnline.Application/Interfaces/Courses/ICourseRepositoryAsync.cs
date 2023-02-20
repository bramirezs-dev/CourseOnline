using System;
using CourseOnline.Domain.Entities;

namespace CourseOnline.Application.Interfaces.Courses
{
	public interface ICourseRepositoryAsync : IGenericRepositoryAsync<Course>
	{
		public Task<List<Course>> GetCoursesComplete();

		public Task<Course> GetCourseComplete(Guid id);
	}
}

