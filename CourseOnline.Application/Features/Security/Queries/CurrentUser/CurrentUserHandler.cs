using System;
using AutoMapper;
using CourseOnline.Application.DTOs.Login;
using CourseOnline.Application.Interfaces;
using CourseOnline.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CourseOnline.Application.Features.Security.Queries.CurrentUser
{
	public class CurrentUserHandler :IRequestHandler<CurrentUserQuery, UserDTO>
	{
        private readonly UserManager<User> _userManager;
        private readonly IJwtGenerator _jwtGenerator;
        private readonly IUserSession _userSession;
        private readonly IMapper _mapper;

        public CurrentUserHandler(UserManager<User> userManager, IJwtGenerator jwtGenerator, IUserSession userSession, IMapper mapper)
		{
            _userManager = userManager;
            _jwtGenerator = jwtGenerator;
            _userSession = userSession;
            _mapper = mapper;
        }

        public async Task<UserDTO> Handle(CurrentUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(_userSession.GetUserSession());
            var result = _mapper.Map<UserDTO>(user);
            result.Token = _jwtGenerator.CreateToken(user);
            return result;
             
        }
    }
}

