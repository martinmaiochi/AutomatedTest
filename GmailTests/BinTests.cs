using NUnit.Framework;

namespace GmailTests
{
	[TestFixture]
    public class BinTests : GmailTestsBase
    {
        [Test(Description = "Empty all the e-mails on bin")]
        public void EmptyBinIfPossible() 
        {
            System.Threading.Thread.Sleep(2000);
            if (components.MainPage.EmptyBinNowButton?.Displayed ?? true)
            {
                components.MainPage.EmptyBinNowButton.Click();
                components.MainPage.ConfirmEmptyBinNowButton.Click();
            }
            Assert.Pass();
        }

		protected override void SetupTest()
		{
			base.SetupTest();
            components.MainPage.BinButton.Click();
        }
    }
}
