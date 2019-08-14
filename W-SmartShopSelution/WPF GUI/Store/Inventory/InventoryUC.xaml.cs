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

        private List<StockModel> Stocks { get; set; }


        #endregion

        #region Help variables

        private List<StockModel> FStocks { get; set; } = new List<StockModel>();
        private List<CategoryModel> Categories { get; set; }
        private List<BrandModel> Brands { get; set; }

        private List<string> SearchTypes { get; set; } =new List<string>() {"Name","SerialNumber"};
        #endregion

        #region Main Functions and Events
        public InventoryUC()
        {
            InitializeComponent();


            SetInitialValues();

        }



        #endregion

        #region set the initianl values

        

        /// <summary>
        /// Set the Initial values for the stocks list, Categories list , CategoryValue_InventoryUC , brand list ,  BrandValue_InventoryUC 
        /// </summary>
        private void SetInitialValues()
        {
            // set the ProductSearchType_InventoryUC values
            ProductSearchType_InventoryUC.ItemsSource = null;
            ProductSearchType_InventoryUC.ItemsSource = SearchTypes;

            // Set the stocks list form the public variables
            
            UpdateStocksFromThePublicVaribles();
            StocksList_Inventory.ItemsSource = null;
            StocksList_Inventory.ItemsSource = Stocks;
            

            UpdateCategoriesFromThePublicVaribles();
            CategoryValue_InventoryUC.ItemsSource = null;
            CategoryValue_InventoryUC.ItemsSource = Categories;
            CategoryValue_InventoryUC.DisplayMemberPath = "Name";


            UpdateBrandsFromThePublicVaribles();
            BrandValue_InventoryUC.ItemsSource = null;
            BrandValue_InventoryUC.ItemsSource = Brands;
            BrandValue_InventoryUC.DisplayMemberPath = "Name";

        }

        /// <summary>
        /// Updates the stocks with the LosginStoreStocks public variables
        /// Called each time we need to update the stocks
        /// </summary>
        private void UpdateStocksFromThePublicVaribles()
        {
            Stocks = PublicVariables.LoginStoreStocks;
        }

        /// <summary>
        /// Updates the categories with the categories public variables
        /// Called each time we need to update the categories
        /// </summary>
        private void UpdateCategoriesFromThePublicVaribles()
        {
            PublicVariables.Categories = GlobalConfig.Connection.GetCategories();
            Categories = PublicVariables.Categories;
            
        }

        /// <summary>
        /// Updates the brands with the Brands public variables
        /// Called each time we need to update the brands
        /// </summary>
        private void UpdateBrandsFromThePublicVaribles()
        {
            PublicVariables.Brands = GlobalConfig.Connection.GetBrands();
            Brands = PublicVariables.Brands;
        }


        #endregion

        #region CategoryCB and Brand CB events 

        /// <summary>
        /// Private event called when CategoryValue_InventoryUC combobox OR BrandValue_InventoryUC combobox sellection  changed to filter the StocksList_Inventory gridView by selected category or brand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FilterStocksByCategoryAndBrand(object sender, SelectionChangedEventArgs e)
        {

            FStocks = GlobalConfig.Connection.FilterStocksByCategoryAndBrand(Stocks, (CategoryModel)CategoryValue_InventoryUC.SelectedItem, (BrandModel)BrandValue_InventoryUC.SelectedItem);

            StocksList_Inventory.ItemsSource = null;
            StocksList_Inventory.ItemsSource = FStocks;


        }
        #endregion

        #region Hole Form Events

        /// <summary>
        /// reset the default value from the hole form from the public variables
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetStockResultsButton_InventoryUC_Click(object sender, RoutedEventArgs e)
        {
            SetInitialValues();
            SetInitialValues();
        }

        /// <summary>
        /// called when search button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProductSearchButton_InventoryUC_Click(object sender, RoutedEventArgs e)
        {
            if(ProductSearchType_InventoryUC.Text == "SerialNumber")
            {
                FStocks = GlobalConfig.Connection.FilterStocksBySerialNumber(Stocks, ProductSearchValue_InventoryUC.Text);
                StocksList_Inventory.ItemsSource = null;
                StocksList_Inventory.ItemsSource = FStocks;
            }
            else if(ProductSearchType_InventoryUC.Text == "Name")
            {
                FStocks = GlobalConfig.Connection.FilterStocksByName(Stocks, ProductSearchValue_InventoryUC.Text);

                StocksList_Inventory.ItemsSource = null;
                StocksList_Inventory.ItemsSource = FStocks;
            }
            else
            {
                MessageBox.Show("CHoose the search type first");
            }
        }

        private void AddNewProdcutToTheInventoryButton_InventoryUC_Click(object sender, RoutedEventArgs e)
        {
            
            AddStockToStoreUC addStockToStoreUC = new AddStockToStoreUC(PublicVariables.Store);
            Window window = new Window
            {
                Title = "Add Prodcut to the inventory",
                Content = addStockToStoreUC,
                SizeToContent = SizeToContent.Height,
                Width = 1350,
                ResizeMode = ResizeMode.NoResize
            };
            window.ShowDialog();
            SetInitialValues();

        }

        private void ModifySelectedButton_InventoryUC_Click(object sender, RoutedEventArgs e)
        {
            StockModel stock = new StockModel();
            stock = (StockModel)StocksList_Inventory.SelectedItem;
            if(stock != null)
            {

                ModifyStockUC modifyStockUC = new ModifyStockUC(stock);
                Window window = new Window
                {
                    Title = "Modify Stock",
                    Content = modifyStockUC,
                    SizeToContent = SizeToContent.WidthAndHeight,
                    ResizeMode = ResizeMode.NoResize
                };
                window.ShowDialog();
                SetInitialValues();

            }
            else
            {
                MessageBox.Show("There is no product selected !");
            }

        }

        #endregion


    }
}
