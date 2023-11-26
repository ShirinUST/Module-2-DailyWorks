using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy_1_Naaptol.PageObjects
{
    internal class ProductPage
    {
        IWebDriver driver;
        public ProductPage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        int id;

        //Arrange
        [FindsBy(How = How.XPath, Using = "(//a[@target='_blank'])[position()=10]")]
        private IWebElement DesiredProduct { get; set; }

        //Act
       
        public SelectedProductPage ClickDesiredProduct()
        {
            DesiredProduct.Click();
            return new SelectedProductPage(driver);
        }
    }
}
