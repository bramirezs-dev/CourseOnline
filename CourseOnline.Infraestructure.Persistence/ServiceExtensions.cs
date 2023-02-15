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

namespace CourseOnline.Infraestructure.Persistence
{
    public static class ServiceExtensions
    {
        public static void AddPersistenceLayer(this IServiceCollection service, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                service.AddDbContext<CoursesOnlineConext>(opt =>
                {
                    opt.UseInMemoryDatabase(databaseName: "CoursesOnline");
                });

            }
            else
            {
                service.AddDbContext<CoursesOnlineConext>(opt =>
                {
                    opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly(typeof(CoursesOnlineConext).Assembly.FullName)
                       );
                });
            }

            service.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));

            // Add Service Identity
            var builder = service.AddIdentityCore<User>();
            var identityBuilder = new IdentityBuilder(builder.UserType, builder.Services);

            identityBuilder.AddEntityFrameworkStores<CoursesOnlineConext>()
                .AddSignInManager<SignInManager<User>>();


        }
    }
}
