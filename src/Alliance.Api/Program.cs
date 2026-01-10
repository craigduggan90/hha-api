using Alliance.Api.Infrastructure;
using Alliance.Api.Infrastructure.Logging;
using Alliance.Api.Infrastructure.MediaTypes;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureServer();

builder.Services.AddControllers(options => options.InputFormatters.Add(new PlainTextFormatter()));

var app = builder.Build();

app.UseMiddleware<RequestLoggingMiddleware>();
app.MapControllers();

app.Run();
