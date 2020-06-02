using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.WindowsRuntime;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace GmailTests
{
    [TestFixture]
    public class SendEmailTests : GmailTestsBase
    {
        [Test(Description = "Send an e-mail")]
        [TestCase("tucamaiochi@gmail.com", "title", "text", ExpectedResult = true)]
        [TestCase("tucamaiochigmail.com", "title", "text", ExpectedResult = false)]
        public bool MessageSentDisplayed(string emailTo, string title, string emailBody)
        {
            components.ComposeButton.Click();
            System.Threading.Thread.Sleep(2000);
            components.SendToField.Click();
            components.SendToField.SendKeys(emailTo);
            components.SubjectField.SendKeys(title);
            components.EmailBodyField.SendKeys(emailBody);
            components.SendButton.Click();
            System.Threading.Thread.Sleep(3000);
            if (!components.MessageSentString?.Displayed ?? true)
            {
                return false;
            }
            return true;
        }
    }
}