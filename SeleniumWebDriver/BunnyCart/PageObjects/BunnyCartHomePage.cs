using BunnyCart.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.PageObjects
{
    internal class BunnyCartHomePage
    {
        IWebDriver driver;
        public BunnyCartHomePage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        //Arrange
        [FindsBy(How =How.Id,Using ="search")]
        [CacheLookup]
        private IWebElement SearchElement { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text()='Create an Account'][1]")]
        private IWebElement CreateAccountLink { get; set; }

        [FindsBy(How = How.Id, Using = "firstname")]
        private IWebElement FirstNameInput { get; set; }

        [FindsBy(How = How.Id, Using = "lastname")]
        [CacheLookup]
        private IWebElement LastNameInput { get; set; }

        [FindsBy(How = How.Id, Using = "popup-email_address")]
        private IWebElement? EmailInput { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement? PasswordInput { get; set; }

        [FindsBy(How = How.Name, Using = "password_confirmation")]
        private IWebElement? ConfirmPasswordInput { get; set; }

        [FindsBy(How = How.Id, Using = "mobilenumber")]
        private IWebElement? MobileNumberInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@title='Create an Account']")]
        private IWebElement? SignInButton { get; set; }



        //Act
        public void ClickCreateAnAccountLink()
        {
            CreateAccountLink?.Click();
        }

        public void SignUp(string firstName, string lastName, string email,
            string pwd, string conpwd, string mbno)
        {
            IWebElement modal = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(
                    By.XPath("((//div[@class='modal-inner-wrap'])[position()=2])")));

            FirstNameInput?.SendKeys(firstName);
            LastNameInput?.SendKeys(lastName);
            EmailInput?.SendKeys(email);

            CoreCodes.ScrollIntoView(driver, modal.FindElement(By.Id("password")));
            PasswordInput?.SendKeys(pwd);
            ConfirmPasswordInput?.SendKeys(conpwd);

            CoreCodes.ScrollIntoView(driver, modal.FindElement(By.Id("mobilenumber")));
            MobileNumberInput?.SendKeys(mbno);
            Thread.Sleep(1000);
            SignInButton?.Click();


        }
       
        public SearchResultsPage TypeSearchInput(string searchtext)
        {
            if (SearchElement == null)
            {
                throw new NoSuchElementException(nameof(SearchElement));
            }
            SearchElement.SendKeys(searchtext);
            SearchElement.SendKeys(Keys.Enter);
            return new SearchResultsPage(driver);
        }

    }
}
