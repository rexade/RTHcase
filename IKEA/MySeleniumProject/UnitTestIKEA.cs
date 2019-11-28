using System;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;
using System.Threading;
using System.Diagnostics;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.WaitHelpers;
using LandindPageClass;
using static MySeleniumProject.TestInitializeClass;


//using TearUp;
namespace MySeleniumProject
{

    [TestClass]
    public class IkeaCheck
    {
        TestInitializeClass chrome = new TestInitializeClass();
        public TestContext TestContext { get; set; }


        [TestCleanup]
        public void Clean() //Rensa cookies
        {

            chrome.CleanUp(TestContext);
        }


        [TestMethod]
        public void IkeaTest()
        {

            chrome.SetUp();

            var pageElement = new LandingPage(driver);
            var pageAssert = new PageAssert(driver);

            // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);                       
            string fp = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).FullName;


            //Start

            //pageElement.AgeBanner().Click();
            //pageElement.VapehusetLogo().Click();

            //Menus
            //pageElement.EjuiceMenuTopBar().Click();
            //pageElement.CookieBannerButton().Click();
            //pageElement.BuyList().Click();
            //pageElement.StartKitMenuTopBar().Click();
            //pageElement.ModsMenuTopBar().Click(); // Om varan tar slut då kan man ändra härifrån till en annan så att man kan testa med antal och lägg i varukorg.
            //pageElement.ModsItem().Click();  //En produkt bland moddar på websidan denna då kan man ändra om det behövs


            //Equal or no waiting for result

            //Varan slut?  då ska man ändra nedanstående raderna fram till Select anropet
            /*pageAssert.AssertModItems();
            pageElement.SelectColour().Click();
            pageElement.Colour().Click();


            // Select för att kunna skicka eller välja 
            SelectElement oSelect = new SelectElement(pageElement.Colour());
            oSelect.SelectByText("Navy Blue");


            pageElement.EmailBanner().Click();
            pageElement.Button().Click();
            pageElement.Varukorg().Click();
            pageElement.X_icon().Click();
            pageElement.Vapehuset_Icon().Click();
            pageAssert.VapehusetMainPageAssert();
            pageElement.SearchField().Click();
            //SendKey skicka input
            pageElement.SearchField().SendKeys("billig");
            pageElement.SearchConfirmButton().Click();
            pageElement.Logo().Click();
            pageElement.MilkshakeLiquids().Click();
            pageElement.Post566Button().Click();
            pageElement.CloseDrawer().Click();
            pageElement.MenuItem4514().Click();
            pageElement.CottonBacon().Click();
            pageElement.QuantityUp();
            pageElement.AddToCart().Click();
            pageElement.Varukorg().Click();
            
            string currentValue = pageAssert.InputVarukorgBoxInfo().GetAttribute("value");
            Assert.AreEqual("3", currentValue);

            string sourceHtml = pageAssert.InputVarukorgBoxInfo().GetAttribute("inputmode");
            Debug.WriteLine(sourceHtml, "Rad 242");

         /*   (ITakesScreenshot)driver).GetScreenshot().SaveAsFile("EjuiceCheckboxChanged.png");
            string path2 = Path.Combine(fp, "EjuiceCheckboxChanged.png");
            */
        }


    }
}



