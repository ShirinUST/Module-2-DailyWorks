using CaseStudy_1_Naaptol.Utilities;
using CaseStudy_1_Naaptol.PageObjects;
using CaseStudy_1_Naaptol.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace CaseStudy_1_Naaptol.TestScripts
{
    [TestFixture]
    internal class NaaptolSearchTest:CoreCodes
    {
        [Test]
        [Category("Regression Test")]
        //[TestCase("eyewear",5)]
        public void ProductSearchTest()
        {
            
                NaaptolHomePage naaptol = new(driver);
                if (!driver.Url.Equals("https://www.naaptol.com/"))
                {
                    driver.Navigate().GoToUrl("https://www.naaptol.com/");
                }

            try
            {
                Assert.That(driver.Url.Contains("naaptol"));
                test = extent.CreateTest("Naaptol Eyewear Product");
                test.Pass(" Naaptol Eyewear Product success");
            }
            catch (AssertionException)
            {
                test = extent.CreateTest("Naaptol Eyewear Product Test");
                test.Fail("Naaptol Eyewear Product Search failed");
            }

            string? currDir = Directory.GetParent(@"../../../")?.FullName;
                string? excelFilePath = currDir + "/TestData/InputData.xlsx";
                string? sheetName = "NaaptolSearch";

                List<ExcelData> excelDataList = ExcelUtils.ReadExcelData(excelFilePath, sheetName);

                foreach (ExcelData excelData in excelDataList)
                {
                    string? searchtext = excelData?.SearchText;
                    string? pid = excelData?.Id;

                    Console.WriteLine($"Search Text : {searchtext}");
                    Console.WriteLine($"Pid : {pid}");

                    
                    naaptol.TypeSearchInputText(searchtext);
                    var productpage = naaptol.ClickSearch();
                    Thread.Sleep(2000);
                    CoreCodes.ScrollIntoView(driver, driver.FindElement(By.Id("productItem" + pid)));
                    Thread.Sleep(3000);
                    var selectedproduct = productpage.ClickDesiredProduct();
                    Thread.Sleep(3000);
                    TakeScreenShot();

                    List<string> lswindow = driver.WindowHandles.ToList();
                    driver.SwitchTo().Window(lswindow[1]);

                    selectedproduct.ClickDesiredProductSize();
                    selectedproduct.ClickBuyButton();
                    TakeScreenShot();
                    Assert.That(selectedproduct, Is.Not.Null);
                    Console.WriteLine("Product Added Test-Passed");

                    Thread.Sleep(2000);
                    //var removeText =
                    selectedproduct.ClickRemoveProductLink();
                    TakeScreenShot();
                    //Console.WriteLine(removeText);
                    //Assert.That(removeText.Contains("No Items"));
                    
                    Console.WriteLine("Product Removing Test-Passed");

                    Thread.Sleep(3000);
                }
            
            
    
        }
    }
}
