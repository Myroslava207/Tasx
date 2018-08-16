using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasx.PageObjects

{
    public class HomePage 
    {
        public IWebDriver driver;
        public HomePage(IWebDriver driver) => this.driver = driver;

        public IWebElement translitePage => driver.FindElement(By.XPath("/html/body/div[3]/div[3]/div[2]/div[5]/div[3]/h2/a"));

    }
}
