using System;
using System.Net;
using AutoMapper;
using CourseOnline.Application.DTOs.Login;
using CourseOnline.Application.Exceptions;
using CourseOnline.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CourseOnline.Application.Features.Security.Queries.Login
{
	public class LoginQueryHandler : IRequestHandler<LoginQuery, UserDTO>
	{
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;

        public LoginQueryHandler(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper)
		{
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        public async Task<UserDTO> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new CustomException<object> { Response = new { message = "not found user"}, StatusCode = HttpStatusCode.NotFound };
            }

            var isValid = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (isValid.Succeeded)
            {
                var result = _mapper.Map<UserDTO>(user); 
                return result;
            }

            throw new CustomException<object> { Response = new { message = "Unauthorized user" }, StatusCode = HttpStatusCode.Unauthorized };
        }
    }
}

