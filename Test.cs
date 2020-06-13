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
using QA_Registracija.Libraries;
using System.CodeDom;

namespace QA_Registracija
{
    class Test
    {
        private IWebDriver driver;
        [Test]
        public void QATest()
        {
            CSVHandler CSV = new CSVHandler();
            Excel.Worksheet Sheet = CSV.OpenCSV(@"C:\Users\Milijana\Desktop\ddt6.csv");
            int rows = Sheet.UsedRange.Rows.Count;
            int columns = Sheet.UsedRange.Columns.Count;
            string name, description, expected, FirstName, LastName, Email, UN, P, CP;
            bool IsExpected = true;
            for (int i = 2; i <= rows; i++)
            {
                TestContext.Write("Name of Test Case: {0},Description: {1},Expected: {2}    ", Sheet.Cells[i, 1].Value, Sheet.Cells[i, 2].Value, Sheet.Cells[i, 3].Value);
                FileManagment.Scrivi("Name of Test Case: " + Sheet.Cells[i, 1].Value.ToString()+"  Description: "+ Sheet.Cells[i,2].Value.ToString()+"  Expected: "+ Sheet.Cells[i,3].Value);
                name = Sheet.Cells[i, 1].Value;
                description = Sheet.Cells[i, 2].Value;
                expected = Sheet.Cells[i, 3].Value;
                FirstName = Sheet.Cells[i, 4].Value;
                LastName = Sheet.Cells[i, 5].Value;
                Email = Sheet.Cells[i, 6].Value;
                UN = Sheet.Cells[i, 7].Value;
                P = Sheet.Cells[i, 8].Value;
                CP = Sheet.Cells[i, 9].Value;
                ShopHomePage pocetna = new ShopHomePage(driver);
                pocetna.GoToPage();
                Register R;
                R = pocetna.ClicReg();
                pocetna = R.ClickButtonRegister(FirstName,LastName ,Email,UN,P,CP);
                if (pocetna.Uspeh != null)
                {
                    if(expected=="pass")
                    {
                        TestContext.WriteLine("  Successful Test!!!  ");
                        FileManagment.Scrivere("  Successful Test!!!  ");
                    }
                    else
                    {
                        TestContext.WriteLine("  The test is failed!!!  ");
                        FileManagment.Scrivere("  The test is failed!!!  ");
                        IsExpected = false;
                    }
                }
                else
                {
                    if (expected == "fail")
                    {
                        TestContext.WriteLine("  Successful Test!!!  ");
                        FileManagment.Scrivere("  Successful Test!!!  ");
                    }
                    else
                    {
                        TestContext.WriteLine("  The test is failed!!!  ");
                        FileManagment.Scrivere("  Successful Test!!!  ");
                        IsExpected = false;
                    }
                }
                
                TestContext.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------");
                FileManagment.Scrivere("---------------------------------------------------------------------------------------------------------------------------------------------");
            }
            if(IsExpected==true)
            {
                Assert.Pass("Great job!!!");
            }
            else
            {
                Assert.Fail("Some test has an unexpected result!!!");
            }
            CSV.Close();

        }
        [Test]
        public void ShopingTest()
        {
                string username="M";
                string password="ML";
                UInt64 X = 0;
                UInt64 Y = 0;
                ShopHomePage home = new ShopHomePage(driver);
                home.GoToPage();
                ShopLoginPage SLP;
                SLP = home.ClickOnLoginLink();
                home = SLP.Login(username, password);
                if (home.Welcome != null)
                {
                Porudzbina P;
                home.UnesiKolicinu("3");
                P = home.ClickOrder();
                home=P.ClickContinueShopping();
                home.UnesiKolicinuEnterprice("3");
                P = home.ClickOrderEnterprise();
                home = P.ClickContinueShopping();
                CartPage C;
                C = home.ClickOnViewCart();
                X = C.TotalColumn;
                ConfirmationPage CP;
                CP = C.ClickCheckout();
                home = CP.ClickGoBack();
                HistoryPage HP;
                HP = home.ClickHistory();
                Y = HP.HystoryTotalColumn;

                if (X == Y)
                {
                    
                       TestContext.WriteLine("Successful Test!!!{0}={1}",X,Y);
                       Assert.Pass("Successful Test!!!");
                }
            

                }
                else
                {
                     Assert.Fail("The test is failed");
                     TestContext.WriteLine("The test is failed");
                }
               
            
        
        }
      
        [SetUp]
        public void Setup()
        {
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();   
        }
        [TearDown]
       public void TearDown()
        {   if (this.driver != null)
            {
                this.driver.Close();
            }
        }
        
    }
}
