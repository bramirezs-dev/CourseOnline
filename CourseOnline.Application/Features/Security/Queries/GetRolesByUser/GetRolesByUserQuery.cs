using MediatR;

namespace CourseOnline.Application.Features.Security.Queries.GetRolesByUser
{
    public class GetRolesByUserQuery : IRequest<List<string>>
    {
        public string  Username { get; set; }
    }
}