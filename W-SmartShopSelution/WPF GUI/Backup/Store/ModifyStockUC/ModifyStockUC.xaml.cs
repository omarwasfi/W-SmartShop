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
    /// Interaction logic for ModifyStockUC.xaml
    /// </summary>
    public partial class ModifyStockUC : UserControl
    {
        #region Main Variables

        private StockModel Stock { get; set; }

        #endregion

        #region set the initianl values

        /// <summary>
        /// Edit the stock Quantity Or remove it from the database
        /// </summary>
        /// <param name="stock"> stock model </param>
        public ModifyStockUC( StockModel stock )
        {
            InitializeComponent();

            Stock = stock;

            SetInitialValues();


        }



        private void SetInitialValues()
        {


            StoreNameValue_ModifyStockUC.Text = Stock.Store.Name;
            ProductNameValue_ModifyStockUC.Text = Stock.Product.Name;
            SerialNumberValue_ModifyStockUC.Text = Stock.Product.SerialNumber;
            QuantityValue_ModifyStockUC.Text = Stock.Quantity.ToString();


        }

        #endregion

        #region Hole Form Events

        /// <summary>
        /// Remove the stock from the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveFromStoreButton_ModifyStockUC_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult deleteStockConfirmation = System.Windows.MessageBox.Show("This Product will be removed from the store", "Remove Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (deleteStockConfirmation == MessageBoxResult.Yes)
            {
                GlobalConfig.Connection.RemoveStockFromTheDatabase(Stock);

                PublicVariables.LoginStoreStocks = GlobalConfig.Connection.FilterStocksByStore(PublicVariables.Store);
                PublicVariables.Stocks = GlobalConfig.Connection.GetStocks();

                var parent = this.Parent as Window;
                if (parent != null) { parent.DialogResult = true; parent.Close(); }
            }
            else
            {
                QuantityValue_ModifyStockUC.Text = Stock.Quantity.ToString();
            }
        }

        /// <summary>
        /// Check if the quantity vaild then update the stock with the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfirmButton_ModifyStockUC_Click(object sender, RoutedEventArgs e)
        {
            if(QuantityValue_ModifyStockUC.Text.Length > 0)
            {
                int quantity = new int();
                if(int.TryParse(QuantityValue_ModifyStockUC.Text,out quantity))
                {
                    if(quantity > 0)
                    {

                        Stock.Quantity = quantity;

                        GlobalConfig.Connection.UpdateStockData(Stock);

                        PublicVariables.LoginStoreStocks = GlobalConfig.Connection.FilterStocksByStore(PublicVariables.Store);
                        PublicVariables.Stocks = GlobalConfig.Connection.GetStocks();


                        var parent = this.Parent as Window;
                        if (parent != null) { parent.DialogResult = true; parent.Close(); }
                    }
                    else
                    {
                        MessageBox.Show("Quantity can't be less than 1");
                    }
                }
                else
                {
                    MessageBox.Show("Quantity Should be a number !");
                    QuantityValue_ModifyStockUC.Text = Stock.Quantity.ToString();
                }
            }
            else
            {
                MessageBox.Show("The quantity value can't be empty");
                QuantityValue_ModifyStockUC.Text = Stock.Quantity.ToString();

            }
        }

        /// <summary>
        /// Close the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_ModifyStockUC_Click(object sender, RoutedEventArgs e)
        {
            var parent = this.Parent as Window;
            if (parent != null) { parent.DialogResult = true; parent.Close(); }
        }

        /// <summary>
        /// Reset the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetButton_ModifyStockUC_Click(object sender, RoutedEventArgs e)
        {
            SetInitialValues();
        }

        #endregion


    }
}
