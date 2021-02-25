using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Challenge_2
{
    //    Welcome to UI Automation Challenge 2
    //
    //    For this challenge it's all about creating clean, readable and maintainable code. Below
    //    are five tests that work (just about) but require cleaning up. Update this code base
    //    so that it's easier to maintain, more readable, and has sensible ways of asserting
    //    data. You might want to research different approaches to improving UI automation such as
    //    Page Object Models and implicit vs. explicit waits, as well as NUnit features that can make things
    //    easier to maintain

    public class Challenge2Tests
    {
        IWebDriver driver;
        AdminPage adminPage;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }

        //  Test one: Check to see if you can log in with valid credentials
        //Test one: Refactored
        [Test]
        public void VerifyLoginWithValidCredentialsDisplaysLogoutLink()
        {
            driver.Url = "https://automationintesting.online/#/admin";
            adminPage = new AdminPage(driver);
            adminPage.LoginToAdminPage("admin", "password");

            Assert.IsTrue(adminPage.IsLogoutLinkDisplayed());
        }

        //[Test] //Test one: Original
        //public void VerifyCanLoginWithValidCredentials()
        //{
        //    IWebDriver driver;
        //    driver = new ChromeDriver();
        //    driver.Url = "https://automationintesting.online/#/admin";
        //    driver.FindElement(By.CssSelector("footer p a:nth-child(5)")).Click();
        //    Thread.Sleep(1000);
        //    driver.FindElement(By.XPath("//div[@class=\"form-group\"][1]/input")).SendKeys("admin");
        //    Thread.Sleep(1000);
        //    driver.FindElement(By.XPath("//div[@class=\"form-group\"][2]/input")).SendKeys("password");
        //    Thread.Sleep(1000);
        //    driver.FindElement(By.ClassName("float-right")).Click();

        //    Thread.Sleep(5000);

        //    IWebElement webElement = driver.FindElement(By.ClassName("navbar-collapse"));
        //    Console.WriteLine(webElement.Text);
        //    Boolean title = webElement.Text.Contains("Rooms");

        //    Assert.IsTrue(title);
        //    driver.Close();
        //}

        //  Test two: Check to see if rooms are saved and displayed in the UI
        [Test]
        public void VerifyRoomsAreSavedAndDisplayedInUI()
        {
            IWebDriver driver;
            driver = new ChromeDriver();
            driver.Url = "https://automationintesting.online/#/admin";
            driver.FindElement(By.CssSelector("footer p a:nth-child(5)")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//div[@class=\"form-group\"][1]/input")).SendKeys("admin");
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//div[@class=\"form-group\"][2]/input")).SendKeys("password");
            Thread.Sleep(1000);
            driver.FindElement(By.ClassName("float-right")).Click();

            Thread.Sleep(2000);

            driver.FindElement(By.CssSelector(".room-form > div:nth-child(1) input")).SendKeys("101");
            driver.FindElement(By.CssSelector(".room-form > div:nth-child(4) input")).SendKeys("101");
            Thread.Sleep(1000);
            driver.FindElement(By.ClassName("btn-outline-primary")).Click();

            Thread.Sleep(5000);

            Assert.That(driver.FindElements(By.ClassName(".detail")).Count != 1);
            driver.Close();
        }


        //  Test three: Check to see the confirm message appears when branding is updated
        [Test]
        public void VerifyConfirmMessageAppearsWhenBrandingIsUpdated()
        {
            IWebDriver driver;
            driver = new ChromeDriver();
            driver.Url = "https://automationintesting.online/#/admin";
            driver.FindElement(By.CssSelector("footer p a:nth-child(5)")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//div[@class=\"form-group\"][1]/input")).SendKeys("admin");
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//div[@class=\"form-group\"][2]/input")).SendKeys("password");
            Thread.Sleep(1000);
            driver.FindElement(By.ClassName("float-right")).Click();

            driver.Url = "https://automationintesting.online/#/admin/branding";

            Thread.Sleep(5000);

            driver.FindElement(By.ClassName("form-control")).SendKeys("Test");
            driver.FindElement(By.ClassName("btn-outline-primary")).Click();

            Thread.Sleep(1001);

            int count = driver.FindElements(By.XPath("//button[text()=\"Close\"]")).Count;

            if (count == 1)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
            driver.Close();
        }

        //  Test four: Check to see if the contact form shows a success message
        [Test]
        public void VerifyContactFormShowsSuccessMessage()
        {
            IWebDriver driver;
            driver = new ChromeDriver();
            driver.Url = "https://automationintesting.online/";
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector("input[placeholder=Name]")).SendKeys("TEST123");
            driver.FindElement(By.CssSelector("input[placeholder=Email]")).SendKeys("TEST123@TEST.COM");
            driver.FindElement(By.CssSelector("input[placeholder=Phone]")).SendKeys("01212121311");
            driver.FindElement(By.CssSelector("input[placeholder=Subject]")).SendKeys("TEsTEST");
            driver.FindElement(By.CssSelector("textarea")).SendKeys("TEsTESTTEsTESTTEsTEST");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//button[text()=\"Submit\"]")).Click();

            Thread.Sleep(4000);
            Assert.True(driver.FindElement(By.CssSelector(".contact")).Text.Contains("Thanks for getting in touch"));
            driver.Close();
        }

        //  Test five: Check to see if unread messages are bolded
        [Test]
        public void VerifyUnreadMessagesAreBolded()
        {
            IWebDriver driver;
            driver = new ChromeDriver();
            driver.Url = "https://automationintesting.online/#/admin/messages";
            
            driver.FindElement(By.XPath("//div[@class=\"form-group\"][1]/input")).SendKeys("admin");
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//div[@class=\"form-group\"][2]/input")).SendKeys("password");
            Thread.Sleep(1000);
            driver.FindElement(By.ClassName("float-right")).Click();

            Thread.Sleep(3000);
            Assert.True(CheckCount(driver.FindElements(By.CssSelector(".read-false"))));
            driver.Close();
        }

        private bool CheckCount(IReadOnlyCollection<IWebElement> elements)
        {
            if (elements.Count >= 1)
            {
                return true;
            }

            return false;
        }
    }
}