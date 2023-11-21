using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3_20_11_2023
{
    [TestFixture]
    internal class FlipkartTest:CoreCode
    {
        [Test]
        [Order(1)]
        [Author("Shirin","sheri@gm.com")]
        [Description("closing the popup")]
        [Category("Regression Testing")]
        public void ClosePopupTest()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(500);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element Not Found";

            IWebElement closePopup = wait.Until(d => d.FindElement(By.XPath("//span[@role='button']")));
            closePopup.Click();
        }
        [Test]
        [Order(2)]
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

            IWebElement searchElement = wait.Until(d => d.FindElement(By.ClassName("Pke_EE")));
            searchElement.SendKeys("laptop");
            searchElement.SendKeys(Keys.Enter);
            //IWebElement search = wait.Until(d => d.FindElement(By.ClassName("_2iLD__")));
            //search.Click();
            Assert.That(driver.Title.Contains("Laptop"));
            Thread.Sleep(2000);
        }
    }
}
