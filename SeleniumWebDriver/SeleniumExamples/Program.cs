
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExamples;

GHPTests gHPTests = new();
List<string> browser = new List<string>();
browser.Add("Edge");
browser.Add("Chrome");
//Console.WriteLine("1. Edge   2. Chrome");
//int option=Convert.ToInt32(Console.ReadLine());
foreach (var browserItem in browser)
{
    switch (browserItem)
    {
        case "Edge":
            gHPTests.InitializeEdgeDriver();
            break;
        case "Chrome":
            gHPTests.InitializeChromeDriver();
            break;
    }
    try
    {
        //gHPTests.TitleTest();
        //gHPTests.PageSourceTest();
        //gHPTests.PageTestAndUrlTest();
        //gHPTests.GSTest();
        //gHPTests.GmailLinkTest();
        //gHPTests.GImageLinkTest();
        //gHPTests.LocalizationTest();
        gHPTests.GAppYoutubeTest();

    }
    catch (AssertionException)
    {
        Console.WriteLine("fail ");
    }
    catch(Exception)
    {
        Console.WriteLine("Failed");
    }
}
gHPTests.Destruct();
