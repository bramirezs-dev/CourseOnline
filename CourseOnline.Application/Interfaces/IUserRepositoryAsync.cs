using System;
using CourseOnline.Domain.Entities;

namespace CourseOnline.Application.Interfaces
{
	public interface IUserRepositoryAsync : IGenericRepositoryAsync<User>
    {
		public Task<bool> ExistEmail(string email);

        public Task<bool> ExistUserName(string userName);

        public Task<bool> ExistEmailAndUsername (string email, string username);
    }
}

