using System;
using CourseOnline.Application.Interfaces;
using CourseOnline.Application.Interfaces.Courses;
using CourseOnline.Domain.Entities;
using MediatR;

namespace CourseOnline.Application.Features.Comments.Commands.AddComment
{
	public class AddCommentHandler : IRequestHandler<AddCommentCommand, Comment>
	{
        private readonly ICourseRepositoryAsync _courseRepository;
        private readonly IGenericRepositoryAsync<Comment> _genericRepository;

        public AddCommentHandler(ICourseRepositoryAsync courseRepository, IGenericRepositoryAsync<Comment> genericRepository)
		{
           _courseRepository = courseRepository;
            _genericRepository = genericRepository;
        }

        public async Task<Comment> Handle(AddCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new Comment
            {
                Id = Guid.NewGuid(),
                TextComment = request.TextComment,
                Score = request.Score,
                Student = request.Student,
                CourseId = request.CourseId
            };

            var result = await _genericRepository.AddAsync(comment);
            if (result == null)
            {
                throw new Exception("Can't create comment");
            }

            return result;
        }
    }
}

