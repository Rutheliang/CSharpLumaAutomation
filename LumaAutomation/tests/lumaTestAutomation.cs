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
                personal_info.fillInput("firstname", firstName);
                personal_info.fillInput("lastname", lastName);

                CreateAccountPage signin_info = new CreateAccountPage(getDriver());
                signin_info.fillInput("email_address", emailAdd);
                signin_info.fillInput("password", passWord);
                signin_info.fillInput("password-confirmation", confirmPassword);

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
                validation_error.validationError("firstname");            
                validation_error.validationError("lastname");
                validation_error.validationError("email_address");
                validation_error.validationError("password");
                validation_error.validationError("password-confirmation");
            }



            [Test]      
            public void loginAccount()
            {
                LoginPage login_account = new LoginPage(getDriver());
                login_account.SignIn();  

                CreateAccountPage customer_login = new CreateAccountPage(getDriver());
                customer_login.fillInput("email", "test@yahoo.com");
                customer_login.fillInput("pass", "Test@1234");

                LoginPage signin_button = new LoginPage(getDriver());
                signin_button.SigninButton();                  
            }



            [Test]      
            public void loginAccount_validationError()
            {
                LoginPage login_account = new LoginPage(getDriver());
                login_account.SignIn();  

                LoginPage signin_button = new LoginPage(getDriver());
                signin_button.SigninButton();   

                CreateAccountPage validation_error = new CreateAccountPage(getDriver());
                validation_error.validationError("email");            
                validation_error.validationError("pass");               
            }
        


        }

    }
