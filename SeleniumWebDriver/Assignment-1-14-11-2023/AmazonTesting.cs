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
            driver = new ChromeDriver();//setting the browser to be Chrome
            driver.Url = "https://www.amazon.com/";//opens amazon page
        }
        public void TitleTest()
        {
            Console.WriteLine("Title: "+driver.Title);//Title of the webpage
            Assert.AreEqual("Amazon.com. Spend less. Smile more.",driver.Title);//comparing the titles
            Console.WriteLine("Title test passed");
        }
        public void CheckUrlTest()
        {
            Console.WriteLine(driver.Url);//url of the driver
            Assert.AreEqual("https://www.amazon.com/", driver.Url);//compare the url's
            Console.WriteLine("Url test Passed");
        }
        public void Destruct()
        {
            driver.Close();//closing the browser
        }

    }
}
