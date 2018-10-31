using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewellProject3A
{
    public partial class frmYTDCalc : Form
    {
        public frmYTDCalc()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCalcYTD_Click(object sender, EventArgs e)
        {

            /*****************************************
             * this method calculates the total 
             * amount paid, total interest paid,
             * and total principal paid, based on 
             * values of interest rate, monthly payment,
             * and number of payments
             * ***************************************/

            try
            {
                // get the monthly payment amount, interest rate, and number of payments made
                // from the Payment, Interest Rate, and Number of Payments text boxes, respectively
                decimal monthlyPayment = 0m;
                Decimal.TryParse(txtYTDPmt.Text, 
                    System.Globalization.NumberStyles.AllowCurrencySymbol | 
                    System.Globalization.NumberStyles.AllowDecimalPoint |
                    System.Globalization.NumberStyles.AllowThousands,
                    System.Globalization.CultureInfo.CurrentCulture, out monthlyPayment);
                decimal interestRate = Convert.ToDecimal(txtYTDIntRate.Text);
                int numberOfPayments = Convert.ToInt32(txtYTDNoPmts.Text);


                // calculate and assign the values for the
                // totalAmountPaid, totalInterestPaid, and totalPrincipalPaid variables
                decimal totalAmountPaid = monthlyPayment * numberOfPayments;
                decimal totalInterestPaid = totalAmountPaid * interestRate;
                decimal totalPrincipalPaid = totalAmountPaid - totalInterestPaid;

                // format the values and display them in their text boxes
                txtYTDTotlPd.Text = totalAmountPaid.ToString("c"); // currency format
                txtYTDTotlIntPd.Text = totalInterestPaid.ToString("c"); // currency format
                txtYTDTotlPrinPd.Text = totalPrincipalPaid.ToString("c"); // currency format

                // move the focus to the Monthly Payment text box
                txtYTDPmt.Focus();
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "Invalid numeric format. Please check all entries.",
                    "Entry Error");
            }
            catch (OverflowException)
            {
                MessageBox.Show(
                    "Overflow error. Please enter smaller values.",
                    "Entry Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    ex.GetType().ToString());
            }
        }
        

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
