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
    public class Inkopslista
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
        [TestCategory("Inköplistan")]

        public void Buy()
        {

            landingPage.CookieBannerButton().SendKeys(Keys.Enter);
            landingPage.MyBuyList().Click();

            pageAssert.AssertInkop(); //assert           
            landingPage.ProductsFromBuyList().Click();

            landingPage.MyBuyList().Click();
            landingPage.LogInButtonBuyList().Click();
            landingPage.CreateAccountFromLogIn().Click();

            landingPage.MyBuyList().Click();
            landingPage.CreateAccountBuyList().Click();
            pageAssert.AssertCreateNewAccount();


        }

        [TestMethod]
        [TestCategory("Inköplistan")]

        public void AvailableStore()
        {
            landingPage.CookieBannerButton().SendKeys(Keys.Enter);

            landingPage.Products().Click();
            landingPage.ProductsFurniture().Click();
            landingPage.ProductsFurnitureTableAndDesks().Click();
            landingPage.BuyItem().Click();
            landingPage.BuyItemAdd().Click();
            landingPage.ItemAddCheckBannerBuyList().Click();

            landingPage.MyBuyList().Click();
            landingPage.AvailableDepartmentStore().Click();
            pageAssert.AssertInkopTillganglig();  //assert funkar inte

        }

        [TestMethod]
        [TestCategory("Inköplistan")]

        public void BuyCancelButton()
        {

            landingPage.CookieBannerButton().SendKeys(Keys.Enter);
            landingPage.Products().Click();
            landingPage.ProductsFurniture().Click();
            landingPage.ProductsFurnitureTableAndDesks().Click();
            landingPage.BuyItem().Click();
            landingPage.BuyItemAdd().Click();
            landingPage.ItemAddCheckBannerBuyList().Click();

            landingPage.LOGO().Click();
            landingPage.MyBuyList().Click();
            landingPage.DeleteProductInShopList().Click();
            landingPage.Cancel().Click();

        }

        [TestMethod]
        [TestCategory("Inköplistan")]

        public void AddToShoppingBagFromBuyList()
        {
            landingPage.CookieBannerButton().SendKeys(Keys.Enter);
            landingPage.Products().Click();
            landingPage.ProductsFurniture().Click();
            landingPage.ProductsFurnitureTableAndDesks().Click();
            landingPage.BuyItem().Click();
            landingPage.BuyItemAdd().Click();
            landingPage.ItemAddCheckBannerBuyList().Click();
        }

        [TestMethod]
        [TestCategory("Inköplistan")]

        public void AddToShoppingBagFromBuyListCloseBanner()
        {
            landingPage.CookieBannerButton().SendKeys(Keys.Enter);
            pageAssert.AssertGlobal(); //assert
            landingPage.Products().Click();
            landingPage.ProductsFurniture().Click();
            landingPage.ProductsFurnitureTableAndDesks().Click();
            landingPage.AddFurnitureTableAndDesks().Click();
            landingPage.AddFurnitureTableAndDesksToCart().Click();

            landingPage.CartIcon().Click();
            landingPage.SelectAmount().Click();
            landingPage.GoToCheckOut().Click();
            landingPage.ZipCode().SendKeys("123 45");
            
        }

        [TestMethod]
        [TestCategory("Inköplistan")]

        public void BuyDeleteButton()
        {
            landingPage.CookieBannerButton().SendKeys(Keys.Enter);
            pageAssert.AssertGlobal(); //assert

            landingPage.Products().Click();
            landingPage.ProductsFurniture().Click();
            landingPage.ProductsFurnitureTableAndDesks().Click();
            landingPage.BuyItem().Click();
            landingPage.BuyItemAdd().Click();
            landingPage.ItemAddCheckBannerBuyList().Click();

            landingPage.MyBuyList().Click();
            landingPage.DeleteProductInShopList().Click();
            pageAssert.AssertTabortInkop();  //assert
            landingPage.DeleteItem().Click();
        }

    }
}