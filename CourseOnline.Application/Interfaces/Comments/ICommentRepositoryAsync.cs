using System;
using CourseOnline.Domain.Entities;

namespace CourseOnline.Application.Interfaces.Comments
{
	public interface ICommentRepositoryAsync : IGenericRepositoryAsync<Comment>
	{
		Task<List<Comment>> GetCommentByCourseId(Guid courseId);
	}
}

