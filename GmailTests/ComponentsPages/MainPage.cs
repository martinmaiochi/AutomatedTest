using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using OpenQA.Selenium;

namespace GmailTests.ComponentsPages
{
	public class MainPage 
	{
		private IWebDriver _driver;
		public MainPage(IWebDriver driver) 
		{
			_driver = driver;
		}
		//Buttons//
		public IWebElement ComposeButton => _driver.FindElement(By.CssSelector(".aic .z0 div"));
		public IWebElement SendButton => _driver.FindElement(By.XPath(".//*[contains(@class, 'T-I') and contains(@class, 'J-J5-Ji') and contains(@class, 'aoO')]"));
		public IWebElement AttachFileInput => _driver.FindElement(By.CssSelector(".bAK input[type=\"file\"]"));
		public IWebElement InboxButton => _driver.FindElement(By.CssSelector("[data-tooltip=\"Inbox\"] .bzz .aio .nU a[title=\"Inbox\"]"));
		public IWebElement BinButton => _driver.FindElement(By.CssSelector("[data-tooltip=\"Bin\"] .bzz .aio .nU a[title=\"Bin\"]"));
		public IWebElement StarredButton => _driver.FindElement(By.CssSelector("[data-tooltip=\"Starred\"] .TN .aio .nU a[title=\"Starred\"]"));
		public IWebElement MarkAsUnreadButton => _driver.FindElement(By.CssSelector(".nH .aeH .D .nH .Cq .bzn .G-tF .G-Ni [title=\"Mark as unread\"] .asa")); //available after selecting an email
		public IWebElement StarredEmailButton => _driver.FindElement(By.CssSelector("table[role =\"grid\"] tr:first-of-type td.apU span")); //starred option for the first mail of the list
		
		//Fields//
		public IWebElement SendToField => _driver.FindElement(By.CssSelector(".bzf .eV .oj .wO textarea"));
		public IWebElement SubjectField => _driver.FindElement(By.Name("subjectbox"));
		public IWebElement EmailBodyField => _driver.FindElement(By.XPath(".//*[contains(@class, 'Am') and contains(@class, 'Al')]"));

		//Strings//
		public IWebElement MessageSentString => _driver.FindElements(By.CssSelector(".J-J5-Ji .vh .aT .bAq")).FirstOrDefault();
		public IWebElement FirstEmailTitleString => _driver.FindElement(By.CssSelector("[role =\"grid\"] tr:first-of-type .xY .xS .xT .y6 .bog span"));//Used to get Title of the first email on the grid
		public IWebElement FirstEmailRow => _driver.FindElement(By.CssSelector("[role =\"grid\"] tr:first-of-type"));

		//pop-ups//
		public IWebElement NoRecipientPopUp => _driver.FindElement(By.ClassName("Kj-JD-Jz"));

	}
}
