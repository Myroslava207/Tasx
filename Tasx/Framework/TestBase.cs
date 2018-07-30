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
    [TestFixture]
    public class TestBase 
    {
        public IWebDriver driver;
        string testname = TestContext.CurrentContext.Test.Name;

        [OneTimeSetUp]
        public void BaseOneTimeSetUp()
        {
            OneTimeSetUp();
        }

        public virtual void OneTimeSetUp()
        {
        }

        [SetUp]
        public void BaseSetUp()
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine(testname);
                          
        }

        [TearDown]
        public void BaseTearDown()
        {
            Console.WriteLine("--------------------------");

            Console.WriteLine(TestContext.CurrentContext.Result.Outcome.Status);

            
              var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            string title = TestContext.CurrentContext.Test.Name;
            string runname = title + DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss");
            string filePath = @"C:\";

            screenshot.SaveAsFile(filePath + runname + ".jpg", ScreenshotImageFormat.Jpeg);




        }


        [OneTimeTearDown]
        public void  BaseOneTimeTearDown()
        {

            OneTimeTearDown();
            //driver.Quit();
        }

        public virtual void OneTimeTearDown()
        {

        }

    }
}
