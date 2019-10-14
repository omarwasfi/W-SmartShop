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

        /// <summary>
        /// All the Operations in the database
        /// </summary>
        private List<OperationModel> Operations { get; set; }

        #endregion

        #region Help Variables

        /// <summary>
        /// The filtered operations 
        /// </summary>
        private List<OperationModel> FOperations { get; set; }
        

        /// <summary>
        /// Used to prevent the Operation loading in the initializing proces
        /// </summary>
        private Boolean CanLoadTheOperation { get; set; }

        #endregion

        #region set the initianl values


        public CashUC()
        {
            InitializeComponent();
            SetInitialValues();

        }

        private void SetInitialValues()
        {
            
            

            UpdateTheOperationsFromThePublicVariables();

            OperationsList_CashUC.ItemsSource = Operations;
            TotalSellsValue_CashUC.Text = GlobalConfig.Connection.TotalSellsIncome(Operations).ToString();

            EndDateValue_CashUC.DisplayDateEnd = DateTime.Now;
            EndDateValue_CashUC.DisplayDateStart = new DateTime(2010,1,1);
            EndDateValue_CashUC.SelectedDate = DateTime.Now;

            StartDateValue_CashUC.DisplayDateEnd = DateTime.Now;
            StartDateValue_CashUC.DisplayDateStart = new DateTime(2010,1,1);
            StartDateValue_CashUC.SelectedDate = new DateTime(2019, 9, 1);

            ShopeeWalletNowValue_CashUC.Text = GlobalConfig.Connection.GetTheShopeeWallet(Operations).ToString();
            TotalSellsProfitValue_CashUC.Text = GlobalConfig.Connection.TotalSellsProfit(Operations).ToString();
            DateOfShopeeWalletValue_CashUC.Text = DateTime.Now.ToShortDateString();
            ShopeeWalletAtDateValue_CashUC.Text = GlobalConfig.Connection.GetTheShopeeWallet(GlobalConfig.Connection.FilterOperationsByDate(Operations, new DateTime(2010, 1, 1), DateTime.Now)).ToString();


            CanLoadTheOperation = false;
            LoadTheOperations();
            CanLoadTheOperation = true;
        }

        /// <summary>
        /// Update and set the operations , Update all kind of orders
        /// </summary>
        private void UpdateTheOperationsFromThePublicVariables()
        {
            PublicVariables.Orders = GlobalConfig.Connection.GetOrders();
            PublicVariables.IncomeOrders = GlobalConfig.Connection.GetIncomeOrders();
            PublicVariables.ShopBills = GlobalConfig.Connection.GetShopBills();

            PublicVariables.Operations = GlobalConfig.Connection.GetOperations();
            Operations = null;
            Operations = PublicVariables.Operations;
        }



        #endregion

        #region Hole User Grid Events

        /// <summary>
        /// Filter all the operations by date
        /// </summary>
        private void LoadTheOperations()
        {
            if (CanLoadTheOperation)
            {
                DateTime startDate = (DateTime)StartDateValue_CashUC.SelectedDate;
                DateTime endDate = (DateTime)EndDateValue_CashUC.SelectedDate;


                FOperations = GlobalConfig.Connection.FilterOperationsByDate(Operations, startDate, endDate);
                OperationsList_CashUC.ItemsSource = null;
                OperationsList_CashUC.ItemsSource = FOperations;

                TotalSellsValue_CashUC.Text = GlobalConfig.Connection.TotalSellsIncome(FOperations).ToString();
                TotalSellsProfitValue_CashUC.Text = GlobalConfig.Connection.TotalSellsProfit(FOperations).ToString();
                DateOfShopeeWalletValue_CashUC.Text = endDate.ToShortDateString();
                ShopeeWalletAtDateValue_CashUC.Text = GlobalConfig.Connection.GetTheShopeeWallet(GlobalConfig.Connection.FilterOperationsByDate(Operations, new DateTime(2010, 1, 1),endDate)).ToString();

            }

        }

        private void EndDateValue_CashUC_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadTheOperations();
            
        }

        private void StartDateValue_CashUC_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadTheOperations();
        }

        private void ReloadTabButton_CashUC_Click(object sender, RoutedEventArgs e)
        {
            SetInitialValues();
        }

        #endregion


    }
}
