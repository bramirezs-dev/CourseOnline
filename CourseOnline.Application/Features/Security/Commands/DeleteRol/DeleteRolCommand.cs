using MediatR;

namespace CourseOnline.Application.Features.Security.Commands.DeleteRol
{
    public class DeleteRolCommand :IRequest
    {
        public string Name { get; set; }
    }
}