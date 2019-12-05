using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using LandindPageClass;
using static MySeleniumProject.TestInitializeClass;
using System.Threading;


//using TearUp;
namespace MySeleniumProject
{

    [TestClass]
    public class StartSidan
    {
        TestInitializeClass chrome = new TestInitializeClass();
        public TestContext TestContext { get; set; }


        [TestCleanup]
        public void Clean() //Rensa cookies
        {

            chrome.CleanUp(TestContext);
        }


        [TestInitialize]
        public void SetUp()
        {

            chrome.SetUp();
        }


        [TestMethod, TestCategory ("Startsidan")]

        public void Products()
        {

            var pageElement = new LandingPage(driver);
            var pageAssert = new PageAssert(driver);

             

            pageElement.CookieBannerButton().Click();
            
            pageElement.LOGO().Click();

            pageAssert.AssertMainpage();        //finns assert som ska fixas!!

            pageElement.ShoppingBag().Click();
            pageElement.BuyList().Click();          
            pageElement.Products().Click();
            pageElement.ProductsFurniture().Click();

            pageElement.ProductsFurnitureTableAndDesks().Click();
            pageAssert.AssertProductMoblerBord(); //assert

            pageElement.LOGO().Click();
            pageElement.Products().Click();
            pageAssert.AssertProductpage();// Assert

            pageElement.ProductsFurniture().Click();
            pageAssert.AssertProductMobler(); //assert

            pageElement.ProductsFurnitureTv().Click();
            pageAssert.AssertProductForvaringTv(); //assert

            pageElement.LOGO().Click();
            pageElement.Products().Click();

            pageElement.ProductsTextiles().Click();     
            pageAssert.AssertProductTextil(); //assert
         
            pageElement.ProductsTextilesKitchen().Click();
            pageAssert.AssertProductTextilKök(); //assert



        }
        [TestMethod, TestCategory("Startsidan")]
        public void ProductsDel2()
        {

            

            var pageElement = new LandingPage(driver);
            var pageAssert = new PageAssert(driver);


            pageElement.CookieBannerButton().Click();

         
            pageElement.LOGO().Click();
            pageElement.Products().Click();
            pageElement.ProductsTextiles().Click();
            
            pageElement.ProductsTextilesCurtains().Click();
            pageAssert.AssertProductTextilGard();  //assert
           
            pageElement.LOGO().Click();
            pageElement.MyProfile().Click();

        }

        }



        [TestClass]
    public class Inköpslistan
    {
        TestInitializeClass chrome = new TestInitializeClass();
        public TestContext TestContext { get; set; }


        [TestCleanup]
        public void Clean() //Rensa cookies
        {

            chrome.CleanUp(TestContext);
        }


        [TestInitialize]
        public void SetUp()
        {

            chrome.SetUp();
        }

        [TestMethod, TestCategory("Inköplistan")]

        public void Buy()
        {

          
            var pageElement = new LandingPage(driver);
            var pageAssert = new PageAssert(driver);

          

            pageElement.LOGO().Click();
            //pageElement.CookieBannerButton().Click();
            pageElement.MyBuyList().Click();

            pageAssert.AssertInkop(); //assert           
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
            pageAssert.AssertTabortInkop();  //assert
            pageElement.DeleteItem().Click();


        }


    }




        [TestClass]
    public class KundVagn
    {
        TestInitializeClass chrome = new TestInitializeClass();
        public TestContext TestContext { get; set; }


        [TestCleanup]
        public void Clean() //Rensa cookies
        {

            chrome.CleanUp(TestContext);
        }

        [TestInitialize]
        public void SetUp()
        {

            chrome.SetUp();
        }


        [TestMethod, TestCategory("KundVagn")]

        public void Cart()
        {

          

            var pageElement = new LandingPage(driver);
           var pageAssert = new PageAssert(driver);

            pageElement.CookieBannerButton().Click();
         
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

            pageElement.CloseBannerIfDisplayed();
            pageElement.LOGO().Click();
            pageElement.CartIcon().Click();
            pageElement.DeleteProductFromBuyList().Click();
            pageElement.CancelFromBuylist().Click();

            pageElement.LOGO().Click();
            pageElement.CartIcon().Click();
            pageElement.DeleteProductFromBuyList().Click();
            pageElement.ConfirmDeleteFromBuyList().Click();
            
     




        }

        [TestMethod, TestCategory("KundVagn")]

        public void CartCheckout()
        {

           
            var pageElement = new LandingPage(driver);
            var pageAssert = new PageAssert(driver);

            pageElement.CookieBannerButton().Click();
                       
            pageElement.Products().Click();
            pageElement.ProductsFurniture().Click();
            pageElement.ProductsFurnitureTableAndDesks().Click();
            pageElement.BuyItem().Click();
            // var n = pageElement.getNbrOfItemsInCart();
            pageElement.ProductAddToCartButton().Click();
            // pageElement.WaitUntilCartContainsNbrOfElement(n + 1);
            Thread.Sleep(1000);
            pageElement.CloseBannerIfDisplayed();
            pageElement.CartIcon().Click();
            pageElement.GoToCheckOut().Click();


            pageElement.LOGO().Click();
             pageAssert.AssertGlobal(); //assert*/


        }


    }




        [TestClass]
    public class SökFält
    {
        TestInitializeClass chrome = new TestInitializeClass();
        public TestContext TestContext { get; set; }


        [TestCleanup]
        public void Clean() //Rensa cookies
        {

            chrome.CleanUp(TestContext);
        }

        [TestInitialize]
        public void SetUp()
        {

            chrome.SetUp();
        }
        [TestMethod, TestCategory("Sökfältet")]

        public void SearchFieldAssert()
        {

           
            var pageElement = new LandingPage(driver);
           var pageAssert = new PageAssert(driver);
            pageElement.LOGO().Click();
            pageElement.SearchField().Click();         
            pageElement.SearchField().Clear();
            pageElement.SearchField().SendKeys("DOCKSTA");
            pageElement.SearchFieldSumbit().Click();
            pageAssert.FindItemBord();//assert                       Assert fungerar inte


            pageElement.LOGO().Click();
            pageElement.SearchField().Click();
            pageElement.SearchField().Clear();
            pageElement.SearchField().SendKeys("TOBIAS");
            pageElement.SearchFieldSumbit().Click();
            pageAssert.FindItemStol(); //assert                          Assert fungerar inte

        }


        [TestMethod, TestCategory("Sökfältet")]

        public void SearchField()
        {

           
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


        [TestCleanup]
        public void Clean() //Rensa cookies
        {

            chrome.CleanUp(TestContext);
        }

        [TestInitialize]
        public void SetUp()
        {

            chrome.SetUp();
        }


        [TestMethod, TestCategory("Min Profil")]

        public void Profile()
        {

           

            var pageElement = new LandingPage(driver);
            var pageAssert = new PageAssert(driver);

            pageElement.CookieBannerButton().Click();

            pageElement.LOGO().Click();

            pageElement.ProfileIcon().Click();

            pageElement.Username().Click();
            pageElement.Username().SendKeys("exampl@gmail.com");

            pageElement.Password().Click();
            pageElement.Password().SendKeys("selenium");
            pageElement.LoginButton().Click();

            pageAssert.AssertLoginFail(); //assert 

            // pageAssert.AssertLoginRightemailWrongpass(); //assert  funkar inte
           // pageAssert.AssertLoginSuccess(); // assert som går inte att tesa just nu har inga konto?

            pageElement.LostPassword().Click();
            pageElement.CreateFamilyAccount().Click();

            pageAssert.AssertIkeaFamilyRubrik(); //assert 


            pageElement.LOGO().Click();
            pageElement.ProfileIcon().Click();
            pageElement.CreateAccount().Click();

            pageElement.LOGO().Click();

               
        }

    }


 }



