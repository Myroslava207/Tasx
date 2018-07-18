using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasx
{
    public class Tasx
    {
        IWebDriver driver;

        [OneTimeSetUp]

        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://tasx.com/login?returnUrl=%2F");

        }
        [Test]

        public void LoginPageTitle()
        {
            Assert.AreEqual("Tasx", driver.Title);

        }

        [Test]

        public void LoginFieldUserName()
        {
            IWebElement LoginField = driver.FindElement(By.XPath("//input[@name='username']"));
            Assert.IsTrue(LoginField.Displayed);
        }

        [Test]

        public void LoginFieldPassword()
        {
            IWebElement LoginField = driver.FindElement(By.Name("password"));
            Assert.IsTrue(LoginField.Displayed);
        }

        [Test]

        public void LoginButtonSignIn()
        {
            IWebElement LoginButton = driver.FindElement(By.Id("login-button"));
            Assert.IsTrue(LoginButton.Displayed);
        }

        [Test]

        public void LoginButtonForgot()
        {
            IWebElement LoginButton = driver.FindElement(By.Id("forgot-password"));
            Assert.IsTrue(LoginButton.Displayed);
        }

        [Test]

        public void LoginButtonAccount()
        {
            IWebElement LoginButton = driver.FindElement(By.Id("create-account"));
            Assert.IsTrue(LoginButton.Displayed);
        }

        [Test]

        public void LoginButtonTitle()
        {
            IWebElement LoginTitle = driver.FindElement(By.XPath("//span[contains(text(),'have and account')]"));
            Assert.IsTrue(LoginTitle.Displayed);
        }
        public void LoginForm()
        {
            IWebElement LoginFormAll = driver.FindElement(By.XPath("//*[@id='login - form']"));
            Assert.IsTrue(LoginFormAll.Displayed);
        }
    

        [OneTimeTearDown]
         public void TearDown()
        {
            driver.Quit();
        }
    }
}


