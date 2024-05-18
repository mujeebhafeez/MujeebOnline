using MujeebOnline.Constants;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MujeebOnline.Connector
{
    public class RestRequestOptions
    {
        public RestRequestOptions(string endPoint, string method = HTTPVerbListConstants.POST, string contentType = ContentTypeConstants.JSON)
        {
            EndPoint = endPoint;
            Method = method;
            ContentType = contentType;
        }
        private readonly string[] POSTMethods = new string[] { "POST", "PUT", "DELETE" };
        public string EndPoint { get; set; }
        public string Method { get; set; }
        public string RequestBody { get; set; }
        public string ContentType { get; set; }
        public long ContentLength { get; set; }
        public Dictionary<string, string> HeaderCollections { get; set; } = new();
        public bool IsRequestHasBody
        {
            get
            {
                return (!String.IsNullOrEmpty(RequestBody) && POSTMethods.Contains(Method));
            }
        }

        public RestRequestOptions UseBasicAuth(string userName, string password)
        {
            string _credentials = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes($"{userName}:{password}"));
            HeaderCollections.Add("Basic", _credentials);
            return this;
        }

    }
}
