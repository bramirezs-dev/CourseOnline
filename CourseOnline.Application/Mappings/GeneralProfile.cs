using System;
using AutoMapper;
using CourseOnline.Application.DTOs.Courses;
using CourseOnline.Application.DTOs.Login;
using CourseOnline.Domain.Entities;

namespace CourseOnline.Application.Mappings
{
    public class GeneralProfile :Profile
    {
        public GeneralProfile()
        {
            CreateMap<Course, CreateCourseDTO>().ReverseMap();

            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}

