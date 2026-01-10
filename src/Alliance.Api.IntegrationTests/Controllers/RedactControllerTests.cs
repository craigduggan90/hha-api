using System.Net;
using System.Text;

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

    public class RedactText
    {
        [Fact]
        public async Task ShouldReturnServiceName_WhenCalled()
        {
            const string input = "A dog, a monkey or a dolphin are all mammals. A snake, however, is not a mammal, it " +
                                 "is a reptile. Who can say what a DogSnake is?";

            const string expected = "A REDACTED, a monkey or a REDACTED are all mammals. A REDACTED, however, is not a " +
                                    "REDACTED, it is a reptile. Who can say what a DogSnake is?";
            
            const HttpStatusCode expectedStatusCode = HttpStatusCode.OK;
            
            await using var factory = new ApiWebApplicationFactory();
            using var client = factory.CreateClient();

            var response = await client.PostAsync(
                BaseUrl,
                new StringContent(input, Encoding.UTF8),
                TestContext.Current.CancellationToken);
            
            Assert.Equal(expectedStatusCode, response.StatusCode);

            var actual = await response.Content.ReadAsStringAsync(TestContext.Current.CancellationToken);
            Assert.Equal(expected, actual);
        }
    }
}