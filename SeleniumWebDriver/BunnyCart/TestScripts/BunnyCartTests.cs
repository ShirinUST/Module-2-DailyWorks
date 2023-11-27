using BunnyCart.PageObjects;
using BunnyCart.Utilities;
using OpenQA.Selenium;
using Serilog;
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
            string directory = Directory.GetParent(@"../../../").FullName;
            string logfilepath = directory + "/Logs/log_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
            Log.Logger = new LoggerConfiguration().
                WriteTo.Console().
                WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day).
                CreateLogger();

            BunnyCartHomePage bunnyCart = new BunnyCartHomePage(driver);
            Log.Information("Create Account Test Started");
            bunnyCart.ClickCreateAnAccountLink();
            Log.Information("Create account link clicked");
            Thread.Sleep(2000);
            try
            {

                //Assert.That(driver.FindElement(By.XPath("//div[@class='modal-inner-wrap']//following::h1[2]"))
                //    .Text, Is.EqualTo("Create an Account"));

                Assert.IsTrue(driver?.FindElement(By.XPath("//div[@class='modal-inner-wrap']//following::h1[2]"))
                    .Text == "Create an Account",$"Test failed for Create Account");
                Log.Information("Test passed for Create Account");

                bunnyCart.SignUp("John", "Doe", "john.doe@example.com", "12345", "12345", "9876543210");
            }
            catch (AssertionException ex)
            {
                Log.Error($"Test failed for Create Account.\n Exception: {ex.Message}");
         
                Console.WriteLine("Create Acc modal not present");
            }

            Log.CloseAndFlush();
        }
        
    }
}
