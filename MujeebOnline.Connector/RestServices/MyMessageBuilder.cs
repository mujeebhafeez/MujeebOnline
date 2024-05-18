
using MujeebOnline.Constants;
using MujeebOnline.Entities;
using MujeebOnline.ViewModels;
using MujeebOnline.Utility;

namespace MujeebOnline.Connector
{
    public class MyMessageBuilder : RestMessageParser<string, List<EmployeeVM>>
    {
        public override List<EmployeeVM> ProcessRequest(string request, int moduleId)
        {
            string _url = "https://localhost:7188/api/Employee/GetDataFromUSP";
            string _username = null;
            string _password = null;

            RestRequestOptions _requestOptions = new RestRequestOptions
                                        (_url, HTTPVerbListConstants.GET, ContentTypeConstants.JSON);
            _requestOptions.RequestBody = BuidRequest(request, moduleId);
            //_requestOptions.UseBasicAuth(_username, _password);
            var executedDate = ExecuteRequest(_requestOptions);
            var responseDetail = GetResponse(executedDate);
            return responseDetail;

        }
        public override string BuidRequest(string request, int moduleId)
        {
            string _serializedObject = request.GetJsonSerializedSerialize();
            return _serializedObject;
        }

        public override List<EmployeeVM> GetResponse(string response)
        {
            var muj1 = response.GetJsonDeserialized<List<EmployeeVM>>();
            return muj1;
        }

    }
}
