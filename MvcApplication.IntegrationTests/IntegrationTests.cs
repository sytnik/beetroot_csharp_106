using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;

namespace MvcApplication.IntegrationTests;

public class IntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public IntegrationTests(WebApplicationFactory<Program> factory) => _factory = factory;
    
    // check index for anonymous user
    [Theory]
    [InlineData("/")]
    [InlineData("/home/index")]
    public async Task GetPageAllowAnonymous(string url)
    {
        // arrange
        var client = _factory
            .CreateClient(new WebApplicationFactoryClientOptions {AllowAutoRedirect = false});
        // act
        var response = await client.GetAsync(url);
        // assert
        response.EnsureSuccessStatusCode();
        var contentType = "text/html; charset=utf-8";
        Assert.Equal(contentType,
            response.Content.Headers.ContentType?.ToString());
    }
    
    [Theory]
    [InlineData("/home/privacy")]
    [InlineData("/home/userprofile")]
    public async Task GetRedirectWithNoAuth(string url)
    {
        // arrange
        var client = _factory
            .CreateClient(new WebApplicationFactoryClientOptions {AllowAutoRedirect = false});
        // act
        var response = await client.GetAsync(url);
        // assert
        Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
        var loginPath = "/Home/Login";
        Assert.Contains(loginPath, response.Headers.Location?.OriginalString);
    }
}