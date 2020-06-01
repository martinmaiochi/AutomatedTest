using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace GmailTests
{
    [TestFixture]
    public class LoginTests
	{
        private IWebDriver driver;
        private Components components;
        public string URL;

        [Test(Description = "Verify that Enter functionality is working properly or not")]
        public void Autentication()
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
        }
    }
}