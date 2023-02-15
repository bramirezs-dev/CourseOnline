using System;
using FluentValidation;

namespace CourseOnline.Application.Features.Courses.Commands.CreateCourse
{
    public class CreateCourseCommandValidator :AbstractValidator<CreateCourseCommand>
    {
        public CreateCourseCommandValidator()
        {
            RuleFor(dto => dto.courseDTO.Title).NotNull().WithMessage("it's necesary title");
            RuleFor(dto => dto.courseDTO.Description).NotNull().WithMessage("it's necesary description");
            RuleFor(dto => dto.courseDTO.PublishDate).NotNull().WithMessage("it's necesary publish date");
        }
    }
}

