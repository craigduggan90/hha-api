using System.Net;

namespace Alliance.Api.IntegrationTests.Controllers;

public static class RedactControllerTests
{
    private const string BaseUrl = "redact";
    
    public class GetServiceName
    {
        [Fact]
        public async Task ShouldReturnServiceName_WhenCalled()
        {
            const HttpStatusCode expectedStatusCode = HttpStatusCode.OK;
            const string expectedContent = "Redaction Service";
            
            await using var factory = new ApiWebApplicationFactory();
            using var client = factory.CreateClient();

            var response = await client.GetAsync(BaseUrl, TestContext.Current.CancellationToken);
            Assert.Equal(expectedStatusCode, response.StatusCode);

            var actual = await response.Content.ReadAsStringAsync(TestContext.Current.CancellationToken);
            Assert.Equal(expectedContent, actual);
        }
    }
}