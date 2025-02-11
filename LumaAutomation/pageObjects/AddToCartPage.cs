using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace LumaAutomation.pageObjects
{
    public class AddToCartPage
    {
        IWebDriver driver;
        
        public AddToCartPage(IWebDriver driver)
        {
            this.driver = driver;           
        }

         public void addToCart()
        {
                driver.FindElement(By.XPath("//div[@option-label='S']")).Click();
                driver.FindElement(By.XPath("//div[@option-label='Blue']")).Click();
                driver.FindElement(By.XPath("//span[contains(text(),'Add to Cart')]")).Click();

                String confirmText = driver.FindElement(By.XPath("//div[@data-bind='html: $parent.prepareMessageForHtml(message.text)']")).Text;
                Assert.That(confirmText.Contains("You added"), Is.True);

                
                driver.FindElement(By.XPath("//a[@class='action showcart']")).Click();
                driver.FindElement(By.XPath("//button[@id='top-cart-btn-checkout']")).Click();

        }
    }
}