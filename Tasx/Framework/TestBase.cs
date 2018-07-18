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
using Tasx.PageObjects;

namespace Tasx.Tests
{
   public class TestBase 
    {
        public IWebDriver driver;
        
        [OneTimeSetUp]
        public void BaseOneTimeSetUp()
        {
            driver = WebDriverFactory.GetInstance();
            AccountPage accountPage = Navigator.NavigateToInbox(driver);
            accountPage.SetCreateMEssage(); 


        }

        [SetUp]
        public void BaseSetUp()
        {
            Console.WriteLine(TestContext.CurrentContext.Test.Name);
                     

        }

        [TearDown]
        public void BaseTearDown()
        {
            
            Console.WriteLine(TestContext.CurrentContext.Result);
        }

        [OneTimeTearDown]
        public void  BaseOneTimeTearDown()
        {

            //AccountPage accountPage = Navigator.NavigateToInbox(driver);
            //accountPage.OpenFolderWithMessages();
            //accountPage.DeleteMessages();
            //driver.SwitchTo().Alert().Accept();
            driver.Quit();
            OneTimeTearDown();
        }
        public virtual void OneTimeTearDown()
        {

        }

    }
}
