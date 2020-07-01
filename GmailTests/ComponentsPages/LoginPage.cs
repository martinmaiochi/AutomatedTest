using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace GmailTests.ComponentsPages
{
	public class LoginPage
	{
		private IWebDriver _driver;
		public LoginPage(IWebDriver driver)
		{
			_driver = driver;
		}
		//Buttons//
		public IWebElement IdentifierNextButton => _driver.FindElement(By.XPath("//*[@id=\"identifierNext\"]/span/span"));
		public IWebElement PasswordNextButton => _driver.FindElement(By.CssSelector(".FliLIb .U26fgb .CwaK9"));


		//Fields//
		public IWebElement UserNameField => _driver.FindElement(By.XPath("//*[@id=\"identifierId\"]"));
		public IWebElement PasswordField => _driver.FindElement(By.XPath("//*[@id=\"password\"]/div[1]/div/div[1]/input"));
	}
}
