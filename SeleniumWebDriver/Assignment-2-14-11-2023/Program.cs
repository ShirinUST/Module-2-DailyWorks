using Assignment_2_14_11_2023;
using NUnit.Framework;

NavigationTest navigation = new();
try
{
    navigation.Initilaization();
    navigation.NavigateToYahooTest();
    navigation.NavigateToGoogleTest();
    navigation.NavigateToYahooTest();
    navigation.NavigateToGoogleTest();
    navigation.SearchTest();
    navigation.RefreshTest();

}
catch(AssertionException)
{
    Console.WriteLine("Test failed");
}
finally
{
    navigation.Destruct();
}