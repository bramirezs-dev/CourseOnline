using System;
namespace CourseOnline.Domain.DapperEntities
{
	public class InstructorModel
	{
        public Guid InstructorId { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Grade { get; set; }
    }
}

