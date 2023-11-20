using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace SeleniumExamples
{
    internal class AmazonTest
    {
        IWebDriver? driver;

        public void InitializeEdgeDriver()
        {
            driver = new EdgeDriver();
            driver.Url = "https://www.amazon.com/";
            driver.Manage().Window.Maximize();
        }
        public void InitializeChromeDriver()
        {
            driver = new ChromeDriver();
            driver.Url = "https://www.amazon.com/";
            driver.Manage().Window.Maximize();
        }
        public void TitleTest()
        {
            Console.WriteLine("Title: " + driver.Title);//Title of the webpage
            Assert.That(driver.Title.Contains("Amazon"));//comparing the titles
            Console.WriteLine("Title test passed");
        }

        public void LogoClickTest()
        {
            driver.FindElement(By.Id("nav-logo-sprites")).Click();
            Assert.That(driver.Title.Contains("Amazon"));//comparing the titles
            Console.WriteLine("Logo click test- passed");

        }
        public void SearchProductTest()
        {
            driver.FindElement(By.Id("twotabsearchtextbox")).SendKeys("IPhone");
            //Thread.Sleep(2000);
            driver.FindElement(By.Id("nav-search-submit-button")).Click();
            //Thread.Sleep(2000);
            Assert.That(("Amazon.com : IPhone".Equals(driver.Title)) && (driver.Url.Contains("IPhone")));
            Console.WriteLine("Search product test-passed");
        }
        public void ReloadHomePage()
        {
            driver.Navigate().GoToUrl("https://www.amazon.com/");
            Thread.Sleep(1000);
        }
        public void TodaysDealsTest()
        {
            IWebElement todaysdeals = driver.FindElement(By.LinkText("Today's Deals"));
            if(todaysdeals == null)
            {
                throw new NoSuchElementException("Todays deals link is not present");
            }
            todaysdeals.Click();
            Assert.That(driver.FindElement(By.TagName("h1")).Text.Equals("Today's Deals"));
            Console.WriteLine("Today's Deals Test Passed");
        }

        public void SignInAccListTest()
        {
            IWebElement hellosignin = driver.FindElement(By.Id("nav-link-accountList-nav-line-1"));
            if(hellosignin == null)
            {
                throw new NoSuchElementException("Hello sign in is not present");
            }
            IWebElement account = driver.FindElement(By.XPath("//*[@id=\"nav-link-accountList\"]/span"));
            if(account == null)
            {
                throw new NoSuchElementException("Hello Account and lists is not present");
            }
            Assert.That(hellosignin.Text.Equals("Hello, sign in"));
            Console.WriteLine("Hello , sign in present - pass");
            Assert.That(account.Text.Equals("Account & Lists"));
            Console.WriteLine("Account & List test passed");
        }
        public void SearchAndFilterProductByBrandTest()
        {
            driver.FindElement(By.Id("twotabsearchtextbox")).SendKeys("mobile phones");
            Thread.Sleep(2000);
            driver.FindElement(By.Id("nav-search-submit-button")).Click();
           
            driver.FindElement(By.XPath("//*[@id=\"p_89/Motorola\"]/span/a/div/label/i")).Click();
            //Assert.That(("Amazon.com : IPhone".Equals(driver.Title)) && (driver.Url.Contains("IPhone")));
            Assert.True(driver.FindElement(By.XPath("//*[@id=\"p_89/Motorola\"]/span/a/div/label/input")).Selected);
            Console.WriteLine("Motorola is selected");

            driver.FindElement(By.ClassName("a-expander-prompt")).Click();

            driver.FindElement(By.XPath("//*[@id=\"p_89/Apple\"]/span/a/div/label/i")).Click();
            //Assert.That(("Amazon.com : IPhone".Equals(driver.Title)) && (driver.Url.Contains("IPhone")));
            Assert.True(driver.FindElement(By.XPath("//*[@id=\"p_89/Apple\"]/span/a/div/label/input")).Selected);
            Console.WriteLine("Apple is selected");



        }
        public void SortBySelectTest()
        {
            IWebElement sortby = driver.FindElement(By.ClassName("a-native-dropdown-a-declarative"));
            SelectElement sortbyselect = (SelectElement)sortby;
            sortbyselect.SelectByValue("1");
            Thread.Sleep(1000);
            Console.WriteLine(sortbyselect.SelectedOption);
        }

        public void Destruct()
        {
            driver.Close();
        }
}
}
