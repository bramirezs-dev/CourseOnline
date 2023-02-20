using System;
using CourseOnline.Application.Interfaces;
using CourseOnline.Domain.Entities;
using MediatR;
using System.Linq;
using CourseOnline.Application.DTOs.Courses;
using AutoMapper;
using CourseOnline.Application.Interfaces.Courses;

namespace CourseOnline.Application.Features.Courses.Queries.GetAllCourses
{
    public class GetAllCoursesQueryHandler : IRequestHandler<GetAllCoursesQuery, List<CourseDTO>>
    {
        private readonly ICourseRepositoryAsync _courseRepositoryAsync;
        private readonly IMapper _mapper;

        public GetAllCoursesQueryHandler(ICourseRepositoryAsync courseRepositoryAsync, IMapper mapper)
        {
            _courseRepositoryAsync = courseRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<List<CourseDTO>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
        {
            var courses = await _courseRepositoryAsync.GetCoursesComplete();

            var coursesDTO = _mapper.Map<List<Course>, List<CourseDTO>>(courses);

            return coursesDTO;
        }
    }
}

