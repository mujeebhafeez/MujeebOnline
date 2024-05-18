using Dapper;
using MujeebOnline.Entities;
using MujeebOnline.ExceptionsAndLoggings;
using System.Collections.Generic;

namespace MujeebOnline.Repositories
{
    public class EmployeeRepository : GenericDataAccess
    {
        private readonly IRepositoryServiceProvider _repositoryServiceProvider;

        public EmployeeRepository(IRepositoryServiceProvider repositoryServiceProvider)
        {
            _repositoryServiceProvider = repositoryServiceProvider;
        }

        public async Task<List<Employee>> GetEmployeeList()
        {
            HandledExceptionGeneric.LogInformation("EmployeeRepository");
            string sql = "SELECT TOP (1000) [EmployeeID],[Name],[Position],[Office],[Age],[Salary] FROM [db_muj].[dbo].[Employee] order by 1 desc";
            var employeeList = await GetAll<Employee>(sql);
            return employeeList.ToList();
        }

        public async Task<bool> InsertEmployeeData(Employee emp)
        {

            string sql = "INSERT INTO [db_muj].[dbo].[Employee] ([Name],[Position],[Salary]) " +
                "VALUES (@Name,@Position,@Salary)";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Name", emp.Name);
            parameters.Add("Position", emp.Position);
            parameters.Add("Salary", emp.Salary);

            //var employeeList = await Insert<Employee>(emp, sql);
            var employeeList = await Execute<Employee>(sql, parameters);
            return employeeList;
        }

        public async Task<bool> DeleteEmployeeData(Employee emp)
        {

            string sql = "DELETE FROM [db_muj].[dbo].[Employee] WHERE [EmployeeID] = @EmployeeID";

            var employeeList = await Insert<Employee>(emp, sql);
            return employeeList;
        }

        public async Task<DBResponse<List<Employee>>> GetEmployeeListFromUsp()
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Mode", "GET");
            parameters.AddResponseParameters();
            string sql = "SELECT TOP (1000) [EmployeeID],[Name],[Position],[Office],[Age],[Salary] FROM [db_muj].[dbo].[Employee] order by 1 desc";
            var employeeList = await GetAll<Employee>(sql, parameters);
            var response = parameters.GetResponse();
            return new DBResponse<List<Employee>>(response.ResponseCode,response.Description, employeeList.ToList());

        }

        public async Task<DBResponse> GetEmployeeListFromUspNoData()
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Mode", "GET");
            parameters.AddResponseParameters();
            string sql = "SELECT TOP (1000) [EmployeeID],[Name],[Position],[Office],[Age],[Salary] FROM [db_muj].[dbo].[Employee] order by 1 desc";
            var employeeList = await GetAll<Employee>(sql, parameters);
            var response = parameters.GetResponse();
            return new DBResponse(response.ResponseCode, response.Description);

        }
    }
}
