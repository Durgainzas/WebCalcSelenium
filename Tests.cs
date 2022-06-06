using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using WebCalcSelenium.Pages;

namespace WebCalcSelenium
{
    public class Tests
    {
        EdgeDriver driver;

        [SetUp]
        public void Setup()
        {
            try
            {
                driver = new EdgeDriver(@"C:\tools\msedgedriver\");
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(3000);
                
            }
            catch (Exception e)
            {

                TestContext.Error.Write(e.Message);
            }

        }

        [Test]
        public void Test1()
        {
            HomePage homePage = new HomePage(driver);
            var equations = new List<string>() { "35*999+(100/4)", "cos(pi)", "sqrt(81)" };

            homePage.GoToPage()
                    .SubmitCookieConsent()
                    .CalculateFirstEquation("34990")
                    .Clear()
                    .CalculateSecondEquation("-1")
                    .Clear()
                    .CalculateThirdEquation("81")
                    .FindInHistory(equations);

        }

        [TearDown]
        public void TearDown()
        {
            //driver.Quit();
        }
    }
}