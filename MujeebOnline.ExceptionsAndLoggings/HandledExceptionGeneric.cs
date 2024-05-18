using Serilog;

namespace MujeebOnline.ExceptionsAndLoggings
{
    public static class HandledExceptionGeneric
    {


        public static void LogException(string message, Exception exception) 
        {
            var handledException = new HandledException(message, exception);
            Log.Error($"{message}  {exception}");
            return;
        }

        public static HandledException LogExceptionAndThrow(string message, Exception exception)
        {
            var handledException = new HandledException(message, exception);
            Log.Error($"{message}  {exception}");
            return handledException;
        }

        public static void LogInformation(string message)
        {
            Log.Information(message);
        }
    }
}
