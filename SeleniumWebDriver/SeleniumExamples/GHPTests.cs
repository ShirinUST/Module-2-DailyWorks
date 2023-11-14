using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumExamples
{
    internal class GHPTests
    {
        IWebDriver? driver;

        public void InitializeEdgeDriver()
        {
            driver = new EdgeDriver();
            driver.Url = "https://www.google.com";
        }
        public void InitializeChromeDriver()
        {
            driver = new ChromeDriver();
            driver.Url = "https://www.google.com";
        }
        public void TitleTest()
        {
            Thread.Sleep(2000);
            Console.WriteLine("Title "+driver.Title);
            Console.WriteLine("Title Length " + driver.Title.Length);
            Assert.AreEqual("Google", driver.Title);
            Console.WriteLine("Pass");
        }
        public void PageSourceTest()
        {
            //Console.WriteLine("PS : " + driver.PageSource);
            Console.WriteLine("PS Len : " + driver.PageSource.Length);
        }
        public void PageTestAndUrlTest()
        {
            
            Console.WriteLine("PS Len : " + driver.PageSource.Length);
            Console.WriteLine(driver.Url);
            Assert.AreEqual("https://www.google.com/", driver.Url);
            Console.WriteLine("PSURl Test - Passed");
        }
        public void GSTest()
        {
            IWebElement searchinputtextbox = driver.FindElement(By.Id("APjFqb"));
            searchinputtextbox.SendKeys("max fashions");
            Thread.Sleep(2000);
            IWebElement gsButton = driver.FindElement(By.ClassName("gNO89b"));  //Name("btnK"));
            gsButton.Click();
            Assert.AreEqual("max fashions - Google Search", driver.Title);
            Console.WriteLine("Google Search Test - Pass");
        }
        public void GmailLinkTest()
        {
            driver.Navigate().Back();
            driver.FindElement(By.LinkText("Gmail")).Click();
            Thread.Sleep(3000);
            // Assert.That(driver.Title.Contains("Gmail"));
            Assert.That(driver.Url.Contains("gmail"));
            //Assert.That(driver.Title.Contains("Images"));
            Console.WriteLine("Gmail test Passed!");

        }
        public void GImageLinkTest()
        {
            driver.Navigate().Back();
            //driver.FindElement(By.LinkText("Gmail")).Click();
            driver.FindElement(By.PartialLinkText("mag")).Click();
            Thread.Sleep(3000);
            // Assert.That(driver.Title.Contains("Gmail"));
            //Assert.That(driver.Url.Contains("gmail"));
            Assert.That(driver.Title.Contains("Images"));
            IWebElement searchinputtextbox = driver.FindElement(By.Id("APjFqb"));
            searchinputtextbox.SendKeys("BTS");
            IWebElement gsButton = driver.FindElement(By.ClassName("Tg7LZd"));
            gsButton.Click();
            Thread.Sleep(4000);
            Console.WriteLine("GImage test Passed!");

        }

        public void LocalizationTest()
        {
            driver.Navigate().Back();
            string location=driver.FindElement(By.XPath("/html/body/div[1]/div[6]/div[1]")).Text;
            Thread.Sleep(3000);
            // Assert.That(driver.Title.Contains("Gmail"));
            Assert.That(location.Equals("India"));
            //Assert.That(driver.Title.Contains("Images"));
            Console.WriteLine("localization test Passed!");

        }
        public void Destruct()
        {
            driver.Close();
        }
    }
}
