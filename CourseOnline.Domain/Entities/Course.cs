using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseOnline.Domain.Entities
{
    public  class Course
    {
        public int CourseId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime PublishDate { get; set; }

        public byte[]? CoverPhoto { get; set; }
        /*public Price PromotionPrice { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<CourseInstructor> LinkInstructors { get; set; }*/
    }
}
