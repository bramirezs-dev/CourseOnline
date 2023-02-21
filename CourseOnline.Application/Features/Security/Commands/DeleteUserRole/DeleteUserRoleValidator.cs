using FluentValidation;

namespace CourseOnline.Application.Features.Security.Commands.DeleteUserRole
{
    public class DeleteUserRoleValidator : AbstractValidator<DeleteUserRoleCommand>
    {
        public DeleteUserRoleValidator()
        {
            RuleFor( roleUser => roleUser.Rolname).NotNull().NotEmpty().WithMessage("it's required Rolname");
            RuleFor( roleUser => roleUser.Username).NotNull().NotEmpty().WithMessage("it's required Username");
        }
    }
}