namespace SneakerArt.API.Tests.Steps;

[Binding]
public class ShoesServiceStepDefinitions
{
    [Given(@"the Endpoint https://localhost:(.*)/api/v(.*)/shoes is available")]
    public void GivenTheEndpointHttpsLocalhostApiVShoesIsAvailable(int port, int version)
    {
        ScenarioContext.StepIsPending();
    }

    [When(@"a Post Request is sent")]
    public void WhenAPostRequestIsSent(Table table)
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"A Response is Received with Status (.*)")]
    public void ThenAResponseIsReceivedWithStatus(int p0)
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"a Shoe Resource is included in Response Body")]
    public void ThenAShoeResourceIsIncludedInResponseBody(Table table)
    {
        ScenarioContext.StepIsPending();
    }
}