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
        private CSVHandler CSV,M;
        [Test]
        public void QATest()
        {
            //CSVHandler CSV = new CSVHandler();
            Excel.Worksheet Sheet = this.CSV.OpenCSV(@"C:\Users\Milijana\Desktop\ddt6.csv");
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
                FileManagment.Scrivi("Name of Test Case: " + Sheet.Cells[i, 1].Value.ToString());
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
                        FileManagment.Scrivere("Successful Test!!!");
                    }
                    else
                    {
                        TestContext.WriteLine("The test failed!!!");
                        FileManagment.Scrivere("The test failed!!!");
                        IsExpected = false;
                    }
                }
                else
                {
                    if (expected == "fail")
                    {
                        TestContext.WriteLine("Successful Test!!!");
                        FileManagment.Scrivere("Successful Test!!!");
                    }
                    else
                    {
                        TestContext.WriteLine("The test failed!!!");
                        FileManagment.Scrivere("Successful Test!!!");
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
        [Test]
        public void ShopingTest()
        {
            Excel.Worksheet Sheet = this.CSV.OpenCSV(@"C:\Users\Milijana\Desktop\ddt5.csv");
            int rows = Sheet.UsedRange.Rows.Count;
            int columns = Sheet.UsedRange.Columns.Count;
            string name;
            string username;
            string password;
            for (int i = 2; i<= rows; i++)
            {
                name = Sheet.Cells[i, 1].Value;
                username = Sheet.Cells[i, 2].Value;
                password = Sheet.Cells[i, 3].Value;
                ShopHomePage home = new ShopHomePage(driver);
                home.GoToPage();
                ShopLoginPage SLP;
                SLP = home.ClickOnLoginLink();
                home = SLP.Login(username, password);
                string Actualy = "Prosao";
                if (home.Welcome != null)
                {
                    home.ClickLogout();

                }
                else
                {

                    Actualy = "Nije prosao";
                }
                TestContext.WriteLine("Ime testa: {0}, Ussername je: {1},Password je: {2},Stanje  {3}", name, username, password, Actualy);
                FileManagment.Scrivere("Ime: " + name + "Username: " + username + "Password:" + password + "Stanje" + Actualy);
            }
        this.CSV.Close();
        }
        [Test]
        public void FinallyShop()
        {
            Excel.Worksheet Sheet = this.CSV.OpenCSV(@"C:\Users\Milijana\Desktop\ddt5.csv");
            int rows = Sheet.UsedRange.Rows.Count;
            int columns = Sheet.UsedRange.Columns.Count;
            TestContext.WriteLine("broj redova {0}, broj kolona{1}", rows, columns);
            this.CSV.Close();
            this.CSV = null;
            Excel.Worksheet MSheet = M.OpenCSV(@"C:\Users\Milijana\Desktop\miki.csv");
            // rows = Sheet.UsedRange.Rows.Count;
              //columns = Sheet.UsedRange.Columns.Count;
            //TestContext.WriteLine("broj redova {0}, broj kolona{1}", rows, columns);
            CSV.Close();
            /*Excel.Worksheet Sheet = this.CSV.OpenCSV(@"C:\Users\Milijana\Desktop\ddt5.csv");
            int rows = Sheet.UsedRange.Rows.Count;
            int columns = Sheet.UsedRange.Columns.Count;
            string name;
            string username;
            string password;
            string quantity;
            string shipping;
            
            
             name = Sheet.Cells[2, 1].Value;
             username = Sheet.Cells[2, 2].Value;
             password = Sheet.Cells[2, 3].Value;
             this.CSV.Close();
             this.CSV = null;
             /*ShopHomePage home = new ShopHomePage(driver);
             home.GoToPage();
             ShopLoginPage SLP;
             SLP = home.ClickOnLoginLink();
             home = SLP.Login("aaa", "aaa");
            //if(home.Welcome!=null)
            //{
                Excel.Worksheet Sheet = this.CSV.OpenCSV(@"C:\Users\Milijana\Desktop\miki.csv");
               int rows1 = Sheet.UsedRange.Rows.Count;
                int columns1 = Sheet.UsedRange.Columns.Count;
                TestContext.WriteLine("broj redova {0}, broj kolona{1}", rows1, columns1);
                for (int i = 2; i <= rows1; i++)
                {   ShopHomePage home = new ShopHomePage(driver);
                    home.GoToPage();
                    ShopLoginPage SLP;
                    SLP = home.ClickOnLoginLink();
                    home = SLP.Login("aaa", "aaa");
                   string name = Sheet.Cells[i, 1].Value;
                   string  quantity = Convert.ToString(Sheet.Cells[i, 2].Value);
                   string shipping = Convert.ToString(Sheet.Cells[i, 3].Value);
                    string rezultat;
                    Porudzbina P;
                    home.UnesiKolicinu(quantity);
                    P = home.ClickOrder();
                    rezultat = P.Shipping.Text;
                    System.Threading.Thread.Sleep(1000);
                    TestContext.WriteLine("Rezultat je {0}", rezultat);
                    P.ClickCheckout();
                   home.ClickLogout();
                
            }

            //}
            //else
            /*{
                TestContext.WriteLine("Neuspesno");
                Assert.Fail("Neuspesan LogIn");
            }*/
            this.CSV.Close();
            this.CSV = null;

        }
        [SetUp]
        public void Setup()
        {
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            this.CSV = new CSVHandler();
            M = new CSVHandler();
            
        }
        [TearDown]
       public void TearDown()
        {   if (this.driver != null)
            {
                this.driver.Close();
            }
        //if (this.CSV!=null)
          //{
               // this.CSV.Close();
            //}

        }
        private void LogLine(string Message)
        {
            FileManagment.Scrivere(Message);
            TestContext.WriteLine(Message);
        }

        private void Log(string Message)
        {
             FileManagment.Scrivi(Message);
            TestContext.Write(Message);
        }
    }
}
