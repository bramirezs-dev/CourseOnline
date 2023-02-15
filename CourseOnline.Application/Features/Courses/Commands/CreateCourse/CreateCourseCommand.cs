using System;
using CourseOnline.Application.DTOs.Courses;
using CourseOnline.Domain.Entities;
using MediatR;

namespace CourseOnline.Application.Features.Courses.Commands.CreateCourse
{
    public class CreateCourseCommand : IRequest<Course>
    {
        public CreateCourseDTO courseDTO { get; set; }
    }
}

