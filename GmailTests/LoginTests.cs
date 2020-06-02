using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace GmailTests
{
	[TestFixture]
    public class LoginTests : GmailTestsBase
	{
        [Test(Description = "Verify that Enter functionality is working properly or not")]
        public void Autentication()
        {
            base.Autenticate();
        }

		protected override void SetupTest()
		{
            URL = "https://www.gmail.com";
            driver = new ChromeDriver();
            components = new Components(driver);
            driver.Navigate().GoToUrl(URL);
        }
	}
}