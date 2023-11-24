using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.PageObjects
{
    internal class ProductPage
    {
        IWebDriver driver;
        public ProductPage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        //Arrange
        [FindsBy(How = How.ClassName, Using = "qty-inc")]
        [CacheLookup]
        private IWebElement CountIncrementLink { get; set; }
        [FindsBy(How = How.Id, Using = "product-addtocart-button")]
        [CacheLookup]
        private IWebElement AddToCartLink { get; set; }

        public void ClickCountIncrementLink()
        {
            CountIncrementLink.Click();
        }
        public void ClickAddToCartLink()
        {
            AddToCartLink.Click();
        }
    }
}
