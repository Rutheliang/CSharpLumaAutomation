using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace LumaAutomation.pageObjects
{
    public class CreateAccountPage
    {
       IWebDriver driver;

        public CreateAccountPage(IWebDriver driver)
        {
            this.driver = driver;           
        }

         public void createAccount()
        {
            driver.FindElement(By.LinkText("Create an Account")).Click(); 
        }

        public void personalInformation(String locator, String fillText)
        {
                driver.FindElement(By.Id(locator)).SendKeys(fillText);   
        }


        public void signinInformation(String locator, String fillText)
        {
                driver.FindElement(By.Id(locator)).SendKeys(fillText);   
        }
        
    }
}