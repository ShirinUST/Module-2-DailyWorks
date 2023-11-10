using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniunNunitExamples
{
    public class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Url = "https://www.google.com";
        }

        [Test]
        public void CheckForTitle()
        {
            
            Thread.Sleep(10000);
            string title=driver.Title;
            Assert.AreEqual("Google", title);
            //driver.Close();
        }
        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}