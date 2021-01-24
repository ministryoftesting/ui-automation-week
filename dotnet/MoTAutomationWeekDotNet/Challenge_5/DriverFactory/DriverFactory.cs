using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Challenge_5
{
    public class DriverFactory
    {
        public DriverFactory()
        {

        }

        public IWebDriver Create()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            return new ChromeDriver();
        }
    }
}
