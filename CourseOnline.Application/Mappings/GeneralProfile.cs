using System;
using AutoMapper;
using CourseOnline.Domain.Entities;

namespace CourseOnline.Application.Mappings
{
    public class GeneralProfile :Profile
    {
        public GeneralProfile()
        {
            CreateMap<Course, Course>().ReverseMap();
        }
    }
}

