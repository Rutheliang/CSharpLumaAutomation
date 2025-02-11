using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace LumaAutomation.pageObjects
{
    public class ShoppingOptionPage
    {
         IWebDriver driver;
        
        public ShoppingOptionPage(IWebDriver driver)
        {
            this.driver = driver;           
        }

         public void shoppingOption()
        {
                driver.FindElement(By.XPath("(//div[@role='presentation'])[2]")).Click();
                driver.FindElement(By.XPath("//a[@aria-label='S']//div[contains(@class,'swatch-option text')][normalize-space()='S']")).Click();
                driver.FindElement(By.XPath("//span[text()='Clear All']")).Click();
                
                driver.FindElement(By.XPath("(//div[@role='presentation'])[4]")).Click();
                driver.FindElement(By.XPath("//a[@aria-label='Blue']//div[contains(@class,'swatch-option color')]")).Click();
                driver.FindElement(By.XPath("//li[@class='item product product-item'][2]")).Click(); 

        }



    }
}