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
    [TestFixture,Order(2)]
    internal class SearchTests:CoreCodes
    {
        [Test]
        [TestCase("water","3")]
        public void ProductLinkTest(string product,string pid)
        {
            BunnyCartHomePage homePage = new BunnyCartHomePage(driver);
            var searchresult = homePage.TypeSearchInput(product);
            Thread.Sleep(3000);
            CoreCodes.ScrollIntoView(driver, driver.FindElement(By.XPath("//div[@class='product-item-inner'][1]")));
            Thread.Sleep(3000);
            var productPage=searchresult.ClickProductLink(pid);
            Thread.Sleep(3000);
            productPage.ClickCountIncrementLink();
            Thread.Sleep(2000);
            productPage.ClickAddToCartLink();
            Thread.Sleep(2000);

        }
    }
}
