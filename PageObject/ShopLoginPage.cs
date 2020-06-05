using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;
using Excel = Microsoft.Office.Interop.Excel;
using QA_Registracija.PageObject;
using System.Threading;
using NUnit.Framework;

namespace QA_Registracija.PageObject
{
    class ShopLoginPage
    {

        private IWebDriver driver;
        private WebDriverWait wait;
        public ShopLoginPage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(70));
        }
        public IWebElement UsernameInput
        {
            get
            {
                IWebElement element = null;
                try
                {
                    wait.Until(EC.ElementIsVisible(By.Name("username")));
                    element = this.driver.FindElement(By.Name("username"));
                }
                catch (Exception)
                {
                }
                return element;
            }
        }

        public IWebElement PasswordInput
        {
            get
            {
                IWebElement element = null;
                try
                {
                   //wait.Until(EC.ElementIsVisible(By.Name("password")));
                    element = this.driver.FindElement(By.Name("password"));
                }
                catch (Exception)
                {
                }
                return element;
            }
        }

        public IWebElement LoginButton
        {
            get
            {
                IWebElement element = null;
                try
                {
                    //wait.Until(EC.ElementIsVisible(By.Name("login")));
                    element = this.driver.FindElement(By.Name("login"));
                }
                catch (Exception)
                {
                }
                return element;
            }
        }

        public ShopHomePage Login(string username, string password)
        {
            UsernameInput.SendKeys(username);
            PasswordInput.SendKeys(password);
            LoginButton.Click();
           // wait.Until(EC.ElementIsVisible(By.XPath("//h2[contains(text(), 'Welcome back,')]")));
            return new ShopHomePage(this.driver);
        }
    }
}
