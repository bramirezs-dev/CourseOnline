using System;
using CourseOnline.Domain.Entities;
using MediatR;

namespace CourseOnline.Application.Features.Comments.Commands.AddComment
{
	public class AddCommentCommand :IRequest<Comment>
	{
        public string Student { get; set; }

        public int Score { get; set; }

        public string TextComment { get; set; }

        public Guid CourseId { get; set; }

    }
}

