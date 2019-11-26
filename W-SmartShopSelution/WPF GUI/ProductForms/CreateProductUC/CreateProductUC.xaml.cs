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
                for (int i = 1; i <= NewProducts.Count; i++)
                {
                    ProductModel product = NewProducts[i - 1];
                    GlobalConfig.ProductValidator = new ProductValidator();


                    ValidationResult result = GlobalConfig.ProductValidator.Validate(product);

                    if (result.IsValid == false)
                    {

                        MessageBox.Show("number " + i + " " + result.Errors[0].ErrorMessage);

                    }
                    else
                    {
                        /* if (GlobalConfig.Connection.CheckIfTheProductBarCodeUnique(Products, product.BarCode))
                         {
                             // Save the Product to the database

                             product = GlobalConfig.Connection.AddProductToTheDatabase(product);
                             PublicVariables.RecentlyAddProducts.Add(product);
                         }
                         else
                         {
                             MessageBox.Show("The Barcode Value is used before and it has to be unique , we will Generate the barcode Value for you.");



                             List<ProductModel> products = new List<ProductModel>();
                             foreach (ProductModel productModel in Products)
                             {
                                 products.Add(productModel);

                             }
                             foreach (ProductModel productModel in NewProducts)
                             {
                                 products.Add(productModel);

                             }

                             product.BarCode = GlobalConfig.Connection.CreateBarCode(product, products);
                             products.Add(product);

                             NewProductsList_CreateProductUC.ItemsSource = null;
                             NewProductsList_CreateProductUC.ItemsSource = NewProducts;


                         }*/


                    }
                }

                SetInitialValues();

            }
        }



        #endregion



        #region DifferentBarCodeGrid Events

        /// <summary>
        /// After press enter While select the quantity textBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuantityValue_CreateproductUC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                int quantity;
                if(int.TryParse(QuantityValue_CreateproductUC.Text, out quantity))
                {

                    if(quantity > 0)
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

                            for(int i = 1; i <= quantity; i++)
                            {
                                ProductModel product = new ProductModel();
                                product.Name = ProductNameValue.Text;
                                product.Category = (CategoryModel)CategoryValue.SelectedItem;
                                product.Brand = (BrandModel)BrandValue.SelectedItem;
                                product.QuantityType = QuantityTypeValue.Text;
                                product.Size = "";
                                product.BarCode = GlobalConfig.Connection.CreateBarCode(product);
                                product.SerialNumber = "";
                                product.SerialNumber2 = "";
                                product.Details = DetailsValue.Text;
                                product.SalePrice = new decimal();
                                product.IncomePrice = new decimal();
                                product.ExpirationPeriod = new TimeSpan(0, 0, 0, 0);
                                product.AlarmQuantity = new int();
                                NewProducts.Add(product);

                            }

                            NewProductsList.ItemsSource = null;
                            NewProductsList.ItemsSource = NewProducts;

                        }
                        else
                        {
                            MessageBox.Show("Enter the Product Name First");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Quantity should be 1 or more");
                    }
                }
                else
                {
                    MessageBox.Show("Quantity should be a number !");
                }


               
            }

         

        }


        private void SameSalePriceCheckBox_CreateProductUC_Click(object sender, RoutedEventArgs e)
        {
            if(SameSalePriceCheckBox_CreateProductUC.IsChecked == true)
            {
                SameSalePriceValue.IsEnabled = true;

            }
            else
            {
                SameSalePriceValue.IsEnabled = false;
            }
            
        }

        private void SameIncomePriceCheckBox_CreateProductUC_Click(object sender, RoutedEventArgs e)
        {

            if (SameIncomePriceCheckBox_CreateProductUC.IsChecked == true)
            {
                SameIncomePriceValue.IsEnabled = true;

            }
            else
            {
                SameIncomePriceValue.IsEnabled = false;
            }
        }

        private void SameSerialNumberCheckBox_CreateProductUC_Click(object sender, RoutedEventArgs e)
        {
            if (SameSerialNumberCheckBox_CreateProductUC.IsChecked == true)
            {
                SameSerialNumberValue_CreateproductUC.IsEnabled = true;

            }
            else
            {
                SameSerialNumberValue_CreateproductUC.IsEnabled = false;
            }
        }
        private void SameSerialNumber2CheckBox_CreateProductUC_Click(object sender, RoutedEventArgs e)
        {
            if (SameSerialNumber2CheckBox_CreateProductUC.IsChecked == true)
            {
                SameSerialNumber2Value_CreateproductUC.IsEnabled = true;

            }
            else
            {
                SameSerialNumber2Value_CreateproductUC.IsEnabled = false;
            }
        }

        private void SameSalePriceValue_CreateproductUC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
               /* if (decimal.TryParse(SameSalePriceValue_CreateproductUC.Text, out decimal salePrice))
                {
                    foreach (ProductModel product in NewProducts)
                    {
                        product.SalePrice = salePrice;
                    }
                    NewProductsList_CreateProductUC.ItemsSource = null;
                    NewProductsList_CreateProductUC.ItemsSource = NewProducts;
                }
                else
                {
                    foreach (ProductModel product in NewProducts)
                    {
                        product.SalePrice = 0;
                    }
                    NewProductsList_CreateProductUC.ItemsSource = null;
                    NewProductsList_CreateProductUC.ItemsSource = NewProducts;
                }*/

            }

        }

        private void SameIncomePriceValue_CreateproductUC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
               /* if (decimal.TryParse(SameIncomePriceValue_CreateproductUC.Text, out decimal incomePrice))
                {
                    foreach (ProductModel product in NewProducts)
                    {
                        product.IncomePrice = incomePrice;
                    }
                    NewProductsList_CreateProductUC.ItemsSource = null;
                    NewProductsList_CreateProductUC.ItemsSource = NewProducts;
                }
                else
                {
                    foreach (ProductModel product in NewProducts)
                    {
                        product.IncomePrice = 0;
                    }
                    NewProductsList_CreateProductUC.ItemsSource = null;
                    NewProductsList_CreateProductUC.ItemsSource = NewProducts;
                }*/

            }

        }

        private void SameSerialNumberValue_CreateproductUC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
               /* if (SameSerialNumberValue_CreateproductUC.Text.Length > 0)
                {
                    foreach (ProductModel product in NewProducts)
                    {
                        product.SerialNumber = SameSerialNumberValue_CreateproductUC.Text;
                    }
                    NewProductsList_CreateProductUC.ItemsSource = null;
                    NewProductsList_CreateProductUC.ItemsSource = NewProducts;
                }
                else
                {
                    foreach (ProductModel product in NewProducts)
                    {
                        product.SerialNumber = "";
                    }
                    NewProductsList_CreateProductUC.ItemsSource = null;
                    NewProductsList_CreateProductUC.ItemsSource = NewProducts;
                }*/

            }
        }

        private void SameSerialNumber2Value_CreateproductUC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                /*if (SameSerialNumber2Value_CreateproductUC.Text.Length > 0)
                {
                    foreach (ProductModel product in NewProducts)
                    {
                        product.SerialNumber2 = SameSerialNumber2Value_CreateproductUC.Text;
                    }
                    NewProductsList_CreateProductUC.ItemsSource = null;
                    NewProductsList_CreateProductUC.ItemsSource = NewProducts;
                }
                else
                {
                    foreach (ProductModel product in NewProducts)
                    {
                        product.SerialNumber2 = "";
                    }
                    NewProductsList_CreateProductUC.ItemsSource = null;
                    NewProductsList_CreateProductUC.ItemsSource = NewProducts;

                }*/

            }
        }






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
