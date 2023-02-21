using System;
using CourseOnline.Application.Interfaces;
using CourseOnline.Security.TokenSecurity;
using Microsoft.Extensions.DependencyInjection;

namespace CourseOnline.Security
{
	public static class ServiceExtensions
	{
        public static void AddSecurityCustom(this IServiceCollection service)
        {
            service.AddScoped<IJwtGenerator, JwtGenerator>();

            service.AddScoped<IUserSession, UserSession>();

        }
    }
}

