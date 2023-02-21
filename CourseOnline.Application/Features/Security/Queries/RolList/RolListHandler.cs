using CourseOnline.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CourseOnline.Application.Features.Security.Queries.RolList
{
    public class RolListHandler : IRequestHandler<RolListQuery, List<IdentityRole>>
    {
        private readonly IGenericRepositoryAsync<IdentityRole>_identityRepository;
        public RolListHandler(IGenericRepositoryAsync<IdentityRole> identityRepository)
        {
            _identityRepository = identityRepository;
        }
        public async Task<List<IdentityRole>> Handle(RolListQuery request, CancellationToken cancellationToken)
        {
            var roles = await _identityRepository.GetAllAsync();
            return roles.ToList();

        }
    }
}