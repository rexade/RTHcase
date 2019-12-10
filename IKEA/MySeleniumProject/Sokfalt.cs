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
    public class Sokfalt
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
        [TestCategory("Sökfältet")]

        public void SearchFielDocksta()
        {
            landingPage.CookieBannerButton().SendKeys(Keys.Enter);
            landingPage.SearchField().Click();
            landingPage.SearchField().Clear();
            landingPage.SearchField().SendKeys("DOCKSTA");
            pageAssert.FindItemBord();
            landingPage.SearchFieldSumbit().Click();
            //assert                       Assert fungerar inte
        }

        [TestMethod]
        [TestCategory("Sökfältet")]

        public void SearchFieldTobias()
        {
            landingPage.CookieBannerButton().SendKeys(Keys.Enter);
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

            landingPage.CookieBannerButton().SendKeys(Keys.Enter);

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

    }
}