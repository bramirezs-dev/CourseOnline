using System;
using CourseOnline.Application.Interfaces.CourseInstructors;
using CourseOnline.Domain.Entities;
using CourseOnline.Infraestructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CourseOnline.Infraestructure.Persistence.Repositories
{
	public class CourseInstructorRepositoryAsync : GenericRepositoryAsync<CourseInstructor>, ICourseInstructorRepositoryAsync
    {
        private readonly DbSet<CourseInstructor> _couserInstructor;
		public CourseInstructorRepositoryAsync(CoursesOnlineContext coursesOnline):base(coursesOnline)
		{
            _couserInstructor = coursesOnline.Set<CourseInstructor>();

        }

        public async Task<List<CourseInstructor>> GetCourseInstructorByCourseAsync(Guid course)
        {
            return await _couserInstructor.Where(courseInstructor => courseInstructor.CourseId == course).ToListAsync();
        }
    }
}

