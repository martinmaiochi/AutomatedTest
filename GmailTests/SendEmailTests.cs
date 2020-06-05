using System.Runtime.InteropServices.WindowsRuntime;
using NUnit.Framework;
using OpenQA.Selenium;

namespace GmailTests
{
	[TestFixture]
    public class SendEmailTests : GmailTestsBase
    {
        [Test(Description = "Send an e-mail")]
        [TestCase("tucamaiochi@gmail.com", "titleforTest", "text", ExpectedResult = true)]
        [TestCase("tucamaiochigmail.com", "title", "text", ExpectedResult = false)]
        public bool MessageSentDisplayed(string emailTo, string title, string emailBody)
        {
            System.Threading.Thread.Sleep(2000);
            components.MainPage.SendToField.Click();
            components.MainPage.SendToField.SendKeys(emailTo);
            components.MainPage.SubjectField.SendKeys(title);
            components.MainPage.EmailBodyField.SendKeys(emailBody);
            components.MainPage.SendButton.Click();
            System.Threading.Thread.Sleep(3000);
            if (!components.MainPage.MessageSentString?.Displayed ?? true)
            {
                return false;
            }
            return true;
        }

        [TestCase("tucamaiochi@gmail.com", "title", "I'm attaching this document", ExpectedResult = true)]
        [TestCase("tucamaiochi@gmail.com", "title", "text", ExpectedResult = false)]
        public bool CheckMissingAttachement(string emailTo, string title, string emailBody)
        {
            System.Threading.Thread.Sleep(2000);
            components.MainPage.SendToField.Click();
            components.MainPage.SendToField.SendKeys(emailTo);
            components.MainPage.SubjectField.SendKeys(title);
            components.MainPage.EmailBodyField.SendKeys(emailBody);
            components.MainPage.SendButton.Click();
            System.Threading.Thread.Sleep(1000);
			try
			{
                var alert = driver.SwitchTo().Alert().Text;
                return alert.Contains("It seems like you have forgotten to attach a file.");
            }
			catch (NoAlertPresentException)
			{
                return false;
			}

        }

        [TestCase("title", "text", ExpectedResult = true)]
        public bool MissingToNotification(string title, string emailBody)
        {
            System.Threading.Thread.Sleep(2000);
            components.MainPage.SendToField.Click();
            components.MainPage.SubjectField.SendKeys(title);
            components.MainPage.EmailBodyField.SendKeys(emailBody);
            components.MainPage.SendButton.Click();
            System.Threading.Thread.Sleep(3000);
            if (!components.MainPage.NoRecipientPopUp.Displayed)
            {
                return false;
            }
            return true;
        }

        protected override void SetupTest()
        {
            base.SetupTest();
            components.MainPage.ComposeButton.Click();
        }
    }
}