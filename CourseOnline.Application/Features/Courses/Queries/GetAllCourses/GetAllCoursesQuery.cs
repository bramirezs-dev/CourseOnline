using System;
using MediatR;
using CourseOnline.Domain.Entities;
namespace CourseOnline.Application.Features.Courses.Queries.GetAllCourses
{
    public class GetAllCoursesQuery: IRequest<IReadOnlyList<Course>>
    {
        
    }
}

