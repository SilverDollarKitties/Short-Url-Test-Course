using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ShortUrl_WebDriverTests
{
    public class Tests
    {
        private const string url = "https://shorturl.nakov.repl.co/urls";
        private WebDriver driver;

        [SetUp]
        public void OpenBrowser()
        {
            this.driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [TearDown]
        public void CloseBrowser()
        {
            this.driver.Quit();
        }

        [Test]
        public void Test1()
        {
            driver.Navigate().GoToUrl(url);

            var table = driver.FindElement(By.CssSelector("body > main > table > tbody > tr:nth-child(1) > td:nth-child(1)"));
            Assert.IsNotNull(table);
        }

        [Test]
        public void Test_CreateNewUrl_ValidData()
        {
            driver.Navigate().GoToUrl("https://shorturl.nakov.repl.co/");
            driver.FindElement(By.LinkText("Short URLs")).Click();
            driver.FindElement(By.LinkText("Add URL")).Click();
            driver.FindElement(By.Id("url")).Click();
            driver.FindElement(By.Id("url")).SendKeys("https://softuni.bg");
            driver.FindElement(By.CssSelector("button")).Click();
            driver.FindElement(By.CssSelector("body > main > table > tbody > tr:nth-child(58) > td:nth-child(2)"));
            Assert.IsNotNull("body > main > table > tbody > tr:nth-child(58) > td:nth-child(2)");

        }

        [Test]
        public void Test_CreateNewUrl_InvalidData()
        {
            driver.Navigate().GoToUrl("https://shorturl.nakov.repl.co/"); 
            driver.FindElement(By.LinkText("Add URL")).Click();
            driver.FindElement(By.Id("url")).Click();
            driver.FindElement(By.Id("url")).SendKeys("123123");
            driver.FindElement(By.CssSelector("button")).Click();
            driver.FindElement(By.CssSelector(".err")).Click();
        }

        [Test]
        public void Test_InvalidURL()
        {
            driver.Navigate().GoToUrl("https://shorturl.nakov.repl.co/go/123123");
            driver.FindElement(By.CssSelector("body > div"));
        }
        [Test]
        public void Test_VistorCountIncreases()
        {
            driver.Navigate().GoToUrl("https://shorturl.nakov.repl.co/");
            driver.FindElement(By.LinkText("Short URLs")).Click();
            driver.FindElement(By.LinkText("http://shorturl.nakov.repl.co/go/nak")).Click();
            Thread.Sleep(5000);
            driver.Navigate().GoToUrl("https://shorturl.nakov.repl.co/urls");
            driver.FindElement(By.CssSelector("th:nth-child(3)")).Click();
               

        }


    }
}