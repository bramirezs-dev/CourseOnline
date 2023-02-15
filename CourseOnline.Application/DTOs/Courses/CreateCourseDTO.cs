using System;
using System.ComponentModel.DataAnnotations.Schema;
using CourseOnline.Domain.Entities;

namespace CourseOnline.Application.DTOs.Courses
{
    public class CreateCourseDTO 
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime PublishDate { get; set; }

        public byte[]? CoverPhoto { get; set; }
    }
}

