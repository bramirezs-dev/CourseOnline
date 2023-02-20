using System;
using CourseOnline.Domain.Entities;

namespace CourseOnline.Application.Interfaces.Prices
{
	public interface IPriceRepositoryAsync :IGenericRepositoryAsync<Price>
	{
		Task<Price> GetPriceByCourseId(Guid courseId);
	}
}

