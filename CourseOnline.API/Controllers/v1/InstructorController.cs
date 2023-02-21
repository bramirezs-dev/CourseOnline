using System;
using CourseOnline.Application.Features.Instructors.Command.CreateInstructor;
using CourseOnline.Application.Features.Instructors.Command.DeleteInstructor;
using CourseOnline.Application.Features.Instructors.Command.UpdateInstructor;
using CourseOnline.Application.Features.Instructors.Queries.GetCourses;
using CourseOnline.Application.Features.Instructors.Queries.GetInstructor;
using CourseOnline.Domain.DapperEntities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseOnline.API.Controllers.v1
{
    [Route("api/v{version}/[controller]")]
    [ApiController]
    public class InstructorController: BaseController
	{

		public InstructorController()
		{
		}
        [Authorize(Roles = "Admin")]
		[HttpGet]

		public async Task<IEnumerable<InstructorModel>> GetInstructors()
		{
			return await Mediator.Send(new GetInstructorsQuery());
		}

        [HttpGet("{id}")]
        public async Task<InstructorModel> GetInstructor(Guid id)
        {
            return await Mediator.Send(new GetInstructorQuery { InstructorId = id});
        }

        [HttpPost]

        public async Task<ActionResult<Unit>> CreateInstructors(CreateInstructorCommand instructor)
        {
            return await Mediator.Send(instructor);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<Unit>> UpdateInstructors(Guid id,UpdateInstructorCommand instructor)
        {
            instructor.InstructorId = id;
            return await Mediator.Send(instructor);
        }


        [HttpDelete("{id}")]

        public async Task<ActionResult<Unit>> DeleteInstructors(Guid id)
        {
            return await Mediator.Send(new DeleteInstructorCommand { InstructorId = id});
        }


    }
}

