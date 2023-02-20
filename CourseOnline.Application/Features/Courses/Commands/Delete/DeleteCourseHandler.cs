using System;
using CourseOnline.Application.Exceptions;
using CourseOnline.Application.Interfaces;
using CourseOnline.Application.Interfaces.Comments;
using CourseOnline.Application.Interfaces.CourseInstructors;
using CourseOnline.Application.Interfaces.Prices;
using CourseOnline.Domain.Entities;
using MediatR;

namespace CourseOnline.Application.Features.Courses.Commands.DeleteCourse
{
	public class DeleteCourseHandler : IRequestHandler<DeleteCourseCommand>
	{
        private readonly IGenericRepositoryAsync<Course> _genericRepositoryAsync;
        private readonly ICourseInstructorRepositoryAsync _instructorRepositoryAsync;
        private readonly ICommentRepositoryAsync _commentRepository;
        private readonly IPriceRepositoryAsync _priceRepository;

        public DeleteCourseHandler(IGenericRepositoryAsync<Course> genericRepositoryAsync,
            ICourseInstructorRepositoryAsync instructorRepositoryAsync,
            ICommentRepositoryAsync commentRepository,
            IPriceRepositoryAsync priceRepository

            )
		{
            _genericRepositoryAsync = genericRepositoryAsync;
            _instructorRepositoryAsync = instructorRepositoryAsync;
            _commentRepository = commentRepository;
            _priceRepository = priceRepository;
        }

        public async Task<Unit> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {


            var course = await _genericRepositoryAsync.GetByIdAsync(request.CourseId);
            if (course == null)
            {
                throw new CustomException<object>
                {
                    Response = new { message = "Course not exist" },
                    StatusCode = System.Net.HttpStatusCode.BadRequest
                };
            }

            var courseInstructoreDB = await  _instructorRepositoryAsync.GetCourseInstructorByCourseAsync(request.CourseId);
            foreach (var courseInstructor in courseInstructoreDB)
            {
                await _instructorRepositoryAsync.DeleteAsync(courseInstructor);
            }

            var commentsDb = await _commentRepository.GetCommentByCourseId(course.Id);
            foreach (var comment in commentsDb)
            {
                await _commentRepository.DeleteAsync(comment);
            }

            var priceDB = await _priceRepository.GetPriceByCourseId(course.Id);

            if (priceDB != null)
            {
               await _priceRepository.DeleteAsync(priceDB);
            }

            await _genericRepositoryAsync.DeleteAsync(course);

            return Unit.Value;
           
        }
    }
}

