using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy_1_Naaptol.PageObjects
{
    internal class NaaptolHomePage
    {
        IWebDriver driver;
        public NaaptolHomePage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How =How.Id, Using = "header_search_text")]
        private IWebElement SearchTextInput { get; set; }

        public void TypeSearchInputText(string text)
        {
            SearchTextInput.SendKeys(text);
        }
        public ProductPage ClickSearch()
        {
            SearchTextInput.SendKeys(Keys.Enter);
            return new ProductPage(driver);
        }
    }
}
