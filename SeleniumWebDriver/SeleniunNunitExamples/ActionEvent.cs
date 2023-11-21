using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniunNunitExamples
{
    [TestFixture]
    internal class ActionEvent:CoreCodes
    {
        [Test]
        public void HomeLinkTest()
        {
            IWebElement homeLink=driver.FindElement(By.LinkText("Home"));
            IWebElement tdHome = driver.FindElement(By.XPath("//tr[@class='mouseOut'][1]"));

            Actions actions= new Actions(driver);
            Action mouseOverAction = () =>  actions.MoveToElement(homeLink).Build().Perform();
            Console.WriteLine("Before : "+tdHome.GetCssValue("background-color"));
            mouseOverAction.Invoke();
            Console.WriteLine("After : " + tdHome.GetCssValue("background-color"));

            Thread.Sleep(1000);

        }

        [Test]
        public void MultipleActionTest()
        {
            driver.Navigate().GoToUrl("https://www.linkedin.com/");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(500);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element Not Found";

            IWebElement emailInput = wait.Until(d => d.FindElement(By.Id("session_key")));

            Actions actions = new Actions(driver);
            Action upperCaseInput = () => actions
            .KeyDown(Keys.Shift)
            .SendKeys(emailInput,"hello")
            .KeyUp(Keys.Shift)
            .Build()
            .Perform();

            upperCaseInput.Invoke();
            Thread.Sleep(4000);
            Console.WriteLine("Text is : "+emailInput.GetAttribute("value"));
        }
    }
}
