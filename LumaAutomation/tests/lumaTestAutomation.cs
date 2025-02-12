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

            [Test, Category("Smoke")]
            public void addItem()

            {
                HomePage search_item = new HomePage(getDriver());
                search_item.searchItem();

                ShoppingOptionPage shopping_option = new ShoppingOptionPage(getDriver());
                shopping_option.shoppingOption();

                AddToCartPage add_to_cart = new AddToCartPage(getDriver());
                add_to_cart.addToCart();                
            }

          
          [Test, TestCaseSource("AddTestDataConfig")]
            public void createAccount(string firstName, string lastName, string emailAdd, string passWord, string confirmPassword)

            {
                CreateAccountPage create_account = new CreateAccountPage(getDriver());
                create_account.createAccount();  

                CreateAccountPage personal_info = new CreateAccountPage(getDriver());
                personal_info.personalInformation("firstname", firstName);
                personal_info.personalInformation("lastname", lastName);

                CreateAccountPage signin_info = new CreateAccountPage(getDriver());
                signin_info.signinInformation("email_address", emailAdd);
                signin_info.signinInformation("password", passWord);
                signin_info.signinInformation("password-confirmation", confirmPassword);

                CreateAccountPage confirm_create_account = new CreateAccountPage(getDriver());
                confirm_create_account.confirmCreateAccount();
            }

            public static IEnumerable<TestCaseData> AddTestDataConfig()
            {
            yield return new TestCaseData("Ruthelia", "Rodri", "test@yahoo.com", "Testing@1234", "Testing@1234");
            yield return new TestCaseData("Mark", "Villa", "abc@gmail.com", "Testing@5678", "Testing@5678");
            }


            [Test]
            
            public void createAccount_validationError()
            {
                CreateAccountPage create_account = new CreateAccountPage(getDriver());
                create_account.createAccount();  

                CreateAccountPage confirm_create_account = new CreateAccountPage(getDriver());
                confirm_create_account.confirmCreateAccount();
                
                CreateAccountPage validation_error = new CreateAccountPage(getDriver());
                validation_error.createaccountInvalid("firstname");            
                validation_error.createaccountInvalid("lastname");


            }
        


        }

    }
