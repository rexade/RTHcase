using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using LandindPageClass;
using static MySeleniumProject.TestInitializeClass;
using System.Threading;
using System;


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
            chrome.SetUp();
            Timer = DateTime.Now;
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

            landingPage.CookieBannerButton().Click();

        }

        [TestMethod, TestCategory("Startsidan")]

        public void MainPageCheck()
        {
            landingPage.CookieBannerButton().Click();
            pageAssert.AssertMainpage();        //finns assert som ska fixas!!

        }

        [TestMethod, TestCategory("Startsidan")]
        public void MainPageCheckLogo()
        {
            landingPage.CookieBannerButton().Click();
            landingPage.LOGO().Click();
            pageAssert.AssertMainpage();
        }

        [TestMethod, TestCategory("Startsidan")]
        public void MainPageGoToShopList()
        {
            landingPage.CookieBannerButton().Click();
            landingPage.LOGO().Click();
            pageAssert.AssertMainpage();
            landingPage.BuyList().Click();
            pageAssert.AssertInkop(); //Text "Inte redo att köpa riktigt än?"

        }

        [TestMethod, TestCategory("Startsidan")]
        public void MainPageGoToShopBag()
        {
            landingPage.CookieBannerButton().Click();
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
            landingPage.CookieBannerButton().Click();
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
            landingPage.CookieBannerButton().Click();
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
            landingPage.CookieBannerButton().Click();
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
            landingPage.CookieBannerButton().Click();
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
        }

        [TestMethod]
        [TestCategory("Startsidan")]
        [TestCategory("Produkter")]
        [TestCategory("Möbler")]
        [TestCategory("Kundvagn")]
        [TestCategory("CheckOut")]
        public void GoToFinalCheckOut()
        {
            landingPage.CookieBannerButton().Click();
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

        /*landingPage.ShoppingBag().Click();
        landingPage.BuyList().Click();          
        landingPage.Products().Click();
        landingPage.ProductsFurniture().Click();

        landingPage.ProductsFurnitureTableAndDesks().Click();
        pageAssert.AssertProductMoblerBord(); //assert

        /*landingPage.LOGO().Click();
        landingPage.Products().Click();
        pageAssert.AssertProductpage();// Assert

        landingPage.ProductsFurniture().Click();
        pageAssert.AssertProductMobler(); //assert

        landingPage.ProductsFurnitureTv().Click();
        pageAssert.AssertProductForvaringTv(); //assert

        landingPage.LOGO().Click();
        landingPage.Products().Click();

        landingPage.ProductsTextiles().Click();     
        pageAssert.AssertProductTextil(); //assert

        landingPage.ProductsTextilesKitchen().Click();
        pageAssert.AssertProductTextilKök(); //assert

        landingPage.LOGO().Click();
        landingPage.Products().Click();
        landingPage.ProductsTextiles().Click();

        landingPage.ProductsTextilesCurtains().Click();
        pageAssert.AssertProductTextilGard();  //assert

        landingPage.LOGO().Click();
        landingPage.MyProfile().Click();
        */

    }

}


    /*
    [TestClass]
    public class Inköpslistan
    {
        TestInitializeClass chrome = new TestInitializeClass();
        public TestContext TestContext { get; set; }


        /*[TestCleanup]
        public void Clean() //Rensa cookies
        {
            TestModel model = new TestModel();
            model.TestName = TestContext.TestName;
            model.TestCategory = TestContext.FullyQualifiedTestClassName;
            model.TestTime = DateTime.Now;
            model.TestStatus = TestContext.CurrentTestOutcome;

            MongoCRUD db = new MongoCRUD("IKEA");
            db.InsertRecord("Test", model);
            chrome.CleanUp(TestContext);
        }
        */
        /*
        [TestMethod, TestCategory("Inköplistan")]

        public void Buy()
        {

            chrome.SetUp();

            var pageElement = new LandingPage(driver);
           // var pageAssert = new PageAssert(driver);

            pageElement.CookieBannerButton().Click();

            pageElement.LOGO().Click();
            pageElement.MyBuyList().Click();

           // pageAssert.AssertInkop(); //assert
         //   pageAssert.AssertTabortInkop();  //assert
            pageElement.ProductsFromBuyList().Click();


            pageElement.LOGO().Click();
            pageElement.MyBuyList().Click();
            pageElement.LogInButtonBuyList().Click();
            pageElement.CreateAccountFromLogIn().Click();


            pageElement.LOGO().Click();
            pageElement.MyBuyList().Click();
            pageElement.CreateAccountBuyList().Click();

            pageElement.LOGO().Click();
          
        }

        [TestMethod, TestCategory("Inköplistan")]

        public void AvailableStore()
        {

            chrome.SetUp();

            var pageElement = new LandingPage(driver);
            var pageAssert = new PageAssert(driver);

            pageElement.CookieBannerButton().Click();


            pageElement.LOGO().Click();
            pageElement.Products().Click();
            pageElement.ProductsFurniture().Click();
            pageElement.ProductsFurnitureTableAndDesks().Click();
            pageElement.BuyItem().Click();
            pageElement.BuyItemAdd().Click();
            pageElement.ItemAddCheckBannerBuyList().Click();


            pageElement.MyBuyList().Click();
            pageElement.AvailableDepartmentStore().Click();
          //  pageAssert.AssertInkopTillganglig();  //assert funkar inte

        }

        [TestMethod, TestCategory("Inköplistan")]

        public void BuyCancelButton()
        {

            chrome.SetUp();

            var pageElement = new LandingPage(driver);
           
            pageElement.CookieBannerButton().Click();

            pageElement.LOGO().Click();


            pageElement.LOGO().Click();
            pageElement.Products().Click();
            pageElement.ProductsFurniture().Click();
            pageElement.ProductsFurnitureTableAndDesks().Click();
            pageElement.BuyItem().Click();
            pageElement.BuyItemAdd().Click();
            pageElement.ItemAddCheckBannerBuyList().Click();


            pageElement.LOGO().Click();
            pageElement.MyBuyList().Click();
            pageElement.DeleteProductInShopList().Click();
            pageElement.Cancel().Click();

        }

        [TestMethod, TestCategory("Inköplistan")]

        public void AddToShoppingBagFromBuyList()
        {

            chrome.SetUp();

            var pageElement = new LandingPage(driver);
             var pageAssert = new PageAssert(driver);

            pageElement.CookieBannerButton().Click();


            pageElement.LOGO().Click();
            pageElement.Products().Click();
            pageElement.ProductsFurniture().Click();
            pageElement.ProductsFurnitureTableAndDesks().Click();
            pageElement.BuyItem().Click();
            pageElement.BuyItemAdd().Click();
            pageElement.ItemAddCheckBannerBuyList().Click();


            pageElement.LOGO().Click();
            pageAssert.AssertGlobal(); //assert
            pageElement.MyBuyList().Click();
            pageElement.SelectAmount().Click();
            pageElement.SelectAmount().Click();
            pageElement.BuyOnline().Click();
            pageElement.AddToShoppingBagFromBuyList().Click();
            pageElement.CloseBannerKundVagn().Click();
        }


        [TestMethod, TestCategory("Inköplistan")]

        public void BuyDeleteButton()
        {

            chrome.SetUp();

            var pageElement = new LandingPage(driver);
             var pageAssert = new PageAssert(driver);

            pageElement.CookieBannerButton().Click();


            pageElement.LOGO().Click();
            pageAssert.AssertGlobal(); //assert

            pageElement.Products().Click();
            pageElement.ProductsFurniture().Click();
            pageElement.ProductsFurnitureTableAndDesks().Click();
            pageElement.BuyItem().Click();
            pageElement.BuyItemAdd().Click();
            pageElement.ItemAddCheckBannerBuyList().Click();


            pageElement.LOGO().Click();
            pageElement.MyBuyList().Click();
            pageElement.DeleteProductInShopList().Click();
            pageElement.DeleteItem().Click();


        }


    }




        [TestClass]
    public class KundVagn
    {
        TestInitializeClass chrome = new TestInitializeClass();
        public TestContext TestContext { get; set; }


        /* [TestCleanup]
         public void Clean() //Rensa cookies
         {
             TestModel model = new TestModel();
             model.TestName = TestContext.TestName;
             model.TestCategory = TestContext.FullyQualifiedTestClassName;
             model.TestTime = DateTime.Now;
             model.TestStatus = TestContext.CurrentTestOutcome;

             MongoCRUD db = new MongoCRUD("IKEA");
             db.InsertRecord("Test", model);
             chrome.CleanUp(TestContext);
         }
         */
        /*
        [TestMethod, TestCategory("Kundvagn")]

        public void Cart()
        {

            chrome.SetUp();

            var pageElement = new LandingPage(driver);
            var pageAssert = new PageAssert(driver);

            pageElement.CookieBannerButton().Click();

            pageElement.LOGO().Click();
            pageAssert.AssertGlobal(); //assert

            pageElement.CartIcon().Click();
            pageAssert.AssertKundvagn(); //assert

            pageElement.AddProductArtNr().Click();

            pageElement.InputFieldAddProductArtNr().Click();
            pageElement.InputFieldAddProductArtNr().SendKeys("52558555");

            pageElement.ProductQuantityList().Click();
            pageElement.ProductQuantityList().Click();
            pageElement.AddProductArtNrButton().Click();



            pageElement.LOGO().Click();
            pageElement.Products().Click();
            pageElement.ProductsFurniture().Click();
            pageElement.ProductsFurnitureTableAndDesks().Click();
            pageElement.BuyItem().Click();
            pageElement.ProductAddToCartButton().Click();


            pageElement.CartIcon().Click();
            pageElement.DeleteProductFromBuyList().Click();
            pageElement.CancelFromBuylist().Click();


            pageElement.CartIcon().Click();
            pageElement.DeleteProductFromBuyList().Click();
            pageElement.ConfirmDeleteFromBuyList().Click();
   
        }

        [TestMethod, TestCategory("Kundvagn")]

        public void CartCheckout()
        {

            chrome.SetUp();

            var pageElement = new LandingPage(driver);
            var pageAssert = new PageAssert(driver);

            pageElement.CookieBannerButton().Click();

            pageElement.LOGO().Click();

            pageElement.LOGO().Click();
            pageElement.Products().Click();
            pageElement.ProductsFurniture().Click();
            pageElement.ProductsFurnitureTableAndDesks().Click();
            pageElement.BuyItem().Click();
            pageElement.ProductAddToCartButton().Click();
            Thread.Sleep(1000);
            pageElement.CartIcon().Click();
            pageElement.GoToCheckOut().Click();

            pageElement.LOGO().Click();
            pageAssert.AssertGlobal(); //assert


        }


    }

        [TestClass]
    public class SökFält
    {
        TestInitializeClass chrome = new TestInitializeClass();
        public TestContext TestContext { get; set; }

        /*
        [TestCleanup]
        public void Clean() //Rensa cookies
        {
            TestModel model = new TestModel();
            model.TestName = TestContext.TestName;
            model.TestCategory = TestContext.FullyQualifiedTestClassName;
            model.TestTime = DateTime.Now;
            model.TestStatus = TestContext.CurrentTestOutcome;

            MongoCRUD db = new MongoCRUD("IKEA");
            db.InsertRecord("Test", model);
            chrome.CleanUp(TestContext);
        }
        */
        /*
        [TestMethod, TestCategory("Sökfältet")]

        public void SearchFieldAssert()
        {

            chrome.SetUp();

            var pageElement = new LandingPage(driver);
            var pageAssert = new PageAssert(driver);
            pageElement.LOGO().Click();
            pageElement.SearchField().Click();         
            pageElement.SearchField().Clear();
            pageElement.SearchField().SendKeys("DOCKSTA");
            pageElement.SearchFieldSumbit().Click();
           // pageAssert.FindItemBord();//assert                       Assert fungerar inte


            pageElement.LOGO().Click();
            pageElement.SearchField().Click();
            pageElement.SearchField().Clear();
            pageElement.SearchField().SendKeys("TOBIAS");
            pageElement.SearchFieldSumbit().Click();
         //   pageAssert.FindItemStol(); //assert                          Assert fungerar inte

        }


        [TestMethod, TestCategory("Sökfältet")]

        public void SearchField()
        {

            chrome.SetUp();

            var pageElement = new LandingPage(driver);
           



            string fp = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).FullName;
            string folderPath = Path.Combine(fp, "Selenium.txt");


            pageElement.CookieBannerButton().Click();
            pageElement.LOGO().Click();

            int counter = 0;
            string line;

            using (StreamReader st = new StreamReader(folderPath))
            {

                while ((line = st.ReadLine()) != null)
                {
                    pageElement.SearchField().Click();               
                    pageElement.SearchField().Clear();
                    pageElement.SearchField().SendKeys(line);
                    pageElement.SearchFieldSumbit().Click();
                    counter++;
                }
                st.Close();
               
            }
         
        }

    }




        [TestClass]
    public class MinProfil
    {
        TestInitializeClass chrome = new TestInitializeClass();
        public TestContext TestContext { get; set; }

        /*
        [TestCleanup]
        public void Clean() //Rensa cookies
        {
            TestModel model = new TestModel();
            model.TestName = TestContext.TestName;
            model.TestCategory = TestContext.FullyQualifiedTestClassName;
            model.TestTime = DateTime.Now;
            model.TestStatus = TestContext.CurrentTestOutcome;

            MongoCRUD db = new MongoCRUD("IKEA");
            db.InsertRecord("Test", model);
            chrome.CleanUp(TestContext);
        
        }
        */
        /*
        [TestMethod, TestCategory("Min Profil")]

        public void Profile()
        {

            chrome.SetUp();

            var pageElement = new LandingPage(driver);
           // var pageAssert = new PageAssert(driver);

            pageElement.CookieBannerButton().Click();

            pageElement.LOGO().Click();

            pageElement.ProfileIcon().Click();

            pageElement.Username().Click();
            pageElement.Username().SendKeys("exampl@gmail.com");

            pageElement.Password().Click();
            pageElement.Password().SendKeys("selenium");
            pageElement.LoginButton().Click();

            //pageAssert.AssertLoginFail(); //assert funkar inte

            // pageAssert.AssertLoginRightemailWrongpass(); //assert  funkar inte
           // pageAssert.AssertLoginSuccess(); // assert som går inte att tesa just nu har inga konto?

            pageElement.LostPassword().Click();
            pageElement.CreateFamilyAccount().Click();

            //pageAssert.AssertIkeaFamilyRubrik(); //assert funkar inte


            pageElement.LOGO().Click();
            pageElement.ProfileIcon().Click();
            pageElement.CreateAccount().Click();

            pageElement.LOGO().Click();

               
        }

    } */



