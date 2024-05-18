using MujeebOnline.Constants;

namespace MujeebOnline.Entities
{
    public static class APIResponseFormatter
    {

        public static async Task<APIResponse<T>> GetResponseInTarget<TS, T>(this APIResponse<TS> response)
        {
            return await Task.Run(() => new APIResponse<T>
            {
                ActCode = response.ActCode,
                ActDescription = response.ActDescription,
                ActDescriptionKey = response.ActDescriptionKey,
                AdditionalData = response.AdditionalData,
                MessageType = response.MessageType,
                ReplaceTokens = response.ReplaceTokens
            });


        }
    }
}
