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
        IWebDriver driver;

        [SetUp]
        public void StartDriver()
        {
            driver = new ChromeDriver();
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
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

        //[Test]
        //public void YourTurn()
        //{
        //    //Create your own demonstration of a visual check
        //}
    }
}