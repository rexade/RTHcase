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
   
        public static IWebDriver driver; //Här deklarera jag chrome driver globalt för att använda i alla funktioner
        public static WebDriverWait wait;

        public bool IsInitialized;
        public TestInitializeClass()
        {           
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
        public void SetUp()  //Gå till URL
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.ikea.com/se/sv");
        }


        public void CleanUp(TestContext Context, DateTime Timer) //Rensa cookies
        {
            /*if (Context.CurrentTestOutcome != UnitTestOutcome.Passed)
            {
                var fileName = Context.TestName + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
                ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(fileName);
               
            }*/
            TestModel model = new TestModel();
            model.TestTime = DateTime.Now;
            TimeSpan diff = (model.TestTime - Timer);
            model.DurationTime = diff.TotalSeconds;
            model.TestClass = Context.FullyQualifiedTestClassName.Replace("MySeleniumProject.", "");
            model.TestName = Context.TestName;
            model.TestCategory = GetTestCategories(Context);

            if (Context.CurrentTestOutcome == UnitTestOutcome.Passed)
            {
                model.TestStatus = "Passed";
            }
            else if (Context.CurrentTestOutcome == UnitTestOutcome.Failed)
            {
                model.TestStatus = "Failed";
            }
            else
            {
                model.TestStatus = "N/A";
            }


            MongoCRUD db = new MongoCRUD("IKEA");
            db.InsertRecord("Test", model);
            driver.Manage().Cookies.DeleteAllCookies();
            //Assert.AreEqual(0, driver.Manage().Cookies.AllCookies.Count);
        }

        [AssemblyCleanup]
        public static void TearDown()// Stänga ner alla drivers
        {
            driver.Dispose();
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

    }

}
      
