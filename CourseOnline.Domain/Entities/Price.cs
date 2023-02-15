using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseOnline.Domain.Entities
{
    public class Price :BaseEntity
    {
        public decimal CurrentPrice { get; set; }

        public decimal Promotion { get; set; }

        public Guid CourseId { get; set; }

        public Course Course { get; set; }
    }
}
