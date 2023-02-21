using System;
using CourseOnline.Application.Interfaces.Dapper;
using CourseOnline.Application.Interfaces.Instructors;
using CourseOnline.Domain.DapperEntities;
using CourseOnline.Domain.Entities;
using Dapper;

namespace CourseOnline.Infraestructure.Persistence.Repositories
{
	public class InstructorRepositoryAsync : IInstructorRepositoryAsync
	{
        private readonly IFactoryConnection _factoryConnection;

        public InstructorRepositoryAsync(IFactoryConnection factoryConnection)
		{
            _factoryConnection = factoryConnection;
        }

        public async Task<int> AddAsync(InstructorModel instructor)
        {
            var storeProcedure = "usp_New_Instructor";
            try
            {
                var connection = _factoryConnection.GetConnection();
                var result = await connection.ExecuteAsync(storeProcedure,
                                               new {
                                                   InstructorId = Guid.NewGuid(),
                                                   name = instructor.Name,
                                                   lastName = instructor.LastName,
                                                   grade = instructor.Grade
                                               }, commandType: System.Data.CommandType.StoredProcedure);


                _factoryConnection.CloseConnection();
                return result;

            }
            catch (Exception ex)
            {
                throw new Exception("Can`t save the new instructor", ex);

            }
            finally
            {
                _factoryConnection.CloseConnection();
            }
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            var storeProcedure = "usp_Delete_Instructor";
            try
            {
                var connection = _factoryConnection.GetConnection();
                var result = await connection.ExecuteAsync(storeProcedure,
                new
                {
                            InstructorId = id,
                            
                        },
                        commandType: System.Data.CommandType.StoredProcedure

                    );
                _factoryConnection.CloseConnection();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Can't delete instructor", ex);
            }
        }

        public async Task<InstructorModel> GetinstructorById(Guid id)
        {
            var storeProcedure = "usp_Instructor_ById";
            InstructorModel instructor = null;
            try
            {
                var connection = _factoryConnection.GetConnection();

                instructor = await connection.QueryFirstAsync<InstructorModel>(storeProcedure,
                new
                {
                    InstructorId = id,

                },
                        commandType: System.Data.CommandType.StoredProcedure

                    );
                _factoryConnection.CloseConnection();
                return instructor;
            }
            catch (Exception ex)
            {
                throw new Exception("Can't find instructor", ex);
            }
        }

        public async Task<IEnumerable<InstructorModel>> Getinstructors()
        {
            IEnumerable<InstructorModel> instructorList = null;
            var storeProcedure = "usp_Get_Instructors";


            try
            {
                var connection = _factoryConnection.GetConnection();
                instructorList = await connection.QueryAsync<InstructorModel>(storeProcedure, null, commandType: System.Data.CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in the query instructors",ex);
            }
            finally
            {
                _factoryConnection.CloseConnection();
            }

            return instructorList;
        }

        public async Task<int> UpdateAsyn(InstructorModel instructor)
        {
            var storeProcedure = "usp_Update_Instructor";
            try
            {
                var connection = _factoryConnection.GetConnection();
                var result = await connection.ExecuteAsync(storeProcedure,
                        new
                        {
                            InstructorId = instructor.InstructorId,
                            name = instructor.Name,
                            lastName = instructor.LastName,
                            grade = instructor.Grade
                        },
                        commandType: System.Data.CommandType.StoredProcedure

                    );
                _factoryConnection.CloseConnection();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Can't update instructor",ex);
            }
        }
    }
}

