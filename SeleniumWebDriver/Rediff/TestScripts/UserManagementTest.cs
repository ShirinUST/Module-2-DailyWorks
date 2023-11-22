using OpenQA.Selenium.Support.UI;
using Rediff.PageObjects;
using Rediff.Utilities;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rediff.TestScripts
{
    [TestFixture]
    internal class UserManagementTest:CoreCodes
    {
        
        //Asserts
        /*
        [Test, Order(1),Category("Smoke Test")]
        public void CreateAccountLinkTest()
        {
            RediffHomePage homePage=new RediffHomePage(driver);
            driver.Navigate().GoToUrl("https://www.rediff.com/");
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(homePage.CreateAccountLink));
            homePage.CreateAccountLinkClick();
           
            //Console.WriteLine(driver.Title);
            Console.WriteLine(driver.Url);
            Thread.Sleep(3000);
            Assert.That(driver.Url.Contains("register"));
        }
        [Test, Order(2),Category("Smoke Test")]
        public void SignInLinkTest()
        {
            
            var homePage = new RediffHomePage(driver);
            driver.Navigate().GoToUrl("https://www.rediff.com/");
            homePage.SignInClick();
            Thread.Sleep(3000);
            Assert.That(driver.Url.Contains("login"));
        }
        */
        /*
        [Test, Order(1), Category("Regression Test")]
        public void CreateAccountTest()
        {
            var homePage = new RediffHomePage(driver);
            
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(homePage.CreateAccountLink));
           if(!driver.Url.Equals("https://www.rediff.com/"))
            {
                driver.Navigate().GoToUrl("https://www.rediff.com/");
            }
            var createaccountpage = homePage.CreateAccountClick();

            //Console.WriteLine(driver.Title);
           // Console.WriteLine(driver.Url);
            Thread.Sleep(3000);
            createaccountpage.FullNameType("XXX");
            createaccountpage.RediffMailType("XXX");
            createaccountpage.CheckAvailabilityBtnClick();
            Thread.Sleep(3000);

            createaccountpage.CreateMyAccountBtnClick();
            //Assert.That(driver.Url.Contains("register"));
        }
        */
        [Test, Order(1), Category("Regression Test")]
        public void SignInTest()
        {
            var homePage = new RediffHomePage(driver);

           
            if (!driver.Url.Equals("https://www.rediff.com/"))
            {
                driver.Navigate().GoToUrl("https://www.rediff.com/");
            }
            var signInPage = homePage.SignInClick();

    
            Thread.Sleep(3000);
            signInPage.TypeUserName("XXX");
            signInPage.TypePassword("password");
            signInPage.ClickRememberMeCheckBox();
            Assert.False(signInPage.RememberMeChkbx?.Selected);

         
            Thread.Sleep(3000);

            Assert.True(true);
            //Assert.That(driver.Url.Contains("register"));
        }
    }
}
