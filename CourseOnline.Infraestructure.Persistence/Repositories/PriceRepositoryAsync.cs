using System;
using CourseOnline.Application.Interfaces.Prices;
using CourseOnline.Domain.Entities;
using CourseOnline.Infraestructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CourseOnline.Infraestructure.Persistence.Repositories
{
	public class PriceRepositoryAsync : GenericRepositoryAsync<Price> ,IPriceRepositoryAsync
    {
		private readonly DbSet<Price> _price;
		public PriceRepositoryAsync(CoursesOnlineContext context):base(context)
		{
			_price = context.Set<Price>();
		}

        public async Task<Price> GetPriceByCourseId(Guid courseId)
        {
            return await _price.Where(price => price.CourseId == courseId).FirstOrDefaultAsync();
        }
    }
}

