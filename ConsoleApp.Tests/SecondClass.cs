namespace ConsoleApp.Tests;

public class SecondClass
{
    [Theory]
    [InlineData("https://cat-fact.herokuapp.com/facts", true)]
    [InlineData("https://cat-fact.herokuapp.com/facts1", false)]
    public async Task ParamsTest(string url, bool isSuccess)
    {
        var result = await Program.GetResource(url);
        Assert.DoesNotContain(result, "Error");
        // Assert.Equal(isSuccess, result.IsCompletedSuccessfully);
        // var content = await result;
    }
}