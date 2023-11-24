using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.PageObjects
{
    internal class SearchResultsPage
    {
        IWebDriver driver;
        public SearchResultsPage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        //Arrange
        [FindsBy(How = How.XPath, Using = "(//a[@class='product-item-link'])[position()=2]")]
        [CacheLookup]
        private IWebElement FirstProductLink { get; set; }
        public string GetFirstProductLink()
        {
            return FirstProductLink.Text;
        }
        IWebElement GetElement(string Id)
        {
            return driver.FindElement(By.XPath("(//a[@class='product-item-link'])["+Id+"]"));
        }
        public ProductPage ClickProductLink(string Pid)
        {
            GetElement(Pid).Click();
            return new ProductPage(driver);
        }
    }
}
