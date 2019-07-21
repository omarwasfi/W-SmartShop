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


namespace WPF_GUI.ProductManager
{


    /// <summary>
    /// Interaction logic for ProductManagerUC.xaml
    /// </summary>
    public partial class ProductManagerUC : UserControl
    {

        #region Main Variables

        private List<ProductModel> Products { get; set; }

        #endregion

        #region Help variables

        private List<CategoryModel> Categories { get; set; }
        private List<BrandModel> Brands { get; set; }

        private List<ProductModel> FProducts { get; set; } = new List<ProductModel>();

        private List<string> SearchTypes { get; set; } = new List<string>() { "Name", "SerialNumber"};
        #endregion

        #region set the initianl values


        public ProductManagerUC()
        {
            InitializeComponent();

            SetInitialValues();

        }

        /// <summary>
        /// Get variables from the database
        /// set each related Gui to this variables
        /// /// </summary>
        private void SetInitialValues()
        {

            // set the ProductSearchType_InventoryUC values
            ProductSearchType_ProductManagerUC.ItemsSource = null;
            ProductSearchType_ProductManagerUC.ItemsSource = SearchTypes;

            // Update the procducts from the database
            UpdateProductsFromTheDatabase();
            ProductsList_ProductManagerUC.ItemsSource = null;
            ProductsList_ProductManagerUC.ItemsSource = Products;

            
            UpdateCategoriesFromThePublicVaribles();
            CategoryValue_ProductManagerUC.ItemsSource = null;
            CategoryValue_ProductManagerUC.ItemsSource = Categories;
            CategoryValue_ProductManagerUC.DisplayMemberPath = "Name";

            UpdateBrandsFromThePublicVaribles();
            BrandValue_ProductManagerUC.ItemsSource = null;
            BrandValue_ProductManagerUC.ItemsSource = Brands;
            BrandValue_ProductManagerUC.DisplayMemberPath = "Name";
        }


        private void UpdateProductsFromTheDatabase()
        {
            Products = GlobalConfig.Connection.GetProducts();
        }

        /// <summary>
        /// Updates the categories with the categories public variables
        /// Called each time we need to update the categories
        /// </summary>
        private void UpdateCategoriesFromThePublicVaribles()
        {
            Categories = PublicVariables.Categories;
        }

        /// <summary>
        /// Updates the brands with the Brands public variables
        /// Called each time we need to update the brands
        /// </summary>
        private void UpdateBrandsFromThePublicVaribles()
        {
            Brands = PublicVariables.Brands;
        }
        #endregion


        #region CategoryCB and Brand CB events 

        /// <summary>
        /// Private event called when CategoryValue_InventoryUC combobox OR BrandValue_InventoryUC combobox sellection  changed to filter the StocksList_Inventory gridView by selected category or brand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FilterProductsByCategoryAndBrand(object sender, SelectionChangedEventArgs e)
        {

            FProducts = GlobalConfig.Connection.GetProductsByCategoryAndBrand(Products, (CategoryModel)CategoryValue_ProductManagerUC.SelectedItem, (BrandModel)BrandValue_ProductManagerUC.SelectedItem);

            ProductsList_ProductManagerUC.ItemsSource = null;
            ProductsList_ProductManagerUC.ItemsSource = FProducts;


        }
        #endregion

        #region Hole Form Events

        /// <summary>
        /// reset the default value from the hole form from the public variables
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetProductsResultsButton_ProductManagerUC_Click(object sender, RoutedEventArgs e)
        {
            SetInitialValues();
            //SetInitialValues();
        }

        /// <summary>
        /// called when search button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProductSearchButton_ProductManagerUC_Click(object sender, RoutedEventArgs e)
        {
            if (ProductSearchType_ProductManagerUC.Text == "SerialNumber")
            {
                FProducts = GlobalConfig.Connection.FilterProductsBySerialNumber(Products, ProductSearchValue_ProductManagerUC.Text);
                ProductsList_ProductManagerUC.ItemsSource = null;
                ProductsList_ProductManagerUC.ItemsSource = FProducts;
            }
            else if (ProductSearchType_ProductManagerUC.Text == "Name")
            {
                FProducts = GlobalConfig.Connection.FilterProductsByName(Products , ProductSearchValue_ProductManagerUC.Text);

                ProductsList_ProductManagerUC.ItemsSource = null;
                ProductsList_ProductManagerUC.ItemsSource = FProducts;
            }
            else
            {
                MessageBox.Show("CHoose the search type first");
            }
        }
        #endregion

    }
}
