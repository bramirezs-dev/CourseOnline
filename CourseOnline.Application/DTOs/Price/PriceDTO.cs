using System;
namespace CourseOnline.Application.DTOs.Price
{
	public class PriceDTO
	{

        public Guid Id { get; set; }

        public decimal CurrentPrice { get; set; }

        public decimal Promotion { get; set; }

        public Guid CourseId { get; set; }
    }
}

