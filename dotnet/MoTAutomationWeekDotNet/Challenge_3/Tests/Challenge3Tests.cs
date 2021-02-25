using Applitools;
using Applitools.Selenium;
using Challenge_3.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Challenge_3
{
    //    Welcome to UI Automation Challenge 3
    //
    //    For this challenge the focus is improving the assertion for an existing
    //    UI automation test. Rather than asserting on the DOM's state, update the
    //    the test below to do a visual check of the page. Once you've completed
    //    the sample check, create your own example check.

    public class Challenge3Tests
    {
        private IWebDriver driver;
        private EyesRunner runner;
        private Eyes eyes;

        [SetUp]
        public void StartDriver()
        {
            driver = new ChromeDriver();
            runner = new ClassicRunner();
            eyes = new Eyes(runner);
            eyes.ApiKey = "put_your_api_key_here";
            eyes.ServerUrl = "https://eyesapi.applitools.com";
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
            eyes.AbortIfNotClosed();
            TestResultsSummary allTestResults = runner.GetAllTestResults();
        }

        [Test]
        public void CheckHomePageData()
        {
            driver.Url = "https://automationintesting.online/";
            HomePage homePage = new HomePage(driver);

            string imgUrl = homePage.GetHotelLogo().GetAttribute("src");
            Assert.AreEqual("https://www.mwtestconsultancy.co.uk/img/rbp-logo.png", imgUrl);

            int roomImageCount = homePage.GetRoomImageCount();
            Assert.AreEqual(1, roomImageCount);

            int mapCounts = homePage.GetMapImageCount();
            Assert.AreEqual(16, mapCounts);
        }

        [Test]
        public void CheckHomePageDataWithApplitools()
        {
            eyes.Open(driver, "UI Week dotnet", "CheckHomePageDataWithApplitools", new System.Drawing.Size(800, 600));

            driver.Url = "https://automationintesting.online/";
            HomePage homePage = new HomePage(driver);

            eyes.CheckWindow("home page");

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", homePage.GetHotelLogo());
            //string imgUrl = homePage.GetHotelLogo().GetAttribute("src");
            //Assert.AreEqual("https://www.mwtestconsultancy.co.uk/img/rbp-logo.png", imgUrl);
            eyes.CheckWindow("After GetHotelLogo");

            //int roomImageCount = homePage.GetRoomImageCount();
            //Assert.AreEqual(1, roomImageCount);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", homePage.GetFirstRoomInfo());
            eyes.CheckWindow("After GetFirstRoomInfo");

            //int mapCounts = homePage.GetMapImageCount();
            //Assert.AreEqual(16, mapCounts);
            eyes.Close();
        }
    }
}