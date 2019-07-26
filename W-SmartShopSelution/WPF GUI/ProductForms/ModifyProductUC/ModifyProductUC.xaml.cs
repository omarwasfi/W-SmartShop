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
using WPF_GUI.CreateBrand;
using WPF_GUI.CreateCategory;

namespace WPF_GUI.ModifyProduct
{
    /// <summary>
    /// Interaction logic for ModifyProduct.xaml
    /// </summary>
    public partial class ModifyProductUC : UserControl
    {

        #region Main Veriable

        private List<CategoryModel> Categories { get; set; }
        private List<BrandModel> Brands { get; set; }

        private List<StoreModel> Stores { get; set; }

        private ProductModel Product { get; set; }

        private List<StockModel> ProductStocks { get; set; }

        private List<StockModel> UpdatedStocks { get; set; } = new List<StockModel>();

        private List<StockModel> NewStocks { get; set; } = new List<StockModel>();

        #endregion

        #region Not main ! Veriable

        private List<StockModel> Stocks { get; set; }

        #endregion


        #region Initial And Update Tha main Values 
        /// <summary>
        /// the constractor of ModifyProductUC ,  needs a product model
        /// </summary>
        /// <param name="product"> the product that needs to be modified </param>
        public ModifyProductUC( ProductModel product )
        {

            InitializeComponent();

            Product = product;

            SetInitialValues();

        }

        /// <summary>
        /// Set the initial values 
        /// Called to update the categoies CB Or brands , Stores
        /// Product stocks list
        /// </summary>
        private void SetInitialValues()
        {
            UpdateStocksFromTheDatabase();

            GetProdcutStock();

            

            UpdateCategoriesFromThePublicVariables();
            CategoryValue_ModifyProductUC.ItemsSource = null;
            CategoryValue_ModifyProductUC.ItemsSource = Categories;
            CategoryValue_ModifyProductUC.SelectedIndex = Get_CategoryValue_ModifyProductUC_Index(Product.Category);
            CategoryValue_ModifyProductUC.DisplayMemberPath = "Name";

            UpdateBrandsFromThePublicVariables();
            BrandValue_ModifyProductUC.ItemsSource = null;
            BrandValue_ModifyProductUC.ItemsSource = Brands;
            BrandValue_ModifyProductUC.SelectedIndex = Get_BrandValue_ModifyProductUC_Index(Product.Brand);
            BrandValue_ModifyProductUC.DisplayMemberPath = "Name";

            UpdateStoresFromTheDatabase();
            StoreNameValue_ModifyProductUC.ItemsSource = null;
            StoreNameValue_ModifyProductUC.ItemsSource = Stores;
            StoreNameValue_ModifyProductUC.DisplayMemberPath = "Name";


            ProductNameValue_ModifyProductUC.Text = Product.Name;
            SerialNumberValue_ModifyProductUC.Text = Product.SerialNumber;
            SalePriceValue_ModifyProductUC.Text = Product.SalePrice.ToString();
            IncomeValue_ModifyProductUC.Text = Product.IncomePrice.ToString();

        }

        /// <summary>
        /// get the index of brand if it in the BrandValue_ModifyProductUC
        /// </summary>
        /// <param name="brand"></param>
        /// <returns> index of this brand </returns>
        private int Get_BrandValue_ModifyProductUC_Index(BrandModel brand)
        {
            int i = 0;
            var lst = BrandValue_ModifyProductUC.Items.Cast<BrandModel>();
            foreach (var s in lst)
            {
                if (s.Id == brand.Id)
                    return i;

                i++;
            }
            return 0;
        }

        /// <summary>
        /// get the index of categry if it in the CategoryValue_ModifyProductUC
        /// </summary>
        /// <param name="category"></param>
        /// <returns> index of this category </returns>
        private int Get_CategoryValue_ModifyProductUC_Index(CategoryModel category)
        {
            int i = 0;
            var lst = CategoryValue_ModifyProductUC.Items.Cast<CategoryModel>();
            foreach (var s in lst)
            {
                if (s.Id == category.Id)
                    return i;

                i++;
            }
            return 0;
        }

        /// <summary>
        /// Update the categories list with the public variables
        /// </summary>
        private void UpdateCategoriesFromThePublicVariables()
        {
            Categories = PublicVariables.Categories;

        }

        /// <summary>
        /// Update the brands list with the public variables
        /// </summary>
        private void UpdateBrandsFromThePublicVariables()
        {
            Brands = PublicVariables.Brands;
        }


        /// <summary>
        /// Update the Stores list from the database
        /// remove the default store 
        /// </summary>
        private void UpdateStoresFromTheDatabase()
        {
            Stores = GlobalConfig.Connection.GetAllStores();
            Stores.RemoveAt(0);
        }

        /// <summary>
        /// Get all stock from the database  , set the stocks in public variables
        /// </summary>
        private void UpdateStocksFromTheDatabase()
        {
            Stocks = GlobalConfig.Connection.GetStocks();
            PublicVariables.Stocks = null;
            PublicVariables.Stocks = Stocks;
        }

        /// <summary>
        /// Filters the stocks to get the prodcut stocks only
        /// </summary>
        private void GetProdcutStock()
        {
            ProductStocks = GlobalConfig.Connection.GetStocksByProduct(Stocks, Product);
        }


        /// <summary>
        /// Each selecttion change , check if the store in the stocks or not 
        /// if not set the quantity to 0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StoreNameValue_ModifyProductUC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StoreModel selectedStore = new StoreModel();
            selectedStore = (StoreModel)StoreNameValue_ModifyProductUC.SelectedItem;
            if (selectedStore != null)
            {
                foreach (StockModel stock in ProductStocks)
                {
                    if (stock.Store.Id == selectedStore.Id)
                    {
                        QuantityInThisStoreValue_ModifyProductUC.Text = stock.Quantity.ToString();
                        break;
                    }
                    else
                    {
                        QuantityInThisStoreValue_ModifyProductUC.Text = "0";
                    }
                }
            }
            
        }

        /// <summary>
        /// check if the store in the stock , if it is update the quantity of this stock,
        /// if not create new stock
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfirmStoreButton_ModifyProductUC_Click(object sender, RoutedEventArgs e)
        {
            if(StoreNameValue_ModifyProductUC.Text.Length > 0)
            {
                int quantity;
                if (int.TryParse(QuantityInThisStoreValue_ModifyProductUC.Text, out quantity))
                {
                    if (quantity >= 0)
                    {
                        if (CheckIfTheStoreNameInTheStocks(ProductStocks, StoreNameValue_ModifyProductUC.Text))
                        {
                            foreach (StockModel stock in ProductStocks)
                            {
                                if (stock.Store.Name == StoreNameValue_ModifyProductUC.Text)
                                {
                                    stock.Quantity = quantity;
                                    UpdatedStocks.Add(stock);
                                    Stores.Remove((StoreModel)StoreNameValue_ModifyProductUC.SelectedItem);
                                    StoreNameValue_ModifyProductUC.ItemsSource = null;
                                    StoreNameValue_ModifyProductUC.ItemsSource = Stores;
                                    QuantityInThisStoreValue_ModifyProductUC.Text = "";


                                }

                            }
                        }
                        else
                        {
                            StockModel stock = new StockModel();
                            stock.Quantity = quantity;
                            stock.Store = (StoreModel)StoreNameValue_ModifyProductUC.SelectedItem;
                            Stores.Remove((StoreModel)StoreNameValue_ModifyProductUC.SelectedItem);
                            StoreNameValue_ModifyProductUC.ItemsSource = null;
                            StoreNameValue_ModifyProductUC.ItemsSource = Stores;
                            QuantityInThisStoreValue_ModifyProductUC.Text = "";
                            NewStocks.Add(stock);
                        }

                        
                    }
                    else
                    {
                        MessageBox.Show("Quantity Can't be Less than 0");
                    }
                }
                else
                {
                    MessageBox.Show("Enter the Quantity Again ,  make sure there is no Characters in it {just A number}");
                    QuantityInThisStoreValue_ModifyProductUC.Text = "";


                }
            }
            else
            {
                MessageBox.Show("Select Store Name");
            }
        }

        /// <summary>
        /// Get list of stocks and store name to check if it in the stocks list or not
        /// if it is in the stocks list  return true
        /// if not return fales
        /// </summary>
        /// <param name="stocks"></param>
        /// <param name="storeName"></param>
        /// <returns></returns>
        private bool CheckIfTheStoreNameInTheStocks(List<StockModel> stocks , string storeName )
        {
            foreach(StockModel stock in stocks)
            {
                if(stock.Store.Name == storeName)
                {
                    return true;
                }

            }
            return false;
        }

        /// <summary>
        /// Create new Brand and Update the initial values from the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateNewBrandButton_ModifyProductUC_Click(object sender, RoutedEventArgs e)
        {
            CreateBrandUC createBrand = new CreateBrandUC();
            Window window = new Window
            {
                Title = "Create Brand",
                Content = createBrand,
                SizeToContent = SizeToContent.WidthAndHeight,
                ResizeMode = ResizeMode.NoResize
            };
            window.ShowDialog();
            SetInitialValues();
        }

        /// <summary>
        /// Create new category and Update the initial values from the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateNewCategoryButton_ModifyProductUC_Click(object sender, RoutedEventArgs e)
        {
            CreateCategoryUC createCategory = new CreateCategoryUC();
            Window window = new Window
            {
                Title = "Create Category",
                Content = createCategory,
                SizeToContent = SizeToContent.WidthAndHeight,
                ResizeMode = ResizeMode.NoResize
            };
            window.ShowDialog();
            SetInitialValues();
        }

        /// <summary>
        /// Close the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_ModifyProductUC_Click(object sender, RoutedEventArgs e)
        {
            var parent = this.Parent as Window;
            if (parent != null) { parent.DialogResult = true; parent.Close(); }
        }

        /// <summary>
        /// Clear the window by set the initial values again
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearButton_ModifyProductUC_Click(object sender, RoutedEventArgs e)
        {
            SetInitialValues();
        }


        private void ConfirmButton_ModifyProductUC_Click(object sender, RoutedEventArgs e)
        {
            bool confirm = true;

            if (ProductNameValue_ModifyProductUC.Text.Length > 0)
            {
                
                if (ProductNameValue_ModifyProductUC.Text == Product.Name || GlobalConfig.Connection.CheckIfTheProductNameUnique(PublicVariables.Products, ProductNameValue_ModifyProductUC.Text) )
                {
                    if ( SerialNumberValue_ModifyProductUC.Text == Product.SerialNumber || GlobalConfig.Connection.CheckIfTheProductSerialNumberUnique(PublicVariables.Products, SerialNumberValue_ModifyProductUC.Text))
                    {
                        decimal salePrice = new decimal();
                        decimal incomePrice = new decimal();
                        if (decimal.TryParse(SalePriceValue_ModifyProductUC.Text, out salePrice))
                        {
                            if (salePrice > 0)
                            {
                                if (decimal.TryParse(IncomeValue_ModifyProductUC.Text, out incomePrice))
                                {
                                    if (incomePrice > 0)
                                    {
                                        if (BrandValue_ModifyProductUC.Text.Length < 1)
                                        {
                                            BrandValue_ModifyProductUC.SelectedIndex = 0;

                                        }
                                        if (CategoryValue_ModifyProductUC.Text.Length < 1)
                                        {
                                            CategoryValue_ModifyProductUC.SelectedIndex = 0;
                                        }

                                    }
                                    else
                                    {
                                        MessageBox.Show("Income Price Can't be Less than 0.0001");
                                        confirm = false;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Enter the Income Price Again ,  make sure there is no Characters in it {just A number}");
                                    IncomeValue_ModifyProductUC.Text = "";
                                    confirm = false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Sale Price Can't be Less than 0.0001");
                                confirm = false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Enter the sale Price Again ,  make sure there is no Characters in it {just A number}");
                            SalePriceValue_ModifyProductUC.Text = "";

                            confirm = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("This new Serial number is used in Other Product");
                        confirm = false;
                    }
                }
                else
                {
                    MessageBox.Show("This New Name is used In other product");
                    confirm = false;
                }
            }
            else
            {
                MessageBox.Show("Product Name can't be less than 1 character");
                confirm = false;
            }

            // Update the product with the database
            // Update Or add the stocks to the databbase 
            // reset the window
            if (confirm)
            {
                Product.Name = ProductNameValue_ModifyProductUC.Text;
                Product.SerialNumber = SerialNumberValue_ModifyProductUC.Text;
                Product.IncomePrice = decimal.Parse(IncomeValue_ModifyProductUC.Text);
                Product.SalePrice = decimal.Parse(SalePriceValue_ModifyProductUC.Text);
                Product.Brand = (BrandModel)BrandValue_ModifyProductUC.SelectedItem;
                Product.Category = (CategoryModel)CategoryValue_ModifyProductUC.SelectedItem;

                // Update the product with the database
                GlobalConfig.Connection.UpdateProdcutData(Product);



                // Update the products list in the public variables
                PublicVariables.Products = GlobalConfig.Connection.GetProducts();


                foreach (StockModel stock in NewStocks)
                {
                    stock.Product = Product;
                    // save the stock to the database
                    stock.Id = GlobalConfig.Connection.AddStockToTheDatabase(stock).Id;

                    
                }

                foreach (StockModel stock in UpdatedStocks)
                {

                    GlobalConfig.Connection.UpdateStockData(stock);

                   
                }

                // Update the login stocks in the public variables
                PublicVariables.LoginStoreStocks = GlobalConfig.Connection.FilterStocksByStore(PublicVariables.Store);

                // Close the Window
                var parent = this.Parent as Window;
                if (parent != null) { parent.DialogResult = true; parent.Close(); }


                

            }

        }
        #endregion












    }
}
