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
    public class Startsida
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
        [TestCategory("Startsida")]
        public void CookieBanner()
        {

            landingPage.CookieBannerButton().SendKeys(Keys.Enter);

        }

        [TestMethod] 
        [TestCategory("Startsidan")]

        public void MainPageCheck()
        {
            landingPage.CookieBannerButton().SendKeys(Keys.Enter);
            pageAssert.AssertMainpage();
        }

        [TestMethod] 
        [TestCategory("Startsidan")]
        public void MainPageCheckLogo()
        {
            landingPage.CookieBannerButton().SendKeys(Keys.Enter);
            landingPage.LOGO().Click();
            pageAssert.AssertMainpage();
        }

        [TestMethod] 
        [TestCategory("Startsidan")]
        public void MainPageGoToShopList()
        {
            landingPage.CookieBannerButton().SendKeys(Keys.Enter);
            landingPage.LOGO().Click();
            pageAssert.AssertMainpage();
            landingPage.BuyList().Click();
            pageAssert.AssertInkop(); //Text "Inte redo att köpa riktigt än?"

        }

        [TestMethod] 
        [TestCategory("Startsidan")]
        public void MainPageGoToShopBag()
        {
            landingPage.CookieBannerButton().SendKeys(Keys.Enter);
            landingPage.LOGO().Click();
            pageAssert.AssertMainpage();
            landingPage.ShoppingBag().Click();
            pageAssert.AssertKundvagn();
        }

    }
}