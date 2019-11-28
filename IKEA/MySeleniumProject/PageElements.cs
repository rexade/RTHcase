using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

namespace LandindPageClass {
    public class LandingPage
    {

        private IWebDriver driver;
        private WebDriverWait wait;
 


        public LandingPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

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
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/header/div[2]/div/nav[1]/div/ul[1]/li[1]/button")));
        }

        public IWebElement ProductsFurniture() //Klicka på "möbler"
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/header/div[2]/div/nav[1]/div/ul[1]/li[1]/div/div[1]/ul/li[1]/button")));
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
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/header/div[2]/div/nav[1]/div/ul[1]/li[1]/div/div[1]/ul/li[8]/button")));
        }

        public IWebElement ProductsTextilesKitchen() //Klicka på "kökstextilier"
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/header/div[2]/div/nav[1]/div/ul[1]/li[1]/div/div[1]/ul/li[8]/ul/li[4]")));
        }

        public IWebElement ProductsTextilesCurtains() //Klicka på "gardiner och rullgardiner"
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/header/div[2]/div/nav[1]/div/ul[1]/li[1]/div/div[1]/ul/li[8]/ul/li[8]")));
        }


        /*Sökfältet
         
        */
        public IWebElement SearchField() //Klicka på sökrutan 
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[2]/form/div[1]/input")));
        }


        /*INKÖPSLISTAN
         
        */


        public IWebElement MyBuyList() //Klicka på "inköpslista" från inköpslista
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[3]/div[2]/div/div[1]/h1/button")));
        }

        public IWebElement Products() //Klicka på "bläddra bland våra produkter" inifrån inköpslistan
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"one-checkout\"]/div[2]/div/div[3]/div[2]/div[2]/div[1]/a")));
        }

        public IWebElement LogInButtonBuyList() //Klicka på "login" knappen inifrån inköpslistan
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"one-checkout\"]/div[2]/div/div[3]/div[2]/div[2]/div[2]")));
        }

        public IWebElement CreateAccountBuyList() //Klicka på "skapa ett konto" knappen inifrån inköpslistan
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"one-checkout\"]/div[2]/div/div[3]/div[2]/div[1]/a")));
        }

        public IWebElement DeleteProductInShopList() //Klicka på "soptunnaikonen" för att ta bort ett objekt
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"one - checkout\"]/div[2]/div/div[4]/div/div/div[4]/div[2]/div[1]/button")));
        }

        public IWebElement Cancel() //Klicka på "avbryt" efter du klickat på soptunnan
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"one - checkout\"]/div[2]/div/div[4]/div/div/div[4]/div/div[2]/button")));
        }

        public IWebElement DeleteItem() //Klicka på "ta bort" efter du klickat på soptunnan
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"one - checkout\"]/div[2]/div/div[4]/div/div/div[4]/div/div[3]/button")));
        }

        public IWebElement SelectAmount() //Klicka på "antal" listan
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"js_qty_90354327\"]")));
        }

        public IWebElement AddToShoppingBagFromBuyList() //Klicka på "lägg till i kundvagn"
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"one - checkout\"]/div[2]/div/div[4]/div/div/div[4]/div[2]/div[3]/button")));
        }

        public IWebElement AvailableDepartmentStore() //Klicka på "tillgängliga varuhus"
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"one - checkout\"]/div[2]/div/div[2]/div/div[2]/button")));
        }

        /*KUNDVAGN
         
        */
        public IWebElement AddProductArtNr() //Lägg till vara via artikelnummer 
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"one-checkout\"]/div[2]/div/div[2]/div[1]/div/button/span")));
        }

        public IWebElement AddProductArtNrButton() //Klicka på lägg till vara via artikelnummer 
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"one-checkout\"]/div[2]/div/div[2]/div[1]/form/div[2]/button/span")));
        }

        public IWebElement DeleteProductFromBuyList() //Klicka på "soptunnan" från kundvagn
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"one - checkout\"]/div[2]/div/div[2]/div/div/div[4]/div[2]/div[1]/button")));
        }

        public IWebElement CancelFromBuylist() //Klicka på "avbryt"
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"one - checkout\"]/div[2]/div/div[2]/div/div/div[4]/div/div[2]/button")));
        }

        public IWebElement ConfirmDeleteFromBuyList() //Klicka på "ta bort"
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"one - checkout\"]/div[2]/div/div[2]/div/div/div[4]/div[2]/div[3]")));
        }

        public IWebElement GoToCheckOut() //Klicka på "fortsätt till kassan"
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"one - checkout\"]/div[2]/div/div[1]/div/button")));
        }



        /*MIN PROFIL
         
        */

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
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"root\"]/div/div[2]/div/div[2]/form/div[3]")));
        }

        public IWebElement LoginButton() //Klicka på logga in knappen
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"root\"]/div/div[2]/div/div[2]/form/button")));
        }

        public IWebElement CreateFamilyAccount() //Klicka på gå med i IKEA  family
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"root\"]/div/div[2]/div/div[2]/div[5]/a[1]")));
        }

        public IWebElement CreateAccount() //Klicka på skapa ett konto
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"root\"]/div/div[2]/div/div[2]/div[5]/a[2]")));
        }





        public void QuantityUp()
        {
            ReadOnlyCollection<IWebElement> elementList = driver.FindElements(By.CssSelector(".quantity-up"));

            int nbrOfElements = elementList.Count;

            elementList[0].Click();

            foreach (var element in elementList)
            {

                element.Click();
            }
        }

     



    }


}

