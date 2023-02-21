using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CourseOnline.Application.Interfaces;
using CourseOnline.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace CourseOnline.Security.TokenSecurity
{
	public class JwtGenerator : IJwtGenerator
    {
		public JwtGenerator()
		{
		}

        public string CreateToken(User user, List<string> roles)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.UserName)
            };

            if (roles !=null)
            {
                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role,role));
                }
            }

            var key = Keys.keyJwt();

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var descriptionToken = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(30),
                SigningCredentials = credentials
            };


            var handlerToken = new JwtSecurityTokenHandler();
            var token = handlerToken.CreateToken(descriptionToken);

            return handlerToken.WriteToken(token);
        }
    }
}

