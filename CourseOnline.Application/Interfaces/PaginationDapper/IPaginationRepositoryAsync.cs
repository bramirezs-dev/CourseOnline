using CourseOnline.Application.DTOs.Dapper;

namespace CourseOnline.Application.Interfaces.PaginationDapper
{
    public interface IPaginationRepositoryAsync
    {
        Task<PaginationModel> GetPagination(string storeProcedure, 
                                            int numberPage, int countElement, 
                                            IDictionary<string, object> filterParams,
                                            string order
                                            );
    }
}