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

            FProducts = GlobalConfig.Connection.GetProductsByCategoryAndBrand(Products, (CategoryModel)CategoryValue_Sell.SelectedItem, (BrandModel)BrandValue_Sell.SelectedItem);
            ProductValue_Sell.ItemsSource = null;
            ProductValue_Sell.ItemsSource = FProducts;
            ProductValue_Sell.DisplayMemberPath = "Name";
            ProductValue_Sell.SelectedItem = null;
        }
    }
}
