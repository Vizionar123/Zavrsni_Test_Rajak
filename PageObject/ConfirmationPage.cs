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
    class ConfirmationPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        public ConfirmationPage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(70));
        }
        public IWebElement LinkGoBack
        {
            get
            {
                IWebElement element = null;
                try
                {
                    element = this.driver.FindElement(By.XPath("//a[contains(.,'Go back')]"));
                }
                catch (Exception)
                {
                }
                return element;
            }
        }

        public ShopHomePage ClickGoBack()
        {
            this.LinkGoBack?.Click();
            wait.Until(EC.ElementIsVisible(By.XPath("//h2[contains(text(), 'Welcome back,')]")));
            return new ShopHomePage(this.driver);
        }

    }
}
