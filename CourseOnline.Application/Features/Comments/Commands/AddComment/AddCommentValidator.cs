using System;
using FluentValidation;

namespace CourseOnline.Application.Features.Comments.Commands.AddComment
{
	public class AddCommentValidator : AbstractValidator<AddCommentCommand>
	{
		public AddCommentValidator()
		{
			RuleFor(comment => comment.CourseId).NotNull().NotEmpty().WithMessage("it's necesary Course id");
            RuleFor(comment => comment.TextComment).NotNull().NotEmpty().WithMessage("it's necesary Text comment");
            RuleFor(comment => comment.Student).NotNull().NotEmpty().WithMessage("it's necesary Student");
            RuleFor(comment => comment.Score).NotNull().NotEmpty().WithMessage("it's necesary Score");
        }
	}
}

