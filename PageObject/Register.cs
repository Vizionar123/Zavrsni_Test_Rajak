using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;
using Excel = Microsoft.Office.Interop.Excel;
using QA_Registracija.PageObject;
using System.Threading;

namespace QA_Registracija.PageObject
{
    class Register
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        public Register(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(70));
        }
        public IWebElement FirstName
        {
            get
            {
                IWebElement element = null;
                try
                {
                    element = this.driver.FindElement(By.Name("ime"));
                }
                catch (Exception)
                {
                    element = null;
                }
                return element;
            }

        }
        public IWebElement LastName
        {
            get
            {
                IWebElement element = null;
                try
                {
                    element = this.driver.FindElement(By.Name("prezime"));
                }
                catch (Exception)
                {
                    element = null;
                }
                return element;
            }

        }
        public IWebElement Email
        {
            get
            {
                IWebElement element = null;
                try
                {
                    element = this.driver.FindElement(By.Name("email"));
                }
                catch (Exception)
                {
                    element = null;
                }
                return element;
            }

        }
        public IWebElement UserName
        {
            get
            {
                IWebElement element = null;
                try
                {
                    element = this.driver.FindElement(By.Name("korisnicko"));
                }
                catch (Exception)
                {
                    element = null;
                }
                return element;
            }

        }
        public IWebElement Password
        {
            get
            {
                IWebElement element = null;
                try
                {
                    element = this.driver.FindElement(By.Name("lozinka"));
                }
                catch (Exception)
                {
                    element = null;
                }
                return element;
            }

        }
        public IWebElement ConfirmPassword
        {
            get
            {
                IWebElement element = null;
                try
                {
                    element = this.driver.FindElement(By.Name("lozinkaOpet"));
                }
                catch (Exception)
                {
                    element = null;
                }
                return element;
            }

        }
        public IWebElement ButtonRegister
        {
            get
            {
                IWebElement element = null;
                try
                {
                    element = this.driver.FindElement(By.Name("register"));
                }
                catch (Exception)
                {
                    element = null;
                }
                return element;
            }

        }
        public HomePage ClickButtonRegister(string FirstName,string LastName,string Email,string UserName,string Password, string ConfirmPassword)
        {
            this.FirstName?.SendKeys(FirstName);
            this.LastName?.SendKeys(LastName);
            this.Email?.SendKeys(Email);
            this.UserName?.SendKeys(UserName);
            this.Password?.SendKeys(Password);
            this.ConfirmPassword?.SendKeys(ConfirmPassword);
            this.ButtonRegister?.Click();
            return new HomePage(this.driver);

        }
    }
}
