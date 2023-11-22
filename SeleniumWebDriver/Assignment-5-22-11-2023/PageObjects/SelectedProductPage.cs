using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5_22_11_2023.PageObjects
{
    internal class SelectedProductPage
    {
        IWebDriver driver;
        public SelectedProductPage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.LinkText, Using = "Black-2.00")]
        public IWebElement? SizeOfProductLink { get; set; }

        [FindsBy(How = How.Id, Using = "cart-panel-button-0")]
        public IWebElement? BuyBtn { get; set; }

        [FindsBy(How = How.LinkText, Using = "Reading Glasses with LED Lights(LRG4)")]
        public IWebElement? NameOfProduct { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@class,'fancybox-close')]")]
        public IWebElement? CloseLink { get; set; }


        public void SizeSelection()
        {
            SizeOfProductLink?.Click();
        }
        public void ClickBuyBtn()
        {
            BuyBtn?.Click();
        }
        public string CheckTheElement()
        {
            return NameOfProduct.Text;
        }

        public void ClickCloseLink()
        {
            CloseLink?.Click();
        }
    }
}
