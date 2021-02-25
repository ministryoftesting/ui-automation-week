using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Challenge_5
{
    public class DriverFactory
    {
        public DriverFactory()
        {

        }

        private IWebDriver CreateChromeDriver()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            return new ChromeDriver();
        }

        private IWebDriver CreateFirefoxDriver()
        {
            new DriverManager().SetUpDriver(new FirefoxConfig());
            return new FirefoxDriver();
        }

        public IWebDriver GetWebDriver(BrowserType type)
        {
            IWebDriver driver = null;

            switch (type)
            {
                case BrowserType.Chrome:
                    driver = CreateChromeDriver();
                    break;
                case BrowserType.Firefox:
                    driver = CreateFirefoxDriver();
                    break;
                default:
                    break;
            }
            return driver;
        }
        
        public enum BrowserType
        {
            Chrome,
            Firefox
        }

    }
}
