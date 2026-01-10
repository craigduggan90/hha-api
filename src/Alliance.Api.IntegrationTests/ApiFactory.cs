using Microsoft.AspNetCore.Mvc.Testing;

namespace Alliance.Api.IntegrationTests;

public class ApiWebApplicationFactory : WebApplicationFactory<Program>
{
    // If we had a data layer or external dependency to replace with a mock/stub, we'd add an override for
    // ConfigureWebHost here.
}