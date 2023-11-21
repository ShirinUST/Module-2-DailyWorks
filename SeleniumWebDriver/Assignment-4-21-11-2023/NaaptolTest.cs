using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Assignment_4_21_11_2023
{
    
    internal class NaaptolTest:CoreCodes
    {
        [Test]
        [Order(1)]
        [Author("Shirin", "sheri@gm.com")]
        [Description("Searching a product")]
        [Category("Regression Testing")]
        public void ProductSearchingTest()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(500);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element Not Found";

            IWebElement searchElement = wait.Until(d => d.FindElement(By.Id("header_search_text")));
            searchElement.SendKeys("eyewear");
            searchElement.SendKeys(Keys.Enter);
            //IWebElement search = wait.Until(d => d.FindElement(By.ClassName("_2iLD__")));
            //search.Click();
            Assert.That(driver.Title.Contains("eyewear"));
            Thread.Sleep(2000);
        }

        [Test]
        [Order(2)]
        [Author("Shirin", "sheri@gm.com")]
        [Description("Selecting a product")]
        [Category("Regression Testing")]
        public void ProductSelectionTest()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(500);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element Not Found";

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(By.XPath("//a[@title='Reading Glasses with LED Lights (LRG4)'][1]")));

            Thread.Sleep(3000);

            js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//a[@title='Reading Glasses with LED Lights (LRG4)'][1]")));
            Thread.Sleep(2000);

            List<string> lswindow=driver.WindowHandles.ToList();
            driver.SwitchTo().Window(lswindow[1]);
            
        }

        [Test]
        [Order(3)]
        [Author("Shirin", "sheri@gm.com")]
        [Description("Buying a product")]
        [Category("Regression Testing")]
        public void BuyProductTest()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(500);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element Not Found";

            IWebElement sizeElement = wait.Until(d => d.FindElement(By.LinkText("Black-2.50")));
            sizeElement.Click();
            Thread.Sleep(2000);

            IWebElement BuyElement = wait.Until(d => d.FindElement(By.Id("cart-panel-button-0")));
            BuyElement.Click();
            Thread.Sleep(2000);

        }
        [Test]
        [Order(4)]
        [Author("Shirin", "sheri@gm.com")]
        [Description("checkinga  product in the cart")]
        [Category("Regression Testing")]
        public void ViewCartProductTest()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(500);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element Not Found";

            IWebElement selectedElement = wait.Until(d => d.FindElement(By.LinkText("Reading Glasses with LED Lights (LRG4)")));
            Assert.AreEqual(selectedElement.Text, "Reading Glasses with LED Lights (LRG4)");
            Console.WriteLine("The product you selected and in the cart is same. Buy Now");
            Thread.Sleep(2000);

            
            IWebElement closeElement = wait.Until(d => d.FindElement(By.XPath("//*[contains(@class,'fancybox-close')]")));
            closeElement.Click();

        }
    }
}
