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
    class ShopHomePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        public ShopHomePage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(70));
        }
        public void GoToPage()
        {
            this.driver.Navigate().GoToUrl("http://shop.qa.rs/");
        }
        public IWebElement LinkLogin
        {
            get
            {
                IWebElement element = null;
                try
                {
                    wait.Until(EC.ElementIsVisible(By.XPath("//a[@href='/login']")));
                    element = this.driver.FindElement(By.XPath("//a[@href='/login']"));
                }
                catch (Exception)
                {
                }
                return element;
            }
        }
        public IWebElement MestoZaSelect
        {
            get
            {
                IWebElement element = null;
                try
                {
                    //wait.Until(EC.ElementIsVisible(By.XPath("")));
                    element = this.driver.FindElement(By.XPath("//h3[contains(text(),'pro')]//parent::div//following-sibling::div//select"));
                }
                catch (Exception)
                {
                }
                return element;
            }
        }
        public IWebElement DugmeOrder
        {
            get
            {
                IWebElement element = null;
                try
                {
                    //wait.Until(EC.ElementIsVisible(By.XPath("")));
                    element = this.driver.FindElement(By.XPath("//h3[contains(text(),'pro')]//parent::div//following-sibling::div//input[@type='submit']"));
                }
                catch (Exception)
                {
                }
                return element;
            }
        }
        public void UnesiKolicinu(string kol)
        {
            SelectElement select = new SelectElement(this.MestoZaSelect);
            select.SelectByText(kol);
        }
        public IWebElement Logout
        {
            get
            {
                IWebElement element = null;
                try
                {
                    element = this.driver.FindElement(By.XPath("//a[contains(text(),'Logout')]"));
                }
                catch (Exception)
                {
                    element = null;
                }
                return element;
            }

            }
            public ShopHomePage ClickLogout()
             {
                this.Logout?.Click();
                return new ShopHomePage(this.driver);
             }
        
        public IWebElement Welcome
        {
            get
            {
                IWebElement element=null;
                try
                {
                    element = this.driver.FindElement(By.XPath("//h2[contains(text(),'Welcome')]"));
                }
                catch(Exception)
                {
                    element = null;
                }
                return element;
            }
        }
        public ShopLoginPage ClickOnLoginLink()
        {
            this.LinkLogin?.Click();
            //wait.Until(EC.ElementIsVisible(By.ClassName("form-signin-heading")));
            return new ShopLoginPage(this.driver);
        }
        public Porudzbina ClickOrder()
        {
            this.DugmeOrder?.Click();
            return new Porudzbina(this.driver);
        }

    }
}
