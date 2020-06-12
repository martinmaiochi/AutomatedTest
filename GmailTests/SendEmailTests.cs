using System.Runtime.InteropServices.WindowsRuntime;
using GmailTests.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace GmailTests
{
    [TestFixture]
    public class SendEmailTests : GmailTestsBase
    {
        [Test(Description = "Send an e-mail and verify if notification was shown")]
        [TestCase("tucamaiochi@gmail.com", "titleforTest", "text", false, ExpectedResult = true)]
        [TestCase("tucamaiochi@gmail.com", "emailWithAttachment", "text", true, ExpectedResult = true)]
        [TestCase("tucamaiochigmail.com", "title", "text", false, ExpectedResult = false)]
        [TestCase("", "", "", false, ExpectedResult = false)]

        public bool MessageSentDisplayed(string emailTo, string title, string emailBody, bool attachment)
        {
            SendEmail(emailTo, title, emailBody, attachment);
            System.Threading.Thread.Sleep(3000);
            if (!components.MainPage.MessageSentString?.Displayed ?? true)
            {
                return false;
            }
            return true;
        }

        [Test(Description = "Send an e-mail with attachment")]
        [TestCase("tucamaiochi@gmail.com", "titleforTest", "text", ExpectedResult = true)]
        public bool MessageSentWithAttachment(string emailTo, string title, string emailBody)
        {
            SendEmail(emailTo, title, emailBody, true);

            return true;
        }

        [Test(Description = "Send an e-mail with attachment and check if it's row has a Clip icon")]
        [TestCase("tucamaiochi@gmail.com", "titleforTest", "text", true, ExpectedResult = true)]
        [TestCase("tucamaiochi@gmail.com", "titleforTest", "text", false, ExpectedResult = false)]
        public bool CheckAttachmentIcon(string emailTo, string title, string emailBody, bool hasAttachment)
        {
            SendEmail(emailTo, title, emailBody, hasAttachment);
            return EmailRowHelper.HasAttachment(components.MainPage.FirstEmailRow);
        }

        [Test(Description = "Check notification given when you mention attachment without attaching file")]
        [TestCase("tucamaiochi@gmail.com", "title", "I'm attaching this document", ExpectedResult = true)]
        [TestCase("tucamaiochi@gmail.com", "title", "text", ExpectedResult = false)]
        public bool CheckMissingAttachmentMessage(string emailTo, string title, string emailBody)
        {
            SendEmail(emailTo, title, emailBody, false);
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

        [Test(Description = "Open an email and check if it's row was marked as 'read'")]
        [TestCase("tucamaiochi@gmail.com", "CheckEmailWasReadTest", "description", ExpectedResult = true)]
        public bool CheckEmailWasRead(string emailTo, string title, string emailBody)
        {
            SendEmail(emailTo, title, emailBody, false);
            System.Threading.Thread.Sleep(2000);
            var firstRow = components.MainPage.FirstEmailRow;
            
            Assert.IsTrue(EmailRowHelper.IsUnread(firstRow));

            components.MainPage.FirstEmailRow.Click();
            System.Threading.Thread.Sleep(2000);
            components.MainPage.InboxButton.Click();
            System.Threading.Thread.Sleep(2000);

            var firstRowRead = components.MainPage.FirstEmailRow;

            Assert.IsTrue(EmailRowHelper.IsRead(firstRowRead));

            return true;
        }

        [Test(Description = "Send an email and verify if it was recieved")]
        [TestCase("tucamaiochi@gmail.com", "CheckEmailWasSentTest", "description", ExpectedResult = true)]
        public bool CheckEmailWasSent(string emailTo, string title, string emailBody)
        {
            SendEmail(emailTo, title, emailBody, false);
            System.Threading.Thread.Sleep(1000);

            var mailTitleInbox = components.MainPage.FirstEmailTitleString.Text;

            Assert.AreEqual(mailTitleInbox, "CheckEmailWasSentTest");

            return true;
        }

        [Test(Description = "verify if notification of missing email address is shown")]
        [TestCase("title", "text", ExpectedResult = true)]
        public bool MissingToNotification(string title, string emailBody)
        {
            SendEmail("", title, emailBody, false);
            System.Threading.Thread.Sleep(3000);
            if (!components.MainPage.NoRecipientPopUp.Displayed)
            {
                return false;
            }
            return true;
        }

        [Test(Description = "Mark a read email as unread and check if row is as unread")]
        [TestCase("tucamaiochi@gmail.com", "title", "text", ExpectedResult = true)]
        public bool CheckEmailUnreadRow(string emailTo, string title, string emailBody)
        {
            SendEmail(emailTo, title, emailBody, false);
            components.MainPage.FirstEmailRow.Click();
            System.Threading.Thread.Sleep(2000);
            components.MainPage.InboxButton.Click();
            System.Threading.Thread.Sleep(2000);

            var checkbox = EmailRowHelper.GetCheckBox(components.MainPage.FirstEmailRow);
            checkbox.Click();

            System.Threading.Thread.Sleep(1000);
            components.MainPage.MarkAsUnreadButton.Click();
            System.Threading.Thread.Sleep(2000);
            components.MainPage.FirstEmailCheckBoxButton.Click();

            EmailRowHelper.IsUnread(components.MainPage.FirstEmailRow);

            return true;
        }

        private void SendEmail(string emailTo, string title, string emailBody, bool attachment)
        {

            System.Threading.Thread.Sleep(2000);
            if (!string.IsNullOrEmpty(emailTo))
            {
                components.MainPage.SendToField.Click();
                components.MainPage.SendToField.SendKeys(emailTo);
            }

            if (!string.IsNullOrEmpty(title))
            {
                components.MainPage.SubjectField.SendKeys(title);
            }

            if (!string.IsNullOrEmpty(emailBody))
            {
                components.MainPage.EmailBodyField.SendKeys(emailBody);
            }

            if (attachment)
            {
                components.MainPage.AttachFileInput.SendKeys(System.Environment.CurrentDirectory + "\\Attachments\\picture.png");
                System.Threading.Thread.Sleep(3000);
            }
            components.MainPage.SendButton.Click();
            System.Threading.Thread.Sleep(3000);

        }

        protected override void SetupTest()
        {
            base.SetupTest();
            components.MainPage.ComposeButton.Click();
        }
    }
}