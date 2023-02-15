using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseOnline.Domain.Entities
{
    public class CourseInstructor 
    {
        public Guid CourseId { get; set; }
        public Guid InstructorId { get; set; }

        public Course Course { get; set; }

        public Instructor Instructor { get; set; }
    }
}
