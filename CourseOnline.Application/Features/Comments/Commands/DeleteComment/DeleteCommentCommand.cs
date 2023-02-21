using System;
using MediatR;

namespace CourseOnline.Application.Features.Comments.Commands.DeleteComment
{
	public class DeleteCommentCommand :IRequest
	{
		public Guid CommentId { get; set; }
	}
}

