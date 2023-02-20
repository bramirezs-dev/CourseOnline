using System;
using FluentValidation;

namespace CourseOnline.Application.Features.Courses.Commands.CreateCourse
{
    public class CreateCourseCommandValidator :AbstractValidator<CreateCourseCommand>
    {
        public CreateCourseCommandValidator()
        {
            RuleFor(dto => dto.courseDTO.Title).NotNull().WithMessage("it's necesary title");
            RuleFor(dto => dto.courseDTO.Description).NotNull().NotEmpty().WithMessage("it's necesary description");
            RuleFor(dto => dto.courseDTO.PublishDate).NotNull().WithMessage("it's necesary publish date");
            RuleFor(dto => dto.courseDTO.Price).NotNull().WithMessage("it's necesary price");
            RuleFor(dto => dto.courseDTO.Promotion).NotNull().WithMessage("it's necesary promotion");
            RuleFor(dto => dto.courseDTO.Instructors).NotNull().WithMessage("it's necesary list of instructors");

        }
    }
}

