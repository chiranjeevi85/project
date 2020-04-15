using CurrencyConverterApp.Const;
using CurrencyConverterApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CurrencyConverterApp.FactoryClass
{
    public class CurrencyConvertorBuild : ICurrencyConvertor
    {
        public static Dictionary<string, decimal> refDic = new Dictionary<string, decimal>
            {
                { Currency.USD, 1.25M },
                { Currency.AUD, 1.98M },
                { Currency.EUR, 1.15M }
            };
        /// <summary>
        /// currency converator calculation happen in this function
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="currenytoconvert"></param>
        /// <returns></returns>
        public decimal CurrencyConvertor(int amount, string currenytoconvert)
        {
            return amount * LookupReferenceData(currenytoconvert);
        }

        public decimal LookupReferenceData(string factor)
        {
            // Try to get the result in the static Dictionary
            if (refDic.TryGetValue(factor, out decimal result))
            {
                return result;
            }
            else
            {
                return 0;
            }

        }
    }
}