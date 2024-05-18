using Dapper;
using System.Data;

namespace MujeebOnline.Repositories
{
    public class DBResponse
    {
        public int ResponseCode { get; set; }
        public string Description { get; set; }
        public bool IsSucceed => ResponseCode == 0;

        public DBResponse(int? responseCode, string description)
        {
            ResponseCode = responseCode ?? 0;
            Description = description;
        }
    }

    public class DBResponse<T> : DBResponse
    {
        public DBResponse(int? responseCode = 0, string description = null, T data = default) : base(responseCode, description)
        {
            Data = data;
        }

        public T Data { get; }

    }

    public static class DBResponseExtenstions
    {

        public static DynamicParameters AddResponseParameters(this DynamicParameters parameters)
        {
            parameters.Add("@resCode", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@resDescription", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
            return parameters;
        }

        public static DBResponse GetResponse(this DynamicParameters parameters)
        {
            return new(parameters.Get<int?>("@resCode"), Convert.ToString(parameters.Get<string>("@resDescription")));
        }
        public static DBResponse<T> GetResponse<T>(this DynamicParameters parameters, string dataParameterName)
        {
            var dataValue = parameters.Get<T>(dataParameterName);
            return new DBResponse<T>(parameters.Get<int?>("@resCode"), Convert.ToString(parameters.Get<string>("@resDescription")), dataValue);
        }
    }
}
