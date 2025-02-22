
using System;
using System.Configuration;
using System.IO;
using System.Threading;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using AventStack.ExtentReports.Reporter;
using CSharpSelFramework.utilities;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
//using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;

namespace CSharpSelFramework.utilities
{
    public class Base
    {
        
        public ExtentReports extent;
        public ExtentTest test;
       
        //report file
        [OneTimeSetUp]
        public void Setup()

        {
            //Configuration

            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            String reportPath =projectDirectory + "//index.html";
            var htmlReporter = new  ExtentSparkReporter(reportPath);
             extent = new ExtentReports();
            extent.AddSystemInfo("Host Name", "Local host");
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("Username", "Rahul Shetty");

        }


        public IWebDriver driver;
           [SetUp]
            public void StartBrowser()

            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
                
                //Configuration
                var browserName = ConfigurationManager.AppSettings["browser"];

                InitBrowser(browserName);

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                driver.Manage().Window.Maximize();
                driver.Url = "https://magento.softwaretestingboard.com/";


            }

        public IWebDriver getDriver()

        {
            return driver;
        }

        
        public void InitBrowser(string browserName)

        {

            switch (browserName)
            {

                case "Chrome":

                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;
                    
                    
                //case "Firefox":

                    //new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    //driver = new FirefoxDriver();
                    //break;



                case "Edge":

                    driver = new EdgeDriver();
                    break;

            }

        }


        [TearDown]
        public void AfterTest()

        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;

            DateTime time = DateTime.Now;
            String fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";

            if (status == TestStatus.Failed)
            {
              
                test.Fail("Test failed", captureScreenShot(driver, fileName));
                test.Log(Status.Fail,"test failed with logtrace"+ stackTrace);

            }
            else if (status == TestStatus.Passed)
            {
          
            }

            extent.Flush();
            
            
            //driver.Quit();
             
        }


        public Media captureScreenShot(IWebDriver driver,String screenShotName)

        {
            ITakesScreenshot ts= (ITakesScreenshot)driver;
           var screenshot= ts.GetScreenshot().AsBase64EncodedString;

           return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenShotName).Build();

        }

        

    }
}
