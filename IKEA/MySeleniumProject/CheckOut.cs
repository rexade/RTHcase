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
    public class CheckOut
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

        [TestMethod]
        [TestCategory("CheckOut")]
        public void GoToFinalCheckOut()
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
            else
            {
                landingPage.CartIcon().Click();
            }
            landingPage.GoToCheckOut().Click();
        }

        [TestMethod]
        [TestCategory("CheckOut")]
        public void GoToCheckOut()
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
                landingPage.CloseBannerCustomer().SendKeys(Keys.Enter);
            }
            else
            {
                landingPage.CartIcon().Click();
            }
        }

    }
}