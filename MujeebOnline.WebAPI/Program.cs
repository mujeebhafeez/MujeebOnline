using MujeebOnline.AutoMapper;
using MujeebOnline.Repositories;
using MujeebOnline.Business;
using MujeebOnline.Connector;
using MujeebOnline.Caching;
using MujeebOnline.Utility;
using Serilog;
using MujeebOnline.ExceptionsAndLoggings.SeriLog;
using MujeebOnline.WebAPI.Middlewares;
using ConfigurationManager = MujeebOnline.Utility.ConfigurationManager;
using MujeebOnline.Entities;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var Configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", false, true)
    .AddJsonFile("appsettings.Development.json", false, true)
    .AddCommandLine(args)
    .AddEnvironmentVariables()
    .Build();



try
{
    Log.Logger = SeriLogExtensions.Configuration();

    Log.Information("Starting web application");
    var builder = WebApplication.CreateBuilder(args);
    Log.Information("ending web application");

    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            //ValidIssuer = Configuration["Jwt:Issuer"],
            //ValidAudience = Configuration["Jwt:Issuer"],
            //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
            ValidIssuer = ConfigurationManager.GetValue("Jwt:Issuer"),
            ValidAudience = ConfigurationManager.GetValue("Jwt:Audience"),
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManager.GetValue("Jwt:Key")))
        };
    });

    // Add services to the container.
    //builder.Services.AddMemoryCache();
    builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
    builder.Services.AddSingleton(new DBConfigurationManager(Configuration));
    builder.Services.AddSingleton(new ConfigurationManager(Configuration));
    builder.Services.AddSingleton<ISessionManager, SessionManager>();
    builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    builder.Services.AddScoped<IRepositoryServiceProvider, RepositoryServiceProvider>();
    builder.Services.AddScoped<IBusinessProvider, BusinessProvider>();
    builder.Services.AddScoped<IExternalServiceProvider, ExternalServiceProvider>();


    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "Mujeeb Online Swagger"
        });

        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description = "Add JWT auth token like BEARER *",
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            In = ParameterLocation.Header,
            Scheme = "Bearer"

        });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                },
                Scheme="Bearer",
                Name="Bearer",
                In=ParameterLocation.Header
            },
            new List<string>()
            }

        });
    });

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseMiddleware<MessageInspector>();

    app.UseHttpsRedirection();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Error($"exception in program: {ex}");
}
finally
{
    Log.Information($"finally in program");
}