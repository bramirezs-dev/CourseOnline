using System;
using AutoMapper;
using CourseOnline.Application.DTOs.Courses;
using CourseOnline.Application.Interfaces;
using CourseOnline.Domain.Entities;
using MediatR;

namespace CourseOnline.Application.Features.Courses.Commands.CreateCourse
{
    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, Course>
    {
        private readonly IGenericRepositoryAsync<Course> _course;
        private readonly IMapper _mapper;

        public CreateCourseCommandHandler(IGenericRepositoryAsync<Course> course, IMapper mapper)
        {
            _course = course;
            _mapper = mapper;
        }

        public async Task<Course> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {

            var course = _mapper.Map<Course>(request.courseDTO);
            var result = await _course.AddAsync(course);
            return result;
        }
    }
}

