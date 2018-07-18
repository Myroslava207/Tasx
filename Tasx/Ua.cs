using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasx
{
    class Ua
    {

        IWebDriver driver;

        [OneTimeSetUp]

        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.i.ua/");

        }
        [Test]

        public void LoginPageTitle()
        {
            Assert.AreNotEqual("І.UA - твоя пошта ", driver.Title);

        }

        [Test]
        public void AllForm()
        {
            IWebElement Form = driver.FindElement(By.XPath("/html/body/div[3]/div[3]/div[3]/div[2]/div[1]/div[3]"));
            Assert.IsTrue(Form.Displayed);

        }

        [Test]
        public void FieldLogin()
        {
            IWebElement Login = driver.FindElement(By.XPath("//input[@name='login']"));
            Assert.IsTrue(Login.Displayed);

        }

        [Test]
        public void FieldPassword()
        {
            IWebElement Password = driver.FindElement(By.XPath("//input[@name='pass']"));
            Assert.IsTrue(Password.Displayed);

        }

        [Test]
        public void Select()
        {
            IWebElement Select = driver.FindElement(By.XPath("//select[@name='domn']"));
            Assert.IsTrue(Select.Displayed);

        }

        [Test]
        public void ButtonLogin()
        {
            IWebElement ButtonLogin = driver.FindElement(By.XPath("//input[@value='Увійти']"));
            Assert.IsTrue(ButtonLogin.Displayed);

        }


        [Test]
        public void LingReg()
        {
            IWebElement Link = driver.FindElement(By.XPath("//a[@href='//passport.i.ua/']"));
            Assert.IsTrue(Link.Displayed);

        }

        [Test]
        public void LingReminder()
        {
            IWebElement Reminder = driver.FindElement(By.XPath("//a[@href='//passport.i.ua/recover/']"));
            Assert.IsTrue(Reminder.Displayed);

        }

        [Test]
        public void LogIn()
        {
            IWebElement Login = driver.FindElement(By.XPath("//input[@name='login']"));
            IWebElement Password = driver.FindElement(By.XPath("//input[@name='pass']"));
            IWebElement ButtonLogin = driver.FindElement(By.XPath("/html/body/div[3]/div[3]/div[3]/div[2]/div[1]/div[3]/form/p/input"));
            Login.SendKeys("autoTest1234@i.ua ");
            Password.SendKeys("autoTest1234autoTest1234");
            ButtonLogin.Click();
            Assert.AreEqual("Вхідні - I.UA ", driver.Title);

        }

        [Test]
        public void LogIn2()
        {
            IWebElement Login = driver.FindElement(By.XPath("//input[@name='login']"));
            IWebElement Password = driver.FindElement(By.XPath("//input[@name='pass']"));
            IWebElement ButtonLogin = driver.FindElement(By.XPath("//input[@value='Увійти']"));
            IWebElement Select = driver.FindElement(By.XPath("//select[@name='domn']"));
            Login.SendKeys("autoTest1234@i.ua ");
            Password.SendKeys("autoTest1234autoTest1234");

            SelectElement dropdown = new SelectElement(Select);
            string selectedOption = dropdown.SelectedOption.Text;
            dropdown.SelectByText("ua.fm"); 
            
           Assert.AreEqual("ua.fm", dropdown.SelectedOption.Text);
           Assert.True(Login.Displayed);
        }



        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}

