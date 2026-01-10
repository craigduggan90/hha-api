using System.Globalization;
using System.Text;

namespace Alliance.Api.Infrastructure.Logging;

public class RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        var request = context.Request;
        
        if(request.Method == HttpMethods.Post)
            logger.LogInformation(await GetRequestContent(request));

        await next(context);
    }

    private static async Task<string> GetRequestContent(HttpRequest request)
    {
        request.EnableBuffering();
        
        if (!(request.ContentLength > 0)) 
            return string.Empty;
        
        var buffer = new byte[Convert.ToInt32(request.ContentLength, CultureInfo.InvariantCulture)];
        await request.Body.ReadExactlyAsync(buffer, 0, buffer.Length);
            
        var requestContent = Encoding.UTF8.GetString(buffer);
        request.Body.Position = 0;
        return requestContent;
    }
}