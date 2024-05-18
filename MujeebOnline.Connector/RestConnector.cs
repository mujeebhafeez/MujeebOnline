
using System.Collections;
using System.Net;
using System.Text;

namespace MujeebOnline.Connector
{
    public class RestConnector
    {
        private RestRequestOptions _restRequestOptions;

        public RestConnector(RestRequestOptions restRequestOptions)
        {
            restRequestOptions = _restRequestOptions;
        }

        public string Invoke(RestRequestOptions _restRequestOptions)
        {
            string _response = String.Empty;
            try
            {
                HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.
                                            Create(new Uri(_restRequestOptions.EndPoint));
                httpRequest.ContentType = _restRequestOptions.ContentType;
                httpRequest.Method = _restRequestOptions.Method;
                if (_restRequestOptions.HeaderCollections is not null)
                {
                    foreach (var customHeader in _restRequestOptions.HeaderCollections)
                        httpRequest.Headers.Add(customHeader.Key, customHeader.Value);
                }

                if (_restRequestOptions.IsRequestHasBody)
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(_restRequestOptions.RequestBody);
                    httpRequest.ContentLength = bytes.Length;
                    _restRequestOptions.ContentLength = bytes.Length;
                    using (Stream stream = httpRequest.GetRequestStream())
                    {
                        stream.Write(bytes, 0, bytes.Length);
                        stream.Close();
                    }
                }

                using (HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse())
                {
                    using (Stream stream = httpResponse.GetResponseStream())
                    {
                        _response = (new StreamReader(stream)).ReadToEnd();
                    }
                }

            } catch (Exception ex)
            {

            }
            finally
            {

            }
            return _response;
        }
    }
}
