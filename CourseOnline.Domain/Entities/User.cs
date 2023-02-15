using System;
using Microsoft.AspNetCore.Identity;

namespace CourseOnline.Domain.Entities
{
    public class User : IdentityUser
    {
        public string NameComplete { get; set; }
    }
}

