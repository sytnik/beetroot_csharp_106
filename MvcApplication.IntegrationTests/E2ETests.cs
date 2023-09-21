using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;

namespace MvcApplication.IntegrationTests
{
    public class HomeControllerE2ETests : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly Process _appProcess;

        public HomeControllerE2ETests()
        {
            _appProcess = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "dotnet",
                    Arguments = "run --project ../../../../MvcApplication/MvcApplication.csproj",
                    UseShellExecute = true,
                    CreateNoWindow = false,
                }
            };
            _appProcess.Start();
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            _driver.Manage().Window.Maximize();
            _driver.Url = "https://localhost:5001/";
        }

        [Fact]
        public void IndexPage_LoadsCorrectly()
        {
            var element = _driver.FindElement(By.Id("textBlock"));
            Assert.NotNull(element);
        }
        
        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
            _appProcess.Kill();
            _appProcess.Dispose();
        }
    }
}