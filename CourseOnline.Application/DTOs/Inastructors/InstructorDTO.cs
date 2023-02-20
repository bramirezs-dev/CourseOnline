using System;
using CourseOnline.Domain.Entities;

namespace CourseOnline.Application.DTOs.Inastructors
{
	public class InstructorDTO
	{
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Grade { get; set; }

        public byte[] ProfilePhoto { get; set; }

    }
}

