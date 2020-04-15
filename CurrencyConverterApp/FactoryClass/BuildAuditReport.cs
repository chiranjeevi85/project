using CurrencyConverterApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace CurrencyConverterApp.FactoryClass
{
    public class BuildAuditReport : IAuditReport
    {
        /// <summary>
        /// Record the currency convertion of the user with time in AuditReport.txt
        /// </summary>
        /// <param name="currency"></param>
        public void WriteAuditInput(string currency)
        {
            string folderPath = Directory.GetParent(System.AppDomain.CurrentDomain.RelativeSearchPath).FullName;

            FileStream objFileStrome = new FileStream(folderPath + @"\AuditReport.txt", FileMode.Append, FileAccess.Write);
            StreamWriter objStreamWriter = new StreamWriter(objFileStrome);
            objStreamWriter.Write(currency + "," + DateTime.Now.ToString() + "\n");
            objStreamWriter.Close();
            objFileStrome.Close();
        }


        /// <summary>
        /// Read All the data from text file and create object to query the condition
        /// </summary>
        /// <returns></returns>
        public List<AuditValues> ReadAuditInput()
        {
            List<AuditValues> au = new List<AuditValues>();

            string folderPath = Directory.GetParent(System.AppDomain.CurrentDomain.RelativeSearchPath).FullName;

            string[] lines = File.ReadAllLines(folderPath + @"\AuditReport.txt");

            foreach (string line in lines)
            {
                string[] values = line.Split(',');
                AuditValues obj = new AuditValues
                {
                    Currency = values[0],
                    InputDatetime = Convert.ToDateTime(values[1])
                };

                au.Add(obj);
            }

            return au;
        }
    }

    public class AuditValues
    {
        public string Currency { get; set; }
        public DateTime InputDatetime { get; set; }
    }
}