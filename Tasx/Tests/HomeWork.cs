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




namespace Tasx
{
    class HomeWork : TestBase
    {
        

        [Test]
        public void LogIn2()
        {
            LoginPage LoginP = new LoginPage(driver);

            

            LoginP.SetCheckboxClick();
            LoginP.SetSelect();
            LoginP.LoginField();

            Assert.True(LoginP.LoginField().Displayed);
            Assert.True(LoginP.PasswordField().Displayed);
            Assert.True(LoginP.Checkbox().Selected);

            LoginP.SetLoginButton();
        }

      

        [Test]
        public void CheckYourEmail()
        {
                      
            AccountPage AccountP = new AccountPage(driver);

            AccountP.SetAccountTitle();
                       
            Assert.AreEqual("autoTest1234@i.ua", AccountP.AccountTitle.Text);



        }
        [Test]
        public void CheckMails()
        {
            
            AccountPage AccountP = new AccountPage(driver);
            
            Assert.AreEqual("Невелика довідка про можливості пошти", AccountP.Message1.Text);
            Assert.AreEqual("Ласкаво просимо на I.UA!", AccountP.Message2.Text);
        }

        [Test]
        public void CheckPopup()
        {
           
            AccountPage AccountP = new AccountPage(driver);

            AccountP.MoveOnMessage();
            Thread.Sleep(1000);
            AccountP.SetWaitTranslateButton();
           
        }

        [Test]
        public void DeleteMail()
        {
            LoginPage LoginP = new LoginPage(driver);
            LoginP.SetLoginButton();
            IWebElement CheckBoxMail = driver.FindElement(By.XPath("//span[text()='Невелика довідка про можливості пошти']"));
            CheckBoxMail.Click();

           // Assert.True(CheckBoxMail.Selected);

            IWebElement Del = driver.FindElement(By.XPath("//span[@buttonname='del']"));
            Del.Click();

            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();

            bool isLetterDeleted = false;
            
            try
            {
                CheckBoxMail.Click();

            }
            catch (OpenQA.Selenium.NoSuchElementException)
            {
                isLetterDeleted = true;

            }

            Assert.True(isLetterDeleted);

        }

        [Test]
        public void MultipleWindows()
        {
            IWebElement Login = driver.FindElement(By.XPath("//input[@name='login']"));
            IWebElement Password = driver.FindElement(By.XPath("//input[@name='pass']"));
            IWebElement ButtonLogin = driver.FindElement(By.XPath("/html/body/div[3]/div[3]/div[3]/div[2]/div[1]/div[3]/form/p/input"));
            Login.SendKeys("autoTest1234@i.ua");
            Password.SendKeys("autoTest1234autoTest1234");
            ButtonLogin.Click();

            var LoginTitle = driver.FindElement(By.XPath("//span[@class='sn_menu_title']"));
            string LoginCheck = LoginTitle.Text;
  //          Assert.AreEqual("autoTest1234@i.ua", LoginTitle.Text);

            string CurrentWindow = driver.CurrentWindowHandle;
            IWebElement BasicPage = driver.FindElement(By.XPath("//*[@id='header_overall']/div[1]/ul[1]/li[1]/a"));
            // BasicPage.Click(); 

            BasicPage.SendKeys(Keys.Control + Keys.Return);

            var windows = driver.WindowHandles;

            foreach (var window in windows)
            {
                if (window != CurrentWindow)
                {
                    driver.SwitchTo().Window(window);
                }
            }

           IWebElement Logout = driver.FindElement(By.XPath("/html/body/div[2]/div[3]/ul[1]/li[8]/a"));
            Logout.Click();

            driver.SwitchTo().Window(CurrentWindow);
               
            driver.Navigate().Refresh();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(p => driver.FindElement(By.XPath("/html/body")).Displayed);
            IWebElement Login1 = driver.FindElement(By.XPath("/ html / body")); 
            Assert.True(Login1.Displayed);

        }


         
         [TestCase ("Myroslawa95@gmail.com")]
        public void EditMail(string mail)
        {
            
            AccountPage AccountP = new AccountPage(driver);

            AccountP.SetOpenSavedMessage();

            AccountP.EditToField1Message(mail);
            AccountP.UploadFiles();
            AccountP.SetSaveMessageButton();

            AccountP.SetOpenSavedMessage();

            Assert.AreEqual(AccountP.ToFieldMessage.GetAttribute("value"), mail);

            AccountP.SetSaveMessageButton();
            //AccountP.OpenFolderWithMessages();
            //AccountP.DeleteMessages();


        }

        [Test]
        public void EditMail2(string body)
        {

            AccountPage AccountP = new AccountPage(driver);

            AccountP.SetOpenSavedMessage();

            AccountP.EditToField2Message(body);
            // AccountP.UpoadFiles();
            AccountP.SetSaveMessageButton();

            AccountP.SetOpenSavedMessage();

            Assert.AreEqual(AccountP.BodyFieldMessage.GetAttribute("value"), body);

            AccountP.SetSaveMessageButton();
            //AccountP.OpenFolderWithMessages();
            //AccountP.DeleteMessages();


        }



    }
}
