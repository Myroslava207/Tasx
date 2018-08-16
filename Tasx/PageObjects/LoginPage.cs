using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasx.PageObjects
{
    public class LoginPage
    {
        public IWebDriver driver;
        public LoginPage(IWebDriver driver) => this.driver = driver;

        public IWebElement LoginField() => driver.FindElement(By.XPath("//input[@name='login']"));
        public IWebElement PasswordField() => driver.FindElement(By.XPath("//input[@name='pass']"));
        public IWebElement ButtonLogin => driver.FindElement(By.XPath("/html/body/div[3]/div[3]/div[3]/div[2]/div[1]/div[3]/form/p/input"));
        public IWebElement Select() => driver.FindElement(By.XPath("//select[@name='domn']"));
        public IWebElement Checkbox() => driver.FindElement(By.XPath("//input[@name='auth_type']"));

        public void Login(string username, string password)
        {
            LoginField().SendKeys(username);
            PasswordField().SendKeys(password);
            ButtonLogin.Click();
        }
        public void SetCheckboxClick()
        {
           Checkbox().Click();
        }
        public void SetSelect()
        {
            SelectElement dropdown = new SelectElement(Select());
            string selectedOption = dropdown.SelectedOption.Text;
            dropdown.SelectByText("i.ua"); 
        }
        public void SetLoginButton()
        {
            ButtonLogin.Click();
<<<<<<< HEAD
        }        
=======
        }

        // Wrong input credentials (Login or password)
        public IWebElement IncorrectCredentials() => driver.FindElement(By.XPath("//*[@id='lform_errCtrl']/div[1]"));

>>>>>>> c919d2afd76fadbbac44cd86d57b41092035d642
    }
}
