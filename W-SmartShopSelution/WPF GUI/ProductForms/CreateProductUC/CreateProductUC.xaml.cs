using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using FluentValidation;
using Library;
using FluentValidation.Results;
using WPF_GUI.CreateBrand;
using WPF_GUI.CreateCategory;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace WPF_GUI.CreateProduct
{
    /// <summary>
    /// Interaction logic for CreateProductUC.xaml
    /// </summary>
    public partial class CreateProductUC : UserControl
    {
        #region Main Veriable

        /// <summary>
        /// Used only when create more than product at the same time -> eachone has different barcode
        /// </summary>
        private List<ProductModel> NewProducts = new List<ProductModel>();

        #endregion

        #region Initial And Update Tha main Values 

        public CreateProductUC()
        {
            InitializeComponent();

            SetInitialValues();

        }


        /// <summary>
        /// Set the initial values 
        /// </summary>
        private void SetInitialValues()
        {
            CategoryValue.ItemsSource = null;
            CategoryValue.ItemsSource = PublicVariables.Categories;
            CategoryValue.DisplayMemberPath = "Name";

            BrandValue.ItemsSource = null;
            BrandValue.ItemsSource = PublicVariables.Brands;
            BrandValue.DisplayMemberPath = "Name";

            ProductNameValue.Text = "";
            QuantityTypeValue.Text = "";
            SizeValue.Text = "";
            ProductBarCodeValue.Text = "";
            SerialNumberValue.Text = "";
            SerialNumber2Value.Text = "";
            ExpirationPerid.Value =new TimeSpan(0,0,0,0);
            QuantityAlarmValue.Value = null;
            SalePriceValue.Value = 0;
            IncomePriceValue.Value = 0;
            DetailsValue.Text = "";

            NewProducts = new List<ProductModel>();
            AllPeacesTheSameRadioButton_CreateProductUC.IsChecked = true;
            SameBarCodeGrid_CreateProductUC.Visibility = Visibility.Visible;
            DifferentBarCodeGrid_CreateProductUC.Visibility = Visibility.Collapsed;

            SameSizeCheckBox.IsChecked = false;
            SameSalePriceCheckBox.IsChecked = false;
            SameIncomePriceCheckBox.IsChecked = false;
            SameSalePriceCheckBox.IsChecked = false;
            SameSerialNumberCheckBox.IsChecked = false;
            SameSerialNumber2CheckBox.IsChecked = false;
            SameExpirationPeriodCheckBox.IsChecked = false;
            SameQuantityAlarmCheckBox.IsChecked = false;

        }


        #endregion

        #region Hole Form Events

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            SetInitialValues();
        }

      
        /// <summary>
        /// Money validation for any text accepts money
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoneyValidation(object sender, TextCompositionEventArgs e)
        {
            GlobalConfig.NumberValidation.MoneyValidationTextBox(sender, e);
        }

        /// <summary>
        /// Number Validation for the TextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberValidation(object sender, TextCompositionEventArgs e)
        {
            GlobalConfig.NumberValidation.IntegerValidationTextBox(sender, e);
        }


        /// <summary>
        /// Show And hide the 2 Grid view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButton_Clicked(object sender, RoutedEventArgs e)
        {
            if (AllPeacesTheSameRadioButton_CreateProductUC.IsChecked == true)
            {
                SameBarCodeGrid_CreateProductUC.Visibility = Visibility.Visible;
                DifferentBarCodeGrid_CreateProductUC.Visibility = Visibility.Collapsed;

                
            }
            else
            {

                SameBarCodeGrid_CreateProductUC.Visibility = Visibility.Collapsed;
                DifferentBarCodeGrid_CreateProductUC.Visibility = Visibility.Visible;
            }
        }
        private void GenetateNewBarCodeButton_CreateProductUC_Click(object sender, RoutedEventArgs e)
        {
            GenerateBarCode();
        }

        private void GenerateBarCode()
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

                ProductModel product = new ProductModel();
                product.Name = ProductNameValue.Text;
                product.Category =(CategoryModel)CategoryValue.SelectedItem;
                product.Brand = (BrandModel)BrandValue.SelectedItem;

                ProductBarCodeValue.Text = GlobalConfig.Connection.CreateBarCode(product);
            }
            else
            {
                MessageBox.Show("Choose Product Name first !!");
            }
        }

        private void ConfitmButton_Click(object sender, RoutedEventArgs e)
        {
            if (AllPeacesTheSameRadioButton_CreateProductUC.IsChecked == true)
            {
                ProductModel product = new ProductModel();
                product.Name = ProductNameValue.Text;
                product.QuantityType = QuantityTypeValue.Text;
                product.Size = SizeValue.Text;
                product.BarCode = ProductBarCodeValue.Text;
                product.SerialNumber = SerialNumberValue.Text;
                product.SerialNumber2 = SerialNumber2Value.Text;
                product.Details = DetailsValue.Text;
                product.SalePrice = SalePriceValue.Value.Value;
                product.IncomePrice = IncomePriceValue.Value.Value;
                product.ExpirationPeriod = ExpirationPerid.Value.Value;
                product.AlarmQuantity = (int)QuantityAlarmValue.Value;
                product.Category = (CategoryModel)CategoryValue.SelectedItem;
                product.Brand = (BrandModel)BrandValue.SelectedItem;

                GlobalConfig.ProductValidator = new ProductValidator();

                ValidationResult result = GlobalConfig.ProductValidator.Validate(product);

                if (result.IsValid == false)
                {

                    MessageBox.Show(result.Errors[0].ErrorMessage);

                }
                else
                {
                    GlobalConfig.Connection.AddProductToTheDatabase(product);
                    SetInitialValues();
                }

            }
            else
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
                    foreach(ProductModel product in NewProducts)
                    {
                        GlobalConfig.Connection.AddProductToTheDatabase(product);
                    }
                    SetInitialValues();
                }


            }
        }



        #endregion


        #region DifferentBarCodeGrid

        private void UpdateDifferentBarCodeGrid()
        {

            if (SameSizeCheckBox.IsChecked == true)
            {
                foreach(ProductModel product in NewProducts)
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
                if ((TimeSpan)SameExpirationPeridValue.Value.Value!= null)
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
                        product.BarCode = Product.CreateBarCode(product,NewProducts);
                        product.SerialNumber = "";
                        product.SerialNumber2 = "";
                        product.Details = DetailsValue.Text;
                        product.SalePrice = new decimal();
                        product.IncomePrice = new decimal();
                        product.ExpirationPeriod = new TimeSpan(0, 0, 0, 0);
                        product.AlarmQuantity = new int();
                        NewProducts.Add(product);

                    }

                    UpdateDifferentBarCodeGrid();

                }
                else
                {
                    MessageBox.Show("Enter the Product Name First");
                }
            }
        }

        private void SameSizeCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if(SameSizeCheckBox.IsEnabled == true)
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
            UpdateDifferentBarCodeGrid();
        }

        private void SameSalePriceCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if(SameSalePriceCheckBox.IsChecked == true)
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
            UpdateDifferentBarCodeGrid();
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
            UpdateDifferentBarCodeGrid();
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
            UpdateDifferentBarCodeGrid();
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
            UpdateDifferentBarCodeGrid();
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
            UpdateDifferentBarCodeGrid();
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
            UpdateDifferentBarCodeGrid();
        }

        #endregion
        #endregion


        #region Grid Switching events


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
