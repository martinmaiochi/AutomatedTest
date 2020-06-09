using System.Runtime.InteropServices.WindowsRuntime;
using NUnit.Framework;
using OpenQA.Selenium;

namespace GmailTests
{
    [TestFixture]
    public class SendEmailTests : GmailTestsBase
    {
        [Test(Description = "Send an e-mail")]
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

        [TestCase("tucamaiochi@gmail.com", "title", "I'm attaching this document", ExpectedResult = true)]
        [TestCase("tucamaiochi@gmail.com", "title", "text", ExpectedResult = false)]
        public bool CheckMissingAttachementMessage(string emailTo, string title, string emailBody)
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
            var firstRow = components.MainPage.FirstEmailRow.GetAttribute("class");
            
            Assert.IsTrue(firstRow.Contains("zE"));

            components.MainPage.FirstEmailRow.Click();
            System.Threading.Thread.Sleep(2000);
            components.MainPage.InboxButton.Click();
            System.Threading.Thread.Sleep(2000);

            var firstRowRead = components.MainPage.FirstEmailRow.GetAttribute("class");

            Assert.IsTrue(firstRowRead.Contains("yO"));

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
                components.MainPage.AttachFileInput.SendKeys("./Attachments/picture.png");
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