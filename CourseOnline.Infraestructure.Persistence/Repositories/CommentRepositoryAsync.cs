using System;
using CourseOnline.Application.Interfaces.Comments;
using CourseOnline.Domain.Entities;
using CourseOnline.Infraestructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CourseOnline.Infraestructure.Persistence.Repositories
{
	public class CommentRepositoryAsync : GenericRepositoryAsync<Comment>,ICommentRepositoryAsync
    {

        private readonly DbSet<Comment> _comment;

		public CommentRepositoryAsync(CoursesOnlineContext coursesOnline):base(coursesOnline)
		{
            _comment = coursesOnline.Set<Comment>();
		}

        public async Task<List<Comment>> GetCommentByCourseId(Guid courseId)
        {
            return await _comment.Where(comment => comment.CourseId == courseId).ToListAsync();
        }
    }
}

