using MujeebOnline.ExceptionsAndLoggings;
using MujeebOnline.ViewModels;
using MujeebOnline.Utility;
using MujeebOnline.Entities;
using System.Threading;
using Newtonsoft.Json.Linq;

namespace MujeebOnline.WorkerService
{
    public class MyWorkerService : BaseWorkerService
    {
        private Timer _timer;
        private int count = 0;
        CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        CancellationToken _stoppingToken;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _stoppingToken = stoppingToken;
            HandledExceptionGeneric.LogInformation($"Worker running at: {DateTimeOffset.Now}");

            try
            {

                while (!_stoppingToken.IsCancellationRequested)
                {
                    HandledExceptionGeneric.LogInformation($"Worker running at: {DateTimeOffset.Now}");
                    await ProcessMyWorkerServiceFunction();
                    _stoppingToken = cancelTokenSource.Token;
                    cancelTokenSource.Cancel();
                    HandledExceptionGeneric.LogInformation($"Worker stopping at: {DateTimeOffset.Now}");
                }

           }

            catch (Exception ex)
            {
                //UnWrap aggregate exceptions
                if (ex is AggregateException aggregateException)
                {
                    foreach (var innerException in aggregateException.Flatten().InnerExceptions)
                    {
                        HandledExceptionGeneric.LogException("One or many tasks failed.", innerException);
                    }
                }
                else
                {
                    HandledExceptionGeneric.LogException("Exception executing tasks", ex);
                }
            }
        }

 

        public async Task ProcessMyWorkerServiceFunction()
        {
              count ++;
            var _repositoryServiceProvider = GetRepositoryProvider();
            var employeeList = _repositoryServiceProvider.EmployeeRepository.GetEmployeeList();

            var _businessProvider = GetBusinessProvider();

            var muj = "[{\"EmployeeID\":1,\"Name\":\"mujeeb\",\"Position\":\"IT\",\"Salary\":15000,\"mujint\":0,\"mujstr\":null},{\"EmployeeID\":12,\"Name\":\"zxcvz\",\"Position\":\"asda\",\"Salary\":2131,\"mujint\":0,\"mujstr\":null},{\"EmployeeID\":13,\"Name\":\"adsasdadasdasdasdasd\",\"Position\":\"sfsdf\",\"Salary\":13123,\"mujint\":0,\"mujstr\":null},{\"EmployeeID\":14,\"Name\":\"SMSSSSzzzzzSM\",\"Position\":\"SMAAAasdasdas\",\"Salary\":24570664,\"mujint\":0,\"mujstr\":null},{\"EmployeeID\":2002,\"Name\":\"string1\",\"Position\":\"string2\",\"Salary\":456,\"mujint\":0,\"mujstr\":null},{\"EmployeeID\":2003,\"Name\":\"strinsadadg\",\"Position\":\"strasdaasdasdsadasing\",\"Salary\":9090,\"mujint\":0,\"mujstr\":null}]";

            var muj1 = muj.GetJsonDeserialized<List<EmployeeVM>>();
            HandledExceptionGeneric.LogInformation("GetData");
            HandledExceptionGeneric.LogExceptionAndThrow("GetData Exception", null);
            var result = await _businessProvider.EmployeeBusiness.GetEmployee();
            var resultVM = result;
            var muj2 = resultVM.First();
            var abc = muj2.GetJsonSerializedSerialize();
            var muj2abc = abc.GetJsonDeserialized<Employee>();
            HandledExceptionGeneric.LogInformation("GetData" + resultVM.GetJsonSerializedSerialize());
            //throw new System.ArgumentException("Parameter cannot be null", "original");
 
            HandledExceptionGeneric.LogInformation($"Worker count at: {count}");
            await Task.CompletedTask;
        }
    }
}