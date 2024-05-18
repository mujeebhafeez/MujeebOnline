using Serilog;
using Serilog.Exceptions;
using Serilog.Formatting.Json;

namespace MujeebOnline.ExceptionsAndLoggings.SeriLog
{
    public static class SeriLogExtensions
    {

        public static ILogger Configuration()
        {
            var logger = new LoggerConfiguration()
                .WriteTo.Console(new JsonFormatter())
                .WriteTo.File(new JsonFormatter(),"mujeeblog.json")
                .Enrich.FromLogContext()
                .Enrich.WithExceptionDetails()
                .Enrich.WithMachineName()
                .Enrich.FromLogContext()
                .CreateLogger();

            return logger;
        }
    }
}
