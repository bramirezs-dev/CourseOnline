using System;
using CourseOnline.Application.DTOs.Courses;
using CourseOnline.Application.Features.Courses.Commands.CreateCourse;
using CourseOnline.Application.Features.Courses.Queries.GetAllCourses;
using CourseOnline.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CourseOnline.API.Controllers.v1
{
    [Route("api/v{version}/[controller]")]
    [ApiController]
    public class CoursesController : BaseController
    {
        public CoursesController()
        {
        }

        [HttpGet]
        public async Task<IReadOnlyList<Course>> GetAllCourses()
        {
            return await Mediator.Send(new GetAllCoursesQuery());
        }

        [HttpPost]
        public async Task<Course> AddCourse(CreateCourseDTO course)
        {
            return await Mediator.Send(new CreateCourseCommand { courseDTO = course});
        }

    }
}

