using CourseOnline.Application.DTOs.Dapper;
using CourseOnline.Application.Interfaces.PaginationDapper;
using MediatR;

namespace CourseOnline.Application.Features.Courses.Queries.GetPagination
{
    public class PaginationHandler : IRequestHandler<PaginationQuery, PaginationModel>
    {
        private readonly IPaginationRepositoryAsync _paginationRepositoryAsync;
        public PaginationHandler(IPaginationRepositoryAsync paginationRepositoryAsync)
        {
            _paginationRepositoryAsync=paginationRepositoryAsync;
        }
        public async Task<PaginationModel> Handle(PaginationQuery request, CancellationToken cancellationToken)
        {
            var storeProcedure = "usp_Get_Pagination";
            var order = "Titulo";

            var parameters = new Dictionary<string,object>();

            parameters.Add("CourseName", request.Title);
            return await _paginationRepositoryAsync.GetPagination(storeProcedure,request.NumberPage,request.CountElement,parameters,order);
            throw new NotImplementedException();
        }
    }
}