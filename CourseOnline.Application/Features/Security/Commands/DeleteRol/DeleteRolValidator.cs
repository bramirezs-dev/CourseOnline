using FluentValidation;

namespace CourseOnline.Application.Features.Security.Commands.DeleteRol
{
    public class DeleteRolValidator : AbstractValidator<DeleteRolCommand>
    {
        public DeleteRolValidator()
        {
            RuleFor( rol => rol.Name).NotNull().NotEmpty().WithMessage("it's required Name");
        }
    }
}