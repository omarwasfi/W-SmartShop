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

namespace WPF_GUI
{
    /// <summary>
    /// Interaction logic for ManagerUC.xaml
    /// </summary>
    public partial class ManagerUC : UserControl
    {
        #region Main Variables
        #endregion

        #region Set InitalValues

        public ManagerUC()
        {
            InitializeComponent();
            SetInitialValues();
        }

        private void SetInitialValues()
        {
            UserGrid.Visibility = Visibility.Visible;

            CapitalValue.Value = PublicVariables.Organization.GetCapital;
            StockValue.Value = PublicVariables.Organization.GetStockValue;
            ShopeeWalletValue.Value = PublicVariables.Organization.GetShopeeWalletValue;
            NotPaidOrderValue.Value = PublicVariables.Organization.GetNotPaidOrdersValue;
            LoansValue.Value = PublicVariables.Organization.GetLoans;
            FreeMoneyValue.Value = PublicVariables.Organization.GetFreeMoney;

            StoreNameValue.Text = PublicVariables.Store.Name;
            StoreShopeeWalletValue.Value = PublicVariables.Store.GetShopeeWallet;
            StoreStockValue.Value = PublicVariables.Store.GetStocksIncomeValue;

            StoreTotalSellsValue.Value = PublicVariables.Store.GetTotalSellsValue;
            TotalProfitValue.Value = PublicVariables.Store.GetTotalReceivedProfit;
            TotalPaidValue.Value = PublicVariables.Store.GetTotalPaidOrders;
            TotalNotPaidValue.Value = PublicVariables.Store.GetNotPaidOrdersValue;
            TotalSellsWithoutProfitsValue.Value = PublicVariables.Store.GetSellsWihtoutProfits;
            BillsValue.Value = PublicVariables.Store.GetTotalShopBillsValue;
            //StaffSalariesValue.Value = PublicVariables.Store.GetStaffSalaries;
            //IncomeOrdersValue.Value = PublicVariables.Store.;
            TotalPaidIncomeOrdersValue.Value = PublicVariables.Store.GetTotalPaidIncomeOrdersValue;
            TotalLoansValue.Value = PublicVariables.Store.GetLoans;

        }

        #endregion

        #region Grid Events
        private void InvestButton_Click(object sender, RoutedEventArgs e)
        {
            UserGrid.Visibility = Visibility.Collapsed;
            InvestGrid.Visibility = Visibility.Visible;
        }

        private void BackToUserGridButton_FromInvestGrid_Click(object sender, RoutedEventArgs e)
        {
            UserGrid.Visibility = Visibility.Visible;
            InvestGrid.Visibility = Visibility.Collapsed;
            SetInitialValues();
        }

        private void RevenueButton_Click(object sender, RoutedEventArgs e)
        {
            UserGrid.Visibility = Visibility.Collapsed;
            RevenueGrid.Visibility = Visibility.Visible;
        }

        private void BackToUserGridButton_FromRevenueGrid_Click(object sender, RoutedEventArgs e)
        {
            UserGrid.Visibility = Visibility.Visible;
            RevenueGrid.Visibility = Visibility.Collapsed;
            SetInitialValues();
        }
        private void TransformButton_Click(object sender, RoutedEventArgs e)
        {
            UserGrid.Visibility = Visibility.Collapsed;
            TransformGrid.Visibility = Visibility.Visible;
        }
        private void BackToUserGridButton_FromTransformGrid_Click(object sender, RoutedEventArgs e)
        {
            UserGrid.Visibility = Visibility.Visible;
            TransformGrid.Visibility = Visibility.Collapsed;
            SetInitialValues();
        }

        private void DeTransformButton_Click(object sender, RoutedEventArgs e)
        {
            UserGrid.Visibility = Visibility.Collapsed;
            DeTransformGrid.Visibility = Visibility.Visible;
        }

        private void BackToUserGridButton_FromDeTransformGrid_Click(object sender, RoutedEventArgs e)
        {
            UserGrid.Visibility = Visibility.Visible;
            DeTransformGrid.Visibility = Visibility.Collapsed;
            SetInitialValues();
        }


        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            SetInitialValues();
        }

        #endregion

    }
}
