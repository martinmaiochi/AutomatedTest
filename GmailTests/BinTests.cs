using NUnit.Framework;

namespace GmailTests
{
	[TestFixture]
    public class BinTests : GmailTestsBase
    {
        [Test(Description = "Empty all the e-mails on bin")]
        public void EmptyBin() 
        {
            
        }

		protected override void SetupTest()
		{
			base.SetupTest();
            components.BinButton.Click();
        }
    }
}
