using Challenge_2.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Challenge_2
{
    public class AdminPage : BasePage
    {
        private IWebElement usernameField
        {
            get { return Driver.FindElement(By.Id("username")); }
        }

        private IWebElement passwordField
        {
            get { return Driver.FindElement(By.Id("password")); }
        }

        private IWebElement loginButton
        {
            get { return Driver.FindElement(By.Id("doLogin")); }
        }

        private IWebElement navbar
        {
            get { return Driver.FindElement(By.CssSelector(".navbar")); }
        }

        private IWebElement roomsLink
        {
            get { return Driver.FindElement(By.LinkText("Rooms")); }
        }

        private IWebElement logoutLink
        {
            get { return Driver.FindElement(By.LinkText("Logout")); }
        }

        private IWebElement createButton
        {
            get { return Driver.FindElement(By.Id("createRoom")); }
        }

        public AdminPage(IWebDriver driver) : base(driver)
        {
        }

        public void LoginToAdminPage(string username, string password)
        {
            usernameField.SendKeys(username);
            passwordField.SendKeys(password);
            loginButton.Click();
        }


        public bool IsLogoutLinkDisplayed()
        {
            return logoutLink.Displayed;
        }

    }
}
