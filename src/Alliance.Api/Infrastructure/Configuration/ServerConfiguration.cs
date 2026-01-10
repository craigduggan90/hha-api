namespace Alliance.Api.Infrastructure.Configuration;

public class ServerConfiguration
{
    public int Port { get; init; } = 8080;

    public string LogFilePath { get; init; } = "../../.logs/redact-api.log";
}