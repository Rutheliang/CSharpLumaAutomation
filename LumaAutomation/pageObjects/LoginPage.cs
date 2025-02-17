using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;


namespace LumaAutomation.pageObjects
{
    public class LoginPage
    {
    IWebDriver driver;
        
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;           
        }       

        public void SignIn()
        {
            driver.FindElement(By.LinkText("Sign In")).Click();
        }


        public void SigninButton()
        {
            driver.FindElement(By.XPath("//button[@class='action login primary']")).Click();   
        }




    }
}