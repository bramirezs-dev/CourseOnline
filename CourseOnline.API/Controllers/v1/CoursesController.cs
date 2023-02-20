using System;
using CourseOnline.Application.DTOs.Courses;
using CourseOnline.Application.Features.Courses.Commands.CreateCourse;
using CourseOnline.Application.Features.Courses.Commands.DeleteCourse;
using CourseOnline.Application.Features.Courses.Commands.UpdateCourse;
using CourseOnline.Application.Features.Courses.Queries.GetAllCourses;
using CourseOnline.Application.Features.Courses.Queries.GetCourse;
using CourseOnline.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseOnline.API.Controllers.v1
{
    [Route("api/v{version}/[controller]")]
    [ApiController]
    public class CoursesController : BaseController
    {

        [HttpGet]
        //[Authorize]
        public async Task<List<CourseDTO>> GetAllCourses()
        {
            return await Mediator.Send(new GetAllCoursesQuery());
        }

        [HttpGet("{id}")]
        //[Authorize]
        public async Task<CourseDTO> GetCourse(Guid id)
        {
            return await Mediator.Send(new GetCourseQuery { Id = id });
        }


        [HttpPost]
        public async Task<Course> AddCourse(CreateCourseDTO course)
        {
            return await Mediator.Send(new CreateCourseCommand { courseDTO = course});
        }

        [HttpPut("{id}")]
        public async Task<Unit> UpdateCourse(Guid id, UpdateCourseCommand courseCommand)
        {
            courseCommand.CourseId = id;
            return await Mediator.Send(courseCommand);
        }

        [HttpDelete("{id}")]
        public async Task<Unit> DeleteCourse(Guid id)
        {
            return await Mediator.Send(new DeleteCourseCommand { CourseId = id});
        }

    }
}

