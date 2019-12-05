﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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


        public void CleanUp(TestContext Context) //Rensa cookies
        {
            /*if (Context.CurrentTestOutcome != UnitTestOutcome.Passed)
            {
                var fileName = Context.TestName + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
                ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(fileName);
               
            }*/
            driver.Manage().Cookies.DeleteAllCookies();
        }

        [AssemblyCleanup]
        public static void TearDown()// Stänga ner alla drivers
        {
            driver.Dispose();
        }
    
    }

}
      
