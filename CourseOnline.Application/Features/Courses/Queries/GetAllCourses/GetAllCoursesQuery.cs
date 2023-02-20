using System;
using MediatR;
using CourseOnline.Domain.Entities;
using CourseOnline.Application.DTOs.Courses;

namespace CourseOnline.Application.Features.Courses.Queries.GetAllCourses
{
    public class GetAllCoursesQuery: IRequest<List<CourseDTO>>
    {
        
    }
}

