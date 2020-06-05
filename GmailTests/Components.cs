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
		private BinPage _binPage;
		private StarredPage _starredPage;

		public Components(IWebDriver driver)
		{
			_driver = driver;
			_loginPage = new LoginPage(driver);
			_mainPage = new MainPage(driver);
			_binPage = new BinPage(driver);
			_starredPage = new StarredPage(driver);
		}

		public LoginPage LoginPage => _loginPage;
		public MainPage MainPage => _mainPage;
		public BinPage BinPage => _binPage;
		public StarredPage StarredPage => _starredPage;
	}
}
