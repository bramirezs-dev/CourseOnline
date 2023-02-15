using System;
using CourseOnline.Application.Interfaces;
using CourseOnline.Domain.Entities;
using MediatR;
using System.Linq;

namespace CourseOnline.Application.Features.Courses.Queries.GetAllCourses
{
    public class GetAllCoursesQueryHandler : IRequestHandler<GetAllCoursesQuery, IReadOnlyList<Course>>
    {
        private readonly IGenericRepositoryAsync<Course> _genericRepositoryAsync;
        public GetAllCoursesQueryHandler(IGenericRepositoryAsync<Course> genericRepositoryAsync)
        {
            _genericRepositoryAsync = genericRepositoryAsync;
        }

        public async Task<IReadOnlyList<Course>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
        {
            var courses = await _genericRepositoryAsync.GetAllAsync();
            return courses;
        }
    }
}

