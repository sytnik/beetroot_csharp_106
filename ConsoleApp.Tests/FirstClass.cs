namespace ConsoleApp.Tests;

public class FirstClass
{
    public FirstClass()
    {
    }
    
    [Fact]
    public async Task SimpleTest()
    {
        var dtos = await Program.PrintCatFacts();
        Assert.NotEmpty(dtos);
    }


}