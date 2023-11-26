using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy_1_Naaptol.PageObjects
{
    internal class SelectedProductPage
    {
        IWebDriver driver;
        public SelectedProductPage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        //Arrange
        [FindsBy(How = How.LinkText, Using = "Rose Gold-2.00")]
        private IWebElement DesiredProductSize { get; set; }

        [FindsBy(How = How.Id, Using = "cart-panel-button-0")]
        private IWebElement BuyButton { get; set; }

        [FindsBy(How = How.LinkText, Using = "Remove")]
        private IWebElement RemoveProductLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[text()='You have No Items in Cart !!! ']")]
        private IWebElement RemovedProduct { get; set; }

        public void ClickDesiredProductSize()
        {
            DesiredProductSize.Click();
        }

        public void ClickBuyButton()
        {
            BuyButton.Click();
        }

        public string ClickRemoveProductLink()
        {
            RemoveProductLink.Click();

            return RemovedProduct.Text;
        }

    }
}
