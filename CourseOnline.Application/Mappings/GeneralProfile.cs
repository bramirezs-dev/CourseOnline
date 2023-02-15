using System;
using AutoMapper;
using CourseOnline.Application.DTOs.Courses;
using CourseOnline.Domain.Entities;

namespace CourseOnline.Application.Mappings
{
    public class GeneralProfile :Profile
    {
        public GeneralProfile()
        {
            CreateMap<Course, CreateCourseDTO>().ReverseMap();
        }
    }
}

