using System;
using CourseOnline.Application.DTOs.Comment;
using CourseOnline.Application.DTOs.Inastructors;
using CourseOnline.Application.DTOs.Price;
using CourseOnline.Domain.Entities;

namespace CourseOnline.Application.DTOs.Courses
{
	public class CourseDTO
	{

        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime PublishDate { get; set; }

        public byte[]? CoverPhoto { get; set; }

        public ICollection<InstructorDTO> Instructors { get; set; }

        public PriceDTO Price { get; set; }

        public ICollection<CommentDTO> Comments { get; set; }
    }
}

