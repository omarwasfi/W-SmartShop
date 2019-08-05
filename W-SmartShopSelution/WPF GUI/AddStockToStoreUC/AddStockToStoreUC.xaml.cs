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
    /// Interaction logic for AddStockToStoreUC.xaml
    /// 
    /// Get store
    /// get the products no in the stock of this store 
    /// add the selected products to the store
    /// </summary>
    public partial class AddStockToStoreUC : UserControl
    {

        #region Main Variables

        /// <summary>
        /// All The stock in the database
        /// </summary>
        private List<StockModel> Stocks { get; set; }

        /// <summary>
        /// The selected store 
        /// </summary>
        private StoreModel Store { get; set; }

        /// <summary>
        /// The new stocks that the user add
        /// </summary>
        private List<StockModel> NewStocks { get; set; } = new List<StockModel>();

        /// <summary>
        /// all the prodcuts
        /// </summary>
        private List<ProductModel> Products { get; set;}

        /// <summary>
        /// The prodcuts that's not in the store's stock
        /// </summary>
        private List<ProductModel> FProducts { get; set; }


        #region Help variables
        /// <summary>
        /// The selected store stocks
        /// </summary>
        private List<StockModel> StoreStocks = new List<StockModel>();

        /// <summary>
        /// All stores
        /// </summary>
        private List<StoreModel> Stores { get; set; }

        /// <summary>
        /// Are we working with the global stocks or not
        /// </summary>

        private List<CategoryModel> Categories { get; set; }
        private List<BrandModel> Brands { get; set; }


        private List<string> SearchTypes { get; set; } = new List<string>() { "Name", "SerialNumber" };
        #endregion

        #endregion


        #region set the initianl values

        /// <summary>
        /// is global stocks False the user will be able to Add  stocks to his store ONLY
        /// If True the user can Add  stocks to all stores
        /// </summary>
        /// <param name="store"> The store that we want to add the new products in </param>
        public AddStockToStoreUC(StoreModel store )
        {
            InitializeComponent();

            Store = store;

            SetInitialValues();
        }


        private void SetInitialValues()
        {

            // set the ProductSearchType_InventoryUC values
            ProductSearchType_AddStockToStoreUC.ItemsSource = null;
            ProductSearchType_AddStockToStoreUC.ItemsSource = SearchTypes;

            
                List<StoreModel> stores = new List<StoreModel>();
                stores.Add(Store);

                StoreValue_AddStockToStoreUC.ItemsSource = stores;
                StoreValue_AddStockToStoreUC.DisplayMemberPath = "Name";

                QuantityValue_AddStockToStoreUC.Text = "1";


                UpdateProductsFromThePublicVaribles();

                FProductsList_AddStockToStoreUC.ItemsSource = null;

                UpdateStocksFromThePublicVaribles();


                UpdateCategoriesFromThePublicVaribles();
                CategoryValue_AddStockToStoreUC.ItemsSource = null;
                CategoryValue_AddStockToStoreUC.ItemsSource = Categories;
                CategoryValue_AddStockToStoreUC.DisplayMemberPath = "Name";


                UpdateBrandsFromThePublicVaribles();
                BrandValue_AddStockToStoreUC.ItemsSource = null;
                BrandValue_AddStockToStoreUC.ItemsSource = Brands;
                BrandValue_AddStockToStoreUC.DisplayMemberPath = "Name";

                StoreValue_AddStockToStoreUC.SelectedValue = null;
                StoreValue_AddStockToStoreUC.SelectedValue = Store;


           




        }

        /// <summary>
        /// Updates the stocks with the Stocks public variables
        /// Called each time we need to update the stocks from the public variables
        /// </summary>
        private void UpdateStocksFromThePublicVaribles()
        {
            Stocks = PublicVariables.Stocks;
        }

        /// <summary>
        /// Updates the categories with the categories public variables
        /// Called each time we need to update the categories
        /// </summary>
        private void UpdateCategoriesFromThePublicVaribles()
        {
            Categories = PublicVariables.Categories;
            Categories.RemoveAt(0);
        }

        /// <summary>
        /// Updates the brands with the Brands public variables
        /// Called each time we need to update the brands
        /// </summary>
        private void UpdateBrandsFromThePublicVaribles()
        {
            Brands = PublicVariables.Brands;
            Brands.RemoveAt(0);
        }

        /// <summary>
        /// Updates the products with the prodcuts public variables
        /// Called each time we need to update the prodcuts
        /// </summary>
        private void UpdateProductsFromThePublicVaribles()
        {
            Products = PublicVariables.Products;
            Products.RemoveAt(0);
        }

        /// <summary>
        /// Update the stores with the stores in  public veriables
        /// </summary>
        private void UpdateStores()
        {
            Stores = PublicVariables.Stores;
        }



        /// <summary>
        /// Called to update the list of StoreStocks , After each store change
        /// </summary>
        private void UpdateTheStoreStocks()
        {
            StoreStocks = GlobalConfig.Connection.FilterStocksListByStore(Stocks, Store);
        }


        /// <summary>
        /// Update FProducts by get the products thats not in the store
        /// </summary>
        private void UpdateFProdcuts()
        { 
            FProducts = GlobalConfig.Connection.GetTheProductsNotInTheStocks(Products, StoreStocks);
        }

        #endregion

        #region CategoryCB and Brand CB events 


        /// <summary>
        /// Filter products by brand and category if any of them changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FilterProductsByCategoryAndBrand(object sender, SelectionChangedEventArgs e)
        {

            FProductsList_AddStockToStoreUC.ItemsSource = null;

            FProductsList_AddStockToStoreUC.ItemsSource
                = GlobalConfig.Connection.GetProductsByCategoryAndBrand(FProducts, (CategoryModel)CategoryValue_AddStockToStoreUC.SelectedItem, (BrandModel)BrandValue_AddStockToStoreUC.SelectedItem);
        }



        #endregion


        #region Hole form events


        /// <summary>
        /// each storevalue change
        /// set the storemodel to the selected store
        /// get the products that the store don't have in his stocks 
        /// set th FProdcuts list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StoreValue_AddStockToStoreUC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((StoreModel)StoreValue_AddStockToStoreUC.SelectedItem != null)
            {
                Store = null;
                Store = (StoreModel)StoreValue_AddStockToStoreUC.SelectedItem;
                UpdateTheStoreStocks();
                UpdateFProdcuts();
                FProductsList_AddStockToStoreUC.ItemsSource = null;
                FProductsList_AddStockToStoreUC.ItemsSource = FProducts;
                
                

            }
        }



        private void AddToTheCurrentStoreButton_AddStockToStoreUC_Click(object sender, RoutedEventArgs e)
        {
            if((ProductModel)FProductsList_AddStockToStoreUC.SelectedItem != null)
            {
                int quantity = new int();
                if(int.TryParse(QuantityValue_AddStockToStoreUC.Text , out quantity))
                {
                    if(quantity > 0)
                    {

                        StockModel stock = new StockModel();
                        stock.Product = (ProductModel)FProductsList_AddStockToStoreUC.SelectedItem;
                        stock.Quantity = quantity;
                        stock.Store = Store;

                        NewStocks.Add(stock);
                        FProducts.Remove(stock.Product);

                        QuantityValue_AddStockToStoreUC.Text = "1";

                        NewStocksList_AddStockToStoreUC.ItemsSource = null;
                        NewStocksList_AddStockToStoreUC.ItemsSource = NewStocks;

                        FProductsList_AddStockToStoreUC.ItemsSource = null;
                        FProductsList_AddStockToStoreUC.ItemsSource = FProducts;

                    }
                    else
                    {
                        MessageBox.Show("Quanitity must be more than 0");
                    }
                }
                else
                {
                    MessageBox.Show("quantity is not a number");
                }


            }
            else
            {
                MessageBox.Show("Choose product");
            }
        }


        /// <summary>
        /// Close the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_AddStockToStoreUC_Click(object sender, RoutedEventArgs e)
        {
            var parent = this.Parent as Window;
            if (parent != null) { parent.DialogResult = true; parent.Close(); }
        }

        /// <summary>
        /// Clear and reset the form by setInitialValues
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearButton_AddStockToStoreUC_Click(object sender, RoutedEventArgs e)
        {
            SetInitialValues();
        }


        private void ConfirmButton_AddStockToStoreUC_Click(object sender, RoutedEventArgs e)
        {
            foreach(StockModel stock in NewStocks)
            {
                GlobalConfig.Connection.AddStockToTheDatabase(stock);
            }

            PublicVariables.Stocks = GlobalConfig.Connection.GetStocks();
            PublicVariables.LoginStoreStocks = GlobalConfig.Connection.FilterStocksByStore(PublicVariables.Store);


            var parent = this.Parent as Window;
            if (parent != null) { parent.DialogResult = true; parent.Close(); }
        }

        private void RemoveSelectedStockButton_AddStockToStoreUC_Click(object sender, RoutedEventArgs e)
        {
            StockModel stock = new StockModel();
            stock = (StockModel)NewStocksList_AddStockToStoreUC.SelectedItem;
            if (stock != null)
            {
                FProducts.Add(stock.Product);
                NewStocks.Remove(stock);

                FProductsList_AddStockToStoreUC.ItemsSource = null;
                FProductsList_AddStockToStoreUC.ItemsSource = FProducts;

                NewStocksList_AddStockToStoreUC.ItemsSource = null;
                NewStocksList_AddStockToStoreUC.ItemsSource = NewStocks;

            }
            else
            {
                MessageBox.Show("There is no Product selected !");
            }
        }



        /// <summary>
        /// Called when search button clicked 
        /// check the search type 
        /// if it serialNumber Or Name Filter by The selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProductSearchButton_AddStockToStoreUC_Click(object sender, RoutedEventArgs e)
        {
            if (ProductSearchType_AddStockToStoreUC.Text == "SerialNumber")
            {
                FProductsList_AddStockToStoreUC.ItemsSource = null;
                FProductsList_AddStockToStoreUC.ItemsSource =
                    GlobalConfig.Connection.FilterProductsBySerialNumber(FProducts, ProductSearchValue_AddStockToStoreUC.Text);

            }
            else if (ProductSearchType_AddStockToStoreUC.Text == "Name")
            {
                FProductsList_AddStockToStoreUC.ItemsSource = null;

                FProductsList_AddStockToStoreUC.ItemsSource =
                    GlobalConfig.Connection.FilterProductsByName(FProducts, ProductSearchValue_AddStockToStoreUC.Text);
            }
            else
            {
                MessageBox.Show("CHoose the search type first");
            }
        }



        #endregion


    }
}
