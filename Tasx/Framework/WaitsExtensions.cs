using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tasx.Framework
{
    public static class WaitsExtensions
    {
        public static void WaitForElementDisplayed(this IWebDriver driver, IWebElement element, double timeSpan = 100)
        {
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeSpan));
            wait.Until(p => element.Displayed);
        }
        
    }
}
