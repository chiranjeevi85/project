using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CurrencyConverterApp
{
    public static class Helper
    {
        /// <summary>
        /// Validation added to the form while conversation
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="currency"></param>
        /// <returns></returns>
        public static string Validation(string amount, string currency)
        {
            string result = "";
            if (!int.TryParse(amount, out int value))
            {
                result = "Enter only number to convert";
            }
            else if(currency == "Select Currency")
            {
                result += "Select Currency";
            }
                return result;
        }

        /// <summary>
        ///  Validation added to the audit report generation
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static string DateTimeValidation(string startDate, string endDate)
        {
            string result = "";
            if (startDate == "")
            {
                result = "Enter start date";
            }
            else if (endDate == "")
            {
                result += "Enter end date";
            }
            else if(Convert.ToDateTime(startDate) > Convert.ToDateTime(endDate))
            {
                result += "start date cannot be less than end date";
            }
            return result;
        }
    }
}