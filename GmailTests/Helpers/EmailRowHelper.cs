using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using OpenQA.Selenium;

namespace GmailTests.Helpers
{
	public static class EmailRowHelper
	{
		public static bool IsUnread(IWebElement emailRow)
		{
			return emailRow.GetAttribute("class").Contains("zE");
		}

		public static bool IsRead(IWebElement emailRow)
		{
			return emailRow.GetAttribute("class").Contains("yO");
		}

		public static bool HasAttachment(IWebElement emailRow)
		{
			var emailRowAttachmentColumn = emailRow.FindElement(By.XPath("./td[contains(@class, 'yf')]"));

			var attachmentImg = emailRowAttachmentColumn.FindElements(By.XPath("./img[contains(@title, 'Has attachment')]"));
			return attachmentImg.Count == 1;
		}

		public static IWebElement GetCheckBox(IWebElement emailRow)
		{
			var checkBox = emailRow.FindElement(By.XPath("./td[contains(@class, 'oZ-x3')]/div[contains(@class, 'oZ-jc')]"));
			return checkBox;

		}

	}
}
