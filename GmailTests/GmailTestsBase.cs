using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace GmailTests
{
	public abstract class GmailTestsBase
	{
        protected IWebDriver driver;
        protected Components components;
        protected string URL;

        [TearDown]
        protected virtual void TearDownTest()
        {
            driver.Close();
        }

        [SetUp]
        protected virtual void SetupTest()
        {
            URL = "https://www.gmail.com";
            driver = new ChromeDriver();
            components = new Components(driver);
            driver.Navigate().GoToUrl(URL);
            Autenticate();
        }

        public void Autenticate()
        {
            System.Threading.Thread.Sleep(2000);
            components.UserNameField.Click();
            System.Threading.Thread.Sleep(2000);
            components.UserNameField.SendKeys(Settings.EmailLogin);
            components.UserNameField.SendKeys(Keys.Enter);
            System.Threading.Thread.Sleep(4000);
            components.PasswordField.SendKeys(Settings.EmailPassword);
            components.PasswordNextButton.Click();
            System.Threading.Thread.Sleep(4000);
            if (!components.ComposeButton.Displayed)
            {
                Assert.Fail("Login was not successful");
            }
        }
    }
}
