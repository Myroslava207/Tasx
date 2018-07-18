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
    class VijetUA
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
        public void Goro()
        {
            IWebElement Tommorow = driver.FindElement(By.XPath("//a[contains(text(),'Гороскоп на завтра')]"));
            Assert.IsTrue(Tommorow.Displayed);

        }

        [Test]
        public void Gor()
        {
            IWebElement TommorowAll = driver.FindElement(By.CssSelector("a:contains('Телець')"));
            Assert.IsTrue(TommorowAll.Displayed);

        }

        [Test]
        public void AllVij()
        {
            IWebElement AllVig = driver.FindElement(By.XPath("a:contains('Телець')"));
            Assert.IsTrue(AllVig.Displayed);

        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}

