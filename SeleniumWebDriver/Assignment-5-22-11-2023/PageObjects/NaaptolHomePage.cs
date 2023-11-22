using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5_22_11_2023.PageObjects
{
    internal class NaaptolHomePage
    {
        IWebDriver? driver;
        public NaaptolHomePage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver,this);
        }
        [FindsBy(How = How.Id, Using = "header_search_text")]
        public IWebElement? SearchElement { get; set; }

        public void TypeSearchElement(string search)
        {
            SearchElement.SendKeys(search);
        }
        public ProductsPage SearchClick()
        {
            SearchElement.SendKeys(Keys.Enter);
            return new ProductsPage(driver);
        }
    }
}
