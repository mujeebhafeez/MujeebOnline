using MujeebOnline.Connector;
using MujeebOnline.Constants;
using MujeebOnline.Entities;
using MujeebOnline.ExceptionsAndLoggings;
using MujeebOnline.Repositories;
using MujeebOnline.Caching;
using MujeebOnline.ViewModels;
using MujeebOnline.Utility;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using Microsoft.Extensions.Configuration;
using ConfigurationManager = MujeebOnline.Utility.ConfigurationManager;

namespace MujeebOnline.Business
{
    public class EmployeeBusiness
    {
        private readonly IRepositoryServiceProvider _repositoryServiceProvider;
        private readonly IBusinessProvider _businessProvider;
        private readonly IExternalServiceProvider _externalServiceProvider;


        public EmployeeBusiness(IBusinessProvider businessProvider, IRepositoryServiceProvider repositoryServiceProvider, IExternalServiceProvider externalServiceProvider)
        {
            _businessProvider = businessProvider;
            _repositoryServiceProvider = repositoryServiceProvider;
            _externalServiceProvider = externalServiceProvider;
        }

        public async Task<APIResponse<List<Employee>>> GetEmployeeList()
        {
            try
            {
                var cachedmujeeb = CachingHelper.GetMujeeb();
                var cachedValue = CachingHelper.GetConfigList();
                var employeeList = await _repositoryServiceProvider.EmployeeRepository.GetEmployeeListFromUsp();
                var cachedValue2 = CachingHelper.GetConfigList();
                if (!employeeList.IsSucceed)
                    return APIResponse<List<Employee>>.Failed(LanguageTextConstants.Failure, "GetEmployeeListFromUsp failure");

                return APIResponse<List<Employee>>.Success(employeeList.Data, LanguageTextConstants.Success, "GetEmployeeListFromUsp success");




            }
            catch (Exception ex)
            {

                throw;
            }


        }


        public async Task<List<EmployeeVM>> GetEmployeeFromESB()
        {
            try
            {
                var esb = _externalServiceProvider.MyMessageBuilder.ProcessRequest("my request", 123);
                var mylist = new List<EmployeeVM>() {
                    new EmployeeVM() { EmployeeID = 1, mujint = 1 }
                };
                if (esb is null)
                    esb = mylist;

                return esb;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public Task<List<Employee>> GetEmployee()
        {
            try
            {
                var muj =  ConfigurationManager.GetArrayValue<string>("MujeebKey");
                HandledExceptionGeneric.LogInformation("EmployeeBusiness");
                var employeeList = _repositoryServiceProvider.EmployeeRepository.GetEmployeeList();
                return employeeList;
            }
            catch (Exception ex)
            {

                throw;
            }


        }


 


    public Task<bool> InsertEmployee(Employee emp)
    {
        try
        {
            var employeeList = _repositoryServiceProvider.EmployeeRepository.InsertEmployeeData(emp);
            return employeeList;
        }
        catch (Exception ex)
        {

            throw;
        }


    }

    public Task<bool> DeleteEmployee(Employee emp)
    {
        try
        {
            var employeeList = _repositoryServiceProvider.EmployeeRepository.DeleteEmployeeData(emp);
            return employeeList;
        }
        catch (Exception ex)
        {

            throw;
        }


    }

    public async Task<List<Employee>> GetEmployeeFromUSP()
    {
        try
        {
            var abc = "asda";

            HandledExceptionGeneric.LogInformation("EmployeeBusiness");
            var employeeList = _repositoryServiceProvider.EmployeeRepository.GetEmployeeListFromUsp().GetAwaiter().GetResult();
            var employeeListNoData = _repositoryServiceProvider.EmployeeRepository.GetEmployeeListFromUspNoData().GetAwaiter().GetResult();
            if (employeeList.IsSucceed)
            {
                abc = "xyz";
            }
            var muj = new List<Employee>();
            foreach (var employee in employeeList.Data)
            {
                muj.Add(employee);
            }
            return muj;
        }
        catch (Exception ex)
        {

            throw;
        }


    }



}
}
