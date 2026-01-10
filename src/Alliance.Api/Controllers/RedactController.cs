using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Alliance.Api.Controllers;

[ApiController]
[Route("redact")]
public class RedactController : ControllerBase
{
    [HttpGet]
    [Produces("text/plain")]
    public IActionResult GetServiceName()
        => Ok("Redaction Service");

    [HttpPost]
    [Consumes(MediaTypeNames.Text.Plain)]
    [Produces("text/plain")]
    public IActionResult RedactTest([FromBody] string input)
        => Ok($"REDACTED: {input}");
}