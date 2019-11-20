using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.IO;

namespace LandindPageClass
{
    public class PageAssert
    {

        private IWebDriver driver;
        private WebDriverWait wait;


        public PageAssert(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        }


        public IWebElement ModsItemText()
        {
            return driver.FindElement(By.XPath("//h2[contains(.,'SMOK Mag 225W Mod Specifikationer:')]"));


        }

        public IWebElement ModsItemText1()
        {


            return driver.FindElement(By.XPath("//h3[contains(.,'SMOK TFV12 Prince Tank Specifikationer:')]"));
        }


        public void AssertModItems()
        {

            Assert.AreEqual("SMOK Mag 225W Mod Specifikationer:", ModsItemText().Text);
            Assert.AreEqual("SMOK TFV12 Prince Tank Specifikationer:", ModsItemText1().Text);
        }



    }


}

