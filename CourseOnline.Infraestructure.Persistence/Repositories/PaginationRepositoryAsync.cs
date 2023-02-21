using CourseOnline.Application.DTOs.Dapper;
using CourseOnline.Application.Interfaces.Dapper;
using CourseOnline.Application.Interfaces.PaginationDapper;
using Dapper;

namespace CourseOnline.Infraestructure.Persistence.Repositories
{
    public class PaginationRepositoryAsync : IPaginationRepositoryAsync
    {
        private readonly  IFactoryConnection _factoryConnection;
        public PaginationRepositoryAsync(IFactoryConnection factoryConnection)
        {
            _factoryConnection = factoryConnection;
        }
        public async Task<PaginationModel> GetPagination(string storeProcedure, int numberPage, int countElement, IDictionary<string, object> filterParams, string order)
        {
            PaginationModel paginationModel = new PaginationModel();
            List<IDictionary<string,object>> reportList = null;
            int totalRecords =0;
            int totalPages =0;
            try
            {
                var connection = _factoryConnection.GetConnection();
                DynamicParameters parameters = new DynamicParameters();

                foreach (var param in filterParams)
                {
                    parameters.Add($"{param.Key}",param.Value);
                }

                parameters.Add("NumberPages",numberPage);
                parameters.Add("CountElement",countElement);
                parameters.Add("Order",order);

                parameters.Add("TotalRecords",totalRecords, System.Data.DbType.Int32, System.Data.ParameterDirection.Output);
                parameters.Add("TotalPages",totalPages, System.Data.DbType.Int32, System.Data.ParameterDirection.Output);

                var result = await connection.QueryAsync(storeProcedure,parameters,commandType: System.Data.CommandType.StoredProcedure);
                reportList = result.Select(pagination => (IDictionary<string,object>) pagination).ToList();
                paginationModel.RecordsList = reportList;
                paginationModel.NumberPages = parameters.Get<int>("@TotalPages");
                paginationModel.TotalRecords = parameters.Get<int>("@TotalRecords");
            }
            catch (System.Exception ex)
            {
                throw new Exception("Can't execute pagination",ex);
            }finally{
                _factoryConnection.CloseConnection();
            }
            return paginationModel;
        }
    }
}