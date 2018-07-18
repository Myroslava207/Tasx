using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasx.Framework;

namespace Tasx.PageObjects
{
    public class AccountPage
    {

        public IWebDriver driver;
        public AccountPage(IWebDriver driver) => this.driver = driver;
        public IWebElement AccountTitle => driver.FindElement(By.XPath("//span[@class='sn_menu_title']"));
        public IWebElement Message1 => driver.FindElement(By.XPath("//span[text()='Невелика довідка про можливості пошти']"));
        public  IWebElement Message2 => driver.FindElement(By.XPath("//span[text()='Ласкаво просимо на I.UA!']"));
        public IWebElement PopupInfoMassage => driver.FindElement(By.XPath("//div[@id='prflpudvmbox_userInfoPopUp']"));

        public void SetAccountTitle()
        {
            string LoginCheck = AccountTitle.Text;
        }

        public void MoveOnMessage()
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(Message1).Build().Perform();
        }

        public void SetWaitTranslateButton()
        {
            WaitsExtensions.WaitForElementDisplayed(driver, PopupInfoMassage, 3);
            
        }
        public IWebElement CreateMessageButton => driver.FindElement(By.XPath("/html/body/div[1]/div[4]/ul/li[2]/a"));
        public IWebElement ToFieldMessage => driver.FindElement(By.XPath("//textarea[@name = 'to']"));
        public IWebElement SubjectFieldMessage => driver.FindElement(By.XPath("//input[@name = 'subject']"));
        public IWebElement BodyFieldMessage => driver.FindElement(By.XPath("//div[@class = 'text_editor_browser']"));
        public IWebElement SaveMessageButton => driver.FindElement(By.XPath("//input[@value = 'Зберегти чернетку']"));
        public IWebElement OpenFolderWithSavedMessages => driver.FindElement(By.XPath("/html/body/div[1]/div[5]/div[2]/div/div/div[2]/div[2]/div[3]/ul/li[3]/a"));
        public IWebElement OpenSavedMessageButton => driver.FindElement(By.XPath("//span[text() = 'Topic this mail']"));
        public IWebElement UploadFile => driver.FindElement(By.XPath("//span[text() = 'Вкласти файл']"));
        public IWebElement ChooseFileForUpload => driver.FindElement(By.XPath("//input[@type = 'file']"));
        public IWebElement DownloadAttachedFile => driver.FindElement(By.XPath("//a[@href ='http://wdatt.i.ua/upl/3/1/9974713_1410259248/1.txt?i=5zf20pdUkC62SmA1zUtV4Q&e=1532006862&ip=95.46.141.167']"));


        public void SetCreateMEssage()
        {
            CreateMessageButton.Click();
            SubjectFieldMessage.SendKeys("Topic this mail");
            SaveMessageButton.Click();
        }

        public void OpenFolderWithMessages()
        {
            OpenFolderWithSavedMessages.Click();
            
        }
        public void SetOpenSavedMessage()
        {
            OpenFolderWithSavedMessages.Click();
            OpenSavedMessageButton.Click();
        }


        public IWebElement EditToField1Message(string mail)
        {
            ToFieldMessage.SendKeys(mail);
            return ToFieldMessage;
        }
        public IWebElement EditToField2Message(string body)
        {
            BodyFieldMessage.SendKeys("Myroslawa95@gmail.com");
            return ToFieldMessage;
        }

        public void UploadFiles()
        {
           // string File = "‪1.txt";
            //string FilesPath = @"C:\\Users\\Myroslava\\Desktop\\" + File;
            UploadFile.Click();
            ChooseFileForUpload.Click();
            ChooseFileForUpload.SendKeys("C:\\Users\\Myroslava\\Desktop\\‪1.txt");
            DownloadAttachedFile.Click();




        }
        public void SetEditSubjectFieldMessage()
        {
            SubjectFieldMessage.SendKeys("Topic this mail");
        }

        public void SetEditBodyFieldMessage()
        {
            BodyFieldMessage.SendKeys("Description");
        }

        public void SetSaveMessageButton()
        {
            SaveMessageButton.Click();
        }

        public IWebElement CheckboxSelectMessage => driver.FindElement(By.XPath("//div[contains(@class, 'row')]//a//span[text()='Topic this mail']//parent::*/parent::*/parent::*//input[@type='checkbox']"));
        public IWebElement RemoveMessage => driver.FindElement(By.XPath("//span[@class = 'button l_r del']"));

        public void DeleteMessages()
        {
            CheckboxSelectMessage.Click();
            RemoveMessage.Click();
            driver.SwitchTo().Alert().Accept();
        }

    }
}
