using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;

namespace GmailTests
{
	[TestFixture]
	public class StarredTests : GmailTestsBase
	{
		[Test(Description = "Check if first Mail was moved to Starred and then unselect it")]
		public void MoveMailToStarred()
		{
			components.MainPage.StarredEmailButton.Click();
			var mailTitleInbox = components.MainPage.FirstEmailTitleString.Text;
			components.MainPage.StarredButton.Click();
			System.Threading.Thread.Sleep(2000);
			var mailTitleStarred = components.StarredPage.FirstEmailTitleString.Text;
			if (mailTitleInbox == mailTitleStarred)
			{
				components.StarredPage.UnstarredEmailButton.Click();
			}
			else
			{
				Assert.Fail();
			}
		}

		protected override void SetupTest()
		{
			base.SetupTest();
		}
	}
}
