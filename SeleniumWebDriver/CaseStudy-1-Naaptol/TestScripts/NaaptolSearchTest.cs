using CaseStudy_1_Naaptol.Utilities;
using CaseStudy_1_Naaptol.PageObjects;
using CaseStudy_1_Naaptol.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace CaseStudy_1_Naaptol.TestScripts
{
    [TestFixture]
    internal class NaaptolSearchTest:CoreCodes
    {
        [Test]
        [TestCase("eyewear",5)]
        public void ProductSearchTest(string search,int id)
        {
            try
            {

                NaaptolHomePage naaptol = new(driver);
                naaptol.TypeSearchInputText(search);
                var productpage = naaptol.ClickSearch();
                Thread.Sleep(2000);
                CoreCodes.ScrollIntoView(driver, driver.FindElement(By.Id("productItem" + id)));
                Thread.Sleep(3000);
                var selectedproduct = productpage.ClickDesiredProduct();
                Thread.Sleep(3000);

                List<string> lswindow = driver.WindowHandles.ToList();
                driver.SwitchTo().Window(lswindow[1]);

                selectedproduct.ClickDesiredProductSize();
                selectedproduct.ClickBuyButton();
                Assert.That(selectedproduct, Is.Not.Null);
                Console.WriteLine("Product Added Test-Passed");

                Thread.Sleep(2000);
                var removeText = selectedproduct.ClickRemoveProductLink();
                Console.WriteLine(removeText);
                Assert.That(removeText.Contains("No Items"));
                Console.WriteLine("Product Removing Test-Passed");

                Thread.Sleep(3000);
            }
            catch(AssertionException)
            {
                Console.WriteLine("Test case failed");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
