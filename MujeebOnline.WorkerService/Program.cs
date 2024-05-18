using MujeebOnline.ExceptionsAndLoggings;
using MujeebOnline.ExceptionsAndLoggings.SeriLog;
using MujeebOnline.Repositories;
using MujeebOnline.WorkerService;
using Serilog;

var Configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", false, true)
    .AddJsonFile("appsettings.Development.json", false, true)
    .AddCommandLine(args)
    .AddEnvironmentVariables()
    .Build();

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

try
{
    Log.Logger = SeriLogExtensions.Configuration();

    HandledExceptionGeneric.LogInformation("Starting worker service");
    var builder = Host.CreateApplicationBuilder(args);
    HandledExceptionGeneric.LogInformation("ending worker service");

    // Add services to the container.
    builder.Services.AddHostedService<MyWorkerService>();
    builder.Services.AddSingleton(new DBConfigurationManager(Configuration));
    builder.Services.AddWindowsService();

    var app = builder.Build();
    app.Run();
}
catch (Exception ex)
{
    HandledExceptionGeneric.LogException($"exception in worker service program: {ex}", ex);
}
finally
{
    HandledExceptionGeneric.LogException($"exception finally in worker service program",null);
}