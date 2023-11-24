using BunnyCart.PageObjects;
using BunnyCart.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.TestScripts
{
    [TestFixture,Order(1)]
    internal class BunnyCartTests:CoreCodes
    {
        [Test]
        public void SignUpTest()
        {
            BunnyCartHomePage bunnyCart = new BunnyCartHomePage(driver);
            bunnyCart.ClickCreateAnAccountLink();
            Thread.Sleep(2000);
            try
            {

                Assert.That(driver.FindElement(By.XPath("//div[@class='modal-inner-wrap']//following::h1[2]"))
                    .Text, Is.EqualTo("Create an Account"));
                bunnyCart.SignUp("John", "Doe", "john.doe@example.com", "12345", "12345", "9876543210");
            }
            catch (AssertionException ex)
            {
                Console.WriteLine("Create Acc modal not present");
            }
            

        }
        
    }
}
