using Challenge_5.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Challenge_5
{
    public class Challenge5Tests
    {
        //    Welcome to UI Automation Challenge 5
        //
        //    For this challenge we're thinking about how we create the
        //    necessary code to run our test across different browsers
        //    easily and with minimal manual intervention. Update the
        //    browser factory so that it can support the running of the
        //    test across multiple browsers

        IWebDriver driver;

        [SetUp]
        public void BuildDriver()
        {
            DriverFactory driverFactory = new DriverFactory();
            driver = driverFactory.Create();
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }

        [Test]
        public void CheckTheHomePageData()
        {
            driver.Url = "https://automationintesting.online/";
            HomePage homePage = new HomePage(driver);

            string imgUrl = homePage.GetHotelLogo().GetAttribute("src");
            Assert.AreEqual("https://www.mwtestconsultancy.co.uk/img/rbp-logo.png", imgUrl);
        }
    }
}