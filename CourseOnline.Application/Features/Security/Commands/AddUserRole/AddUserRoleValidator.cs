using FluentValidation;

namespace CourseOnline.Application.Features.Security.Commands.AddUserRole
{
    public class AddUserRoleValidator : AbstractValidator<AddUserRoleCommand>
    {
        public AddUserRoleValidator()
        {
            RuleFor( roleUser => roleUser.Rolname).NotNull().NotEmpty().WithMessage("it's required Rolname");
            RuleFor( roleUser => roleUser.Username).NotNull().NotEmpty().WithMessage("it's required Username");
        }
    }
}