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

		public static IWebElement GetImportant(IWebElement emailRow)
		{
			var important = emailRow.FindElement(By.XPath("./td[contains(@class, 'WA xY')]/div[contains(@class, 'pG')]/div[contains(@class, 'pH a9q')]"));
			return important;
		}

		public static string GetName(IWebElement emailRow)
		{
			var name = emailRow.FindElement(By.XPath("./td[contains(@class, 'yX xY')]/div[contains(@class, 'yW')]/span[contains(@class, 'bA4')]"));
			return name.Text;
		}

		public static string GetTitle(IWebElement emailRow)
		{
			var title = emailRow.FindElement(By.XPath("./td[contains(@class, 'xY a4W')]/div[contains(@class, 'xS')]/div[contains(@class, 'xT')]/div[contains(@class, 'y6')]/span[contains(@class, 'bog')]"));
			return title.Text;
		}

		public static string GetEmailText(IWebElement emailRow)// NOT WORKING YET
		{
			var title = emailRow.FindElement(By.XPath("./td[contains(@class, 'xY a4W')]/div[contains(@class, 'xS')]/div[contains(@class, 'xT')]/span[contains(@class, 'y2')]"));
			return title.Text;
		}

		public static string GetDate(IWebElement emailRow)
		{
			var date = emailRow.FindElement(By.XPath("./td[contains(@class, 'xW xY')]"));
			return date.Text;
		}
	}
}
