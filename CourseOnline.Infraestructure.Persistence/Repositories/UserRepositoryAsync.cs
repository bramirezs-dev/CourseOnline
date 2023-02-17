using System;
using CourseOnline.Application.Interfaces;
using CourseOnline.Domain.Entities;
using CourseOnline.Infraestructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CourseOnline.Infraestructure.Persistence.Repositories
{
	public class UserRepositoryAsync :  GenericRepositoryAsync<User>,IUserRepositoryAsync
    {
        private readonly DbSet<User> _user;

        public UserRepositoryAsync(CoursesOnlineConext coursesOnlineConext):base(coursesOnlineConext)
		{
            _user = coursesOnlineConext.Set<User>();

        }

        public async Task<bool> ExistEmail(string email)
        {
            var exist = await _user.Where(user => user.Email == email).AnyAsync();
            return exist ? true : false;
        }

        public async Task<bool> ExistUserName(string userName)
        {
            var exist = await _user.Where(user => user.UserName == userName).AnyAsync();
            return exist ? true : false;
        }
    }
}

