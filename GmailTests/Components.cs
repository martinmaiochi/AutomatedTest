using System;
using System.Collections.Generic;
using System.Text;
using GmailTests.ComponentsPages;
using OpenQA.Selenium;

namespace GmailTests
{
	public class Components
	{
		private IWebDriver _driver;
		private LoginPage _loginPage;
		private MainPage _mainPage;

		public Components(IWebDriver driver)
		{
			_driver = driver;
			_loginPage = new LoginPage(driver);
			_mainPage = new MainPage(driver);
		}

		public LoginPage LoginPage => _loginPage;
		public MainPage MainPage => _mainPage;
	}
}
