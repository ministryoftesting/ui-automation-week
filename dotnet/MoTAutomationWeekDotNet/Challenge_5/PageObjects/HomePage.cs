using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Challenge_5.PageObjects
{
    public class HomePage : BasePage
    {

        private IWebElement imgHotelLogo
        {
            get { return Driver.FindElement(By.CssSelector(".hotel-logoUrl")); }
        }

        public HomePage(IWebDriver driver) : base(driver)
        {
            
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver =>
            {
                return driver.FindElement(By.CssSelector(".openBooking")).Displayed;
            });
        }

        public IWebElement GetHotelLogo()
        {
            return imgHotelLogo;
        }
    }
}
