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


namespace Tasx
{
    class Translator : TestBase
    {
        [TestCase("cat", "кот", "Eng")]
        [TestCase("dog", "собака", "Eng")]
        //[TestCase("un chat", "cat", "Fre")]
        public void Testransl(string word, string trans, string language)
        {
            
            HomePage hPage = new HomePage(driver);
            hPage.translitePage.Click();

            TranslatePage tPage = new TranslatePage(driver);
            tPage.Translate(word);
            tPage.SetButtonLanguageDropdown();
            tPage.SetWaitSelectLanguage(language);
            tPage.SetWaitTranslateButton();

            Assert.AreEqual(tPage.Translated.GetAttribute("value"), trans);

            tPage.SetFieldClear();
        }


    }
}
