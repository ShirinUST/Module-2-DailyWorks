using Assignment_1_14_11_2023;
using NUnit.Framework;

AmazonTesting amazon = new();
try
{

    amazon.Initialization();
    amazon.TitleTest();
    amazon.CheckUrlTest();
   
}
catch(AssertionException)
{
    Console.WriteLine("Failed");
}
finally
{
    amazon.Destruct();
}