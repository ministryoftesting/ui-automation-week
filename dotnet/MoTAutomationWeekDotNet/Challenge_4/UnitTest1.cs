using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;

namespace Challenge_4
{
    public class Tests
    {
        protected const string WinAppDriverUrl = "http://127.0.0.1:4723";
        private const string NotepadAppId = @"C:\Windows\System32\notepad.exe";

        protected static WindowsDriver<WindowsElement> session;

        [SetUp]
        public void Setup()
        {
            var appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability("app", NotepadAppId);
            session = new WindowsDriver<WindowsElement>(new Uri(WinAppDriverUrl), appiumOptions);
        }

        [TearDown]
        public void TearDown()
        {
            session.Close();
            try
            {
                session.FindElementByName("Don't Save").Click();
            }
            catch { }
            session.Quit();
        }

        [Test]
        public void Test1()
        {
            var testText = "abcdefABCDEF 12345";
            WindowsElement editBox;
            editBox = session.FindElementByClassName("Edit");
            editBox.SendKeys(testText);
            Assert.AreEqual(testText, editBox.Text);
            
        }
    }
}