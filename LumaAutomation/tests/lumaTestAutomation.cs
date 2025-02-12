using System;
using System.Collections.Generic;
using System.Linq;
using CSharpSelFramework.utilities;
using LumaAutomation.pageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;

    namespace LUMA
    {
        public class LumaTest : Base
        {

            [Test]
            public void searchIteam()

            {
                HomePage search_item = new HomePage(getDriver());
                search_item.searchItem();

                ShoppingOptionPage shopping_option = new ShoppingOptionPage(getDriver());
                shopping_option.shoppingOption();

                AddToCartPage add_to_cart = new AddToCartPage(getDriver());
                add_to_cart.addToCart();                
            }

        
          [Test, TestCaseSource("AddTestDataConfig")]
          
            public void createAccount(string firstName)

            {
                CreateAccountPage create_account = new CreateAccountPage(getDriver());
                create_account.createAccount();  

                CreateAccountPage personal_info = new CreateAccountPage(getDriver());
                personal_info.personalInformation("firstname", firstName);
                personal_info.personalInformation("lastname", "Lastname");

                CreateAccountPage signin_info = new CreateAccountPage(getDriver());
                signin_info.signinInformation("email_address", "test@yahoo.com");
                signin_info.signinInformation("password", "Testing@1234");
                signin_info.signinInformation("password-confirmation", "Testing@1234");
            }


            public static IEnumerable<TestCaseData> AddTestDataConfig()

            {
                yield return new TestCaseData("Ruthelia");
            }


        }

    }
