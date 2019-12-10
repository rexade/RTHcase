using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using LandindPageClass;
using static MySeleniumProject.TestInitializeClass;
using System.Threading;
using System;
using OpenQA.Selenium;


//using TearUp;
namespace MySeleniumProject
{

    [TestClass]
    public class Produkter
    {
        LandingPage landingPage = new LandingPage(driver);
        PageAssert pageAssert = new PageAssert(driver);
        DateTime Timer;
        TestInitializeClass chrome = new TestInitializeClass();
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void SetUp()  //Gå till URL
        {
            Timer = DateTime.Now;
            chrome.SetUp();
        }

        [TestCleanup]
        public void Clean() //Rensa cookies
        {
            chrome.CleanUp(TestContext, Timer);
        }


        [TestMethod]
        [TestCategory("Produkter")]
        public void MainPageToProducts()
        {
            landingPage.CookieBannerButton().SendKeys(Keys.Enter);
            pageAssert.AssertMainpage();
            landingPage.Products().Click();
            pageAssert.AssertProductpage();
        }

        [TestMethod]
        [TestCategory("Produkter")]

        public void ProductsToFurnitureDesk()
        {
            landingPage.CookieBannerButton().SendKeys(Keys.Enter);
            pageAssert.AssertMainpage();
            landingPage.Products().Click();
            pageAssert.AssertProductpage();
            landingPage.ProductsFurniture().Click();
            pageAssert.AssertProductMobler();
            landingPage.ProductsFurnitureTableAndDesks().Click();
            pageAssert.AssertProductMoblerBord();
        }

        [TestMethod]
        [TestCategory("Produkter")]

        public void ProductsToFurnitureDeskAddToCart()
        {
            landingPage.CookieBannerButton().SendKeys(Keys.Enter);
            pageAssert.AssertMainpage();
            landingPage.Products().Click();
            pageAssert.AssertProductpage();
            landingPage.ProductsFurniture().Click();
            pageAssert.AssertProductMobler();
            landingPage.ProductsFurnitureTableAndDesks().Click();
            pageAssert.AssertProductMoblerBord();
            landingPage.AddFurnitureTableAndDesks().Click();
            landingPage.AddFurnitureTableAndDesksToCart().Click();
            if (landingPage.CloseBannerCustomer().Displayed)
            {
                landingPage.CloseBannerCustomer().Click();
            }

        }

        [TestMethod]
        [TestCategory("Produkter")]
        public void ProductsTV()
        {

            landingPage.CookieBannerButton().SendKeys(Keys.Enter);
            landingPage.LOGO().Click();
            landingPage.Products().Click();
            pageAssert.AssertProductpage();// Assert

            landingPage.ProductsFurniture().Click();
            pageAssert.AssertProductMobler(); //assert

            landingPage.ProductsFurnitureTv().Click();
            pageAssert.AssertProductForvaringTv(); //assert
        }

        [TestMethod]
        [TestCategory("Produkter")]
        public void ProductsTextiles()
        {
            landingPage.CookieBannerButton().SendKeys(Keys.Enter);
            landingPage.LOGO().Click();
            landingPage.Products().Click();

            landingPage.ProductsTextiles().Click();
            pageAssert.AssertProductTextil(); //assert

            landingPage.ProductsTextilesKitchen().Click();
            pageAssert.AssertProductTextilKök(); //assert
        }

       

    }
}