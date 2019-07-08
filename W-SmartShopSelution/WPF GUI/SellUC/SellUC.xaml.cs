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


namespace WPF_GUI.Sell
{
    /// <summary>
    /// Interaction logic for SellUC.xaml
    /// </summary>
    public partial class SellUC : UserControl
    {

        public List<CategoryModel> Categories { get; set; }
        public List<BrandModel> Brands { get; set; }
        public List<ProductModel> Products { get; set; }

        /// <summary>
        /// List Of Products after Filtring
        /// </summary>
        public List<ProductModel> FProducts { get; set; }

        /// <summary>
        /// Manage If we can Filter Products or not 
        /// Use when user done choose the product
        /// </summary>
        bool CanFilterProducts = true;

        public SellUC()
        {
            InitializeComponent();
            UpdateLists();
        }

        /// <summary>
        /// Get All the categories from the Database
        /// </summary>
        private void GetCategoriesFromDatabase()
        {
            Categories = GlobalConfig.Connection.GetCategories();
        }

        /// <summary>
        /// Get All brands from the database
        /// </summary>
        private void GetBrandsFromDatabase()
        {
            Brands = GlobalConfig.Connection.GetBrands();
        }

        /// <summary>
        /// Get All Products from the database
        /// </summary>
        private void GetProductsFromDatabase()
        {
            Products = GlobalConfig.Connection.GetProducts();
        }

        /// <summary>
        /// Update All the lists in the UC , 
        /// initialize the uc OR to clear the uc OR Update everything from the database
        /// </summary>
        private void UpdateLists()
        {
            Update_CategoryValue_Sell();
            Update_BrandValue_Sell();
            Update_ProductValue_Sell();
        }



        /// <summary>
        /// Update CategoryValue_Sell combobox from the database
        /// </summary>
        private void Update_CategoryValue_Sell()
        {
            GetCategoriesFromDatabase();
            CategoryValue_Sell.ItemsSource = Categories;
            CategoryValue_Sell.DisplayMemberPath = "Name";
            CategoryValue_Sell.SelectedItem = null;

        }

        /// <summary>
        /// update BrandValue_Sell combobox from the database
        /// </summary>
        private void Update_BrandValue_Sell()
        {
            GetBrandsFromDatabase();
            BrandValue_Sell.ItemsSource = Brands;
            BrandValue_Sell.DisplayMemberPath = "Name";
            BrandValue_Sell.SelectedItem = null;
        }

        /// <summary>
        /// update ProductValue_Sell combobox from the database
        /// </summary>
        private void Update_ProductValue_Sell()
        {
            GetProductsFromDatabase();
            ProductValue_Sell.ItemsSource = Products;
            ProductValue_Sell.DisplayMemberPath = "Name";
            ProductValue_Sell.SelectedItem = null;
        }


        /// <summary>
        /// Private event called when CategoryValue_Sell combobox OR BrandValue_Sell combobox sellection  changed to filter the products combobox by selected category or brand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FilterProductsByCategoryAndBrand(object sender, SelectionChangedEventArgs e)
        {
            if (CanFilterProducts)
            {
                FProducts = GlobalConfig.Connection.GetProductsByCategoryAndBrand(Products, (CategoryModel)CategoryValue_Sell.SelectedItem, (BrandModel)BrandValue_Sell.SelectedItem);
                ProductValue_Sell.ItemsSource = null;
                ProductValue_Sell.ItemsSource = FProducts;
                ProductValue_Sell.DisplayMemberPath = "Name";
                ProductValue_Sell.SelectedItem = null;
            }
        }

        /// <summary>
        /// Fill the Product info on the entire UC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProductValue_Sell_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProductModel product = (ProductModel)ProductValue_Sell.SelectedItem;
            if (product == null)
            {
                ClearProductInfo();
            }
            else
            {
                UpdateProductInfo(product);
            }

        }

        /// <summary>
        /// get the index of brand if it in the BrandValue_Sell
        /// </summary>
        /// <param name="brand"></param>
        /// <returns> index of this brand </returns>
        private int Get_BrandValue_Sell_Index(BrandModel brand)
        {
            int i = 0;
            var lst = BrandValue_Sell.Items.Cast<BrandModel>();
            foreach (var s in lst)
            {
                if (s.Id == brand.Id)
                    return i;

                i++;
            }
            return 0;
        }

        /// <summary>
        /// get the index of categry if it in the CategoryValue_Sell
        /// </summary>
        /// <param name="category"></param>
        /// <returns> index of this category </returns>
        private int Get_CategoryValue_Sell_Index(CategoryModel category)
        {
            int i = 0;
            var lst = CategoryValue_Sell.Items.Cast<CategoryModel>();
            foreach (var s in lst)
            {
                if (s.Id == category.Id)
                    return i;

                i++;
            }
            return 0;
        }

        /// <summary>
        /// Update product info
        /// Category , Brand ,  Serial Number , Sale Price
        /// </summary>
        /// <param name="product"></param>
        private void UpdateProductInfo(ProductModel product)
        {
            SerialNumberValue_Sell.Text = product.SerialNumber;
            PriceValue_Sell.Text = product.SalePrice.ToString();
            DiscountValue_Sell.Text = "0";
            QuantityValue_Sell.Text = "1";
            CanFilterProducts = false;
            CategoryValue_Sell.SelectedIndex = Get_CategoryValue_Sell_Index(product.Category);
            BrandValue_Sell.SelectedIndex = Get_BrandValue_Sell_Index(product.Brand);
            CanFilterProducts = true;
        }

        /// <summary>
        /// Clear product info
        /// Serial Number , Sale Price
        /// </summary>
        private void ClearProductInfo()
        {
            SerialNumberValue_Sell.Text = "";
            PriceValue_Sell.Text = "";
            DiscountValue_Sell.Text = "";
            QuantityValue_Sell.Text = "";
        }

        /// <summary>
        /// Calculate Product money 
        /// 
        /// </summary>
        private void CalculatingProductMoney(ProductModel product,int quantity,decimal salePrice,decimal discount)
        {

        }
    }
}
