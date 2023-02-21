using System;
using CourseOnline.Application.DTOs.Courses;
using CourseOnline.Application.Features.Comments.Commands.AddComment;
using CourseOnline.Application.Features.Comments.Commands.DeleteComment;
using CourseOnline.Application.Features.Courses.Queries.GetAllCourses;
using CourseOnline.Domain.Entities;
using MediatR;
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
        public async Task<Comment> Addcomment(AddCommentCommand comment)
        {
            return await Mediator.Send(comment);
        }

        [HttpDelete("{id}")]
        //[Authorize]
        public async Task<Unit> Deletecomment(Guid id)
        {
            return await Mediator.Send(new DeleteCommentCommand {CommentId = id});
        }
    }
}

