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

namespace QA_Registracija
{
    class Test
    {
        IWebDriver driver;
        [Test]
        public void QATest()
        {
            CSVHandler CSV = new CSVHandler();
            Excel.Worksheet Sheet = CSV.OpenCSV(@"C:\Users\Milijana\Desktop\ddt6.csv");
            int rows = Sheet.UsedRange.Rows.Count;
            int columns = Sheet.UsedRange.Columns.Count;
            //TestContext.WriteLine("Broj redova: {0} Broj kolona: {1}", rows, columns);
            string name, description, expected, FirstName, LastName, Email, UN, P, CP;
            //int pass = 0;
            //int fail = 0;
            bool IsExpected = true;
            for (int i = 2; i <= rows; i++)
            {
                TestContext.Write("Name of Test Case: {0},Description: {1},Expected: {2}    ", Sheet.Cells[i, 1].Value, Sheet.Cells[i, 2].Value, Sheet.Cells[i, 3].Value);
                name = Sheet.Cells[i, 1].Value;
                description = Sheet.Cells[i, 2].Value;
                expected = Sheet.Cells[i, 3].Value;
                FirstName = Sheet.Cells[i, 4].Value;
                LastName = Sheet.Cells[i, 5].Value;
                Email = Sheet.Cells[i, 6].Value;
                UN = Sheet.Cells[i, 7].Value;
                P = Sheet.Cells[i, 8].Value;
                CP = Sheet.Cells[i, 9].Value;
                HomePage pocetna = new HomePage(driver);
                pocetna.GoToPage();
                Register R;
                R = pocetna.ClicReg();
                pocetna = R.ClickButtonRegister(FirstName,LastName ,Email,UN,P,CP);
                if (pocetna.Uspeh != null)
                {
                    if(expected=="pass")
                    {
                        TestContext.WriteLine("Successful Test!!!");
                    }
                    else
                    {
                        TestContext.WriteLine("The test failed!!!");
                        IsExpected = false;
                    }
                }
                else
                {
                    if (expected == "fail")
                    {
                        TestContext.WriteLine("Successful Test!!!");
                    }
                    else
                    {
                        TestContext.WriteLine("The test failed!!!");
                        IsExpected = false;
                    }
                }
                
                TestContext.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------");
            }
            if(IsExpected==true)
            {
                Assert.Pass("Great job!!!");
            }
            else
            {
                Assert.Fail("Some test has an unexpected result!!!");
            }
            //TestContext.WriteLine("Broj proslih je {0}, Broj neuspelih je{1}", pass, fail);
            CSV.Close();

        }
        [SetUp]
        public void Setup()
        {
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
        }
        [TearDown]
       public void TearDown()
        {
            driver.Close();
        }
    }
}
