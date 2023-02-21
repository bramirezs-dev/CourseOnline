using FluentValidation;

namespace CourseOnline.Application.Features.Security.Commands.UpdateUser
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserValidator()
        {
            RuleFor(user => user.Email).NotNull().NotEmpty().WithMessage("it's required email");
            RuleFor(user => user.Name).NotNull().NotEmpty().WithMessage("it's required email");
            RuleFor(user => user.LastName).NotNull().NotEmpty().WithMessage("it's required email");
            RuleFor(user => user.Password).NotNull().NotEmpty().WithMessage("it's required email");
        }
    }
}