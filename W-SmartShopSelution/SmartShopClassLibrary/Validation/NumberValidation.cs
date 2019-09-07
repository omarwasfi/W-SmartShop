using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms.Design.Behavior;
using System.Windows.Input;

namespace Library
{
    public class NumberValidation 
    {
        /// <summary>
        /// Force any textBox to accept only decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MoneyValidationTextBox(object sender, TextCompositionEventArgs e)
        {
          

            Regex regex = new Regex("^[.][0-9]+$|^[0-9]*[.]{0,1}[0-9]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));

            //allows the negative sign
            /* decimal result;
               e.Handled = !decimal.TryParse((sender as TextBox).Text + e.Text, out result);*/

        }

        /// <summary>
        /// Force any textBox to accept only numbers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void IntegerValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            string onlyNumeric = @"^([0-9]+(.[0-9]+)?)$";
            Regex regex = new Regex(onlyNumeric);
            e.Handled = !regex.IsMatch(e.Text);
        }

    }
}
