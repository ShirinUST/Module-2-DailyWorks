using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1_14_11_2023
{
    internal class AmazonTesting
    {
        IWebDriver? driver;
        public void Initialization()
        {
            driver = new ChromeDriver();
            driver.Url = "https://www.amazon.com/";
        }
        public void TitleTest()
        {
            Console.WriteLine("Title: "+driver.Title);
            Assert.AreEqual("Amazon.com. Spend less. Smile more.",driver.Title);
            Console.WriteLine("Title test passed");
        }
        public void CheckUrlTest()
        {
            Console.WriteLine(driver.Url);
            Assert.AreEqual("https://www.amazon.com/", driver.Url);
            Console.WriteLine("Url test Passed");
        }
        public void Destruct()
        {
            driver.Close();
        }

    }
}
