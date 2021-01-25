using OpenQA.Selenium;

namespace Challenge_3.PageObjects
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
