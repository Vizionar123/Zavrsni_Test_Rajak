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
    class HomePage
    {
       private IWebDriver driver;
       private WebDriverWait wait;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(70));
        }
        public void GoToPage()
        {
            this.driver.Navigate().GoToUrl("http://shop.qa.rs/");
        }
        public IWebElement Reg
        {
            get
            {
                IWebElement element = null;
                try
                {
                    element = this.driver.FindElement(By.XPath("//a[@href='/register']"));
                }
                catch (Exception)
                {
                    element = null;
                }
                return element;
            }

        }
        public IWebElement Uspeh
        {
            get
            {
                IWebElement element = null;
                try
                {
                    element = this.driver.FindElement(By.XPath("//strong[text()='Uspeh!']"));
                }
                catch (Exception)
                {
                    element = null;
                }
                return element;
            }

        }
        public Register ClicReg()
        {
            this.Reg?.Click();
            wait.Until(EC.ElementIsVisible(By.XPath("//a[contains(text(),'Shop')]")));
            return new Register(this.driver); 
        }

    }
}
