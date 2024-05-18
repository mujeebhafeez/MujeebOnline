using Microsoft.AspNetCore.Diagnostics;
using MujeebOnline.Constants;
using MujeebOnline.Entities;
using MujeebOnline.ExceptionsAndLoggings;
using MujeebOnline.Utility;
using System.Net;
using System.Text;
using System.Text.Json;

namespace MujeebOnline.WebAPI.Middlewares
{
    public class MessageInspector
    {
        public static readonly JsonSerializerOptions _serializerOptions = new()
        {
            PropertyNamingPolicy = null
        };

        private readonly RequestDelegate _next;
        private readonly IHttpContextAccessor _httpContext;

        public MessageInspector(RequestDelegate next, IHttpContextAccessor httpContext)
        {
            _next = next;
            _httpContext = httpContext;
        }

        public async Task InvokeAsync(HttpContext context, ISessionManager _sessionManager)
        {
            var requestStartDateTime = DateTime.Now;
            string path = context.Request.Path.ToUriComponent();
            var requestDetails =await FormatRequestAndResponse(context,"Request");
            var IPAddress = context.Request.Headers["IPAddress"].ToString();
            string contextRequestPath = $"{context.Request.Path}";
            string requestPath = contextRequestPath.Substring(contextRequestPath.LastIndexOf("/", StringComparison.Ordinal)).Replace("/", "");
            string LogOperation = $"{context.Request.Scheme}://{context.Request.Host}{context.Request.PathBase}{context.Request.Path}" +
                                    $"{context.Request.QueryString}";

            var originalBodyStream = context.Response.Body;

            await using (var responseBody = new MemoryStream())
            {
                context.Response.Body = responseBody;

                try
                {
                    var userID = 101;
                    var userName = "MyUser";
                    var userPassword = "MyPassword";
                    var currentUserDetails = new UserSession()
                    {
                        UserID = userID,
                        UserName = userName,
                        UserPassword = userPassword,
                        IsCancelled = false,
                        Mydetails1 = $"1 : {userID} : {userName} : {userPassword}",
                        Mydetails2 = $"2 : {userID} : {userName} : {userPassword}",
                        UserRequestID = Guid.NewGuid()
                    };
                    _sessionManager.MyUserSession = currentUserDetails;

                    bool isJWTVerified = true;
                    if (!isJWTVerified)
                    {
                        context.Response.ContentType = "application/json";
                        context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;

                        var responseObject = new APIResponse()
                        {
                            ActCode = ReturnCodeEnum.ServerError,
                            ActDescriptionKey = LanguageTextConstants.ServerError,
                            ActDescription = "JWT Not Verified",
                            AdditionalData = "JWT Not Verified - Error Details",
                            MessageType = MessageTypeEnum.Error
                        };
                        await context.Response.WriteAsJsonAsync(responseObject.GetJsonSerializedSerialize(), _serializerOptions);
                        return;
                    }
                    await _next(context);

                }

                catch (Exception ex)
                {
                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    var responseObject = new APIResponse()
                    {
                        ActCode = ReturnCodeEnum.BadRequest,
                        ActDescriptionKey = LanguageTextConstants.BadRequest,
                        ActDescription = "Exception Occured",
                        AdditionalData = ex.ToString(),
                        MessageType = MessageTypeEnum.Error
                    };
                    HandledExceptionGeneric.LogException("MiddleWare Exception:", ex);
                    await context.Response.WriteAsJsonAsync(responseObject.GetJsonSerializedSerialize(), _serializerOptions);
                    return;
                }

                finally
                {
                    var responseDetails = await FormatRequestAndResponse(context, "Response");
                    responseBody.Position = 0;  

                    var requestEndDateTime = DateTime.Now;
                    var elapsedTime = requestEndDateTime - requestStartDateTime;
                    var logMessage = $"{context.Request.Method} {context.Request.Path} {context.Response.StatusCode} {elapsedTime.TotalMilliseconds}ms";
                    HandledExceptionGeneric.LogInformation("MiddleWare Finally:" + logMessage);

                    await responseBody.CopyToAsync(originalBodyStream);
                }
            }
        }

        public static async Task<string> FormatRequestAndResponse(HttpContext context, string logType = "")
        {
            context.Request.EnableBuffering();
            string logText = string.Empty;
            if (logType == "Request")
            {
                context.Request.Body.Seek(0, SeekOrigin.Begin);
                logText = await new StreamReader(context.Request.Body, Encoding.Default).ReadToEndAsync();
                context.Request.Body.Seek(0, SeekOrigin.Begin);
            }
            if (logType == "Response")
            {
                context.Response.Body.Seek(0, SeekOrigin.Begin);
                logText = await new StreamReader(context.Response.Body, Encoding.Default).ReadToEndAsync();
                context.Response.Body.Seek(0, SeekOrigin.Begin);
            }
            return logText;
        }
    }
}









