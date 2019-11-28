﻿using System;
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
        // |||--------------------------INKÖPSLISTAN----------------------|||

        public IWebElement NotReadyBuyYet() //Texten "Inte redo att köpa riktigt än?"
        {
            return driver.FindElement(By.CssSelector("#one-checkout > div.shoppinglist._Rfx0_._Rfx1_._Rfx2_ > div > div.noproducts._Rfx9_._Rfx2_ > div.noproducts__text._Rfx3_._Rfxb_ > p:nth-child(1)"));
        }

        public IWebElement InkopSkapaList() //Texten "Skapa ny lista" Inne i inköpslistan/inköpslistan
        {
            return driver.FindElement(By.CssSelector("body > div.ReactModalPortal > div > div > div > div > button > span"));
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

        //|||----------------------------------------------------SÖkFÄLT--------------------------------------------------||||

        public IWebElement SearchPopularText() //Kollar om Texten i sökfält "Populära söknikar"
        {
            return driver.FindElement(By.CssSelector("#populära_sökningar"));
        }


        //||||----------------------------------------------Produkter-flik--------------------------------------------------|||
        public IWebElement ProductsBedText() //Kollar om Texten Sängar och madrasser i produkter..
        {
            return driver.FindElement(By.CssSelector("body > header > div.header__wrapper > div > nav.header__main-nav > div > ul.main-bygga-menu > li:nth-child(1) > div > div:nth-child(1) > ul > li:nth-child(4) > button"));
        }

        public IWebElement ProductsMoblerText() //Kollar om Texten i Products mobler / "byråar och hgurts..
        {
            return driver.FindElement(By.CssSelector("body > header > div.header__wrapper > div > nav.header__main-nav > div > ul.main-bygga-menu > li:nth-child(1) > div > div:nth-child(1) > ul > li:nth-child(1) > ul > li:nth-child(7)"));
        }

        public IWebElement ProductsForvaringTvText() // Kollar texten i Produkt/Mobler/TV.... text
        {
            return driver.FindElement(By.CssSelector("#content > div.range-main-container > div.js-catalog-product-list-container > div > div > div:nth-child(2) > div:nth-child(1) > div.range-product-list > div > div.range-product-list-introduction > div > div > div > p"));
        }


        public IWebElement ProductsTextiler() // KOllar text i Produkt/Textiler "Babytextilier"
        {
            return driver.FindElement(By.CssSelector("body > header > div.header__wrapper > div > nav.header__main-nav > div > ul.main-bygga-menu > li:nth-child(1) > div > div:nth-child(1) > ul > li:nth-child(8) > ul > li:nth-child(9) > a"));
        }

        public IWebElement ProductsTextilerKökText() // KOllar text i Produkt/Textiler/Kökstextiler "Matlagningen växlar efter årstiderna......."
        {
            return driver.FindElement(By.CssSelector("#content > div.range-main-container > div.js-catalog-product-list-container > div > div > div:nth-child(2) > div:nth-child(1) > div.range-product-list > div > div.range-product-list-introduction > div > div > div > p"));
        }

        public IWebElement ProductsTextilerGardRubrik() // KOllar text i Produkt/Textiler/Gardiner ..."Rubriken."
        {
            return driver.FindElement(By.CssSelector("#gardiner_\&_rullgardiner"));
        }



        //||||----------------------------------------Produkter/Mobler/bord---------------------------------------------|||
        public IWebElement ProductsMoblerBordText() //Kollar om Texten i Products mobler /bord / "Matbord" ..
        {
            return driver.FindElement(By.CssSelector("#content > div.range-catalog-list.js-range-catalog-list > nav > ul > li:nth-child(4) > a > span"));
        }

        public IWebElement ProductsMoblerBordBursText() //Kollar om Texten i Products mobler /bord / "Burs" ..
        {
            return driver.FindElement(By.CssSelector("#content > div.range-main-container > div.js-catalog-product-list-container > div > div > div:nth-child(2) > div:nth-child(1) > div.range-product-list > div > div:nth-child(2) > div > div > a:nth-child(1) > span.product-compact__name"));
        }



        //|||***************************************************ASSERTS********************************************************|||


        //|||***************************************************ASSERTS- KUNDVAGN********************************************************|||

        public void AssertKundvagn() //Kundvagnssidan
        {

            Assert.AreEqual("Kundvagn", KundvagnText().Text); //Jämför texten Kundvagn med texten som finns på kundvagnsidan
            Assert.AreEqual("Säker shopping", SecureshopText().Text);
        }

        //|||***************************************************ASSERTS- STARTSIDAN********************************************************|||

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
        //|||***************************************************ASSERTS PRODUKTER********************************************************|||
        public void AssertProductpage()
        {
            Assert.AreEqual("Sängar & madrasser", ProductsBedText().Text);
        }

        public void AssertProductTextil()
        {
            Assert.AreEqual("Babytextilier", ProductsTextiler().Text);
        }

        public void AssertProductTextilKök()
        {
            Assert.AreEqual("Matlagningen växlar efter årstiderna. Sallader och smoothies byts ut mot soppor, grytor och kakor. Vårt breda sortiment av kökstextilier kompletterar din matlagning under året med grytlappar, förkläden och kökshanddukar som gör det enkelt att tillföra nya färger och mönster till ditt kök.", ProductsTextilerKökText().Text);
        }

        public void AssertProductMobler()
        {
            Assert.AreEqual("Byråar & hurtsar", ProductsMoblerText().Text);
        }

        public void AssertProductMoblerBord()
        {
            Assert.AreEqual("BESTÅ BURS", ProductsMoblerBordBursText().Text);
            Assert.AreEqual("Matbord", ProductsMoblerBordText().Text);
        }

        public void AssertProductForvaringTv()
        {
            Assert.AreEqual("Från den svartvita tv:n till spel, streaming och 3D – vårt tv-tittande har onekligen utvecklats. Men en sak är densamma: du behöver fortfarande en tv-bänk eller en annan tv-förvaringslösning. Vårt sortiment hjälper dig att minimera stöket och hantera kablarna för en snyggare tv-miljö. Så att du kan koppla av och njuta av din tv, även när den inte är på.", ProductsForvaringTvText().Text);
        }

        public void AssertProductTextilGard()
        {
            Assert.AreEqual("Gardiner & rullgardiner", ProductsTextilerGardRubrik().Text);
        }
        //|||***************************************************ASSERTS SÖKFÄLT********************************************************|||

        public void AssertSearchBar()
        {
            Assert.AreEqual("Populära sökningar", SearchPopularText().Text);
        }
        //|||***************************************************ASSERTS INKÖPSLISTAN********************************************************|||

        public void AssertInkop() //Asserts på Inköpslistan
        {
            Assert.AreEqual("Inte redo att köpa riktigt än?", NotReadyBuyYet().Text);
            Assert.AreEqual("Skapa en ny lista", InkopSkapaList().Text);

        }
        //|||***************************************************ASSERTS LOGINSIDA********************************************************|||


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
        //|||***************************************************ASSERTS VID SÖKNINGAR********************************************************|||

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

        public void AssertGlobal() // Asserts som är Globala.
        {
            Assert.AreEqual("Handla på IKEA.se",ShopAtIkea_Text().Text);
        }



    }


}

