using MujeebOnline.Constants;
using System.Text.Json.Serialization;

namespace MujeebOnline.Entities
{
    public class APIResponse
    {
        public ReturnCodeEnum ActCode { get; set; }
        public string ActDescription { get; set; }
        public string ActDescriptionKey { get; set; }
        public string AdditionalData { get; set; }
        public MessageTypeEnum MessageType { get; set; }
        public bool IsSucceed => ActCode == ReturnCodeEnum.Success;
        [JsonIgnore]
        public Dictionary<string, string> ReplaceTokens { get; set; } = new();
        public static APIResponse ServerError(string additionalDataText)
        {
            return new()
            {
                ActCode = ReturnCodeEnum.ServerError,
                ActDescription = "ServerError",
                ActDescriptionKey = LanguageTextConstants.ServerError,
                AdditionalData = additionalDataText,
                MessageType = MessageTypeEnum.Error
            };
        }
    }

    public class APIResponse<T> : APIResponse
    {
        public T ResponseData { get; set; }

        public APIResponse() { }
        public APIResponse(T data, ReturnCodeEnum returnCode = ReturnCodeEnum.Success,
                string actDescription = "Success",
                string actDescriptionKey = LanguageTextConstants.Success,
                string additionalData = null,
                MessageTypeEnum messageType = MessageTypeEnum.Information,
                Dictionary<string, string> replaceTokens = null)
        {
            ResponseData = data;
            ActCode = returnCode;
            ActDescription = actDescription;
            ActDescriptionKey = actDescriptionKey;
            AdditionalData = additionalData;
            MessageType = messageType;
            ReplaceTokens = replaceTokens;
        }

        public static APIResponse<T> ServerError(string additionalDataText)
        {
            return new()
            {
                ResponseData = default,
                ActCode = ReturnCodeEnum.ServerError,
                ActDescription = "ServerError",
                ActDescriptionKey = LanguageTextConstants.ServerError,
                AdditionalData = additionalDataText,
                MessageType = MessageTypeEnum.Error
            };
        }

        public static APIResponse<T> BadRequest(string additionalDataText) =>
                new(default, ReturnCodeEnum.BadRequest, "BadRequest", LanguageTextConstants.BadRequest,
                additionalDataText, MessageTypeEnum.Error);
        public static APIResponse<T> Failed(ReturnCodeEnum returncode, string descriptionKey, string additionalDataText) =>
                       new(default, returncode, "Failure", descriptionKey, additionalDataText, MessageTypeEnum.Error);
        public static APIResponse<T> Failed(string descriptionKey, string additionalDataText) =>
                       new(default, ReturnCodeEnum.Failure, "Failure", descriptionKey, additionalDataText, MessageTypeEnum.Error);
        public static APIResponse<T> Failed(string descriptionKey, string additionalDataText, MessageTypeEnum messageType) =>
                          new(default, ReturnCodeEnum.Failure, "Failure", descriptionKey, additionalDataText, messageType: messageType);
        public static APIResponse<T> InvalidRequest
            (string descriptionKey = LanguageTextConstants.InvalidRequest,
            string additionalDataText = null)
        {
            return new(default, ReturnCodeEnum.InvalidRequest,
                        "InvalidRequest", descriptionKey, additionalDataText, MessageTypeEnum.Error);
        }

        public static APIResponse<T> Success(T responsedata, string descriptionKey, string additionalDataText) =>
                       new(responsedata, ReturnCodeEnum.Success, "Success", descriptionKey, additionalDataText, MessageTypeEnum.Information);

        public static APIResponse<T> Success(T responsedata, string additionalDataText = null) =>
               new(responsedata, ReturnCodeEnum.Success, "Success", LanguageTextConstants.Success, additionalDataText, MessageTypeEnum.Information);

        public APIResponse<T> WithReplaceTokens(Dictionary<string, string> replaceTokensValues)
        {
            ReplaceTokens = replaceTokensValues;
            return this;
        }

        public APIResponse<TR> AS<TR>(TR responseData = default, ReturnCodeEnum? actCode = null,
            string actDescription = null,
            string actDescriptionKey = null,
            string additionalDataText = null
            )
        {
            return new APIResponse<TR>
            {
                ResponseData = responseData,
                ActCode = actCode ?? ActCode,
                ActDescription = actDescription ?? ActDescription,
                ActDescriptionKey = actDescriptionKey ?? ActDescriptionKey,
                AdditionalData = additionalDataText,
                MessageType = MessageType,
                ReplaceTokens = ReplaceTokens
            };
        }

    }


}

