using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace GmailTests
{
	public class Components
	{
		private IWebDriver _driver;
		public Components(IWebDriver driver)
		{
			_driver = driver;
		}

		//Buttons//
		public IWebElement ComposeButton => _driver.FindElement(By.CssSelector(".aic .z0 div"));
		public IWebElement IdentifierNextButton => _driver.FindElement(By.XPath("//*[@id=\"identifierNext\"]/span/span"));
		public IWebElement PasswordNextButton => _driver.FindElement(By.XPath("//*[@id=\"passwordNext\"]/span/span"));
		public IWebElement SendButton => _driver.FindElement(By.XPath(".//*[contains(@class, 'T-I') and contains(@class, 'J-J5-Ji') and contains(@class, 'aoO')]"));


		//Fields//
		public IWebElement UserNameField => _driver.FindElement(By.XPath("//*[@id=\"identifierId\"]"));
		public IWebElement PasswordField => _driver.FindElement(By.XPath("//*[@id=\"password\"]/div[1]/div/div[1]/input"));
		public IWebElement SendToField => _driver.FindElement(By.CssSelector(".bzf .eV .oj .wO textarea"));
		public IWebElement SubjectField => _driver.FindElement(By.Name("subjectbox"));
		public IWebElement EmailBodyField => _driver.FindElement(By.XPath(".//*[contains(@class, 'Am') and contains(@class, 'Al')]"));

		//Strings//
		public IWebElement MessageSentString => _driver.FindElements(By.CssSelector(".J-J5-Ji .vh .aT .bAq")).FirstOrDefault();
	}
}
