using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasx.PageObjects;
using Tasx.Tests;

namespace Tasx.Framework

{
    public static class Navigator   
    {
        

        public static LoginPage NavigateToHomePage(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("http://www.i.ua/");
            return new LoginPage(driver);
        }


        public static AccountPage NavigateToInbox(IWebDriver driver)
        {
            LoginPage loginPage = NavigateToHomePage(driver);
            loginPage.Login(TestConfigurations.Username, TestConfigurations.Password);
            return new AccountPage(driver);
        }

        public static void  OpenPage(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("http://www.i.ua/");

        }
    }
}