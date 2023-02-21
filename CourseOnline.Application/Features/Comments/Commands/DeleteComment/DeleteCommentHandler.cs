using System;
using CourseOnline.Application.Exceptions;
using CourseOnline.Application.Interfaces;
using CourseOnline.Domain.Entities;
using MediatR;

namespace CourseOnline.Application.Features.Comments.Commands.DeleteComment
{
	public class DeleteCommentHandler : IRequestHandler<DeleteCommentCommand>
	{
		private readonly IGenericRepositoryAsync<Comment> _repositoryAsync;
		public DeleteCommentHandler(IGenericRepositoryAsync<Comment> repositoryAsync)
		{
			_repositoryAsync = repositoryAsync;
		}

        public async Task<Unit> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _repositoryAsync.GetByIdAsync(request.CommentId);
			if (comment == null)
			{
				throw new CustomException<object>{
					Response = new {message = "Comment not found"},
					StatusCode = System.Net.HttpStatusCode.NotFound
				};
			}
			await _repositoryAsync.DeleteAsync(comment);
			return Unit.Value;
        }
    }
}

