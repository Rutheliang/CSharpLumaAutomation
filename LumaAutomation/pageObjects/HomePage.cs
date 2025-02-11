using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace LumaAutomation.pageObjects
{
    public class HomePage
    {
        IWebDriver driver;
        
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;           
        }

         public void searchItem()

        {
                Actions a = new Actions(driver);
                a.MoveToElement(driver.FindElement(By.XPath("//span[normalize-space()='Women']"))).Perform();
                a.MoveToElement(driver.FindElement(By.CssSelector("#ui-id-9"))).Perform();
                
                a.MoveToElement(driver.FindElement(By.XPath("//a[@id='ui-id-12']//span[contains(text(),'Hoodies & Sweatshirts')]"))).Click().Perform();
                
        }


    }
}