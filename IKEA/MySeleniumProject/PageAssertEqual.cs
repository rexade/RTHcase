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
        //|||----------------------Global-------------------------|||


        //texten som står längst ner på sidan i footer = "Handla på IKEA.se"
        public IWebElement ShopAtIkea_Text()
        {
            return driver.FindElement(By.CssSelector("#footer-accordion0 > p > span > strong"));
        }

        //|||-------------------Loginpage----------------------------------|||


        public IWebElement RemailWpass() //Texten som kommer upp om man skriver rätt email men fel lösen.-
        {
            return driver.FindElement(By.CssSelector("#root > div > div.sc-cvbbAY.sc-jhAzac.lovXuZ > div > div.sc-gqjmRU.erpLkq > div.sc-bdVaJa.gfemLW > div > div.alert__container > div > p")); 
        }

        public IWebElement LoginAttemptSuccess() //TExten "Min profil" vid lyckad login
        {
            return driver.FindElement(By.CssSelector("#mss-member > div:nth-child(1) > div.WelcomeBoxBlock_1MzF- > div > div > div > div.Container_1XzMO.Left_2GheH > div:nth-child(1)"));
        }
        public IWebElement LoginSuccessPassVisible() //Att lösenordet inte är synligt vid lyckad inloggning.
        {
            return driver.FindElement(By.CssSelector("#mss-member > div:nth-child(1) > div.Container_2In1q > div.Dashboard_I909Q > div:nth-child(8) > div > div.Row_2STcB > div.Content_2ci_A > section"));
        }

        public IWebElement LoginAttemptFail() // Texten "Ditt användarnamn eller lösenord är fel" vid fel inlogg.
        {
            return driver.FindElement(By.CssSelector("# root > div > div.sc-cvbbAY.sc-jhAzac.lovXuZ > div > div.sc-gqjmRU.erpLkq > div.sc-bdVaJa.gfemLW > div > div.alert__container > div > p"));
        }

        //|||-------------------Produkthantering----------------------------------|||

            // ---------------------STOL-----------------------
        public IWebElement StolSearchTobias() //Sökandet av stol  >> Tobias
        {
            return driver.FindElement(By.CssSelector("#search-results > span:nth-child(2) > div > a > span.product-compact__name"));
        }
        public IWebElement StolSearchColor() //Sökandet av stol  >> Färgval
        {
            return driver.FindElement(By.CssSelector("#content > div > div > div.product-result > div > div.search-options > section > div > div.color-filter-desktop > div > button"));
        }
        // --------------------BORD--------------------------
        public IWebElement BordSearchDocksta() //Sökandet av Bord  >> Docksta
        {
            return driver.FindElement(By.CssSelector("#search-results > span:nth-child(3) > div > a > span.product-compact__name"));
        }
        public IWebElement BordSearchPicture() //Sökandet av stol  >> Färgval
        {
            return driver.FindElement(By.CssSelector("#search-results > span:nth-child(3) > div > a > div > div > div > img"));
        }


        //|||----------------------Kundvagnssidan-------------------------|||
        public IWebElement KundvagnText() //Texten som visas på Kundvagnssidan där det står "Kundvagn"
        {
            return driver.FindElement(By.CssSelector("#one-checkout > div.shoppingbag._Rfx0_._Rfx1_._Rfx2_ > div > div.noproducts._Rfx8_._Rfx2_ > div.noproducts__text._Rfx3_._Rfx7_ > h2"));
        }
        public IWebElement SecureshopText() // Texten som visas att sidan har "Säker shopping"
        {
            return driver.FindElement(By.CssSelector("#one-checkout > div.shoppingbag._Rfx0_._Rfx1_._Rfx2_ > div > div.shoppingbag-footer._Rfx2_ > div:nth-child(2) > ul > li.checkoutinformation_secure"));
        }

        //|||----------------------Startstidan-------------------------|||
        public IWebElement StartPageLogo()//Kollar om Headern finns(IKEA LOGO).
        {
            return driver.FindElement(By.CssSelector("body > header > div.header__wrapper > div > div > a > img")); 
        }

        public IWebElement StartPageVaruhusText()//Kollar om Texten Varuhus.
        {
            return driver.FindElement(By.CssSelector("body > header > div.header__wrapper > div > nav.header__main-nav > div > ul.main-bygga-menu > li:nth-child(5) > a > span")); 
        }

        public IWebElement StartPageProductText() //Kollar om Texten Produkter.
        {
            return driver.FindElement(By.CssSelector("body > header > div.header__wrapper > div > nav.header__main-nav > div > ul.main-bygga-menu > li:nth-child(1) > button > span"));
        }

        public IWebElement StartPageRumText()//Kollar om Texten Rum.
        {
            return driver.FindElement(By.CssSelector("body > header > div.header__wrapper > div > nav.header__main-nav > div > ul.main-bygga-menu > li:nth-child(2) > button > span")); 
        }

        public IWebElement StartPageInspirationText()//Kollar om Texten Inspiration.
        {
            return driver.FindElement(By.CssSelector("body > header > div.header__wrapper > div > nav.header__main-nav > div > ul.main-bygga-menu > li:nth-child(3) > button > span")); 
        }

        public IWebElement StartPageKundserviceText() //Kollar om Texten Kundservice.
        {
            return driver.FindElement(By.CssSelector("body > header > div.header__wrapper > div > nav.header__main-nav > div > ul.main-bygga-menu > li:nth-child(6) > a > span"));
        }
        //|||***************************************************ASSERTS********************************************************|||

        public void AssertKundvagn() //Kundvagnssidan
        {

            Assert.AreEqual("Kundvagn", KundvagnText().Text); //Jämför texten Kundvagn med texten som finns på kundvagnsidan
            Assert.AreEqual("Säker shopping", SecureshopText().Text);
        }

        public void AssertMainpage() //Asserts som är på Startsidan
        {
            Assert.AreEqual("Kundvagn", KundvagnText().Text); //Jämför texten Kundvagn med texten som finns på kundvagnsidan
            Assert.IsNotNull(StartPageLogo().Displayed); //Jämför om logon "IKEA i vänstra hörnet" finns.

         //Jämför menyflikarnas text.
            Assert.AreEqual("Produkter", StartPageProductText().Text);
            Assert.AreEqual("Rum", StartPageRumText().Text);
            Assert.AreEqual("Inspiration", StartPageInspirationText().Text);
            Assert.AreEqual("Varuhus", StartPageVaruhusText().Text);
            Assert.AreEqual("Kundservice", StartPageKundserviceText().Text);
        }

        public void AssertLoginFail() //Asserts som är för Felaktig-login
        {
            Assert.AreEqual("Ditt användarnamn eller lösenord är felaktigt.", LoginAttemptFail().Text);
        }

        public void AssertLoginRightemailWrongpass() //assert för rätt email fel lösen
        {
            Assert.AreEqual("Om du inte kommer ihåg ditt lösenord så använd länken Glömt ditt lösenord.", RemailWpass().Text);

        }
        public void AssertLoginSuccess() //Asserts för lyckad login.
        {
            Assert.AreEqual("Min profil", LoginAttemptSuccess().Text);
            Assert.AreEqual("••••••••••", LoginSuccessPassVisible().Text);

        }

        public void FindItemStol() //Asserts för sökning av stol
        {
            Assert.AreEqual("TOBIAS", StolSearchTobias().Text);
            Assert.AreEqual("Färg", StolSearchColor().Text);
        }

        public void FindItemBord() //Asserts för sökning av Bord
        {
            Assert.AreEqual("DOCKSTA", BordSearchDocksta().Text);
            Assert.IsNotNull(BordSearchPicture());
        }

        public void FindItemLampa() //Asserts för sökning av Lampa
        {

        }


        //|||----------------------GLOBAL ASSERTS-------------------------|||

        public void AssertGlobal() // Asserts som är Glabala.
        {
            Assert.AreEqual("Handla på IKEA.se",ShopAtIkea_Text().Text);
        }



    }


}

