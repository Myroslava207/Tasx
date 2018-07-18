using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Tasx.Framework;

namespace Tasx.PageObjects
{
    class TranslatePage
    {
       public IWebDriver driver;

       public TranslatePage(IWebDriver driver) => this.driver = driver;
       public IWebElement TransliteField => driver.FindElement(By.XPath("//*[@id='first_textarea']"));
       public IWebElement ButtonLanguageDropdown => driver.FindElement(By.XPath("//*[@id='first_lang_selector']"));
       public IWebElement SelectLanguage(string language) => driver.FindElement(By.CssSelector($"#popup_language_menu_1 li.popup_menu_item[data-lang={language}]"));
       public IWebElement TranslateButton => driver.FindElement(By.XPath("//*[@id='new_translate']/div[2]/div[1]/div[2]/input"));
       public IWebElement Translated => driver.FindElement(By.Id("second_textarea"));
       public IWebElement FieldClear => driver.FindElement(By.XPath("//*[@id='first_textarea']"));


        public void Translate(string word)
        {
            TransliteField.SendKeys(word);
        }

        public void SetButtonLanguageDropdown()
        {
            ButtonLanguageDropdown.Click();
        }

        public void SetWaitSelectLanguage(string language)
        {
            WaitsExtensions.WaitForElementDisplayed(driver, SelectLanguage(language), 3);
            SelectLanguage(language).Click();
        }

        public void SetWaitTranslateButton()
        {
            WaitsExtensions.WaitForElementDisplayed(driver, TranslateButton, 3);
            TranslateButton.Click();
        }

        public void SetFieldClear()
        {
            FieldClear.Clear();
        }


    }
}
