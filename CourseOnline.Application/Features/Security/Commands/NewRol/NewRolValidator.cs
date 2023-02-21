using FluentValidation;

namespace CourseOnline.Application.Features.Security.Commands.NewRol
{
    public class NewRolValidator : AbstractValidator<NewRolCommand>
    {
        public NewRolValidator()
        {
            RuleFor(rol => rol.Name).NotNull().NotEmpty().WithMessage("it's required Name");
        }
    }
}