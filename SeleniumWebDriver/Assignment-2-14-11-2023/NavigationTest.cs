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
            driver = new ChromeDriver();  //setting the browser to be Chrome
            driver.Url = "https://www.google.com/";   //giving url as google.com.It will open this
        }
        public void NavigateToYahooTest()
        {
            driver.Navigate().GoToUrl("https://www.yahoo.com/");//It will navigate to yahoo
            Thread.Sleep(2000);
            Console.WriteLine("Navigate To Yahoo - Passed");
        }
        public void NavigateToGoogleTest()
        {
            driver.Navigate().Back();//navigate back to google
            Thread.Sleep(1000);
            Console.WriteLine("Back To Google - Passed");
        }
        public void SearchTest()
        {
            IWebElement searchElement = driver.FindElement(By.Id("APjFqb"));//getting web element by Id
            searchElement.SendKeys("what's new for Diwali 2023?");// search text as the given text
            Thread.Sleep(2000);
            IWebElement button = driver.FindElement(By.Name("btnK"));//getting the button to search
            button.Click();//click operation
            Thread.Sleep(2000);
            Assert.AreEqual("what's new for Diwali 2023? - Google Search", driver.Title);//comparing the given title and driver title
            Console.WriteLine("Search Text test passed");
        }
        public void RefreshTest()
        {
            driver.Navigate().Refresh();//refreshing the browser
            Console.WriteLine("Refresh test passed");
        }
        public void Destruct()
        {
            driver.Close();//closing the browser
            Console.WriteLine("Browser Closed Successfully");
        }

    }
}
