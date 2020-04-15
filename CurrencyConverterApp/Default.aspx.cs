using CurrencyConverterApp.FactoryClass;
using CurrencyConverterApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CurrencyConverterApp
{
    public partial class _Default : Page
    {
        private ICurrencyConvertor currency;
        private IAuditReport audit;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.currency = new CurrencyConvertorBuild();
            this.audit = new BuildAuditReport();
        }

        /// <summary>
        /// Do the currency conversation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CurrencyConvertor_Click(object sender, EventArgs e)
        {
            try
            {
                string validate = Helper.Validation(TextBox1.Text, DropDownList2.SelectedItem.ToString());
                if (String.IsNullOrEmpty(validate))
                {
                    decimal output = this.currency.CurrencyConvertor(int.Parse(TextBox1.Text), DropDownList2.SelectedItem.ToString());
                    Label5.Text = "";
                    Label2.Text = output.ToString() + " " + "GBP";
                    this.audit.WriteAuditInput(DropDownList2.SelectedItem.ToString());
                }
                else
                {
                    Label5.Text = validate;
                }
            }
            catch(Exception ex)
            {
                Label5.Text = ex.Message.ToString();
            }
        }

        /// <summary>
        /// select start and end date to get the audit report
        /// ex select start date as 15-04-2020 and end date 16-04-2020
        /// you will get the output report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GenerateReport_Click(object sender, EventArgs e)
        {
            try
            {
                string validate = Helper.DateTimeValidation(TextBox2.Text, TextBox3.Text);
                if (String.IsNullOrEmpty(validate))
                {
                    DateTime startDate = Convert.ToDateTime(TextBox2.Text);
                    DateTime endDate = Convert.ToDateTime(TextBox3.Text);

                    List<AuditValues> auditValues = this.audit.ReadAuditInput();

                    TableRow row = new TableRow();
                    TableRow row2 = new TableRow();
                    TableRow row3 = new TableRow();
                    TableCell cell1 = new TableCell();
                    TableCell cell2 = new TableCell();
                    TableCell cell3 = new TableCell();
                    cell1.Text = auditValues.Where(x => x.Currency == "USD" && x.InputDatetime > startDate && x.InputDatetime < endDate).Count().ToString() + " " + "User did currency conversation from GBP to USD within this date range";
                    cell2.Text = auditValues.Where(x => x.Currency == "AUD" && x.InputDatetime > startDate && x.InputDatetime < endDate).Count().ToString() + " " + "User did currency conversation from GBP to AUD within this date range";
                    cell3.Text = auditValues.Where(x => x.Currency == "EUR" && x.InputDatetime > startDate && x.InputDatetime < endDate).Count().ToString() + " " + "User did currency conversation from GBP to EUR within this date range";
                    row.Cells.Add(cell1);
                    row2.Cells.Add(cell2);
                    row3.Cells.Add(cell3);
                    myTable.Rows.Add(row);
                    myTable.Rows.Add(row2);
                    myTable.Rows.Add(row3);
                    Label5.Text = "";
                }
                else
                {
                    Label5.Text = validate;
                }

            }
            catch(Exception ex)
            {
                Label5.Text = ex.Message.ToString();
            }
        }
    }
}