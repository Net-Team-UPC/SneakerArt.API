﻿using System.Net;
using System.Net.Mime;
using System.Text;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using SneakerArt.API.Collection.Resources;
using SpecFlow.Internal.Json;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace SneakerArt.API.Tests.Steps;

[Binding]
public class ShoesServiceStepDefinitions : WebApplicationFactory<Program>
{
    private readonly WebApplicationFactory<Program> _factory;

    public ShoesServiceStepDefinitions(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }
    
    private HttpClient Client { get; set; }
    private Uri BaseUri { get; set; }
    
    private Task<HttpResponseMessage> Response { get; set; }

    [Given(@"the Endpoint https://localhost:(.*)/api/v(.*)/shoes is available")]
    public void GivenTheEndpointHttpsLocalhostApiVShoesIsAvailable(int port, int version)
    {
        BaseUri = new Uri($"https://localhost:{port}/api/v{version}/shoes");
        Client = _factory.CreateClient(new WebApplicationFactoryClientOptions { BaseAddress = BaseUri });
        
    }

    [When(@"a Post Request is sent")]
    public void WhenAPostRequestIsSent(Table saveShoeResource)
    {
        var resource = saveShoeResource.CreateSet<SaveShoeResource>().First();
        var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
        Response = Client.PostAsync(BaseUri, content);
    }

    [Then(@"A Response is Received with Status (.*)")]
    public void ThenAResponseIsReceivedWithStatus(int expectedStatus)
    {
        var expectedStatusCode = ((HttpStatusCode)expectedStatus).ToString();
        var actualStatusCode = Response.Result.StatusCode.ToString();
        Assert.Equal(expectedStatusCode, actualStatusCode);
    }

    [Then(@"a Shoe Resource is included in Response Body")]
    public async void ThenAShoeResourceIsIncludedInResponseBody(Table expectedShoeResource)
    {
        var expectedResource = expectedShoeResource.CreateSet<ShoeResource>().First();
        var responseData = await Response.Result.Content.ReadAsStringAsync();
        var resource = JsonConvert.DeserializeObject<ShoeResource>(responseData);
        Assert.Equal(expectedResource.Name, resource.Name);
    }
}