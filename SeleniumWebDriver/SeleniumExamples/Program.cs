
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExamples;

GHPTests gHPTests = new();
List<string> browser = new List<string>();
browser.Add("Edge");
browser.Add("Chrome");
Console.WriteLine("1. Edge   2. Chrome");
int option=Convert.ToInt32(Console.ReadLine());
switch(option)
{
    case 1:
        gHPTests.InitializeEdgeDriver();
        break;
    case 2:
        gHPTests.InitializeChromeDriver();
        break;
}

try
{
    gHPTests.TitleTest();
    gHPTests.PageSourceTest();
    gHPTests.PageTestAndUrlTest();
    gHPTests.GSTest();
    gHPTests.GmailLinkTest();
    gHPTests.GImageLinkTest();
    gHPTests.LocalizationTest();

}
catch(AssertionException)
{
    Console.WriteLine("fail ");
}
gHPTests.Destruct();