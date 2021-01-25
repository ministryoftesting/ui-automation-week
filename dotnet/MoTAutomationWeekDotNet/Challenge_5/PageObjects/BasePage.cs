using OpenQA.Selenium;

namespace Challenge_5.PageObjects
{
    public class BasePage
    {
        public IWebDriver Driver { get; set; }
        public BasePage(IWebDriver driver)
        {
            Driver = driver;   
        }
    }
}
