using CurrencyConverterApp.FactoryClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverterApp.Interfaces
{
    public interface IAuditReport
    {
        void WriteAuditInput(string currency);
        List<AuditValues> ReadAuditInput();
    }
}
