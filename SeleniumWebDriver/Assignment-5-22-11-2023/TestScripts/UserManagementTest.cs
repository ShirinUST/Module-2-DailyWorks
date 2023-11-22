using Assignment_5_22_11_2023.PageObjects;
using Assignment_5_22_11_2023.Utilities;

namespace Assignment_5_22_11_2023.TestScripts
{
    [TestFixture]
    internal class UserManagementTest:CoreCodes
    {
        [Test, Order(1), Category("Regression Test")]
        public void ProductSearchTest()
        {
            var homePage = new NaaptolHomePage(driver);

            if (!driver.Url.Equals("https://www.naaptol.com/"))
            {
                driver.Navigate().GoToUrl("https://www.naaptol.com/");
            }
            homePage.TypeSearchElement("eyewear");
            var productPage=homePage.SearchClick();
            Assert.That(driver.Title.Contains("eyewear"));
            Thread.Sleep(3000);

            productPage.ScrollToProduct();
            Thread.Sleep(3000);
            var selectedProduct=productPage.ClickProduct();
            Thread.Sleep(2000);

            List<string> lswindow = driver.WindowHandles.ToList();
            driver.SwitchTo().Window(lswindow[1]);

            selectedProduct.SizeSelection();
            selectedProduct.ClickBuyBtn();
            Thread.Sleep(2000);

            //string result=selectedProduct.CheckTheElement();
            //Assert.AreEqual("Reading Glasses with LED Lights(LRG4)", result);

            selectedProduct.ClickCloseLink();
            Thread.Sleep(3000);

        }
    }
}
