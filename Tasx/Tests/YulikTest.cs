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
    class YulikTest : TestBase
    {
        public override void OneTimeSetUp()
        {
            driver = WebDriverFactory.GetInstance();
            LoginPage loginPage = Navigator.NavigateToHomePage(driver);
        }
        [Test]
        public void LogInWithIncorrectDomain()
        {
            LoginPage loginPage = new LoginPage(driver);

            loginPage.LoginField().SendKeys("test261998");
            loginPage.PasswordField().SendKeys("Password1");
            SelectElement SelectName = new SelectElement(loginPage.Select());
            SelectName.SelectByText("ua.fm");
            loginPage.SetCheckboxClick();
            loginPage.ButtonLogin.Click();
            Assert.IsTrue(loginPage.IncorrectCredentials().Displayed);
        }
        public override void OneTimeTearDown()
        {
            driver.Quit();
        }
    }
}
