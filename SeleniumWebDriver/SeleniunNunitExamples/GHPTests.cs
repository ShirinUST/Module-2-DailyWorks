
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniunNunitExamples
{
    [TestFixture]
    internal class GHPTests:CoreCodes
    {
        [Ignore("other")]
        [Test]
        [Order(10)]
        public void TitleTest()
        {
            //Thread.Sleep(2000);

            Assert.AreEqual("Google", driver.Title);
            Console.WriteLine("Title test Passed");
        }
        [Test]
        public void GSTest()
        {
            IWebElement searchinputtextbox = driver.FindElement(By.Id("APjFqb"));
            searchinputtextbox.SendKeys("max fashions");
            Thread.Sleep(2000);
            IWebElement gsButton = driver.FindElement(By.ClassName("gNO89b"));  //Name("btnK"));
            gsButton.Click();
            Assert.AreEqual("max fashions - Google Search", driver.Title);
            Console.WriteLine("Google Search Test - Pass");
            driver.Navigate().Back();
        }
        [Test]
        public void AllLinkStatusTest()
        {
            List<IWebElement> links = driver.FindElements(By.TagName("a")).ToList();
            foreach(var  link in links)
            {
                string url=link.GetAttribute("href");
                if(url==null)
                {
                    Console.WriteLine("url is null");
                    continue;
                }
                else
                {
                    bool isworking = CheckLinkStatus(url);
                    if(isworking)
                        Console.WriteLine(url+" is working");
                    else
                        Console.WriteLine(url+" is working");
                }
            }
        }


    }
}
