using System;
using System.Security.Claims;
using CourseOnline.Application.Interfaces;
using Microsoft.AspNetCore.Http;

namespace CourseOnline.Security.TokenSecurity
{
    public class UserSession : IUserSession
    {
        private readonly IHttpContextAccessor _httpContextAccesor;

        public UserSession(IHttpContextAccessor httpContextAccesor)
        {
                _httpContextAccesor = httpContextAccesor;
        }

        public string GetUserSession()
        {
            var userName = _httpContextAccesor.HttpContext.User?.Claims?.FirstOrDefault(user => user.Type == ClaimTypes.NameIdentifier)?.Value;
            return userName;
        }
    }
}

