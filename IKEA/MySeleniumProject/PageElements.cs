using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

namespace LandindPageClass
{
    public class LandingPage
    {

        private IWebDriver driver;
        private WebDriverWait wait;



        public LandingPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        }


        public IWebElement LOGO()
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("body > header > div.header__wrapper > div > div > a > img")));
        }

        /* STARTSIDAN

        */
        public IWebElement CookieBannerButton() //Cookie accept button
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("onetrust-accept-btn-handler")));
        }

        public IWebElement ShoppingBag() //Klicka på kundvagn från startsidan
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/header/div[2]/div/nav[2]/ul/li[3]/a/span[2]")));
        }

        public IWebElement BuyList() //Klicka på inköpslistan
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/header/div[2]/div/nav[2]/ul/li[2]/a")));
        }

        public IWebElement MyProfile() //Klicka på min profil
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/header/div[2]/div/nav[2]/ul/li[1]/a/span[2]")));
        }

        public IWebElement Products() //Klicka på "produkter"
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(".main-bygga-menu__item:nth-child(1) > .main-bygga-menu__button > .main-bygga-menu__title")));
        }

        public IWebElement ProductsFurniture() //Klicka på "möbler"
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(".main-bygga-menu__level1__item:nth-child(1) > .main-bygga-menu__level1__item-button")));
        }


        public IWebElement ProductsFurnitureTableAndDesks() //Klicka på "bord och skrivbord"
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/header/div[2]/div/nav[1]/div/ul[1]/li[1]/div/div[1]/ul/li[1]/ul/li[4]")));
        }

        public IWebElement ProductsFurnitureTv() //Klicka på "tv och mediamöbler"
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/header/div[2]/div/nav[1]/div/ul[1]/li[1]/div/div[1]/ul/li[1]/ul/li[9]")));
        }

        public IWebElement ProductsTextiles() //Klicka på "Textilier"
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("body > header > div.header__wrapper > div > nav.header__main-nav > div > ul.main-bygga-menu > li:nth-child(1) > div > div:nth-child(1) > ul > li:nth-child(7) > button")));
        }

        public IWebElement ProductsTextilesKitchen() //Klicka på "kökstextilier"
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/header/div[2]/div/nav[1]/div/ul[1]/li[1]/div/div[1]/ul/li[7]/ul/li[4]/a")));
        }

        public IWebElement ProductsTextilesCurtains() //Klicka på "gardiner och rullgardiner"
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("body > header > div.header__wrapper > div > nav.header__main-nav > div > ul.main-bygga-menu > li:nth-child(1) > div > div:nth-child(1) > ul > li:nth-child(7) > ul > li:nth-child(8) > a")));
        }


        /*Sökfältet
         
        */
        public IWebElement SearchField() //Klicka på sökrutan 
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("body > div:nth-child(4) > form > div > input")));
        }


        public IWebElement SearchFieldSumbit() //Klicka på sökrutan 
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[2]/form/div/span/button[2]")));
        }


        /*INKÖPSLISTAN
         
        */

        public IWebElement CreateAccountFromLogIn() //Klicka på "Skapa konto" från login
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("#root > div > div.sc-cvbbAY.sc-jhAzac.lovXuZ > div > div.sc-gqjmRU.erpLkq > div:nth-child(7) > a:nth-child(6)")));
        }






        public IWebElement MyBuyList() //Klicka på "inköpslista"
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("body > header > div.header__wrapper > div > nav.header__quick-nav > ul > li:nth-child(2) > a > span.hnf-btn__copy > svg > path")));
        }

        public IWebElement ProductsFromBuyList() //Klicka på "bläddra bland våra produkter" inifrån inköpslistan
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"one-checkout\"]/div[2]/div/div[3]/div[2]/div[2]/div[1]/a")));
        }

        public IWebElement LogInButtonBuyList() //Klicka på "login" knappen inifrån inköpslistan
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("#one-checkout > div.shoppinglist._Rfx0_._Rfx1_._Rfx2_ > div > div.noproducts._Rfx9_._Rfx2_ > div.noproducts__text._Rfx3_._Rfxb_ > div.noproducts__options._Rfxa_._Rfxc_._Rfx2_ > div:nth-child(2) > a")));
        }

        public IWebElement CreateAccountBuyList() //Klicka på "skapa ett konto" knappen inifrån inköpslistan
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("#one-checkout > div.shoppinglist._Rfx0_._Rfx1_._Rfx2_ > div > div.noproducts._Rfx9_._Rfx2_ > div.noproducts__text._Rfx3_._Rfxb_ > div:nth-child(3) > a")));
        }

        public IWebElement DeleteProductInShopList() //Klicka på "soptunnaikonen" för att ta bort ett objekt
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("#one-checkout > div.shoppinglist._Rfx0_._Rfx1_._Rfx2_ > div > div.productlist > div > div > div.product__controls > div.product-controls._Rfxg_._Rfx2_ > div.product-controls__remove._Rfxp_ > button > span")));
        }

        public IWebElement Cancel() //Klicka på "avbryt" efter du klickat på soptunnan
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("#one-checkout > div.shoppinglist._Rfx0_._Rfx1_._Rfx2_ > div > div.productlist > div > div > div.product__controls > div > div.product__remove-confirmation-no._Rfx9_ > button > span")));
        }

        public IWebElement DeleteItem() //Klicka på "ta bort" efter du klickat på soptunnan
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("#one-checkout > div.shoppinglist._Rfx0_._Rfx1_._Rfx2_ > div > div.productlist > div > div > div.product__controls > div > div.product__remove-confirmation-yes._Rfx9_ > button > span")));
        }

        public IWebElement SelectAmount() //Klicka på "antal" listan
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("#js_qty_19280680")));
        }

        public IWebElement AddToShoppingBagFromBuyList() //Klicka på "lägg till i kundvagn"
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/main/div[2]/div/div[4]/div/div/div[4]/div[2]/div[3]/button/span")));
        }

        public IWebElement AvailableDepartmentStore() //Klicka på "tillgängliga varuhus"
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("#one-checkout > div.shoppinglist._Rfx0_._Rfx1_._Rfx2_ > div > div.tabs > div > div:nth-child(2) > button > span")));
        }

        public IWebElement BuyOnline() //Klicka på köp online"
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("#one-checkout > div.shoppinglist._Rfx0_._Rfx1_._Rfx2_ > div > div.tabs > div > div:nth-child(1) > button > span")));
        }



        public IWebElement CloseBannerKundVagn() //Klicka på x på visa kundvagnbanner efter att man har lagt till vara i kundvagnen i in köpsöistan"
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/main/div[1]/div/div/button/span/img")));
        }


        /*KUNDVAGN
         
        */
        public IWebElement CartIcon() //Klicka på kundvagnen
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("body > header > div.header__wrapper > div > nav.header__quick-nav > ul > li:nth-child(3) > a > span.hnf-btn__copy.js-shopping-cart-icon > svg > path")));
        }

        public IWebElement AddProductArtNr() //Lägg till vara via artikelnummer 
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"one-checkout\"]/div[2]/div/div[2]/div[1]/div/button/span")));
        }

        public IWebElement AddProductArtNrButton() //Klicka på lägg till vara via artikelnummer 
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"one-checkout\"]/div[2]/div/div[2]/div[1]/form/div[2]/button/span")));
        }

        public IWebElement InputFieldAddProductArtNr() //Inmatningsfält för artikel nummer
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("productId")));
        }

        public IWebElement ProductQuantityList() //Lista med antal man vill lägga till
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("productQuantity")));
        }


        public IWebElement ProductAddToCartButton() //Klicka på lägg till kundvagn i produkt
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("#content > div.product-pip.js-product-pip > div.product-pip__top-container.flex.center-horizontal > div.product-pip__right-container > div.product-pip__purchase > form > button.range-btn.range-btn--transactional.range-leading-icon.fill.js-purchase-add-to-cart")));
        }


        public IWebElement DeleteProductFromBuyList() //Klicka på "soptunnan" från kundvagn
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("#one-checkout > div.shoppingbag._Rfx0_._Rfx1_._Rfx2_ > div > div.productlist > div:nth-child(1) > div > div.product__controls > div.product-controls._Rfxj_._Rfx2_ > div.product-controls__remove._Rfxs_ > button > span > img")));
        }

        public IWebElement CancelFromBuylist() //Klicka på "avbryt"
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("#one-checkout > div.shoppingbag._Rfx0_._Rfx1_._Rfx2_ > div > div.productlist > div:nth-child(1) > div > div.product__controls > div > div.product__remove-confirmation-no._Rfxb_ > button > span")));
        }

        public IWebElement ConfirmDeleteFromBuyList() //Klicka på "ta bort"
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/main/div[2]/div/div[2]/div/div/div[4]/div/div[3]/button/span")));
        }

        public IWebElement GoToCheckOut() //Klicka på "fortsätt till kassan"
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("#one-checkout > div.shoppingbag._Rfx0_._Rfx1_._Rfx2_ > div > div.shoppingbag__headline > div > button > span")));
        }

        public IWebElement CartCloseBanner() //Klicka på "andra tittade på"
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("#content > div.js-sticky-bottom-bar > div.rec-popup-wrapper.rec-popup-wrapper--open > div.rec-popup.rec-popup-ikea-col-12.rec-popup-ikea-col-sm-12.rec-popup-ikea-col-md-6.rec-popup-ikea-col-lg-4.rec-popup--open > div.rec-popup-top > div.rec-popup-top-bar > button > svg")));
        }


        /*MIN PROFIL
         
        */

        public IWebElement ProfileIcon() //Klicka på profile iconen        
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("body > header > div.header__wrapper > div > nav.header__quick-nav > ul > li:nth-child(1) > a > span.hnf-btn__copy > svg")));
        }

        public IWebElement Username() //Klicka på E-post fältet 
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("email")));
        }

        public IWebElement Password() //Klicka på lösenord fältet 
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("password")));
        }

        public IWebElement LostPassword() //Klicka på glömt lösenord
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("#root > div > div.sc-cvbbAY.sc-jhAzac.lovXuZ > div > div.sc-gqjmRU.erpLkq > form > div.sc-fjdhpX.iUnnWV > a")));
        }

        public IWebElement LoginButton() //Klicka på logga in knappen
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div/div/div[2]/div/div[2]/form/button")));
        }

        public IWebElement CreateFamilyAccount() //Klicka på gå med i IKEA  family
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div/div/div[2]/div/div[2]/div[4]/a[1]")));
        }


        public IWebElement CreateFamilyAccountFromForgotPasword() //Klicka på gå med i IKEA  family från glömd lösenord
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("#root > div > div.sc-cvbbAY.sc-jhAzac.lovXuZ > div > div.sc-kgoBCf.AHJjv > div:nth-child(8) > a:nth-child(6)")));
        }



        public IWebElement CreateAccount() //Klicka på skapa ett konto
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.PartialLinkText("Skapa ett konto")));
        }




        //Buy item random



        public IWebElement BuyItem() //klcika köp item
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("#content > div.range-main-container > div.js-catalog-product-list-container > div > div > div:nth-child(2) > div:nth-child(1) > div.range-product-list > div > div:nth-child(1) > div > div > a > span.product-compact__name")));
        }

        public IWebElement BuyItemAdd() //lägg produkten i inköpslistan
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("#content > div.product-pip.js-product-pip > div.product-pip__top-container.flex.center-horizontal > div.product-pip__right-container > div.product-pip__purchase > form > button.range-btn.range-btn--text.range-leading-icon.fill.js-purchase-add-to-list > span > span")));
        }



        public IWebElement ItemAddCheckBannerBuyList() //visa inköpslistan efter att man lagt till produkt banner
        {

            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("#content > div.product-pip.js-product-pip > div.product-pip__top-container.flex.center-horizontal > div.product-pip__right-container > div.product-pip__purchase > form > div:nth-child(7) > div.range-popup-frame > div > div > a")));
        }

        /* public IWebElement ItemAddCheckBannerBuyList(int num) //visa inköpslistan efter att man lagt till produkt banner
         {
             SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement()

         }*/

        public void CloseBannerIfDisplayed()
        {
            if (CartCloseBanner().Displayed)
            {
                CartCloseBanner().Click();
            }
        }




    }
}

