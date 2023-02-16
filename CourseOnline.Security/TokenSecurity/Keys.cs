using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CourseOnline.Security.TokenSecurity
{
	public static class Keys
	{
		public static SymmetricSecurityKey keyJwt()
		{
            return  new SymmetricSecurityKey(Encoding.UTF8.GetBytes("My word secret in the world,"));
        }
	}
}

