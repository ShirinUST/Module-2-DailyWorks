using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2_14_11_2023
{
    internal class NavigationTest
    {
        IWebDriver? driver;
        public void Initilaization()
        {
            driver = new ChromeDriver();
            driver.Url = "https://www.google.com/";
        }
        public void NavigateToYahooTest()
        {
            driver.Navigate().GoToUrl("https://www.yahoo.com/");
            Thread.Sleep(2000);
            Console.WriteLine("Navigate To Yahoo - Passed");
        }
        public void NavigateToGoogleTest()
        {
            driver.Navigate().Back();
            Thread.Sleep(1000);
            Console.WriteLine("Back To Google - Passed");
        }
        public void SearchTest()
        {
            IWebElement searchElement = driver.FindElement(By.Id("APjFqb"));
            searchElement.SendKeys("what's new for Diwali 2023?");
            Thread.Sleep(2000);
            IWebElement button = driver.FindElement(By.Name("btnK"));
            button.Click();
            Thread.Sleep(2000);
            Assert.AreEqual("what's new for Diwali 2023? - Google Search", driver.Title);
            Console.WriteLine("Search Text test passed");
        }
        public void RefreshTest()
        {
            driver.Navigate().Refresh();
            Console.WriteLine("Refresh test passed");
        }
        public void Destruct()
        {
            driver.Close();
            Console.WriteLine("Browser Closed Successfully");
        }

    }
}
