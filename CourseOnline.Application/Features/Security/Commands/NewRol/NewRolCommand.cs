using MediatR;

namespace CourseOnline.Application.Features.Security.Commands.NewRol
{
    public class NewRolCommand : IRequest
    {
        public string Name { get; set; }
    }
}