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
            if (components.BinPage.EmptyBinNowButton?.Displayed ?? true)
            {
                components.BinPage.EmptyBinNowButton.Click();
                components.BinPage.ConfirmEmptyBinNowButton.Click();
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
