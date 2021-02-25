using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace Challenge_3.PageObjects
{
    public class HomePage : BasePage
    {

        private IWebElement imgHotelLogo
        {
            get { return Driver.FindElement(By.CssSelector(".hotel-logoUrl")); }
        }

        private IReadOnlyCollection<IWebElement> imgRooms
        {
            get { return Driver.FindElements(By.CssSelector(".hotel-img")); }
        }

        private IWebElement hotelRoomInfoFirstDiv
        {
            get
            {
                var elems = Driver.FindElements(By.CssSelector(".hotel-room-info"));
                return elems[0];
            }
        }

        private IReadOnlyCollection<IWebElement> imgMaps
        {
            get { return Driver.FindElements(By.CssSelector(".map img")); }
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

        public int GetRoomImageCount()
        {
            return imgRooms.Count;
        }

        public int GetMapImageCount()
        {
            return imgMaps.Count;
        }

        public IWebElement GetFirstRoomInfo()
        {
            return hotelRoomInfoFirstDiv;
        }
    }
}
