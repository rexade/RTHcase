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

        public IWebElement CookieBannerButton() //Cookie accept button
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("onetrust-accept-btn-handler")));
        }

        public IWebElement BuyList() //Klicka på inköpslistan
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/header/div[2]/div/nav[2]/ul/li[2]/a")));
        }

        public IWebElement MyBuyList() //Klicka på inköpslista från "inköpslista"
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[3]/div[2]/div/div[1]/h1/button")));
        }

        public IWebElement Products() //Klicka på "bläddra bland våra produkter" inifrån inköpslistan
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"one-checkout\"]/div[2]/div/div[3]/div[2]/div[2]/div[1]/a")));
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

