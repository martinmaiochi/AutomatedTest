using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace GmailTests.ComponentsPages
{
	public class BinPage
	{
		private IWebDriver _driver;
		public BinPage(IWebDriver driver)
		{
			_driver = driver;
		}
		public IWebElement EmptyBinNowButton => _driver.FindElements(By.CssSelector(".ya .x2")).FirstOrDefault();
		public IWebElement ConfirmEmptyBinNowButton => _driver.FindElement(By.CssSelector(".J-at1-atl"));
	}
}
