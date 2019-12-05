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
using ValidationResult = FluentValidation.Results.ValidationResult;
using Library;

namespace WPF_GUI.Orders.In.PayBillUC
{
    /// <summary>
    /// Interaction logic for PayBillUC.xaml
    /// </summary>
    public partial class PayBillUC : UserControl
    {

        #region Main Variables


        #endregion
        #region set the initianl values

        public PayBillUC()
        {
            InitializeComponent();

            SetInitialValues();


        }


        private void SetInitialValues()
        {
            ShoppeeWalletValue.Value = PublicVariables.Store.GetShopeeWallet;
            TotalPriceValue.Value = 0;
            BillDetailsValue.Text = "";
        }



        #endregion

        #region Hole Form Events, functions


        private void TotalPriceValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            decimal totalPrice = TotalPriceValue.Value.Value;

            if (totalPrice >= ShoppeeWalletValue.Value)
            {
                TotalPriceValue.Value = ShoppeeWalletValue.Value;
            }

        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            SetInitialValues();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            ShopBillModel shopBill = new ShopBillModel();
            shopBill.Store = PublicVariables.Store;
            shopBill.Staff = PublicVariables.Staff;
            shopBill.TotalMoney = TotalPriceValue.Value.Value;
            shopBill.Date = DateTime.Now;
            shopBill.Details = BillDetailsValue.Text;

            GlobalConfig.ShopBillValidator = new ShopBillValidator();

            ValidationResult result = GlobalConfig.ShopBillValidator.Validate(shopBill);

            if (result.IsValid == false)
            {

                MessageBox.Show(result.Errors[0].ErrorMessage);

            }
            else
            {
                GlobalConfig.Connection.AddShopBillToTheDatabase(shopBill);
                SetInitialValues();
            }
        }

        #endregion


    }
}
