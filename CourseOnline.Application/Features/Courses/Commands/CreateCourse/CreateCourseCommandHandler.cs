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
        private readonly IGenericRepositoryAsync<CourseInstructor> _genericCourseInstructorRepository;
        private readonly IGenericRepositoryAsync<Price> _genericPriceRepository;
        private readonly IMapper _mapper;

            public CreateCourseCommandHandler(IGenericRepositoryAsync<Course> course,
                IGenericRepositoryAsync<CourseInstructor> genericCourseInstructorRepository,
                IGenericRepositoryAsync<Price> genericPriceRepository,
                IMapper mapper)
            {
                _course = course;
            _genericCourseInstructorRepository = genericCourseInstructorRepository;
            _genericPriceRepository = genericPriceRepository;
            _mapper = mapper;
            }

            public async Task<Course> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
            {
                Guid _courseId = Guid.NewGuid();
                var course = _mapper.Map<Course>(request.courseDTO);
                course.Id = _courseId;
                var result = await _course.AddAsync(course);

            if (request.courseDTO.Instructors != null)
                {

                    foreach (var instructor in request.courseDTO.Instructors)
                    {
                        var courseInstructor = new CourseInstructor
                        {
                            CourseId = _courseId,
                            InstructorId = instructor
                        };

                    await _genericCourseInstructorRepository.AddAsync(courseInstructor);
                        
                    }
                }

                var price = new Price
                {
                    CourseId = _courseId,
                    CurrentPrice = request.courseDTO.Price,
                    Promotion = request.courseDTO.Promotion,
                    Id = Guid.NewGuid(),
                };

                await _genericPriceRepository.AddAsync(price);

                
                return result;
            }
        }
    }

