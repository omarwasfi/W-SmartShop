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
using ValidationResult = FluentValidation.Results.ValidationResult;


namespace WPF_GUI.ModifyProduct
{
    /// <summary>
    /// Interaction logic for ModifyProduct.xaml
    /// </summary>
    public partial class ModifyProductUC : UserControl
    {

        #region Main Veriable

        /// <summary>
        /// The product that we need to edit or make a similar one of it
        /// </summary>
        ProductModel OrignalProduct { get; set; }

        /// <summary>
        /// List of the new products
        /// </summary>
         List<ProductModel> NewProducts { get; set; }

        #endregion


        #region Initial And Update Tha main Values 
        /// <summary>
        /// the constractor of ModifyProductUC ,  needs a product model
        /// </summary>
        /// <param name="product"> the product that needs to be modified </param>
        public ModifyProductUC( ProductModel product )
        {

            InitializeComponent();

            OrignalProduct = product;

            SetInitialValues();

        }


        private void SetInitialValues()
        {

            CategoryValue.ItemsSource = null;
            CategoryValue.ItemsSource = PublicVariables.Categories;
            CategoryValue.DisplayMemberPath = "Name";

            BrandValue.ItemsSource = null;
            BrandValue.ItemsSource = PublicVariables.Brands;
            BrandValue.DisplayMemberPath = "Name";

            CategoryValue.SelectedItem = OrignalProduct.Category;
            BrandValue.SelectedItem = OrignalProduct.Brand;
            ProductNameValue.Text = OrignalProduct.Name;
            QuantityTypeValue.Text = OrignalProduct.QuantityType;
            SizeValue.Text = OrignalProduct.Size;
            ProductBarCodeValue.Text = OrignalProduct.BarCode;
            SerialNumberValue.Text = OrignalProduct.SerialNumber;
            SerialNumber2Value.Text = OrignalProduct.SerialNumber2;
            ExpirationPerid.Value = OrignalProduct.ExpirationPeriod;
            QuantityAlarmValue.Value = OrignalProduct.AlarmQuantity;
            SalePriceValue.Value = OrignalProduct.SalePrice;
            IncomePriceValue.Value = OrignalProduct.IncomePrice;
            DetailsValue.Text = OrignalProduct.Details;

            NewProducts = new List<ProductModel>();
            QuantityValue.Value = 0;
            NewProductsList.ItemsSource = null;
            NewProductsList.ItemsSource = NewProducts;

            SameSizeCheckBox.IsChecked = false;
            SameSalePriceCheckBox.IsChecked = false;
            SameIncomePriceCheckBox.IsChecked = false;
            SameSalePriceCheckBox.IsChecked = false;
            SameSerialNumberCheckBox.IsChecked = false;
            SameSerialNumber2CheckBox.IsChecked = false;
            SameExpirationPeriodCheckBox.IsChecked = false;
            SameQuantityAlarmCheckBox.IsChecked = false;
        }

        #region Events

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            SetInitialValues();
        }

        private void ConfitmButton_Click(object sender, RoutedEventArgs e)
        {
            OrignalProduct.Name = ProductNameValue.Text;
            OrignalProduct.QuantityType = QuantityTypeValue.Text;
            OrignalProduct.Size = SizeValue.Text;
            OrignalProduct.Details = DetailsValue.Text;
            OrignalProduct.SalePrice = SalePriceValue.Value.Value;
            OrignalProduct.IncomePrice = IncomePriceValue.Value.Value;
            OrignalProduct.ExpirationPeriod = ExpirationPerid.Value.Value;
            OrignalProduct.AlarmQuantity = (int)QuantityAlarmValue.Value;
            
            CategoryModel category = (CategoryModel)CategoryValue.SelectedItem;
            if(category != null)
            {
                OrignalProduct.Category = category;
            }
        
            BrandModel brand = (BrandModel)BrandValue.SelectedItem;
            if (brand != null)
            {
                OrignalProduct.Brand = brand;
            }

            // Update the product
            GlobalConfig.Connection.UpdateProductDataWithTheDatabase(OrignalProduct);

            if (NewProducts.Count > 0)
            {
                bool confirm = true;
                for (int i = 1; i <= NewProducts.Count; i++)
                {
                    ProductModel product = NewProducts[i - 1];
                    GlobalConfig.ProductValidator = new ProductValidator();


                    ValidationResult result = GlobalConfig.ProductValidator.Validate(product);

                    if (result.IsValid == false)
                    {

                        MessageBox.Show("number " + i + " " + result.Errors[0].ErrorMessage);
                        confirm = false;
                    }
                    else
                    {

                    }
                }
                if (confirm)
                {
                    foreach (ProductModel product in NewProducts)
                    {
                        GlobalConfig.Connection.AddProductToTheDatabase(product);
                    }
                }
            }

            
            SetInitialValues();
        }

        #endregion

        #endregion


        #region DifferentBarCodeGrid

        private void UpdateNewSimilarProductsGB()
        {

            if (SameSizeCheckBox.IsChecked == true)
            {
                foreach (ProductModel product in NewProducts)
                {
                    product.Size = SameSizeValue.Text;
                }
            }
            if (SameSalePriceCheckBox.IsChecked == true)
            {
                foreach (ProductModel product in NewProducts)
                {
                    product.SalePrice = (decimal)SameSalePriceValue.Value.Value;
                }

            }
            if (SameIncomePriceCheckBox.IsChecked == true)
            {
                foreach (ProductModel product in NewProducts)
                {
                    product.IncomePrice = (decimal)SameIncomePriceValue.Value.Value;
                }

            }
            if (SameSerialNumberCheckBox.IsChecked == true)
            {
                foreach (ProductModel product in NewProducts)
                {
                    product.SerialNumber = SameSerialNumberValue.Text;
                }

            }
            if (SameSerialNumber2CheckBox.IsChecked == true)
            {
                foreach (ProductModel product in NewProducts)
                {
                    product.SerialNumber2 = SameSerialNumber2Value.Text;
                }

            }
            if (SameExpirationPeriodCheckBox.IsChecked == true)
            {
                if ((TimeSpan)SameExpirationPeridValue.Value.Value != null)
                {
                    foreach (ProductModel product in NewProducts)
                    {
                        product.ExpirationPeriod = (TimeSpan)SameExpirationPeridValue.Value.Value;
                    }
                }


            }
            if (SameQuantityAlarmCheckBox.IsChecked == true)
            {
                foreach (ProductModel product in NewProducts)
                {
                    product.AlarmQuantity = (int)SameQuantityAlarmValue.Value.Value;
                }
            }


            NewProductsList.ItemsSource = null;
            NewProductsList.ItemsSource = NewProducts;
        }

        #region DifferentBarCodeGrid Events

        private void QuantityValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (QuantityValue.Value.Value > 0)
            {
                if (ProductNameValue.Text.Length > 0)
                {
                    if (BrandValue.Text.Length < 1)
                    {
                        BrandValue.SelectedIndex = 0;

                    }
                    if (CategoryValue.Text.Length < 1)
                    {
                        CategoryValue.SelectedIndex = 0;
                    }

                    NewProducts = new List<ProductModel>();

                    for (int i = 1; i <= QuantityValue.Value.Value; i++)
                    {
                        ProductModel product = new ProductModel();
                        product.Name = ProductNameValue.Text;
                        product.Category = (CategoryModel)CategoryValue.SelectedItem;
                        product.Brand = (BrandModel)BrandValue.SelectedItem;
                        product.QuantityType = QuantityTypeValue.Text;
                        product.Size = "";
                        product.BarCode = Product.CreateBarCode(product, NewProducts);
                        product.SerialNumber = "";
                        product.SerialNumber2 = "";
                        product.Details = DetailsValue.Text;
                        product.SalePrice = new decimal();
                        product.IncomePrice = new decimal();
                        product.ExpirationPeriod = new TimeSpan(0, 0, 0, 0);
                        product.AlarmQuantity = new int();
                        NewProducts.Add(product);

                    }

                    UpdateNewSimilarProductsGB();

                }
                else
                {
                    MessageBox.Show("Enter the Product Name First");
                }
            }
        }

        private void SameSizeCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (SameSizeCheckBox.IsEnabled == true)
            {
                SameSizeValue.IsEnabled = true;
            }
            else
            {
                SameSizeValue.IsEnabled = false;
            }
        }
        private void SameSizeValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateNewSimilarProductsGB();
        }

        private void SameSalePriceCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (SameSalePriceCheckBox.IsChecked == true)
            {
                SameSalePriceValue.IsEnabled = true;

            }
            else
            {
                SameSalePriceValue.IsEnabled = false;
            }

        }
        private void SameSalePriceValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateNewSimilarProductsGB();
        }

        private void SameIncomePriceCheckBox_Click(object sender, RoutedEventArgs e)
        {

            if (SameIncomePriceCheckBox.IsChecked == true)
            {
                SameIncomePriceValue.IsEnabled = true;

            }
            else
            {
                SameIncomePriceValue.IsEnabled = false;
            }
        }
        private void SameIncomePriceValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateNewSimilarProductsGB();
        }

        private void SameSerialNumberCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (SameSerialNumberCheckBox.IsChecked == true)
            {
                SameSerialNumberValue.IsEnabled = true;

            }
            else
            {
                SameSerialNumberValue.IsEnabled = false;
            }
        }
        private void SameSerialNumberValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateNewSimilarProductsGB();
        }

        private void SameSerialNumber2CheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (SameSerialNumber2CheckBox.IsChecked == true)
            {
                SameSerialNumber2Value.IsEnabled = true;

            }
            else
            {
                SameSerialNumber2Value.IsEnabled = false;
            }
        }
        private void SameSerialNumber2Value_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateNewSimilarProductsGB();
        }

        private void SameExpirationPeriodCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (SameExpirationPeriodCheckBox.IsChecked == true)
            {
                SameExpirationPeridValue.IsEnabled = true;

            }
            else
            {
                SameExpirationPeridValue.IsEnabled = false;
            }
        }
        private void SameExpirationPeridValue_ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UpdateNewSimilarProductsGB();
        }

        private void SameQuantityChdeckBox_Click(object sender, RoutedEventArgs e)
        {
            if (SameQuantityAlarmCheckBox.IsChecked == true)
            {
                SameQuantityAlarmValue.IsEnabled = true;

            }
            else
            {
                SameQuantityAlarmValue.IsEnabled = false;
            }
        }
        private void SameQuantityAlarmValue_ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UpdateNewSimilarProductsGB();
        }





        #endregion

        #endregion

        #region Grid Switching

        private void CreateNewCategoryButton_CreateProductUC_Click(object sender, RoutedEventArgs e)
        {

            CreateNewCategoryGrid.Visibility = Visibility.Visible;
            UserGrid.Visibility = Visibility.Collapsed;

        }

        private void BackToUserGridButton_FromCreateNewCategoryGrid_Click(object sender, RoutedEventArgs e)
        {
            CreateNewCategoryGrid.Visibility = Visibility.Collapsed;
            UserGrid.Visibility = Visibility.Visible;
            CategoryValue.ItemsSource = null;
            CategoryValue.ItemsSource = PublicVariables.Categories;
        }

        private void CreateNewBrandButton_CreateProductUC_Click(object sender, RoutedEventArgs e)
        {
            CreateNewBrandGrid.Visibility = Visibility.Visible;
            UserGrid.Visibility = Visibility.Collapsed;
        }

        private void BackToUserGridButton_FromCreateNewBrandGrid_Click(object sender, RoutedEventArgs e)
        {
            CreateNewBrandGrid.Visibility = Visibility.Collapsed;
            UserGrid.Visibility = Visibility.Visible;
            BrandValue.ItemsSource = null;
            BrandValue.ItemsSource = PublicVariables.Brands;
        }


        #endregion

      
    }
}
