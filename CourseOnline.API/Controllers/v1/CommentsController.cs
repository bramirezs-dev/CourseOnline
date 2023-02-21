using System;
using CourseOnline.Application.DTOs.Courses;
using CourseOnline.Application.Features.Comments.Commands.AddComment;
using CourseOnline.Application.Features.Courses.Queries.GetAllCourses;
using CourseOnline.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CourseOnline.API.Controllers.v1
{
	public class CommentsController :BaseController
	{
		public CommentsController()
		{
		}

        [HttpPost]
        //[Authorize]
        public async Task<Comment> Addcomment(AddCommentCommand addComment)
        {
            return await Mediator.Send(addComment);
        }
    }
}

