using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tasx.PageObjects;
using Tasx.Tests;
using Tasx.Framework;

namespace Tasx.Tests
{
    [TestFixture]
    [Category("TestAllfunction")]
    class EditMassage : TestBase
    {
       
        public override void OneTimeSetUp()
        {
            driver = WebDriverFactory.GetInstance();
            AccountPage accountPage = Navigator.NavigateToInbox(driver);
           // AccountPage accountPage = new AccountPage(driver);
            accountPage.SetCreateMEssage();
        }

        [TestCase("Myroslawa95@gmail.com")]
        public void EditMail(string mail)
        {

            AccountPage AccountP = new AccountPage(driver);

            AccountP.SetOpenSavedMessage();

            AccountP.EditToField1Message(mail);
            //AccountP.UploadFiles();
            AccountP.SetSaveMessageButton();

            AccountP.SetOpenSavedMessage();

            Assert.AreEqual(AccountP.ToFieldMessage.GetAttribute("value"), mail);

            AccountP.SetSaveMessageButton();
            


        }

        [TestCase("Description")]
        public void EditMail2(string body)
        {

         AccountPage AccountP = new AccountPage(driver);

           AccountP.SetOpenSavedMessage();

            AccountP.EditToField2Message(body);
            
          AccountP.SetSaveMessageButton();

            AccountP.SetOpenSavedMessage();

            Assert.AreEqual(body + "\r\n", AccountP.BodyFieldMessage.GetAttribute("value"));

            AccountP.SetSaveMessageButton();
            //accountp.openfolderwithmessages();
            //accountp.deletemessages();


        }

        [Test]
        public void UploadFiles()
        {
            AccountPage AccountP = new AccountPage(driver);

            AccountP.SetOpenSavedMessage();
            AccountP.UploadFileToMessage();

        }

        public override void OneTimeTearDown()
        {
            AccountPage AccountP = new AccountPage(driver);
            AccountP.OpenFolderWithMessages();
            AccountP.DeleteMessages();
            driver.Quit();
        }
    }
}
