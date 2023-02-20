using System;
using CourseOnline.Application.Exceptions;
using CourseOnline.Application.Interfaces;
using CourseOnline.Application.Interfaces.CourseInstructors;
using CourseOnline.Application.Interfaces.Prices;
using CourseOnline.Domain.Entities;
using MediatR;

namespace CourseOnline.Application.Features.Courses.Commands.UpdateCourse
{
	public class UpdateCourseHandler : IRequestHandler<UpdateCourseCommand>
	{
        private readonly IGenericRepositoryAsync<Course> _genericRepositoryAsync;
        private readonly ICourseInstructorRepositoryAsync _courseInstructorRepository;
        private readonly IPriceRepositoryAsync _genericPriceRepository;

        public UpdateCourseHandler(
            IGenericRepositoryAsync<Course> genericRepositoryAsync,
            ICourseInstructorRepositoryAsync courseInstructorRepository,
            IPriceRepositoryAsync genericPriceRepository
            )
		{
            _genericRepositoryAsync = genericRepositoryAsync;
            _courseInstructorRepository = courseInstructorRepository;
            _genericPriceRepository = genericPriceRepository;
        }

        public async Task<Unit> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await _genericRepositoryAsync.GetByIdAsync(request.CourseId);

            if(course == null)
            {
                throw new CustomException<object>
                {
                    Response = new { message = "Course not exist" },
                    StatusCode = System.Net.HttpStatusCode.BadRequest
                };
            }

            course.Title = request.Title ?? course.Title;
            course.Description = request.Description ?? course.Description;
            course.PublishDate = request.PublishDate ?? course.PublishDate;


            var priceEntity = await _genericPriceRepository.GetPriceByCourseId(course.Id);

            if (priceEntity != null)
            {
                priceEntity.CurrentPrice = request.Price ?? priceEntity.CurrentPrice;
                priceEntity.Promotion = request.Promotion ?? priceEntity.Promotion;

                await _genericPriceRepository.UpdateAsync(priceEntity);

            }else
            {
                priceEntity = new Price
                {
                    Id = Guid.NewGuid(),
                    CurrentPrice = request.Price ?? 0,
                    Promotion = request.Promotion ?? 0,
                    CourseId = request.CourseId
                };
                await _genericPriceRepository.AddAsync(priceEntity);
            }


            if(request.Instructors != null)
            {
                if(request.Instructors.Count > 0)
                {
                    var instructorsDB = await _courseInstructorRepository.GetCourseInstructorByCourseAsync(request.CourseId);
                    foreach (var instructor in instructorsDB)
                    {
                        await _courseInstructorRepository.DeleteAsync(instructor);
                    }

                    foreach (var id in request.Instructors)
                    {
                        var newInsrtuctor = new CourseInstructor
                        {
                            CourseId = request.CourseId,
                            InstructorId = id
                        };

                       await  _courseInstructorRepository.AddAsync(newInsrtuctor);
                    }
                }
            }


           await _genericRepositoryAsync.UpdateAsync(course);

            return Unit.Value;
        }
    }
}

