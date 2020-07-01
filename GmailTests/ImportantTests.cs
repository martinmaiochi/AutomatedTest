using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace GmailTests
{
	[TestFixture]
	public class ImportantTests : GmailTestsBase
	{
		[Test(Description = "Mark E-Mail as important and check if it was moved to Important section")]


		protected override void SetupTest()
		{
			base.SetupTest();
		}
	}
}
