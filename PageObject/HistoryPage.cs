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
    class HistoryPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        public HistoryPage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(70));
        }
        public UInt64 HystoryTotalColumn
        {
            get
            {
                IWebElement element = null;
                UInt64 num = 0;
                try
                {
                    element = this.driver.FindElement(By.XPath("//tbody/tr[1]/td[@class='total']"));
                    num =Convert.ToUInt64(Convert.ToDouble(element.Text));
                   
                }
                catch (Exception)
                {
                }
                return num;
            }
        }
    }
}
