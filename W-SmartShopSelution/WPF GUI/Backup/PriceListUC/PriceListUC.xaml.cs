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

namespace WPF_GUI.PriceListUC
{
    /// <summary>
    /// Interaction logic for PriceListUC.xaml
    /// </summary>
    public partial class PriceListUC : UserControl
    {

        #region Main variables

        /// <summary>
        /// All the stocks in the store
        /// </summary>
        private List<StockModel> Stocks = new List<StockModel>();

        #endregion


        #region set the initianl values


        public PriceListUC()
        {
            InitializeComponent();

            SetInitialValues();

        }

        private void SetInitialValues()
        {

            UpdateTheStocksFromThePublicVariables();

            StockList_PriceListUC.ItemsSource = null;
            StockList_PriceListUC.ItemsSource = Stocks;

        }


        /// <summary>
        /// Update and gets the stocks from the public variables
        /// </summary>
        private void UpdateTheStocksFromThePublicVariables()
        {
            PublicVariables.LoginStoreStocks = GlobalConfig.Connection.FilterStocksByStore(PublicVariables.Store);
            Stocks = null;
            Stocks = PublicVariables.LoginStoreStocks;
        }


        #endregion

    }
}
