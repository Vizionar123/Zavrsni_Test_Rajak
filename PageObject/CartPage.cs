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
using System.Text.RegularExpressions;

namespace QA_Registracija.PageObject
{
    class CartPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(70));
        }
        public UInt64 TotalColumn
        {
            get
            {
                IWebElement element = null;
                UInt64 num=0;
                try
                {
                    element = this.driver.FindElement(By.XPath("//tr[contains(.,'Shipping')]//following-sibling::tr"));
                    string number = Regex.Replace(element.Text, "[^0-9]", "");
                    num = Convert.ToUInt64(number);
                }
                catch (Exception)
                {
                }
                return num;
            }
        }
        

        public IWebElement ButtonContinueShopping
        {
            get
            {
                IWebElement element = null;
                try
                {
                    element = this.driver.FindElement(By.XPath("//a[contains(., 'Continue shopping')]"));
                }
                catch (Exception)
                {
                }
                return element;
            }
        }

        public IWebElement ButtonCheckout
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
                }
                return element;
            }
        }

        public ShopHomePage ClickContinueShopping()
        {
            this.ButtonContinueShopping?.Click();
            wait.Until(EC.ElementIsVisible(By.XPath("//h2[contains(text(), 'Welcome back,')]")));
            return new ShopHomePage(this.driver);
        }

        public ConfirmationPage ClickCheckout()
        {
            this.ButtonCheckout?.Click();
            wait.Until(EC.ElementIsVisible(By.XPath("//h2[contains(text(), 'You have successfully placed your order.')]")));
            return new ConfirmationPage(this.driver);
        }
    }
}
