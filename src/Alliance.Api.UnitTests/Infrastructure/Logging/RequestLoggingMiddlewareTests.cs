using Alliance.Api.Infrastructure.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Testing;
using System.Text;

namespace Alliance.Api.UnitTests.Infrastructure.Logging;

public static class RequestLoggingMiddlewareTests
{
    public class InvokeAsync
    {
        private FakeLogger<RequestLoggingMiddleware> _logger = new();

        [Fact]
        public async Task ShouldLogPostEvents_WithPayload()
        {
            const string message = "A dog, a monkey or a dolphin are all mammals. A snake, however, is not a mammal, " +
                                    "it is a reptile. Who can say what a DogSnake is?";
            using var host = await CreateSut();
            await host.GetTestClient().SendAsync(new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                Content = new StringContent(message, Encoding.UTF8)
            });

            Assert.Equal(message, _logger.LatestRecord.Message);
        }
        
        [Fact]
        public async Task ShouldLogPostEvents_WithEmptyPayload()
        {
            using var host = await CreateSut();
            await host.GetTestClient().SendAsync(new HttpRequestMessage
            {
                Method = HttpMethod.Post,
            });

            Assert.Equal(string.Empty, _logger.LatestRecord.Message);
        }
        
        [Fact]
        public async Task ShouldNotLog_GetEvents()
        {
            using var host = await CreateSut();
            await host.GetTestClient().SendAsync(new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                Content = new StringContent("shouldn't be here", Encoding.UTF8)
            });

            Assert.Equal(0, _logger.Collector.Count);
        }

        private Task<IHost> CreateSut()
        {
            return new HostBuilder()
                .ConfigureWebHost(webBuilder =>
                {
                    webBuilder
                        .UseTestServer()
                        .ConfigureServices(services =>
                        {
                            services.AddSingleton<ILogger<RequestLoggingMiddleware>>(_logger);
                        })
                        .Configure(app =>
                        {
                            app.UseMiddleware<RequestLoggingMiddleware>();
                        });
                })
                .StartAsync();
        }
    }
}