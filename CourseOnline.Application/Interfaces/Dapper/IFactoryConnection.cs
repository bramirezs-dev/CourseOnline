using System;
using System.Data;

namespace CourseOnline.Application.Interfaces.Dapper
{
	public interface IFactoryConnection
	{
		void CloseConnection();

		IDbConnection GetConnection();
	}
}

