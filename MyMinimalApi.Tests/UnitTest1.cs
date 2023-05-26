using Microsoft.AspNetCore.Mvc.Testing;

namespace MyMinimalApi.Tests;

public class UnitTest1
{
    [Fact]
    public async Task TestRootEndpoint()
    {
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();

        var response = await client.GetStringAsync("/");

        Assert.Equal("Hello World!", response);
    }
}