
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExamples;

//2.

AmazonTest amazon= new();
List<string> browser = new List<string>();
//browser.Add("Edge");
browser.Add("Chrome");
//Console.WriteLine("1. Edge   2. Chrome");
//int option=Convert.ToInt32(Console.ReadLine());
foreach (var browserItem in browser)
{
    switch (browserItem)
    {
        //case "Edge":
        //    amazon.InitializeEdgeDriver();
        //    break;
        case "Chrome":
            amazon.InitializeChromeDriver();
            break;
    }
    try
    {
        //amazon.TitleTest();
        //amazon.LogoClickTest();
        //amazon.SearchProductTest();
        //amazon.ReloadHomePage();
        //amazon.TodaysDealsTest();
        //amazon.SignInAccListTest();
        amazon.SearchAndFilterProductByBrandTest();
        //Thread.Sleep(1000);

    }
    catch (AssertionException)
    {
        Console.WriteLine("Fail");
    }
    catch(NoSuchElementException nse)
    {
        Console.WriteLine(nse.Message);
    }
    catch (Exception)
    {
        Console.WriteLine("Failed");
    }
    amazon.Destruct();
}


//1.

//GHPTests gHPTests = new();
//List<string> browser = new List<string>();
////browser.Add("Edge");
//browser.Add("Chrome");
////Console.WriteLine("1. Edge   2. Chrome");
////int option=Convert.ToInt32(Console.ReadLine());
//foreach (var browserItem in browser)
//{
//    switch (browserItem)
//    {
//        //case "Edge":
//        //    gHPTests.InitializeEdgeDriver();
//        //    break;
//        case "Chrome":
//            gHPTests.InitializeChromeDriver();
//            break;
//    }
//    try
//    {
//        //gHPTests.TitleTest();
//        //gHPTests.PageSourceTest();
//        //gHPTests.PageTestAndUrlTest();
//        //gHPTests.GSTest();
//        //gHPTests.GmailLinkTest();
//        //gHPTests.GImageLinkTest();
//        //gHPTests.LocalizationTest();
//        gHPTests.GAppYoutubeTest();

//    }
//    catch (AssertionException)
//    {
//        Console.WriteLine("fail ");
//    }
//    catch(Exception)
//    {
//        Console.WriteLine("Failed");
//    }
//}
//gHPTests.Destruct();
