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
using WPF_GUI.Sell;

namespace WPF_GUI.Inventory
{
    /// <summary>
    /// Interaction logic for InventoryUC.xaml
    /// 
    /// This the inventory for the store that login to the program
    /// Manage the stocks in this store 
    /// remove stocks , Add Stocks , modify Stocks 
    /// 
    /// </summary>
    public partial class InventoryUC : UserControl 
    {

        #region Main Variables



        #endregion

        #region Help variables

     
        #endregion

        #region Main Functions and Events
        public InventoryUC()
        {
            InitializeComponent();


            SetInitialValues();

        }



        #endregion

        #region set the initianl values

        

        
        private void SetInitialValues()
        {
            StocksList.ItemsSource = null;
            StocksList.ItemsSource = PublicVariables.Store.GetStocks;

        }



        #endregion

        #region Hole Form Events


        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            SetInitialValues();
        }

        #endregion

    }
}
