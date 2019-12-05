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
    public class Ikea
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
            TestModel model = new TestModel();
            model.TestTime = DateTime.Now;
            TimeSpan diff = (model.TestTime - Timer);
            model.DurationTime = diff.TotalSeconds;
            model.TestName = TestContext.TestName;
            model.TestCategory = GetTestCategories(TestContext);

            if (TestContext.CurrentTestOutcome == UnitTestOutcome.Passed)
            {
                model.TestStatus = "Passed";
            }
            else if (TestContext.CurrentTestOutcome == UnitTestOutcome.Failed)
            {
                model.TestStatus = "Failed";
            }
            else
            {
                model.TestStatus = "N/A";
            }


            MongoCRUD db = new MongoCRUD("IKEA");
            db.InsertRecord("Test", model);
            chrome.CleanUp(TestContext);
        }

        private string[] GetTestCategories(TestContext context)
        {
            var attributes = Type.GetType(context.FullyQualifiedTestClassName).GetMethod(context.TestName)
                .GetCustomAttributes(typeof(TestCategoryAttribute), true);

            string[] categories = new string[attributes.Length];

            for (int i = 0; i < attributes.Length; i++)
            {
                categories[i] = (((TestCategoryAttribute)attributes[i]).TestCategories[0]);
            }
            Array.Sort(categories, StringComparer.InvariantCulture);
            return categories;
        }

        [TestMethod]
        [TestCategory("Startsida")]
        [TestCategory("Cookiebanner")]
        public void CookieBanner()
        {

            landingPage.CookieBannerButton().SendKeys(Keys.Enter);

        }

        [TestMethod, TestCategory("Startsidan")]

        public void MainPageCheck()
        {
            landingPage.CookieBannerButton().SendKeys(Keys.Enter);
            pageAssert.AssertMainpage();
        }

        [TestMethod, TestCategory("Startsidan")]
        public void MainPageCheckLogo()
        {
            landingPage.CookieBannerButton().SendKeys(Keys.Enter);
            landingPage.LOGO().Click();
            pageAssert.AssertMainpage();
        }

        [TestMethod, TestCategory("Startsidan")]
        public void MainPageGoToShopList()
        {
            landingPage.CookieBannerButton().SendKeys(Keys.Enter);
            landingPage.LOGO().Click();
            pageAssert.AssertMainpage();
            landingPage.BuyList().Click();
            pageAssert.AssertInkop(); //Text "Inte redo att köpa riktigt än?"

        }

        [TestMethod, TestCategory("Startsidan")]
        public void MainPageGoToShopBag()
        {
            landingPage.CookieBannerButton().SendKeys(Keys.Enter);
            landingPage.LOGO().Click();
            pageAssert.AssertMainpage();
            landingPage.ShoppingBag().Click();
            pageAssert.AssertKundvagn();
        }

        [TestMethod]
        [TestCategory("Startsidan")]
        [TestCategory("Produkter")]
        public void MainPageToProducts()
        {
            landingPage.CookieBannerButton().SendKeys(Keys.Enter);
            pageAssert.AssertMainpage();
            landingPage.Products().Click();
            pageAssert.AssertProductpage();
        }

        [TestMethod]
        [TestCategory("Startsidan")]
        [TestCategory("Produkter")]
        [TestCategory("Möbler")]
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
        [TestCategory("Startsidan")]
        [TestCategory("Produkter")]
        [TestCategory("Möbler")]
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
        [TestCategory("Startsidan")]
        [TestCategory("Produkter")]
        [TestCategory("Möbler")]
        [TestCategory("Kundvagn")]
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

        [TestMethod]
        [TestCategory("Startsidan")]
        [TestCategory("Produkter")]
        [TestCategory("Möbler")]
        [TestCategory("Kundvagn")]
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
    }
}

