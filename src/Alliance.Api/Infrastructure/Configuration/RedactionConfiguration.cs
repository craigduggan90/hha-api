namespace Alliance.Api.Infrastructure.Configuration;

public class RedactionConfiguration
{
    public string Notice = "REDACTED"; 
        
    public IEnumerable<string> Keywords { get; init; } = [];
}