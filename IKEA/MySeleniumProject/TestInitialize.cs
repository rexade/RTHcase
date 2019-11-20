using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.IO;
namespace MySeleniumProject
  
{
    [TestClass]
    public  class TestInitializeClass
    {


        // var chromeOptions = new ChromeOptions();
        //  chromeOptions.AddArguments("headless");

       

        public static IWebDriver driver; //Här deklarera jag chrome driver globalt för att använda i alla funktioner
        public static WebDriverWait wait;

        public bool IsInitialized;
        public TestInitializeClass()
        {
            this.SetUp();
           
            IsInitialized = true;

        }



        [AssemblyInitialize]
        public static void Initialize(TestContext context)  //Startar chrome driver
        {

            switch (TestConfig.BrowserForTesting)
            {
                case TestConfig.BrowserType.Chrome:
                    driver = new ChromeDriver();
                    break;
                case TestConfig.BrowserType.Firefox:
                    driver = new FirefoxDriver();
                    break;
                default:
                    Assert.Fail("Invalid test configuration: No browser type set.");
                    break;

            }

            //driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [TestInitialize]
        public void SetUp()  //Gå till uRL
        {
           

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.ikea.com");

        }


        public void CleanUp(TestContext Context) //Rensa cookies
        {

            if (Context.CurrentTestOutcome != UnitTestOutcome.Passed)
            {
                var fileName = Context.TestName + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
                ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(fileName);
                // string fp = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).FullName;
                // string path = System.IO.Path.Combine(fp,fileName);
            }

            driver.Manage().Cookies.DeleteAllCookies();
            Assert.AreEqual(0, driver.Manage().Cookies.AllCookies.Count);
          



        }

        [AssemblyCleanup]
        public static void TearDown()// Stänga near all drivers
        {
            driver.Dispose();

        }
    
    }

}
      
