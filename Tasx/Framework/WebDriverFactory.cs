using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tasx.Framework
{
    class WebDriverFactory
    {
        private const string chrome = "CH";

        private static IWebDriver driver = null;
        public static IWebDriver GetInstance()
        {
            if (driver == null)
            {
                TestConfigurations.Configure();
                if (TestConfigurations.Browser == chrome)
                {
                    driver = new ChromeDriver();
                }
            }
            return driver;
        }
    }
}
