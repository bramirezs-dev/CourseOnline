using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;

using CourseOnline.Application.Features.Security.Commands.NewRol;
using CourseOnline.Application.Features.Security.Commands.DeleteRol;
using Microsoft.AspNetCore.Identity;
using CourseOnline.Application.Features.Security.Queries.RolList;
using CourseOnline.Application.Features.Security.Commands.AddUserRole;
using CourseOnline.Application.Features.Security.Commands.DeleteUserRole;
using CourseOnline.Application.Features.Security.Queries.GetRolesByUser;

namespace CourseOnline.API.Controllers.v1
{
	public class RoleController :BaseController
	{
        [HttpPost]
        //[Authorize]
        public async Task<Unit> AddRole(NewRolCommand role)
        {
            return await Mediator.Send(role);
        }

        [HttpPost("adduserrole")]
        //[Authorize]
        public async Task<Unit> AddRoleUser(AddUserRoleCommand role)
        {
            return await Mediator.Send(role);
        }


        [HttpDelete("deleteuserrole")]
        //[Authorize]
        public async Task<Unit> DeleteRoleUser(DeleteUserRoleCommand role)
        {
            return await Mediator.Send(role);
        }

                [HttpDelete]
        //[Authorize]
        public async Task<Unit> DeleteRole(DeleteRolCommand role)
        {
            return await Mediator.Send(role);
        }

         [HttpGet]
        //[Authorize]
        public async Task<List<IdentityRole>> GetRoles()
        {
            return await Mediator.Send(new RolListQuery());

        }

         [HttpGet("{username}")]
        //[Authorize]
        public async Task<List<string>> GetRole(string username)
        {
            return await Mediator.Send(new GetRolesByUserQuery {Username = username});

        }
        

    }
}

