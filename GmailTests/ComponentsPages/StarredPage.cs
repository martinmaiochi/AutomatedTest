using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic;
using OpenQA.Selenium;

namespace GmailTests.ComponentsPages
{
	public class StarredPage
	{
		private IWebDriver _driver;
		public StarredPage(IWebDriver driver)
		{
			_driver = driver;
		}
		//Buttons//
		public IWebElement UnstarredEmailButton => _driver.FindElement(By.CssSelector("[role =\"main\"] .ae4 .Cp .F tr:first-of-type .apU .T-KT"));

		//Strings//
		public IWebElement FirstEmailTitleString => _driver.FindElement(By.CssSelector("[role =\"main\"] .ae4 .Cp .F tr:first-of-type .bog span"));//Used to get Title of the first email on the grid
	}
}
