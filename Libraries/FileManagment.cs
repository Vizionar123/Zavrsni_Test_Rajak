using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace QA_Registracija.Libraries
{
    class FileManagment
    {
        private static string fileName = @"C:\Users\Milijana\Desktop\izlaz1.log";
        public static void Scrivere(string IlMessagio)
        {
            using(StreamWriter matita= new StreamWriter(fileName,true))
            {
                matita.WriteLine("{0}", IlMessagio);
            }
        }
       
        public static void Scrivi(string IlMessagio)
        {
            using (StreamWriter matita = new StreamWriter(fileName, true))
            {
                matita.Write("{0}", IlMessagio);
            }
        }
    }
}
