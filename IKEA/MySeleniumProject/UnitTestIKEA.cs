/*using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using LandindPageClass;
using static MySeleniumProject.TestInitializeClass;
using System.Threading;
using System;
using OpenQA.Selenium;


using TearUp;
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

        public void ProductsFurnitureTable()
        {

            landingPage.CookieBannerButton().Click();

            landingPage.LOGO().Click();

            pageAssert.AssertMainpage();        //finns assert som ska fixas!!

            landingPage.ShoppingBag().Click();
            landingPage.BuyList().Click();
            landingPage.Products().Click();
            landingPage.ProductsFurniture().Click();

            landingPage.ProductsFurnitureTableAndDesks().Click();
            pageAssert.AssertProductMoblerBord(); //assert
        }
    

        [TestMethod]
        [TestCategory("Produkter")]
        public void ProductsTV()
        {

            landingPage.CookieBannerButton().Click();
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
        public void ProductsKitchen()
        {
            landingPage.CookieBannerButton().Click();
            landingPage.LOGO().Click();
            landingPage.Products().Click();

            landingPage.ProductsTextiles().Click();
            pageAssert.AssertProductTextil(); //assert

            landingPage.ProductsTextilesKitchen().Click();
            pageAssert.AssertProductTextilKök(); //assert
        }

        [TestMethod, TestCategory("Startsidan")]
        public void ProductsDel2()
        {
            landingPage.CookieBannerButton().Click();

            landingPage.LOGO().Click();
            landingPage.Products().Click();
            landingPage.ProductsTextiles().Click();

            landingPage.ProductsTextilesCurtains().Click();
            pageAssert.AssertProductTextilGard();  //assert

            landingPage.LOGO().Click();
            landingPage.MyProfile().Click();
        }

        [TestMethod, TestCategory("Inköplistan")]

        public void Buy()
        {

            landingPage.LOGO().Click();
            //pageElement.CookieBannerButton().Click();
            landingPage.MyBuyList().Click();

            pageAssert.AssertInkop(); //assert           
            landingPage.ProductsFromBuyList().Click();


            landingPage.LOGO().Click();
            landingPage.MyBuyList().Click();
            landingPage.LogInButtonBuyList().Click();
            landingPage.CreateAccountFromLogIn().Click();


            landingPage.LOGO().Click();
            landingPage.MyBuyList().Click();
            landingPage.CreateAccountBuyList().Click();

            landingPage.LOGO().Click();

        }

        [TestMethod] 
        [TestCategory("Inköplistan")]

        public void AvailableStore()
        {
            landingPage.CookieBannerButton().Click();

            landingPage.LOGO().Click();
            landingPage.Products().Click();
            landingPage.ProductsFurniture().Click();
            landingPage.ProductsFurnitureTableAndDesks().Click();
            landingPage.BuyItem().Click();
            landingPage.BuyItemAdd().Click();
            landingPage.ItemAddCheckBannerBuyList().Click();

            landingPage.MyBuyList().Click();
            landingPage.AvailableDepartmentStore().Click();
            //  pageAssert.AssertInkopTillganglig();  //assert funkar inte

        }

        [TestMethod] 
        [TestCategory("Inköplistan")]

        public void BuyCancelButton()
        {

            landingPage.CookieBannerButton().Click();

            landingPage.LOGO().Click();

            landingPage.LOGO().Click();
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
            landingPage.CookieBannerButton().Click();


            landingPage.LOGO().Click();
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
            landingPage.LOGO().Click();
            pageAssert.AssertGlobal(); //assert
            landingPage.MyBuyList().Click();
            landingPage.SelectAmount().Click();
            landingPage.SelectAmount().Click();
            landingPage.BuyOnline().Click();
            landingPage.AddToShoppingBagFromBuyList().Click();
            landingPage.CloseBannerKundVagn().Click();
        }

        [TestMethod] 
        [TestCategory("Inköplistan")]

        public void BuyDeleteButton()
        {
            landingPage.CookieBannerButton().Click();


            landingPage.LOGO().Click();
            pageAssert.AssertGlobal(); //assert

            landingPage.Products().Click();
            landingPage.ProductsFurniture().Click();
            landingPage.ProductsFurnitureTableAndDesks().Click();
            landingPage.BuyItem().Click();
            landingPage.BuyItemAdd().Click();
            landingPage.ItemAddCheckBannerBuyList().Click();


            landingPage.LOGO().Click();
            landingPage.MyBuyList().Click();
            landingPage.DeleteProductInShopList().Click();
            pageAssert.AssertTabortInkop();  //assert
            landingPage.DeleteItem().Click();
        }

        [TestMethod]
        [TestCategory("Kundvagn")]

        public void AddToCart()
        {
            landingPage.CookieBannerButton().Click();

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
            landingPage.CookieBannerButton().Click();

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

            //landingPage.CloseBannerIfDisplayed();
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
            landingPage.CookieBannerButton().Click();

            landingPage.Products().Click();
            landingPage.ProductsFurniture().Click();
            landingPage.ProductsFurnitureTableAndDesks().Click();
            landingPage.BuyItem().Click();
            // var n = pageElement.getNbrOfItemsInCart();
            landingPage.ProductAddToCartButton().Click();
            // pageElement.WaitUntilCartContainsNbrOfElement(n + 1);
            //landingPage.CloseBannerIfDisplayed();
            landingPage.CartIcon().Click();
            landingPage.GoToCheckOut().Click();

            landingPage.LOGO().Click();
            pageAssert.AssertGlobal(); //assert
        }

        [TestMethod]
        [TestCategory("Sökfältet")]

        public void SearchFielDocksta()
        {

            landingPage.LOGO().Click();
            landingPage.SearchField().Click();
            landingPage.SearchField().Clear();
            landingPage.SearchField().SendKeys("DOCKSTA");
            landingPage.SearchFieldSumbit().Click();
            pageAssert.FindItemBord();//assert                       Assert fungerar inte
        }

        [TestMethod]
        [TestCategory("Sökfältet")]

        public void SearchFieldTobias()
        { 
            landingPage.LOGO().Click();
            landingPage.SearchField().Click();
            landingPage.SearchField().Clear();
            landingPage.SearchField().SendKeys("TOBIAS");
            landingPage.SearchFieldSumbit().Click();
            pageAssert.FindItemStol(); //assert                          Assert fungerar inte

        }

        [TestMethod] 
        [TestCategory("Sökfältet")]

        public void SearchField()
        {
            string fp = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).FullName;
            string folderPath = Path.Combine(fp, "Selenium.txt");

            landingPage.CookieBannerButton().Click();
            landingPage.LOGO().Click();

            int counter = 0;
            string line;

            using (StreamReader st = new StreamReader(folderPath))
            {

                while ((line = st.ReadLine()) != null)
                {
                    landingPage.SearchField().Click();
                    landingPage.SearchField().Clear();
                    landingPage.SearchField().SendKeys(line);
                    landingPage.SearchFieldSumbit().Click();
                    counter++;
                }
                st.Close();
            }
        }

        [TestMethod]
        [TestCategory("Min Profil")]

        public void LoginTestInvalidUser()
        {

            landingPage.CookieBannerButton().Click();

            landingPage.LOGO().Click();

            landingPage.ProfileIcon().Click();

            landingPage.Username().Click();
            landingPage.Username().SendKeys("exampl@gmail.com");

            landingPage.Password().Click();
            landingPage.Password().SendKeys("selenium");
            landingPage.LoginButton().Click();

            pageAssert.AssertLoginFail(); //assert 
        }

        [TestMethod] 
        [TestCategory("Min Profil")]

        public void ProfileLoginFail()
        {

            landingPage.CookieBannerButton().Click();

            landingPage.LOGO().Click();

            landingPage.ProfileIcon().Click();

            landingPage.Username().Click();
            landingPage.Username().SendKeys("exampl@gmail.com");

            landingPage.Password().Click();
            landingPage.Password().SendKeys("selenium");
            landingPage.LoginButton().Click();

            pageAssert.AssertLoginFail(); //assert 

            // pageAssert.AssertLoginRightemailWrongpass(); //assert  funkar inte
            // pageAssert.AssertLoginSuccess(); // assert som går inte att tesa just nu har inga konto?

            landingPage.LostPassword().Click();
            landingPage.CreateFamilyAccount().Click();

            pageAssert.AssertIkeaFamilyRubrik(); //assert 

            landingPage.LOGO().Click();
            landingPage.ProfileIcon().Click();
            landingPage.CreateAccount().Click();

            landingPage.LOGO().Click();
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
*/

