using System;
using CourseOnline.Application.Interfaces.Courses;
using CourseOnline.Domain.Entities;
using CourseOnline.Infraestructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CourseOnline.Infraestructure.Persistence.Repositories
{
	public class CourseRepositoryAsync : GenericRepositoryAsync<Course>, ICourseRepositoryAsync
    {
        private readonly DbSet<Course> _courses;

        public CourseRepositoryAsync(CoursesOnlineContext coursesOnline):base(coursesOnline)
		{
            _courses = coursesOnline.Set<Course>();
        }

        public async Task<List<Course>> GetCoursesComplete()
        {
            return await _courses.Include(course => course.PromotionPrice)
                                 .Include(course => course.Comments)
                                 .Include(course => course.LinkInstructors)
                                 .ThenInclude(instructor => instructor.Instructor).ToListAsync();
        }

        public async Task<Course> GetCourseComplete(Guid id)
        {
            return await _courses.Include( course => course.PromotionPrice)
                                 .Include(course => course.Comments)
                                 .Include(course => course.LinkInstructors)
                                 .ThenInclude(instructor => instructor.Instructor)
                                 .FirstOrDefaultAsync( course=> course.Id == id);
        }
    }
}

