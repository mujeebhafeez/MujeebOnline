
namespace MujeebOnline.Connector
{
    public abstract class RestMessageParser<TRequest, TResponse> where TRequest : class
    {
        public abstract TResponse ProcessRequest(TRequest request, int moduleId);
        public abstract string BuidRequest(TRequest request, int moduleId);
        public abstract TResponse GetResponse(string response);
        public virtual string ExecuteRequest(RestRequestOptions _restRequestOptions)
        {
            RestConnector connect = new RestConnector(_restRequestOptions);
            var response = connect.Invoke(_restRequestOptions);
            return response;
        }
    }
}
