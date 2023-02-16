using System;
using CourseOnline.Application.DTOs.Login;
using CourseOnline.Application.Features.Security.Queries.Login;
using CourseOnline.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CourseOnline.API.Controllers.v1
{

    [Route("api/v{version}/[controller]")]
    [ApiController]

    public class LoginController : BaseController
	{
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Login(LoginQuery login)
        {
            return await Mediator.Send(login);
        }
	}
}

