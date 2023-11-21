using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniunNunitExamples
{
    [TestFixture]
    internal class LinkedInTests:CoreCodes
    {
      
        [Test]
        [Author("Shirin","sheri@qwa.com")]
        [Description("Check for Valid Login")]
        [Category("Regression Testing")]
        public void Login1Test()
        {
            WebDriverWait wait=new WebDriverWait(driver,TimeSpan.FromSeconds(5));
            //driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(3);
            /*
            IWebElement emailInput = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("session_key")));
            IWebElement passwordInput = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("session_password")));
            */
            /*
            IWebElement emailInput = wait.Until(d=>d.FindElement(By.Id("session_key")));
            IWebElement passwordInput = wait.Until(d=>d.FindElement(By.Id("session_password")));
            */

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(500);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element Not Found";

            IWebElement emailInput = wait.Until(d => d.FindElement(By.Id("session_key")));
            IWebElement passwordInput = wait.Until(d => d.FindElement(By.Id("session_password")));
            emailInput.SendKeys("pwd.com");
            passwordInput.SendKeys("pwd");

            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //Thread.Sleep(1000);
        }
        [Test]
        [Author("Shirin", "sheri@qwa.com")]
        [Description("Check for Invalid Login")]
        [Category("Smoke Testing")]
        public void LoginTestWithInvalidCredential()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(500);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element Not Found";

            IWebElement emailInput = wait.Until(d => d.FindElement(By.Id("session_key")));
            IWebElement passwordInput = wait.Until(d => d.FindElement(By.Id("session_password")));
            emailInput.SendKeys("qwerty@wer.com");
            passwordInput.SendKeys("qwer");
            Thread.Sleep(3000);
            ClearForm(emailInput);
            ClearForm(passwordInput);

            emailInput.SendKeys("rose@gn.com");
            passwordInput.SendKeys("blueRose");
            Thread.Sleep(3000);
            ClearForm(emailInput);
            ClearForm(passwordInput);

            emailInput.SendKeys("black@lok.com");
            passwordInput.SendKeys("black");
            Thread.Sleep(3000);
            ClearForm(emailInput);
            ClearForm(passwordInput);
        }

        void ClearForm(IWebElement element)
        {
            element.Clear();
        }

        [Test]
        [Author("Shirin", "sheri@qwa.com")]
        [Description("Check for Invalid Login")]
        [Category("Regression Testing")]
        //[TestCase("qwerty@wer.com", "qwer")]
        //[TestCase("rose@gn.com", "blueRose")]
        //[TestCase("black@lok.com", "black")]
        [TestCaseSource(nameof(InvalidLoginData))]
        public void Login3Test(string email,string pwd)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(500);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element Not Found";

            IWebElement emailInput = wait.Until(d => d.FindElement(By.Id("session_key")));
            IWebElement passwordInput = wait.Until(d => d.FindElement(By.Id("session_password")));

            emailInput.SendKeys(email);
            passwordInput.SendKeys(pwd);
            TakeScreenShot();

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(By.XPath("//button[@type='submit']")));

            Thread.Sleep(3000);

            js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//button[@type='submit']")));


            ClearForm(emailInput);
            ClearForm(passwordInput);

            
        }

        static object[] InvalidLoginData()
        {
            return new object[]
            {
                new object[] { "qwerty@wer.com", "qwer" },
                new object[] { "rose@gn.com", "blu" },
                new object[] { "black@lok.com", "blac" }
            };
        }
        
    }
}
//https://www.linkedin.com/