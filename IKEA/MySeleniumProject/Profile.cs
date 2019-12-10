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
    public class Profile
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
        [TestCategory("Min Profil")]

        public void LoginTestInvalidUser()
        {

            landingPage.CookieBannerButton().SendKeys(Keys.Enter);

            landingPage.ProfileIcon().Click();

            landingPage.Username().Click();
            landingPage.Username().SendKeys("exampl@gmail.com");

            landingPage.Password().Click();
            landingPage.Password().SendKeys("selenium");
            landingPage.LoginButton().Click();

            pageAssert.AssertLoginFail();
            //pageAssert.AssertLoginFailUseLostPassword(); //assert 
        }

        [TestMethod]
        [TestCategory("Min Profil")]

        public void ProfileLoginFail()
        {
            landingPage.CookieBannerButton().SendKeys(Keys.Enter);

            landingPage.ProfileIcon().Click();

            landingPage.Username().Click();
            landingPage.Username().SendKeys("test@hotmail.com");

            landingPage.Password().Click();
            landingPage.Password().SendKeys("SeLeNiUm");
            landingPage.LoginButton().Click();

            pageAssert.AssertLoginFail(); //assert 

        }

        [TestMethod]
        [TestCategory("Min Profil")]

        public void ProfileLoginFailCreateAccount()
        {
            landingPage.CookieBannerButton().SendKeys(Keys.Enter);

            landingPage.ProfileIcon().Click();
            landingPage.Username().Click();
            landingPage.Username().SendKeys("exampl@gmail.com");
            landingPage.Password().Click();
            landingPage.Password().SendKeys("selenium");
            landingPage.LoginButton().Click();
            pageAssert.AssertLoginFail();

            //pageAssert.AssertLoginFailUseLostPassword(); //assert 
            landingPage.LostPassword().Click();
            landingPage.CreateFamilyAccount().Click();

            pageAssert.AssertIkeaFamilyRubrik(); //assert 

        }

        [TestMethod]
        [TestCategory("Min Profil")]
        public void CheckProfileSite()
        {
            landingPage.CookieBannerButton().SendKeys(Keys.Enter);
            landingPage.ProfileIcon().Click();
            pageAssert.AssertWelcome(); // Assert
        }

        [TestMethod]
        [TestCategory("Min Profil")]
        public void CreateNewAccount()
        {
            landingPage.CookieBannerButton().SendKeys(Keys.Enter);
            landingPage.ProfileIcon().Click();
            pageAssert.AssertWelcome(); // Assert
            landingPage.CreateAccount().Click();
            pageAssert.AssertCreateNewAccount();
        }

    }
}