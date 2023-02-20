using System;
using AutoMapper;
using CourseOnline.Application.DTOs.Comment;
using CourseOnline.Application.DTOs.CourseInstructor;
using CourseOnline.Application.DTOs.Courses;
using CourseOnline.Application.DTOs.Inastructors;
using CourseOnline.Application.DTOs.Login;
using CourseOnline.Application.DTOs.Price;
using CourseOnline.Domain.Entities;

namespace CourseOnline.Application.Mappings
{
    public class GeneralProfile :Profile
    {
        public GeneralProfile()
        {
            CreateMap<Course, CreateCourseDTO>().ReverseMap();

            CreateMap<Course, CourseDTO>()
                .ForMember( courseDTO => courseDTO.Instructors, course => course.MapFrom(c => c.LinkInstructors.Select (ci => ci.Instructor).ToList()))
                .ForMember( courseDTO => courseDTO.Comments, course => course.MapFrom(course => course.Comments))
                .ForMember(courseDTO => courseDTO.Price, course => course.MapFrom(course => course.PromotionPrice));

            CreateMap<Instructor, InstructorDTO>().ReverseMap();

            CreateMap<CourseInstructor, CourseInstructorDTO>().ReverseMap();

            CreateMap<Price, PriceDTO>().ReverseMap();

            CreateMap<Comment, CommentDTO>().ReverseMap();

            CreateMap<User, UserDTO>().ReverseMap();

        }
    }
}

