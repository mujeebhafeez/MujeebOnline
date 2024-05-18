using Dapper;
using Microsoft.Data.SqlClient;
using MujeebOnline.ExceptionsAndLoggings;
using System.Data;
using System.Reflection.Metadata;

namespace MujeebOnline.Repositories
{
    public abstract class GenericDataAccess
    {

        public virtual IDbConnection GetDbConnection()
        {
            IDbConnection _dbConnection = new SqlConnection(DBConfigurationManager.GetDBConnection("MyDbConnection"));
            if(_dbConnection.State==ConnectionState.Closed)
                _dbConnection.Open();
            return _dbConnection;
        }

        protected virtual async Task<IEnumerable<T>> GetAll<T>(string commandText,DynamicParameters dynamicParameters = null, CommandType commandType = CommandType.Text)
        {
            try
            {
                HandledExceptionGeneric.LogInformation("GenericDataAccess");
                using var db = GetDbConnection();
                var result = await db.QueryAsync<T>(commandText, dynamicParameters, commandType: commandType);
                return result.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected virtual async Task<T> Get<T>(string commandText, DynamicParameters dynamicParameters = null, CommandType commandType = CommandType.Text)
        {
            try
            {
                HandledExceptionGeneric.LogInformation("GenericDataAccess");
                using var db = GetDbConnection();
                var result = await db.QueryAsync<T>(commandText, dynamicParameters, commandType: commandType);
                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected virtual async Task<bool> Insert<T>(T obj, string commandText)
        {
             try
            {
                using var db = GetDbConnection();
                var result = await db.ExecuteAsync(commandText, obj);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        protected virtual async Task<bool> Execute<T>(string commandText, DynamicParameters dynamicParameters = null, CommandType commandType = CommandType.Text)
        {
            try
            {
                var parameterList = new List<DynamicParameters>();
                parameterList.Add(dynamicParameters);
                using var db = GetDbConnection();
                var result = await db.ExecuteAsync(commandText, parameterList);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
