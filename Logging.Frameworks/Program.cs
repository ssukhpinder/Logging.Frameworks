using Logging.Frameworks.ElmahIO.Extensions;
using Logging.Frameworks.NLog.Extensions;
using Logging.Frameworks.Serilog.Extensions;
using NLog;
using NLog.Web;
using Serilog;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings(string.Concat(Directory.GetCurrentDirectory(), ".NLog")).GetCurrentClassLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();


    builder.Services.UseElmahHandler();

    builder.UseNLogHandler(".NLog");

    builder.UseSeriLogHandler(".Serilog");

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    // Configure Serilog for logging
    app.UseSerilogRequestLogging();

    //Configure elmah for logging
    app.UseElmahIo();

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}


