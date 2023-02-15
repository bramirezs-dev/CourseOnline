using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseOnline.Domain.Entities
{
    public class Comment : BaseEntity
    {

        public string Student { get; set; }

        public int Score { get; set; }

        public string TextComment { get; set; }

        public Guid CourseId { get; set; }

        public Course Course { get; set; }
    }
}
