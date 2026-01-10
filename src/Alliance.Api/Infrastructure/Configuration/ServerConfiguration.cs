namespace Alliance.Api.Infrastructure.Configuration;

public class ServerConfiguration
{
    public int Port { get; init; } = 9001;

    public string LogFilePath { get; init; } = "../../.logs/redact-api.log";
}