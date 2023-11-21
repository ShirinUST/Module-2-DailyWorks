using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniunNunitExamples
{
    [TestFixture]
    internal class Elements : CoreCodes
    {
        //[Test]
        //public void TestCheckBox()
        //{
        //    IWebElement elements = driver.FindElement(By.XPath("//h2[text()='Elements']"));
        //    elements.Click();

        //    IWebElement cbmenu = driver.FindElement(By.XPath("//span[text()='Check Box']"));
        //    cbmenu.Click();

        //    List<IWebElement> expandcollapse = driver.FindElements(By.ClassName("rct-collapse rct-collapse-btn")).ToList();
        //    foreach (var item in expandcollapse)
        //    {
        //        item.Click();
        //    }
        //    //IWebElement commandsCheckbox=
        //}

        [Test]
        public void TestFormElements()
        {
            Thread.Sleep(2000);
            IWebElement firstnamefield = driver.FindElement(By.Id("firstName"));
            firstnamefield.SendKeys("Shirin");
            Thread.Sleep(1000);

            Thread.Sleep(2000);
            IWebElement lastnamefield = driver.FindElement(By.Id("lastName"));
            lastnamefield.SendKeys("Safwana");
            Thread.Sleep(1000);

            Thread.Sleep(2000);
            IWebElement emailfield = driver.FindElement(By.XPath("//input[@id='userEmail']"));
            emailfield.SendKeys("Safwanashirin@gm.in");
            Thread.Sleep(1000);

            Thread.Sleep(2000);
            IWebElement gender = driver.FindElement(By.XPath("//label[text()='Male']"));
            gender.Click();
            Thread.Sleep(1000);

            Thread.Sleep(2000);
            IWebElement numberfield = driver.FindElement(By.XPath("//input[@id='userNumber']"));
            numberfield.SendKeys("1234567890");
            Thread.Sleep(1000);

            Thread.Sleep(2000);
            IWebElement dob = driver.FindElement(By.Id("dateOfBirthInput"));
            dob.Click();
            Thread.Sleep(1000);

            IWebElement dobMonth = driver.FindElement(By.ClassName("react-datepicker__month-select"));
            SelectElement select = new(dobMonth);
            select.SelectByIndex(0);
            Thread.Sleep(2000);

            IWebElement dobYear = driver.FindElement(By.ClassName("react-datepicker__year-select"));
            SelectElement select1 = new(dobYear);
            select1.SelectByText("1998");
            Thread.Sleep(2000);

            IWebElement dobday = driver.FindElement(By.XPath("//div[text()='1']"));
            dobday.Click();
            Thread.Sleep(2000);

            IWebElement subject = driver.FindElement(By.Id("subjectsInput"));
            subject.SendKeys("Maths");
            subject.SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            subject.SendKeys("Physics");
            subject.SendKeys(Keys.Enter);
            Thread.Sleep(3000);

            IWebElement hobbiesElement = driver.FindElement(By.XPath("//label[text()='Sports']"));
            hobbiesElement.Click();
            Thread.Sleep(2000);

            IWebElement uploadPicture = driver.FindElement(By.Id("uploadPicture"));
            uploadPicture.SendKeys("C:\\Users\\Administrator\\Downloads");
            Thread.Sleep(1000);


            IWebElement currentAddressField = driver.FindElement(By.Id("currentAddress"));
            currentAddressField.SendKeys("123 Street, City, Country");
            Thread.Sleep(1000);

            IWebElement submitButton = driver.FindElement(By.Id("submit"));
            submitButton.Click();

        }
        [Test]
        public void TestWindows()
        {
            driver.Url = "https://demoqa.com/browser-windows";
            string parentWindowHandle = driver.CurrentWindowHandle;
            Console.WriteLine("Parent Window's handle -> " + parentWindowHandle);
            IWebElement clickElement = driver.FindElement(By.Id("tabButton"));
            for (var i = 0; i < 3; i++)
            {
                clickElement.Click();
                Thread.Sleep(1000);
            }
            List<string> lstWindow = driver.WindowHandles.ToList();
            string lastWindowHandle = "";
            foreach (var handle in lstWindow)
            {
                Console.WriteLine("Switching to window ->" + handle);
                driver.SwitchTo().Window(handle);
                Thread.Sleep(1000);
                Console.WriteLine("Navigating to google.com");
                driver.Navigate().GoToUrl("https://google.com");
                Thread.Sleep(1000);

                lastWindowHandle = handle;
            }
            driver.SwitchTo().Window(parentWindowHandle);
            driver.Quit();
        }
        [Test]
        public void TestAlerts()
        {
            driver.Url = "https://demoqa.com/alerts";

            IWebElement element = driver.FindElement(By.Id("alertButton"));
            Thread.Sleep(5000);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", element);

            IAlert simpleAlert = driver.SwitchTo().Alert();

            Console.WriteLine("Alert text is " + simpleAlert.Text);
            simpleAlert.Accept();
            Thread.Sleep(1000);

            element = driver.FindElement(By.Id("confirmButton"));
            element.Click();
            Thread.Sleep(3000);
            

            IAlert confirmationAlert = driver.SwitchTo().Alert();
            string alertText = confirmationAlert.Text;

            Console.WriteLine("Alert Text is " + alertText);
            confirmationAlert.Dismiss();

            element = driver.FindElement(By.Id("promtButton"));
            element.Click();
            Thread.Sleep(5000);
            IAlert promptAlert = driver.SwitchTo().Alert();
            alertText = promptAlert.Text;
            Console.WriteLine("Alert Text is " + alertText);
            promptAlert.SendKeys("Accepting the alert");
            Thread.Sleep(5000);
            promptAlert.Accept();
        }
        //https://demoqa.com/automation-practice-form
    }
}
