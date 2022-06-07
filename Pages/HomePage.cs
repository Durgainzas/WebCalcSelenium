using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;

namespace WebCalcSelenium.Pages
{
    public class HomePage
    {
        protected IWebDriver driver;

        const string WebPageUrl = "https://web2.0calc.com/";
        const string WebPageName = "Web 2.0 scientific calculator";


        [FindsBy(How = How.XPath, Using = "//button[@aria-label='Consent']")]
        private IWebElement CookieConsent { get; set; }



        [FindsBy(How = How.Id, Using = "BtnPi")]
        private IWebElement BtnPi { get; set; }
        [FindsBy(How = How.Id, Using = "BtnSqrt")]
        private IWebElement BtnSqrt { get; set; }
        [FindsBy(How = How.Id, Using = "BtnPlus")]
        private IWebElement BtnPlus { get; set; }
        [FindsBy(How = How.Id, Using = "BtnMult")]
        private IWebElement BtnMult { get; set; }
        [FindsBy(How = How.Id, Using = "BtnDiv")]
        private IWebElement BtnDiv { get; set; }
        [FindsBy(How = How.Id, Using = "BtnCos")]
        private IWebElement BtnCos { get; set; }
        [FindsBy(How = How.Id, Using = "trigorad")]
        private IWebElement Radians { get; set; }



        [FindsBy(How = How.Id, Using = "BtnCalc")]
        private IWebElement EqualsButton { get; set; }



        [FindsBy(How = How.Id, Using = "Btn0")]
        private IWebElement Btn0 { get; set; }
        [FindsBy(How = How.Id, Using = "Btn1")]
        private IWebElement Btn1 { get; set; }
        [FindsBy(How = How.Id, Using = "Btn3")]
        private IWebElement Btn3 { get; set; }
        [FindsBy(How = How.Id, Using = "Btn4")]
        private IWebElement Btn4 { get; set; }
        [FindsBy(How = How.Id, Using = "Btn5")]
        private IWebElement Btn5 { get; set; }
        [FindsBy(How = How.Id, Using = "Btn6")]
        private IWebElement Btn6 { get; set; }
        [FindsBy(How = How.Id, Using = "Btn8")]
        private IWebElement Btn8 { get; set; }
        [FindsBy(How = How.Id, Using = "Btn9")]
        private IWebElement Btn9 { get; set; }
        [FindsBy(How = How.Id, Using = "BtnParanL")]
        private IWebElement BtnParanL { get; set; }
        [FindsBy(How = How.Id, Using = "BtnParanR")]
        private IWebElement BtnParanR { get; set; }
        [FindsBy(How = How.Id, Using = "BtnClear")]
        private IWebElement BtnClear { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='btn dropdown-toggle pull-right']")]
        private IWebElement HistoryDropdown { get; set; }



        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            PageFactory.InitElements(driver, this);
        }

        public HomePage GoToPage()
        {
            driver.Navigate().GoToUrl(WebPageUrl);
            Assert.AreEqual(WebPageName, driver.Title);
            return this;
        } 

        public HomePage SubmitCookieConsent()
        {
            try
            {
                CookieConsent.Click();
            }
            catch (NoSuchElementException)
            {
                TestContext.WriteLine("Cookie consent not found, skipping..");
            }

            return this;
        }

        public HomePage Clear()
        {
            BtnClear.Click();
            return this;
        }

        public HomePage CalculateFirstEquation(string expectedResult)
        {
            Btn3.Click();
            Btn5.Click();
            BtnMult.Click();
            for (int i = 0; i < 3; i++) Btn9.Click();
            BtnPlus.Click();
            BtnParanL.Click();
            Btn1.Click();
            Btn0.Click();
            Btn0.Click();
            BtnDiv.Click();
            Btn4.Click();
            BtnParanR.Click();

            EqualsButton.Click();

            Assert.IsTrue(driver.FindElement(By.XPath($"//p[contains(@title,{expectedResult})]")).Enabled);

            return this;
        }

        public HomePage CalculateSecondEquation(string expectedResult)
        {
            Radians.Click();
            BtnCos.Click();
            BtnPi.Click();
            BtnParanR.Click();

            EqualsButton.Click();

            Assert.IsTrue(driver.FindElement(By.XPath($"//p[contains(@title,{expectedResult})]")).Enabled);

            return this;
        }
        public HomePage CalculateThirdEquation(string expectedResult)
        {
            BtnSqrt.Click();
            Btn8.Click();
            Btn1.Click();
            BtnParanR.Click();

            EqualsButton.Click();

            Assert.IsTrue(driver.FindElement(By.XPath($"//p[contains(@title,{expectedResult})]")).Enabled);

            return this;
        }

        public HomePage FindInHistory(List<string> historyItems)
        {
            HistoryDropdown.Click();

            foreach (var item in historyItems)
            {
                TestContext.WriteLine($"Asserting: {item}");
                Assert.IsTrue(driver.FindElement(By.XPath($"//p[contains(@title,'{item}')]")).Enabled);
            }


            return this;
        }
    }
}
