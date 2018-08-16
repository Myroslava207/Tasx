using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasx.PageObjects;
using Tasx.Framework;
using Tasx.Tests;


namespace Tasx.Tests
{
    [TestFixture]
    [Category("TestAllfunction")]
    class Translator : TestBase
    {
        
        public override void OneTimeSetUp()
        {
            driver = WebDriverFactory.GetInstance();
            Navigator.OpenPage(driver);
            HomePage hPage = new HomePage(driver);
            hPage.translitePage.Click();
        }

        [TestCase("cat", "кот", "Eng")]
        [TestCase("dog", "собака", "Eng")]
        //[TestCase("un chat", "cat", "Fre")]
        public void Testransl(string word, string trans, string language)
        {
            TranslatePage tPage = new TranslatePage(driver);
            tPage.Translate(word);
            tPage.SetButtonLanguageDropdown();
            tPage.SetWaitSelectLanguage(language);
            tPage.SetWaitTranslateButton();

            Assert.AreEqual(tPage.Translated.GetAttribute("value"), trans);

            tPage.SetFieldClear();
        }       
        public override void OneTimeTearDown()
        {
            driver.Quit();
        }
    }
}
