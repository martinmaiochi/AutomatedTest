using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.WindowsRuntime;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace GmailTests
{
    [TestFixture]
    public class SendEmailTests
    {
        private IWebDriver driver;
        private Components components;
        public string URL;

        [Test(Description = "Send an e-mail")]
        [TestCase("tucamaiochi@gmail.com", "title", "text", ExpectedResult = true)]
        [TestCase("tucamaiochigmail.com", "title", "text", ExpectedResult = false)]
        public bool MessageSentDisplayed(string emailTo, string title, string emailBody)
        {
            components.ComposeButton.Click();
            System.Threading.Thread.Sleep(2000);
            components.SendToField.Click();
            components.SendToField.SendKeys(emailTo);
            components.SubjectField.SendKeys(title);
            components.EmailBodyField.SendKeys(emailBody);
            components.SendButton.Click();
            System.Threading.Thread.Sleep(3000);
            if (!components.MessageSentString?.Displayed ?? true)
            {
                return false;
            }
            return true;
        }

        [TearDown]
        public void TearDownTest()
        {
            driver.Close();
        }

        [SetUp]
        public void SetupTest()
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
            System.Threading.Thread.Sleep(2000);
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