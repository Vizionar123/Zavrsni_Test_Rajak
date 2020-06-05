using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace QA_Registracija.Libraries
{
    class CSVHandler
    {
        private Excel.Application App;
        private Excel.Workbook Workbook;
        private Excel.Worksheet Sheet;
        public CSVHandler()
        {
            this.App = new Excel.Application();
        }
        public Excel.Worksheet OpenCSV(string CSVFile, string CSVDelimiter = ",")
        {
            this.Workbook = this.App.Workbooks.Open(CSVFile, Format: Excel.XlFileFormat.xlCSV, Delimiter: CSVDelimiter);
            this.Sheet = this.Workbook.ActiveSheet;
            return this.Sheet;
        }
        public void Close()
        {
            this.Workbook.Close();
            this.App.Quit();

            Marshal.ReleaseComObject(this.Workbook);
            Marshal.ReleaseComObject(this.App);

            this.Workbook = null;
            this.App = null;
        }

    }
}
