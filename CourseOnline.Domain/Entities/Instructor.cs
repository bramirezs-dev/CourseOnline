using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseOnline.Domain.Entities
{
    public class Instructor
    {
        public int InstructorId { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Grade { get; set; }

        public byte[] ProfilePhoto { get; set; }

       /* public ICollection<CourseInstructor> CourseLink { get; set; }*/
    }
}
