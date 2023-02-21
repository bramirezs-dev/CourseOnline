using System;
using CourseOnline.Application.DTOs.Login;
using CourseOnline.Application.Features.Security.Commands.Register;
using CourseOnline.Application.Features.Security.Commands.UpdateUser;
using CourseOnline.Application.Features.Security.Queries.CurrentUser;
using CourseOnline.Application.Features.Security.Queries.Login;
using CourseOnline.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseOnline.API.Controllers.v1
{

    [Route("api/v{version}/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController : BaseController
	{
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Login(LoginQuery login)
        {
            return await Mediator.Send(login);
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register( RegisterUserCommand user)
        {
            return await Mediator.Send(user);
        }


        [HttpGet]
        public async Task<ActionResult<UserDTO>> ReturnUser()
        {
            return await Mediator.Send(new CurrentUserQuery());
        }

        [HttpPut]
        public async Task<ActionResult<UserDTO>> UpdateUser(UpdateUserCommand user)
        {
            return await Mediator.Send(user);
        }
    }
}

