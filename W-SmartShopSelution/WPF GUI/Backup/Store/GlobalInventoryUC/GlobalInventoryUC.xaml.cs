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
    /// Interaction logic for GlobalInventoryUC.xaml
    /// </summary>
    public partial class GlobalInventoryUC : UserControl
    {

        #region Main Variables

        private List<StockModel> Stocks { get; set; }


        #endregion

        #region Help variables

        private List<StockModel> FStocks { get; set; } = new List<StockModel>();
        private List<CategoryModel> Categories { get; set; }
        private List<BrandModel> Brands { get; set; }

        /// <summary>
        /// all stores
        /// </summary>
        private List<StoreModel> Stores { get; set; }

        private List<string> SearchTypes { get; set; } = new List<string>() { "Name", "SerialNumber" };
        #endregion

        #region set the initianl values


        public GlobalInventoryUC()
        {
            InitializeComponent();

            SetInitialValues();

        }

        private void SetInitialValues()
        {

            // set the ProductSearchType_InventoryUC values
            ProductSearchType_GlobalInventoryUC.ItemsSource = null;
            ProductSearchType_GlobalInventoryUC.ItemsSource = SearchTypes;

            // Set the stocks list form the public variables

            UpdateStocksFromThePublicVaribles();
            StocksList_GlobalInventoryUC.ItemsSource = null;
            StocksList_GlobalInventoryUC.ItemsSource = Stocks;

            UpdateStorsFromThePublicVaribles();
            StoreValue_GlobalInventoryUC.ItemsSource = null;
            StoreValue_GlobalInventoryUC.ItemsSource = Stores;
            StoreValue_GlobalInventoryUC.DisplayMemberPath = "Name";

            UpdateCategoriesFromThePublicVaribles();
            CategoryValue_GlobalInventoryUC.ItemsSource = null;
            CategoryValue_GlobalInventoryUC.ItemsSource = Categories;
            CategoryValue_GlobalInventoryUC.DisplayMemberPath = "Name";


            UpdateBrandsFromThePublicVaribles();
            BrandValue_GlobalInventoryUC.ItemsSource = null;
            BrandValue_GlobalInventoryUC.ItemsSource = Brands;
            BrandValue_GlobalInventoryUC.DisplayMemberPath = "Name";

        }

        /// <summary>
        /// Updates the stocks with the stocks public variables
        /// Called each time we need to update the stocks
        /// </summary>
        private void UpdateStocksFromThePublicVaribles()
        {
            Stocks = PublicVariables.Stocks;
        }

        /// <summary>
        /// Updates the stores with the stores public variables
        /// Called each time we need to update the stores
        /// </summary>
        private void UpdateStorsFromThePublicVaribles()
        {
            PublicVariables.Stores = GlobalConfig.Connection.GetAllStores();
            Stores = PublicVariables.Stores;
            Stores.RemoveAt(0);
        }


        /// <summary>
        /// Updates the categories with the categories public variables
        /// Called each time we need to update the categories
        /// </summary>
        private void UpdateCategoriesFromThePublicVaribles()
        {
            PublicVariables.Categories = GlobalConfig.Connection.GetCategories();
            Categories = PublicVariables.Categories;
            Categories.RemoveAt(0);
        }

        /// <summary>
        /// Updates the brands with the Brands public variables
        /// Called each time we need to update the brands
        /// </summary>
        private void UpdateBrandsFromThePublicVaribles()
        {
            PublicVariables.Brands = GlobalConfig.Connection.GetBrands();
            Brands = PublicVariables.Brands;
            Brands.RemoveAt(0);
        }

        #endregion


        #region CategoryCB , BrandCB And StoreCB events 

        /// <summary>
        /// Private event called when CategoryValue_GlobalInventoryUC combobox OR BrandValue_GlobalInventoryUC combobox sellection  changed to filter the StocksList_Inventory gridView by selected category or brand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FilterStocksByCategoryAndBrand(object sender, SelectionChangedEventArgs e)
        {
            if ((StoreModel)StoreValue_GlobalInventoryUC.SelectedItem != null)
            {
                FStocks = GlobalConfig.Connection.FilterStocksListByStore(Stocks, (StoreModel)StoreValue_GlobalInventoryUC.SelectedItem);


                FStocks = GlobalConfig.Connection.FilterStocksByCategoryAndBrand(FStocks, (CategoryModel)CategoryValue_GlobalInventoryUC.SelectedItem, (BrandModel)BrandValue_GlobalInventoryUC.SelectedItem);

                StocksList_GlobalInventoryUC.ItemsSource = null;
                StocksList_GlobalInventoryUC.ItemsSource = FStocks;
            }
            else
            {
                FStocks = GlobalConfig.Connection.FilterStocksByCategoryAndBrand(Stocks, (CategoryModel)CategoryValue_GlobalInventoryUC.SelectedItem, (BrandModel)BrandValue_GlobalInventoryUC.SelectedItem);

                StocksList_GlobalInventoryUC.ItemsSource = null;
                StocksList_GlobalInventoryUC.ItemsSource = FStocks;
            }

           


        }

        private void StoreValue_GlobalInventoryUC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if((StoreModel)StoreValue_GlobalInventoryUC.SelectedItem != null)
            {

                UpdateCategoriesFromThePublicVaribles();
                CategoryValue_GlobalInventoryUC.ItemsSource = null;
                CategoryValue_GlobalInventoryUC.ItemsSource = Categories;
                CategoryValue_GlobalInventoryUC.DisplayMemberPath = "Name";


                UpdateBrandsFromThePublicVaribles();
                BrandValue_GlobalInventoryUC.ItemsSource = null;
                BrandValue_GlobalInventoryUC.ItemsSource = Brands;
                BrandValue_GlobalInventoryUC.DisplayMemberPath = "Name";

                FStocks = GlobalConfig.Connection.FilterStocksListByStore(Stocks, (StoreModel)StoreValue_GlobalInventoryUC.SelectedItem);

                StocksList_GlobalInventoryUC.ItemsSource = null;
                StocksList_GlobalInventoryUC.ItemsSource = FStocks;

               

            }
           

        }


        #endregion

        #region Hole Form Events

        /// <summary>
        /// Clear and reset the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetStockResultsButton_GlobalInventoryUC_Click(object sender, RoutedEventArgs e)
        {
            SetInitialValues();
            SetInitialValues();

        }

        private void ProductSearchButton_GlobalInventoryUC_Click(object sender, RoutedEventArgs e)
        {
            if (ProductSearchType_GlobalInventoryUC.Text == "SerialNumber")
            {
                FStocks = GlobalConfig.Connection.FilterStocksBySerialNumber(Stocks, ProductSearchValue_GlobalInventoryUC.Text);
                StocksList_GlobalInventoryUC.ItemsSource = null;
                StocksList_GlobalInventoryUC.ItemsSource = FStocks;

                StoreValue_GlobalInventoryUC.ItemsSource = null;
                StoreValue_GlobalInventoryUC.ItemsSource = Stores;
                StoreValue_GlobalInventoryUC.DisplayMemberPath = "Name";

            }
            else if (ProductSearchType_GlobalInventoryUC.Text == "Name")
            {
                FStocks = GlobalConfig.Connection.FilterStocksByName(Stocks, ProductSearchValue_GlobalInventoryUC.Text);

                StocksList_GlobalInventoryUC.ItemsSource = null;
                StocksList_GlobalInventoryUC.ItemsSource = FStocks;

                StoreValue_GlobalInventoryUC.ItemsSource = null;
                StoreValue_GlobalInventoryUC.ItemsSource = Stores;
                StoreValue_GlobalInventoryUC.DisplayMemberPath = "Name";
            }
            else
            {
                MessageBox.Show("CHoose the search type first");
            }
        }



        private void AddProductToTheSelectedStoreButton_GlobalInventoryUC_Click(object sender, RoutedEventArgs e)
        {
            StoreModel store = new StoreModel();
            store = (StoreModel)StoreValue_GlobalInventoryUC.SelectedItem;
            if(store != null)
            {
                AddStockToStoreUC addStockToStoreUC = new AddStockToStoreUC(store);
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
            else
            {
                MessageBox.Show("Select a store !");
            }
            
            
        }

        private void ModifySelectedButton_GlobalInventoryUC_Click(object sender, RoutedEventArgs e)
        {
            StockModel stock = new StockModel();
            stock = (StockModel)StocksList_GlobalInventoryUC.SelectedItem;
            if (stock != null)
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

        private void RefreshButton_GlobalInventoryUC_Click(object sender, RoutedEventArgs e)
        {
            SetInitialValues();
        }

        #endregion


    }
}
