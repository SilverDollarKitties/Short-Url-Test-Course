using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace ShortUrl_DesktopTests
{
    public class DesktopTests
    {
        private const string AppiumUrl = "http://127.0.0.1:4723/wd/hub";
        private const string ShortUrl = "https://shorturl.nakov.repl.co/api";
        private const string appLocation = @"C:\shorturlDesktop\ShortURL-DesktopClient.exe";


        private WindowsDriver<WindowsElement> driver;
        private AppiumOptions options;

        [SetUp]
        public void StartApp()
        {
            options = new AppiumOptions() { PlatformName = "Windows" };
            options.AddAdditionalCapability("app", appLocation);

            driver = new WindowsDriver<WindowsElement>(new Uri(AppiumUrl), options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [TearDown]
        public void CloseApp()
        {
            driver.Quit();
        }

        [Test]
        public void Test_StartApp_FindResult()
        {
            var urlField = driver.FindElementByAccessibilityId("textBoxApiUrl");
            urlField.Clear();
            urlField.SendKeys("https://shorturl.nakov.repl.co/api");

            var buttonConnect = driver.FindElementByAccessibilityId("buttonConnect");
            buttonConnect.Click();

            Thread.Sleep(5000);

            string windowsName = driver.WindowHandles[0];
            driver.SwitchTo().Window(windowsName);

            var title = driver.FindElement(By.Name("https://selenium.dev"));
            Assert.That(title.Text, Is.EqualTo("https://selenium.dev"));
        }

        [Test]
        public void Test_CreateAndFindNewURL()
        {
            var urlField = driver.FindElementByAccessibilityId("textBoxApiUrl");
            urlField.Clear();
            urlField.SendKeys("https://shorturl.nakov.repl.co/api");

            var buttonConnect = driver.FindElementByAccessibilityId("buttonConnect");
            buttonConnect.Click();

            string windowsName = driver.WindowHandles[0];
            driver.SwitchTo().Window(windowsName);

            var buttonAdd = driver.FindElementByAccessibilityId("buttonAdd");
            buttonAdd.Click();

            var urlbutton = driver.FindElementByAccessibilityId("textBoxURL");
            urlbutton.SendKeys("https://www.youtube.com");

            var createbutton = driver.FindElementByAccessibilityId("buttonCreate");
            createbutton.Click();

            var urltitle = driver.FindElement(By.Name("https://www.youtube.com")).Text;
                Assert.That(urltitle, Is.EqualTo("https://www.youtube.com"));


        }
    }
}