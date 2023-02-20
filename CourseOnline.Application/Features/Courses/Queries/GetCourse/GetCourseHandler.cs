using System;
using AutoMapper;
using CourseOnline.Application.DTOs.Courses;
using CourseOnline.Application.Exceptions;
using CourseOnline.Application.Interfaces;
using CourseOnline.Application.Interfaces.Courses;
using CourseOnline.Domain.Entities;
using MediatR;

namespace CourseOnline.Application.Features.Courses.Queries.GetCourse
{
	public class GetCourseHandler :IRequestHandler<GetCourseQuery, CourseDTO>
	{
        private readonly ICourseRepositoryAsync _courseRepository;
        private readonly IMapper _mapper;

        public GetCourseHandler(ICourseRepositoryAsync courseRepository, IMapper mapper)
		{
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<CourseDTO> Handle(GetCourseQuery request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.GetCourseComplete(request.Id);
            if(course == null)
            {
                throw new CustomException<object>
                {
                    Response = new { message = "Course not exist" },
                    StatusCode = System.Net.HttpStatusCode.BadRequest
                };
            }

            var courseDTO = _mapper.Map<CourseDTO>(course);
            return courseDTO;

        }
    }
}

