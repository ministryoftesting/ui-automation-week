using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace Challenge_1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void VerifyLoginWithValidCredentialsDisplaysCreateButton()
        {
            //navigate to https://automationintesting.online/#/admin
            IWebDriver driver;
            driver = new ChromeDriver();
            driver.Url = "https://automationintesting.online/#/admin";

            //fill in username/password fields
            driver.FindElement(By.Id("username")).SendKeys("admin");
            driver.FindElement(By.Id("password")).SendKeys("password");

            //click sign in
            driver.FindElement(By.Id("doLogin")).Click();
            Thread.Sleep(3000);

            //assert that the Create button appears
            Assert.True(driver.FindElement(By.Id("createRoom")).Displayed);
            driver.Close();
        }
    }
}