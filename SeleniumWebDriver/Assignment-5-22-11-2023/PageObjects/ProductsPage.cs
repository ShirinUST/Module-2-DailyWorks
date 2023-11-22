using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5_22_11_2023.PageObjects
{
    internal class ProductsPage
    {
        IWebDriver driver;
        public ProductsPage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[@title='Reading Glasses with LED Lights (LRG4)'][1]")]
        public IWebElement? SelectingProduct { get; set; }

        public void ScrollToProduct()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", SelectingProduct);
        }
        public SelectedProductPage ClickProduct()
        {
            SelectingProduct.Click();
            return new SelectedProductPage(driver);
        }
    }
}
