namespace MujeebOnline.ExceptionsAndLoggings
{
    public class HandledException : Exception
    {

        public HandledException() { }

        public HandledException(string message) : base(message)
        {
        }

        public HandledException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
