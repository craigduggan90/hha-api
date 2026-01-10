using Alliance.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Alliance.Api.Controllers;

[ApiController]
[Route("redact")]
public class RedactController(IRedactionService redactions) : ControllerBase
{
    [HttpGet]
    [Produces("text/plain")]
    public IActionResult GetServiceName()
        => Ok("Redaction Service");

    [HttpPost]
    [Consumes(MediaTypeNames.Text.Plain)]
    [Produces("text/plain")]
    public IActionResult RedactText([FromBody] string input)
        => Ok(redactions.Redact(input));
}