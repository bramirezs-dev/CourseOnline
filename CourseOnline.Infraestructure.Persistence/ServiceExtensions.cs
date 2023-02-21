using CourseOnline.Application.Interfaces;
using CourseOnline.Domain.Entities;
using CourseOnline.Infraestructure.Persistence.Context;
using CourseOnline.Infraestructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseOnline.Application.Interfaces.Courses;
using CourseOnline.Application.Interfaces.CourseInstructors;
using CourseOnline.Application.Interfaces.Comments;
using CourseOnline.Application.Interfaces.Prices;
using CourseOnline.Infraestructure.Persistence.DapperConecction;
using CourseOnline.Application.Interfaces.Dapper;
using CourseOnline.Application.Interfaces.Instructors;
using CourseOnline.Application.Interfaces.PaginationDapper;

namespace CourseOnline.Infraestructure.Persistence
{
    public static class ServiceExtensions
    {
        public static void AddPersistenceLayer(this IServiceCollection service, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                service.AddDbContext<CoursesOnlineContext>(opt =>
                {
                    opt.UseInMemoryDatabase(databaseName: "CoursesOnline");
                });

            }
            else
            {
                service.AddDbContext<CoursesOnlineContext>(opt =>
                {
                    opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly(typeof(CoursesOnlineContext).Assembly.FullName)
                       );
                });
            }

            service.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            service.AddTransient<IUserRepositoryAsync, UserRepositoryAsync>();
            service.AddTransient<ICourseRepositoryAsync, CourseRepositoryAsync>();
            service.AddTransient<ICourseInstructorRepositoryAsync, CourseInstructorRepositoryAsync>();
            service.AddTransient<ICommentRepositoryAsync, CommentRepositoryAsync>();
            service.AddTransient<IPriceRepositoryAsync, PriceRepositoryAsync>();


            service.AddTransient<IInstructorRepositoryAsync, InstructorRepositoryAsync>();
            service.AddTransient<IPaginationRepositoryAsync, PaginationRepositoryAsync>();


            // Add Service Identity
            var builder = service.AddIdentityCore<User>();
            var identityBuilder = new IdentityBuilder(builder.UserType, builder.Services);

            identityBuilder.AddEntityFrameworkStores<CoursesOnlineContext>()
                .AddSignInManager<SignInManager<User>>();


            // configuration chain connection dapper
            service.AddTransient<IFactoryConnection, FactoryConnection>();
            service.AddOptions();

            service.Configure<ConfigurationConnection>(
            opt =>
            {
                opt.DefaultConnection = configuration.GetConnectionString("DefaultConnection");
            });
        }
    }
}
