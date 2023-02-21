using System;
using System.Data;
using CourseOnline.Application.Interfaces.Dapper;
using CourseOnline.Infraestructure.Persistence.DapperConecction;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace CourseOnline.Infraestructure.Persistence.Repositories
{
	public class FactoryConnection : IFactoryConnection
    {
        private  IDbConnection _connection;
        private readonly IOptions<ConfigurationConnection> _configs;

        public FactoryConnection(IOptions<ConfigurationConnection> configs)
		{
            _configs = configs;
        }

        public void CloseConnection()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        public IDbConnection GetConnection()
        {
            if (_connection == null)
            {
                _connection = new SqlConnection(_configs.Value.DefaultConnection);
            }

            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }

            return _connection;
        }
    }
}

