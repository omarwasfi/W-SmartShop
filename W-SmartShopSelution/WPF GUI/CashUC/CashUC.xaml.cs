using Library;
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

namespace WPF_GUI
{
    /// <summary>
    /// Interaction logic for CashUC.xaml
    /// </summary>
    public partial class CashUC : UserControl
    {
        #region Main variables


        #endregion

        #region Help Variables



        #endregion

        #region set the initianl values


        public CashUC()
        {
            InitializeComponent();
            SetInitialValues();

        }

        private void SetInitialValues()
        {
            OperationsList.ItemsSource = null;
            OperationsList.ItemsSource = PublicVariables.Operations;

            TotalPaidOrdersValue.Value = PublicVariables.Store.GetTotalPaidOrders;
            TotalNotPaidValue.Value = PublicVariables.Store.GetNotPaidOrdersValue;

            TotalPaidIncomeOrdersValue.Value = PublicVariables.Store.GetTotalPaidIncomeOrdersValue;
            TotalNotPaidIncomeOrdersValue.Value = PublicVariables.Store.GetLoans;

            ShopeeWalletNowValue.Value = PublicVariables.Store.GetShopeeWallet;
        }





        #endregion

        #region Hole User Grid Events

        private void ReloadTabButton_Click(object sender, RoutedEventArgs e)
        {
            SetInitialValues();
        }

        #endregion


    }
}
