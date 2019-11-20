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

        public IWebElement BuyList()
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/header/div[2]/div/nav[2]/ul/li[2]/a")));
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

