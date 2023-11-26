﻿using CaseStudy_1_Naaptol.Utilities;
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
        [TestCase("eyewear",5)]
        public void ProductSearchTest(string search,int id)
        {
            NaaptolHomePage naaptol = new(driver);
            naaptol.TypeSearchInputText(search);
            var productpage=naaptol.ClickSearch();
            Thread.Sleep(2000);
            CoreCodes.ScrollIntoView(driver, driver.FindElement(By.Id("productItem"+id)));
            Thread.Sleep(3000);
            var selectedproduct=productpage.ClickDesiredProduct();
            Thread.Sleep(3000);

            List<string> lswindow = driver.WindowHandles.ToList();
            driver.SwitchTo().Window(lswindow[1]);

            selectedproduct.ClickDesiredProductSize();
            selectedproduct.ClickBuyButton();
           
        }
    }
}
