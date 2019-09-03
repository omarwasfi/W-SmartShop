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

namespace WPF_GUI.CreateProduct
{
    /// <summary>
    /// Interaction logic for CreateProductUC.xaml
    /// </summary>
    public partial class CreateProductUC : UserControl
    {
        #region Main Veriable

        private List<CategoryModel> Categories { get; set; }
        private List<BrandModel> Brands { get; set; }

        private List<ProductModel> Products { get; set; }

        private List<StoreModel> Stores { get; set; }

        private List<StockModel> NewStocks { get; set; } = new List<StockModel>();

        #endregion

        #region Initial And Update Tha main Values 

        public CreateProductUC()
        {
            InitializeComponent();

            SetInitialValues();

        }


        /// <summary>
        /// Set the initial values 
        /// Called to update the categoies CB Or brands , Products
        /// </summary>
        private void SetInitialValues()
        {

            UpdateCategoriesFromThePublicVariables();
            CategoryValue_CreateProductUC.ItemsSource = null;
            CategoryValue_CreateProductUC.ItemsSource = Categories;
            CategoryValue_CreateProductUC.DisplayMemberPath = "Name";


            UpdateBrandsFromThePublicVariables();
            BrandValue_CreateProductUC.ItemsSource = null;
            BrandValue_CreateProductUC.ItemsSource = Brands;
            BrandValue_CreateProductUC.DisplayMemberPath = "Name";

            UpdateProductsFromTheDatabase();

            UpdateStoresFromTheDatabase();
            StoreNameValue_CreateProductUC.ItemsSource = null;
            StoreNameValue_CreateProductUC.ItemsSource = Stores;
            StoreNameValue_CreateProductUC.DisplayMemberPath = "Name";

            ProductNameValue_CreateProductUC.Text = "";
            ProductBarCodeValue_CreateProductUC.Text = "";
            SerialNumberValue_CreateProductUC.Text = "";
            SerialNumber2Value_CreateProductUC.Text = "";
            SalePriceValue_CreateproductUC.Text = "";
            IncomeValue_CreateproductUC.Text = "";
            DetailsValue_CreateProductUC.Text = "";

        }

        /// <summary>
        /// Update the categories list with the public variables
        /// </summary>
        private void UpdateCategoriesFromThePublicVariables()
        {
            PublicVariables.Categories = GlobalConfig.Connection.GetCategories();
            Categories = PublicVariables.Categories;

        }

        /// <summary>
        /// Update the brands list with the public variables
        /// </summary>
        private void UpdateBrandsFromThePublicVariables()
        {
            PublicVariables.Brands = GlobalConfig.Connection.GetBrands();
            Brands = PublicVariables.Brands;
        }


        /// <summary>
        /// Update the Produts list from the database
        /// </summary>
        private void UpdateProductsFromTheDatabase()
        {
            PublicVariables.Products = GlobalConfig.Connection.GetProducts();
            Products = PublicVariables.Products;
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

        #endregion

        #region Hole Form Events

        /// <summary>
        /// Check if every thing correct 
        /// - check if the product name is not exist in the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateButton_CreateProductUC_Click(object sender, RoutedEventArgs e)
        {
            bool confirm = true;

            if (ProductNameValue_CreateProductUC.Text.Length > 0)
            {
                /*if (GlobalConfig.Connection.CheckIfTheProductNameUnique(PublicVariables.Products, ProductNameValue_CreateProductUC.Text))
                {
                    if (GlobalConfig.Connection.CheckIfTheProductSerialNumberUnique(PublicVariables.Products, SerialNumberValue_CreateProductUC.Text) || GlobalConfig.Connection.CheckIfTheProductSerialNumberUnique(PublicVariables.Products, SerialNumber2Value_CreateProductUC.Text))
                    {
                        
                    }
                    else
                    {
                        MessageBox.Show("This Serial number is used before ,  , it would be better if used a new serial number");
                    }
                }
                else
                {
                    MessageBox.Show("This Name is used before , it would be better if used a new name");
                }*/
            }
            else
            {
                MessageBox.Show("Enter the Product Name");
                confirm = false;
            }


            decimal salePrice = new decimal();
            decimal incomePrice = new decimal();
            if (decimal.TryParse(SalePriceValue_CreateproductUC.Text, out salePrice))
            {
                if (salePrice > 0)
                {
                    if (decimal.TryParse(IncomeValue_CreateproductUC.Text, out incomePrice))
                    {
                        if (incomePrice > 0)
                        {

                            if (GlobalConfig.Connection.CheckIfTheProductBarCodeUnique(Products, ProductBarCodeValue_CreateProductUC.Text))
                            {
                                if (BrandValue_CreateProductUC.Text.Length < 1)
                                {
                                    BrandValue_CreateProductUC.SelectedIndex = 0;

                                }
                                if (CategoryValue_CreateProductUC.Text.Length < 1)
                                {
                                    CategoryValue_CreateProductUC.SelectedIndex = 0;
                                }
                            }
                            else
                            {
                                MessageBox.Show("The Barcode Value is used before and it has to be unique , we will Generate the barcode Value for you.");
                                GenerateBarCode();
                                confirm = false;
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
                        IncomeValue_CreateproductUC.Text = "";
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
                SalePriceValue_CreateproductUC.Text = "";

                confirm = false;
            }


            // Add the product to the database
            // add the stocks to the databbase 
            // reset the window
            if (confirm)
            {
                ProductModel product = new ProductModel();
                product.Name = ProductNameValue_CreateProductUC.Text;
                product.BarCode = ProductBarCodeValue_CreateProductUC.Text;
                product.SerialNumber = SerialNumberValue_CreateProductUC.Text;
                product.SerialNumber2 = SerialNumber2Value_CreateProductUC.Text;
                product.IncomePrice = decimal.Parse(IncomeValue_CreateproductUC.Text);
                product.SalePrice = decimal.Parse(SalePriceValue_CreateproductUC.Text);
                product.Details = DetailsValue_CreateProductUC.Text;
                product.Brand = (BrandModel)BrandValue_CreateProductUC.SelectedItem;
                product.Category = (CategoryModel)CategoryValue_CreateProductUC.SelectedItem;
                // save the product to the database
                product = GlobalConfig.Connection.AddProductToTheDatabase(product);

                // Update the products list in the public variables
                PublicVariables.Products.Add(product);


                foreach (StockModel stock in NewStocks)
                {
                    stock.Product = product;
                    // save the stock to the database
                    stock.Id = GlobalConfig.Connection.AddStockToTheDatabase(stock).Id;

                    // update the LoginStoreStocks in the public variables
                    if (stock.Store.Id == PublicVariables.Store.Id)
                    {
                        PublicVariables.LoginStoreStocks.Add(stock);
                    }

                }

                SetInitialValues();

            }


        }


        /// <summary>
        /// Create new category and Update the initial values from the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateNewCategoryButton_CreateProductUC_Click(object sender, RoutedEventArgs e)
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
        /// Create new Brand and Update the initial values from the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateNewBrandButton_CreateProductUC_Click(object sender, RoutedEventArgs e)
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


        #endregion

        #region Store Info group box Events

        /// <summary>
        /// Check if every thing correct in stock info groupe box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfirmStoreButton_CreateProductUC_Click(object sender, RoutedEventArgs e)
        {
            if( StoreNameValue_CreateProductUC.Text.Length > 0)
            {
                int quantity;
                if(int.TryParse(QuantityInThisStoreValue_CreateProductUC.Text,out quantity))
                {
                    if(quantity >= 0)
                    {
                        StockModel stock = new StockModel();
                        stock.Quantity = quantity;
                        stock.Store = (StoreModel)StoreNameValue_CreateProductUC.SelectedItem;
                        Stores.Remove((StoreModel)StoreNameValue_CreateProductUC.SelectedItem);
                        StoreNameValue_CreateProductUC.ItemsSource = null;
                        StoreNameValue_CreateProductUC.ItemsSource = Stores;
                        QuantityInThisStoreValue_CreateProductUC.Text = "";
                        NewStocks.Add(stock);
                    }
                    else
                    {
                        MessageBox.Show("Quantity Can't be Less than 0");
                    }
                }
                else
                {
                    MessageBox.Show("Enter the Quantity Again ,  make sure there is no Characters in it {just A number}");
                    QuantityInThisStoreValue_CreateProductUC.Text = "";


                }
            }
            else
            {
                MessageBox.Show("Choose Store name");
            }
            
        }



        /// <summary>
        /// Clear the window by set the initial values again
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CleareButton_CreateProductUC_Click(object sender, RoutedEventArgs e)
        {
            SetInitialValues();
        }

        /// <summary>
        /// Close the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_CreateProdcutUC_Click(object sender, RoutedEventArgs e)
        {
            var parent = this.Parent as Window;
            if (parent != null) { parent.DialogResult = true; parent.Close(); }
        }

        private void GenetateNewBarCodeButton_CreateProductUC_Click(object sender, RoutedEventArgs e)
        {
            GenerateBarCode();
        }

        private void GenerateBarCode()
        {
            if (ProductNameValue_CreateProductUC.Text.Length > 0)
            {
                if (BrandValue_CreateProductUC.Text.Length < 1)
                {
                    BrandValue_CreateProductUC.SelectedIndex = 0;

                }
                if (CategoryValue_CreateProductUC.Text.Length < 1)
                {
                    CategoryValue_CreateProductUC.SelectedIndex = 0;
                }

                ProductModel product = new ProductModel();
                product.Name = ProductNameValue_CreateProductUC.Text;
                product.Category =(CategoryModel)CategoryValue_CreateProductUC.SelectedItem;
                product.Brand = (BrandModel)BrandValue_CreateProductUC.SelectedItem;

                ProductBarCodeValue_CreateProductUC.Text = GlobalConfig.Connection.CreateBarCode(product,Products);
            }
            else
            {
                MessageBox.Show("Choose Product Name first !!");
            }


            
        }

        #endregion


    }
}
