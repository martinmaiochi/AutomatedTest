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
			try
			{
                var alert = driver.SwitchTo().Alert();
                alert.Dismiss();
            }
			catch (NoAlertPresentException)
			{
                //if alert was not found, continue the excecution normally
			}
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
            components.LoginPage.UserNameField.Click();
            System.Threading.Thread.Sleep(2000);
            components.LoginPage.UserNameField.SendKeys(Settings.EmailLogin);
            components.LoginPage.UserNameField.SendKeys(Keys.Enter);
            System.Threading.Thread.Sleep(4000);
            components.LoginPage.PasswordField.SendKeys(Settings.EmailPassword);
            components.LoginPage.PasswordNextButton.Click();
            System.Threading.Thread.Sleep(4000);
            if (!components.MainPage.ComposeButton.Displayed)
            {
                Assert.Fail("Login was not successful");
            }
        }
    }
}
