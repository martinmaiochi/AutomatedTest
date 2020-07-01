# GmailTests

This project is a test suite made with Selenium Webdriver and NUnit containing automated tests designed to work on Gmail with the purpose of validation and verification of its functionalities.

## Getting Started

Before running the project, open the Settings file which requires the e-mail address and password of the account where the tests are going to be performed, use this class to put the e-mail credentials.

```bash
public static class Settings
{
	public const string EmailLogin = "yourUsername@gmail.com";
	public const string EmailPassword = "yourPassowrd";
}
```

## Running the Tests

With the credentials all set, tests can be runned by clicking with the right button on any on the Test Explorer and selecting Run.


## ComponentsPages Folder

Contains classes that find the page elements that will be used during tests.
These elements can vary from Buttons, CheckBoxes, fields or even strings and are located by it's CssSelector, name or XPath:

```
public IWebElement ComposeButton => _driver.FindElement(By.CssSelector(".aic .z0 div"));

public IWebElement SubjectField => _driver.FindElement(By.Name("subjectbox")); 

public IWebElement EmailBodyField => _driver.FindElement(By.XPath(".//*[contains(@class, 'Am') and contains(@class, 'Al')]"));
```
## Helpers Folder
