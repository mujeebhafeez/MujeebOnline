using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MujeebOnline.Business;
using MujeebOnline.Entities;
using MujeebOnline.ExceptionsAndLoggings;
using MujeebOnline.ViewModels;
using MujeebOnline.Utility;
using MujeebOnline.AutoMapper;

namespace MujeebOnline.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : Controller
    {

        private readonly IBusinessProvider _businessProvider;
        private readonly ISessionManager _session;
        private readonly IMapper _mapper;

        public EmployeeController(IBusinessProvider businessProvider, IMapper mapper, ISessionManager session)
        {
            _businessProvider = businessProvider;
            _mapper = mapper;
            _session = session;
        }

        [HttpGet]
        public async Task<APIResponse<List<EmployeeVM>>> GetEmployeeDetail()
        {
            var muj = _session.MyUserSession.GetJsonSerializedSerialize();
            var aPIResponse = await _businessProvider.EmployeeBusiness.GetEmployeeList();
            var responseModel = await aPIResponse.GetResponseInTarget<List<Employee>, List<EmployeeVM>>();
            responseModel.ResponseData = AutoMapperHelper.ParseCollection<Employee, EmployeeVM>(aPIResponse.ResponseData);
            return responseModel;


        }

        [HttpGet]
        public async Task<List<EmployeeVM>> GetEmployeeFromESB()
        {

            var result = await _businessProvider.EmployeeBusiness.GetEmployeeFromESB();
            return result;

        }

        [HttpGet]
        public async Task<List<EmployeeVM>> GetData()
        {

            var result = await _businessProvider.EmployeeBusiness.GetEmployee();
            var muj = "[{\"EmployeeID\":1,\"Name\":\"mujeeb\",\"Position\":\"IT\",\"Salary\":15000,\"mujint\":0,\"mujstr\":null},{\"EmployeeID\":12,\"Name\":\"zxcvz\",\"Position\":\"asda\",\"Salary\":2131,\"mujint\":0,\"mujstr\":null},{\"EmployeeID\":13,\"Name\":\"adsasdadasdasdasdasd\",\"Position\":\"sfsdf\",\"Salary\":13123,\"mujint\":0,\"mujstr\":null},{\"EmployeeID\":14,\"Name\":\"SMSSSSzzzzzSM\",\"Position\":\"SMAAAasdasdas\",\"Salary\":24570664,\"mujint\":0,\"mujstr\":null},{\"EmployeeID\":2002,\"Name\":\"string1\",\"Position\":\"string2\",\"Salary\":456,\"mujint\":0,\"mujstr\":null},{\"EmployeeID\":2003,\"Name\":\"strinsadadg\",\"Position\":\"strasdaasdasdsadasing\",\"Salary\":9090,\"mujint\":0,\"mujstr\":null}]";

            var muj1 = muj.GetJsonDeserialized<List<EmployeeVM>>();
            HandledExceptionGeneric.LogInformation("GetData");
            HandledExceptionGeneric.LogExceptionAndThrow("GetData Exception", null);
            var resultVMlist = AutoMapperHelper.ParseCollection<Employee, EmployeeVM>(result);
            var result1 = result.FirstOrDefault();
            var resultVM = _mapper.Map<List<EmployeeVM>>(result);
            var resultVM2 = AutoMapperHelper.Parse<Employee, EmployeeVM>(result1);
            var muj2 = resultVM.First();
            var abc = muj2.GetJsonSerializedSerialize();
            var muj2abc = abc.GetJsonDeserialized<EmployeeVM>();
            HandledExceptionGeneric.LogInformation("GetData" + resultVM.GetJsonSerializedSerialize());
            //throw new System.ArgumentException("Parameter cannot be null", "original");
            return resultVM;

        }

        [HttpPost]
        public async Task<bool> InsertEmployee(Employee emp)
        {
            var result = await _businessProvider.EmployeeBusiness.InsertEmployee(emp);
            var resultVM = _mapper.Map<bool>(result);
            return resultVM;
        }
        [HttpPost]
        public async Task<bool> DeleteEmployee(Employee emp)
        {
            var result = await _businessProvider.EmployeeBusiness.DeleteEmployee(emp);
            var resultVM = _mapper.Map<bool>(result);
            return resultVM;
        }

        [HttpGet]
        public async Task<List<EmployeeVM>> GetDataFromUSP()
        {
            var result = await _businessProvider.EmployeeBusiness.GetEmployeeFromUSP();
            var resultVM = AutoMapperHelper.ParseCollection<Employee, EmployeeVM>(result);
            HandledExceptionGeneric.LogInformation("GetData" + resultVM.GetJsonSerializedSerialize());
            //throw new System.ArgumentException("Parameter cannot be null", "original");
            return resultVM;

        }
    }
}
