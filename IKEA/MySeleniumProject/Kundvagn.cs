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
    public class Kundvagn
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
        [TestCategory("Kundvagn")]
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
        [TestCategory("Kundvagn")]

        public void AddToCart()
        {
            landingPage.CookieBannerButton().SendKeys(Keys.Enter);

            pageAssert.AssertGlobal(); //assert

            landingPage.CartIcon().Click();
            pageAssert.AssertKundvagn(); //assert

            landingPage.AddProductArtNr().Click();

            landingPage.InputFieldAddProductArtNr().Click();
            landingPage.InputFieldAddProductArtNr().SendKeys("52558555");

            landingPage.ProductQuantityList().Click();
            landingPage.ProductQuantityList().Click();
            landingPage.AddProductArtNrButton().Click();

            landingPage.LOGO().Click();
            landingPage.Products().Click();
            landingPage.ProductsFurniture().Click();
            landingPage.ProductsFurnitureTableAndDesks().Click();
            landingPage.BuyItem().Click();
            landingPage.ProductAddToCartButton().Click();
        }

        [TestMethod]
        [TestCategory("Kundvagn")]

        public void Cart()
        {
            landingPage.CookieBannerButton().SendKeys(Keys.Enter);

            pageAssert.AssertGlobal(); //assert

            landingPage.CartIcon().Click();
            pageAssert.AssertKundvagn(); //assert

            landingPage.AddProductArtNr().Click();

            landingPage.InputFieldAddProductArtNr().Click();
            landingPage.InputFieldAddProductArtNr().SendKeys("52558555");

            landingPage.ProductQuantityList().Click();
            landingPage.ProductQuantityList().Click();
            landingPage.AddProductArtNrButton().Click();

            landingPage.LOGO().Click();
            landingPage.Products().Click();
            landingPage.ProductsFurniture().Click();
            landingPage.ProductsFurnitureTableAndDesks().Click();
            landingPage.BuyItem().Click();
            landingPage.ProductAddToCartButton().Click();

            landingPage.LOGO().Click();
            landingPage.CartIcon().Click();
            landingPage.DeleteProductFromBuyList().Click();
            landingPage.CancelFromBuylist().Click();

            landingPage.LOGO().Click();
            landingPage.CartIcon().Click();
            landingPage.DeleteProductFromBuyList().Click();
            landingPage.ConfirmDeleteFromBuyList().Click();
        }

        [TestMethod]
        [TestCategory("Kundvagn")]

        public void CartCheckout()
        {
            landingPage.CookieBannerButton().SendKeys(Keys.Enter);

            landingPage.Products().Click();
            landingPage.ProductsFurniture().Click();
            landingPage.ProductsFurnitureTableAndDesks().Click();
            landingPage.BuyItem().Click();
            landingPage.ProductAddToCartButton().Click();

            landingPage.CartIcon().Click();
            landingPage.GoToCheckOut().Click();

            landingPage.LOGO().Click();
            pageAssert.AssertGlobal(); //assert
        }

        [TestMethod]
        [TestCategory("Kundvagn")]
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
    }
}