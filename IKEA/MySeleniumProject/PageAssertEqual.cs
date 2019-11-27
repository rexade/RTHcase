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
        //Global
        public IWebElement ShopAtIkea_Text()
        {
            return driver.FindElement(By.CssSelector("#footer-accordion0 > p > span > strong"));
        }


        //Kundvagnssidan
        public IWebElement KundvagnText() //Texten som visas på Kundvagnssidan där det står "Kundvagn"
        {
            return driver.FindElement(By.CssSelector("#one-checkout > div.shoppingbag._Rfx0_._Rfx1_._Rfx2_ > div > div.noproducts._Rfx8_._Rfx2_ > div.noproducts__text._Rfx3_._Rfx7_ > h2"));
        }
        public IWebElement SecureshopText() // Texten som visas att sidan har "Säker shopping"
        {
            return driver.FindElement(By.CssSelector("#one-checkout > div.shoppingbag._Rfx0_._Rfx1_._Rfx2_ > div > div.shoppingbag-footer._Rfx2_ > div:nth-child(2) > ul > li.checkoutinformation_secure"));
        }

        //Startsidan
        public IWebElement ModsItemText1()
        {


            return driver.FindElement(By.XPath("//h3[contains(.,'SMOK TFV12 Prince Tank Specifikationer:')]"));
        }




        public void AssertKundvagn() //Kundvagnssidan
        {

            Assert.AreEqual("Kundvagn", KundvagnText().Text); //Jämför texten Kundvagn med texten som finns på kundvagnsidan
            Assert.AreEqual("Säker shopping", SecureshopText().Text);
        }

        public void AssertMainpage() // Asserts som är på Startsidan
        {
            Assert.AreEqual("Kundvagn", KundvagnText().Text); //Jämför texten Kundvagn med texten som finns på kundvagnsidan
        }

        public void AssertGlobal() // Asserts som påverkar alla Ikea pages
        {
            Assert.AreEqual("Handla på IKEA.se",ShopAtIkea_Text().Text);
        }



    }


}

