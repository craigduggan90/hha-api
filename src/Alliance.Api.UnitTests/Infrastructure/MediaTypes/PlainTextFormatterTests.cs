using Alliance.Api.Infrastructure.MediaTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text;

namespace Alliance.Api.UnitTests.Infrastructure.MediaTypes;

public static class PlainTextFormatterTests
{
    public class ReadRequestBodyAsync
    {
        [Fact]
        public async Task ShouldReturnPlainText_ForPlainTextRequestBody()
        {
            const string content = "content";
            var input = new InputFormatterContext(
                new DefaultHttpContext { Request = { Body = new MemoryStream(Encoding.UTF8.GetBytes(content)) } },
                "anything",
                new ModelStateDictionary(),
                new EmptyModelMetadataProvider().GetMetadataForType(typeof(object)),
                (stream, encoding) => new StreamReader(stream, encoding));

            var sut = new PlainTextFormatter();
            var actual = await sut.ReadRequestBodyAsync(input);
            Assert.Equal(content, actual.Model);
        }
    }
}