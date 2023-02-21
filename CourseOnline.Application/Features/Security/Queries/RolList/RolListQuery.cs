using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CourseOnline.Application.Features.Security.Queries.RolList
{
    public class RolListQuery : IRequest<List<IdentityRole>>
    {
        
    }
}