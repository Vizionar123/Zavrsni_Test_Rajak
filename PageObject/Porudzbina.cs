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
    class Porudzbina
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        public Porudzbina(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(70));
        }
        public IWebElement Shipping
        {
            get
            {
                IWebElement element = null;
                try
                {
                    element = this.driver.FindElement(By.XPath("//tr[contains(.,'Shipping')]//td[3]"));
                }
                catch (Exception)
                {
                    element = null;
                }
                return element;
            }
        }
        public IWebElement Checkout
        {
            get
            {
                IWebElement element = null;
                try
                {
                    element = this.driver.FindElement(By.Name("checkout"));
                }
                catch (Exception)
                {
                    element = null;
                }
                return element;
            }
        }
        public void ClickCheckout()
        {
            this.Checkout?.Click();
        }
    }
}
