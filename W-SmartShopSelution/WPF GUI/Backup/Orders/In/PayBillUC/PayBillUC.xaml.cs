using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Library;

namespace WPF_GUI.Orders.In.PayBillUC
{
    /// <summary>
    /// Interaction logic for PayBillUC.xaml
    /// </summary>
    public partial class PayBillUC : UserControl
    {

        #region Main Variables

        /// <summary>
        /// The shopBill MOdel 
        /// </summary>
        ShopBillModel ShopBill = new ShopBillModel();

        #endregion
        #region set the initianl values

        public PayBillUC()
        {
            InitializeComponent();

            SetInitialValues();


        }


        private void SetInitialValues()
        {
            ShopBill = new ShopBillModel();

            TotalPriceValue_PayBillUC.Text = "";

            DateValue_PayBillUC.DisplayDateEnd = DateTime.Now;
            DateValue_PayBillUC.DisplayDateStart = new DateTime(2010, 1, 1);
            DateValue_PayBillUC.SelectedDate = DateTime.Now;

            BillDetailsValue_PayBillUC.Text = "";
        }


        #endregion

        #region Hole Form Events, functions


        /// <summary>
        /// Money validation for any text accepts money
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoneyValidation(object sender, TextCompositionEventArgs e)
        {
            GlobalConfig.NumberValidation.MoneyValidationTextBox(sender, e);
        }

        /// <summary>
        /// Check if the Shopbill Valid to save in the database
        /// </summary>
        /// <returns></returns>
        private Boolean IsValid()
        {
            if (string.IsNullOrWhiteSpace(TotalPriceValue_PayBillUC.Text) == false) 
            {
                
            }
            else
            {
                MessageBox.Show("Enter the Total Price !");
                return false;
            }


            return true;
        }

        private void ConfirmButton_PayBillUC_Click(object sender, RoutedEventArgs e)
        {

            if (IsValid())
            {
                ShopBill.Store = PublicVariables.Store;
                ShopBill.Staff = PublicVariables.Staff;

                // Setting the dateTime
                int hours = DateTime.Now.Hour;
                int minutes = DateTime.Now.Minute;
                int second = DateTime.Now.Second;

                DateTime selectedDate = new DateTime();
                selectedDate = (DateTime)DateValue_PayBillUC.SelectedDate;

                DateTime shopBillDateTime = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, hours, minutes, second);

                ShopBill.Date = shopBillDateTime;

                ShopBill.Details = BillDetailsValue_PayBillUC.Text;

                ShopBill.TotalMoney = decimal.Parse(TotalPriceValue_PayBillUC.Text);


                ShopBill = GlobalConfig.Connection.AddShopBillToTheDatabase(ShopBill);

                OperationModel operation = new OperationModel();
                operation.Date = ShopBill.Date;
                operation.AmountOfMoney = ShopBill.TotalMoney;
                operation.ShopBill = ShopBill;

                GlobalConfig.Connection.AddOperationToDatabase(operation);

                SetInitialValues();
            }

        }
        
        private void RefreshButton_PayBillUC_Click(object sender, RoutedEventArgs e)
        {
            SetInitialValues();
        }

        #endregion


    }
}
