using System;
namespace CourseOnline.Application.DTOs.Comment
{
	public class CommentDTO
	{
        public string Student { get; set; }

        public int Score { get; set; }

        public string TextComment { get; set; }

        public Guid CourseId { get; set; }
    }
}

