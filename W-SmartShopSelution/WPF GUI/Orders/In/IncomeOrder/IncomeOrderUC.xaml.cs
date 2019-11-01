using System;
using System.Collections.Generic;
using System.Globalization;
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
using WPF_GUI.CreateProduct;

namespace WPF_GUI
{
    /// <summary>
    /// Interaction logic for IncomeOrderUC.xaml
    /// 
    /// Get the products 
    /// add it to the grid as a stock
    /// check if this stock exist :  if exist -> Increase the number of it 
    ///                              if not -> Create a new stock
    ///
    /// 
    /// </summary>
    public partial class IncomeOrderUC : UserControl
    {


        #region Main Variables

        /// <summary>
        /// The Logedin store 
        /// </summary>
        private StoreModel Store { get; set; }

        /// <summary>
        /// All The products in the database
        /// </summary>
        private List<ProductModel> Products { get; set; }

        /// <summary>
        /// The logedin staff member
        /// </summary>
        private StaffModel Staff { get; set; }

        /// <summary>
        /// The Supplier 
        /// </summary>
        private SupplierModel Supplier { get; set; }

        

        /// <summary>
        /// The new income order model
        /// </summary>
        private IncomeOrderModel IncomeOrder { get; set; } = new IncomeOrderModel();

        /// <summary>
        /// The new list of IncomeOrderProduct That Will be seted to the IncomeOrder
        /// </summary>
        private List<IncomeOrderProductModel> IncomeOrderProducts { get; set; } = new List<IncomeOrderProductModel>();

        /// <summary>
        /// Created to save the shipping expenss if it's not 0
        /// </summary>
        ShopBillModel ShopBill { get; set; } = new ShopBillModel();
        

        #endregion

        #region Help Variables

        /// <summary>
        /// All Categories in the database
        /// </summary>
        private List<CategoryModel> Categories { get; set; }

        /// <summary>
        /// All brands in the database
        /// </summary>
        private List<BrandModel> Brands { get; set; }

        /// <summary>
        /// The Selected product
        /// </summary>
        private ProductModel Product { get; set; }

        /// <summary>
        /// Filtered Products after the category Or Brands get changed
        /// </summary>
        private List<ProductModel> FProducts { get; set; } = new List<ProductModel>();

        /// <summary>
        /// the loged in store stocks
        /// </summary>
        private List<StockModel> LogedInStoreStocks { get; set; }

        /// <summary>
        /// All suppliers in the database
        /// </summary>
        private List<SupplierModel> Suppliers { get; set; }
        private List<string> SuppliersFullNames { get; set; } = new List<string>();
        private List<string> SuppliersPhoneNumbers { get; set; } = new List<string>();
        private List<string> SuppliersNationalNumbers { get; set; } = new List<string>();

        private bool CanFilterProducts { get; set; } = new bool();

        #endregion

        #region set the initianl values


        public IncomeOrderUC()
        {
            InitializeComponent();


            SetInitialValues();

        }

        private void SetInitialValues()
        {

            UpdateTheProductsFromThePublicVariables();
            ProductValue_IncomeOrderUC.ItemsSource = null;
            ProductValue_IncomeOrderUC.ItemsSource = Products;
            ProductValue_IncomeOrderUC.DisplayMemberPath = "Name";

            UpdateTheStaffFromThePublicVariables();

            UpdateLogedInStoreStocks();

            CanFilterProducts = true;
            ClearProductInfo();


            Update_SuppliersVariablesAndEvents();
            InProg_SupplierNameValue_IncomeOrderUC = false;
            InProg_PhoneNumberValue_IncomeOrderUC = false;
            InProg_NationalNumberValue_IncomeOrderUC = false;


            UpdateTheStoreFromThePublicVariables();

            UpdateTheCategoriesFromThePublicVariables();
            CategoryValue_IncomeOrderUC.ItemsSource = null;
            CategoryValue_IncomeOrderUC.ItemsSource = Categories;
            CategoryValue_IncomeOrderUC.DisplayMemberPath = "Name";

            UpdateTheBrandsFromThePublicVariables();
            BrandValue_IncomeOrderUC.ItemsSource = null;
            BrandValue_IncomeOrderUC.ItemsSource = Brands;
            BrandValue_IncomeOrderUC.DisplayMemberPath = "Name";

            RecentlyAddedGB_IncomeOrderUC.Visibility = Visibility.Collapsed;
            ChooseSupplierGB_IncomeOrderUC.Visibility = Visibility.Visible;

            if(PublicVariables.RecentlyAddProducts.Count > 0)
            {
                RecentlyAddedProductsList_IncomeOrderUC.ItemsSource = PublicVariables.RecentlyAddProducts;
            }

            DateValue_IncomeOrderUC.SelectedDate = DateTime.Now;

            

        }


        /// <summary>
        /// Update And get the products From the publicVariables
        /// </summary>
        private void UpdateTheProductsFromThePublicVariables()
        {
            PublicVariables.Products = null;
            PublicVariables.Products = GlobalConfig.Connection.GetProducts();
            Products = null;
            Products = PublicVariables.Products;
            //Products.RemoveAt(0);

        }

        /// <summary>
        /// Update and get logedInStoreStock from the public variables
        /// </summary>
        private void UpdateLogedInStoreStocks()
        {
            PublicVariables.LoginStoreStocks = null;
            PublicVariables.LoginStoreStocks = GlobalConfig.Connection.FilterStocksByStore(PublicVariables.Store);
            LogedInStoreStocks = null;
            LogedInStoreStocks = PublicVariables.LoginStoreStocks;
        }

        /// <summary>
        /// Update and get the Suppliers from the database
        /// add suppliers full names , phonenumbers and national numbers in one list
        /// add delete pressed events
        /// </summary>
        private void  Update_SuppliersVariablesAndEvents()
        {
            UpdateTheSuppliersFromThePublicVariables();

            foreach (SupplierModel supplier in Suppliers)
            {
                SuppliersFullNames.Add(supplier.Person.FullName);

                if (supplier.Person.PhoneNumber != null)
                {
                    SuppliersPhoneNumbers.Add(supplier.Person.PhoneNumber);
                }
                if (supplier.Person.NationalNumber != null)
                {
                    SuppliersNationalNumbers.Add(supplier.Person.NationalNumber);
                }
            }

            SupplierNameValue_IncomeOrderUC.PreviewKeyDown += DelPressed_SupplierNameValue_IncomeOrderUC;
            PhoneNumberValue_IncomeOrderUC.PreviewKeyDown += DelPressed_PhoneNumberValue_IncomeOrderUC;
            NationalNumberValue_IncomeOrderUC.PreviewKeyDown += DelPressed_NationalNumberValue_IncomeOrderUC;


        }



        /// <summary>
        /// Update and get the Suppliers from the database
        /// </summary>
        private void UpdateTheSuppliersFromThePublicVariables()
        {
            PublicVariables.Suppliers = null;
            PublicVariables.Suppliers = GlobalConfig.Connection.GetSuppliers();
            Suppliers = null;
            Suppliers = PublicVariables.Suppliers;
        }


        

        /// <summary>
        /// get the logedin staff member from the database
        /// </summary>
        private void UpdateTheStaffFromThePublicVariables()
        {
            Staff = null;
            Staff = PublicVariables.Staff;
        }

        /// <summary>
        /// Get the store from the database
        /// </summary>
        private void UpdateTheStoreFromThePublicVariables()
        {
            Store = null;
            Store = PublicVariables.Store;
        }

        /// <summary>
        /// Update and get the categories from the database
        /// </summary>
        private void UpdateTheCategoriesFromThePublicVariables()
        {
            PublicVariables.Categories = null;
            PublicVariables.Categories = GlobalConfig.Connection.GetCategories();
            Categories = null;
            Categories = PublicVariables.Categories;
            //Categories.RemoveAt(0);
        }


        /// <summary>
        /// Update and get the brands from the database
        /// </summary>
        private void UpdateTheBrandsFromThePublicVariables()
        {
            PublicVariables.Brands = null;
            PublicVariables.Brands = GlobalConfig.Connection.GetBrands();
            Brands = null;
            Brands = PublicVariables.Brands;
            //Brands.RemoveAt(0);

        }





        #endregion

        #region Supplier Group Box Events

        // Supplier events & search Functions

        private bool InProg_SupplierNameValue_IncomeOrderUC;
        /// <summary>
        /// Events for SupplierValue changes to auto complete
        /// source : https://stackoverflow.com/questions/950770/autocomplete-textbox-in-wpf
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SupplierNameValue_IncomeOrderUC_TextChanged(object sender, TextChangedEventArgs e)
        {
            var change = e.Changes.FirstOrDefault();
            if (!InProg_SupplierNameValue_IncomeOrderUC)
            {
                InProg_SupplierNameValue_IncomeOrderUC = true;
                var culture = new CultureInfo(CultureInfo.CurrentCulture.Name);
                var source = ((TextBox)sender);
                if (((change.AddedLength - change.RemovedLength) > 0 || source.Text.Length > 0) && !DelKeyPressed_SupplierNameValue_IncomeOrderUC)
                {
                    if (SuppliersFullNames.Where(x => x.IndexOf(source.Text, StringComparison.CurrentCultureIgnoreCase) == 0).Count() > 0)
                    {
                        var _appendtxt = SuppliersFullNames.FirstOrDefault(ap => (culture.CompareInfo.IndexOf(ap, source.Text, CompareOptions.IgnoreCase) == 0));
                        _appendtxt = _appendtxt.Remove(0, change.Offset + 1);
                        source.Text += _appendtxt;
                        source.SelectionStart = change.Offset + 1;
                        source.SelectionLength = source.Text.Length;
                    }
                }
                InProg_SupplierNameValue_IncomeOrderUC = false;
            }
        }
        private static bool DelKeyPressed_SupplierNameValue_IncomeOrderUC;
        internal static void DelPressed_SupplierNameValue_IncomeOrderUC(object sender, KeyEventArgs e)
        { if (e.Key == Key.Back) { DelKeyPressed_SupplierNameValue_IncomeOrderUC = true; } else { DelKeyPressed_SupplierNameValue_IncomeOrderUC = false; } }

        /// <summary>
        ///  Trigers when enter key down while selecting customerNameValue
        /// Compares the current value of the customerNameValue with customers list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SupplierNameValue_IncomeOrderUC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {

                foreach (SupplierModel c in Suppliers)
                {
                    if (c.Person.FullName.Equals(SupplierNameValue_IncomeOrderUC.Text, StringComparison.OrdinalIgnoreCase))
                    {
                        UpdateSupplierInfo(c);
                            }

                }
            }
        }


        /// <summary>
        /// Events for PhoneNumberValue_IncomeOrderUC changes to auto complete
        /// source : https://stackoverflow.com/questions/950770/autocomplete-textbox-in-wpf
        /// </summary>
        private bool InProg_PhoneNumberValue_IncomeOrderUC;
        private void PhoneNumberValue_IncomeOrderUC_TextChanged(object sender, TextChangedEventArgs e)
        {
            var change = e.Changes.FirstOrDefault();
            if (!InProg_PhoneNumberValue_IncomeOrderUC)
            {
                InProg_PhoneNumberValue_IncomeOrderUC = true;
                var culture = new CultureInfo(CultureInfo.CurrentCulture.Name);
                var source = ((TextBox)sender);
                if (((change.AddedLength - change.RemovedLength) > 0 || source.Text.Length > 0) && !DelKeyPressed_PhoneNumberValue_IncomeOrderUC)
                {
                    if (SuppliersPhoneNumbers.Where(x => x.IndexOf(source.Text, StringComparison.CurrentCultureIgnoreCase) == 0).Count() > 0)
                    {
                        var _appendtxt = SuppliersPhoneNumbers.FirstOrDefault(ap => (culture.CompareInfo.IndexOf(ap, source.Text, CompareOptions.IgnoreCase) == 0));
                        _appendtxt = _appendtxt.Remove(0, change.Offset + 1);
                        source.Text += _appendtxt;
                        source.SelectionStart = change.Offset + 1;
                        source.SelectionLength = source.Text.Length;
                    }
                }
                InProg_PhoneNumberValue_IncomeOrderUC = false;
            }
        }
        private static bool DelKeyPressed_PhoneNumberValue_IncomeOrderUC;
        internal static void DelPressed_PhoneNumberValue_IncomeOrderUC(object sender, KeyEventArgs e)
        { if (e.Key == Key.Back) { DelKeyPressed_PhoneNumberValue_IncomeOrderUC = true; } else { DelKeyPressed_PhoneNumberValue_IncomeOrderUC = false; } }


        /// <summary>
        ///  Trigers when enter key down while selecting customerNameValue
        /// Compares the current value of the customerNameValue with customers list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SupplierPhoneNumberValue_IncomeOrderUC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {

                foreach (SupplierModel c in Suppliers)
                {
                    if (c.Person.PhoneNumber != null)
                    {
                        if (c.Person.PhoneNumber.Equals(PhoneNumberValue_IncomeOrderUC.Text, StringComparison.OrdinalIgnoreCase))
                        {
                            UpdateSupplierInfo(c);
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Events for PhoneNumberValue_Sell changes to auto complete
        /// source : https://stackoverflow.com/questions/950770/autocomplete-textbox-in-wpf
        /// </summary>
        private bool InProg_NationalNumberValue_IncomeOrderUC;
        private void NationalNumberValue_IncomeOrderUC_TextChanged(object sender, TextChangedEventArgs e)
        {
            var change = e.Changes.FirstOrDefault();
            if (!InProg_NationalNumberValue_IncomeOrderUC)
            {
                InProg_NationalNumberValue_IncomeOrderUC = true;
                var culture = new CultureInfo(CultureInfo.CurrentCulture.Name);
                var source = ((TextBox)sender);
                if (((change.AddedLength - change.RemovedLength) > 0 || source.Text.Length > 0) && !DelKeyPressed_NationalNumberValue_IncomeOrderUC)
                {
                    if (SuppliersNationalNumbers.Where(x => x.IndexOf(source.Text, StringComparison.CurrentCultureIgnoreCase) == 0).Count() > 0)
                    {
                        var _appendtxt = SuppliersNationalNumbers.FirstOrDefault(ap => (culture.CompareInfo.IndexOf(ap, source.Text, CompareOptions.IgnoreCase) == 0));
                        _appendtxt = _appendtxt.Remove(0, change.Offset + 1);
                        source.Text += _appendtxt;
                        source.SelectionStart = change.Offset + 1;
                        source.SelectionLength = source.Text.Length;
                    }
                }
                InProg_NationalNumberValue_IncomeOrderUC = false;
            }
        }
        private static bool DelKeyPressed_NationalNumberValue_IncomeOrderUC;
        internal static void DelPressed_NationalNumberValue_IncomeOrderUC(object sender, KeyEventArgs e)
        { if (e.Key == Key.Back) { DelKeyPressed_NationalNumberValue_IncomeOrderUC = true; } else { DelKeyPressed_NationalNumberValue_IncomeOrderUC = false; } }


        /// <summary>
        /// Trigers when enter key down while selecting NationalNumberValue_Sell
        /// Compares the current value of the NationalNumberValue_Sell with customersNationalNumbers  list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NationalNumberValue_IncomeOrderUC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {

                foreach (SupplierModel supplier in Suppliers)
                {
                    if (supplier.Person.NationalNumber != null)
                    {
                        if (supplier.Person.NationalNumber.Equals(NationalNumberValue_IncomeOrderUC.Text))
                        {
                            UpdateSupplierInfo(supplier);

                        }
                    }

                }
            }
        }


        /// <summary>
        /// Update supplier data in the gui
        /// </summary>
        /// <param name="supplier"></param>
        private void  UpdateSupplierInfo(SupplierModel supplier)
        {
            Supplier = supplier;
            ClearSupplierInfo();
            InProg_SupplierNameValue_IncomeOrderUC = true;
            InProg_PhoneNumberValue_IncomeOrderUC = true;
            InProg_NationalNumberValue_IncomeOrderUC = true;

            SupplierNameValue_IncomeOrderUC.Text = supplier.Person.FullName;
            if (supplier.Person.PhoneNumber != null)
                PhoneNumberValue_IncomeOrderUC.Text = supplier.Person.PhoneNumber;
            if (supplier.Person.NationalNumber != null)
                NationalNumberValue_IncomeOrderUC.Text = supplier.Person.NationalNumber;
            if(supplier.Company != null)
                CompanyNameValue_IncomeOrderUC.Text = supplier.Company;

            InProg_SupplierNameValue_IncomeOrderUC = false;
            InProg_PhoneNumberValue_IncomeOrderUC = false;
            InProg_NationalNumberValue_IncomeOrderUC = false;

        }

        /// <summary>
        /// Clear supplier date from the supplier groupbox
        /// </summary>
        private void ClearSupplierInfo()
        {
            InProg_SupplierNameValue_IncomeOrderUC = true;
            InProg_PhoneNumberValue_IncomeOrderUC = true;
            InProg_NationalNumberValue_IncomeOrderUC = true;

            SupplierNameValue_IncomeOrderUC.Text = "";
            PhoneNumberValue_IncomeOrderUC.Text = "";
            NationalNumberValue_IncomeOrderUC.Text = "";
            CompanyNameValue_IncomeOrderUC.Text = "";

            InProg_SupplierNameValue_IncomeOrderUC = false;
            InProg_PhoneNumberValue_IncomeOrderUC = false;
            InProg_NationalNumberValue_IncomeOrderUC = false;
        }




        /// <summary>
        /// Open new window contain createSupplierUC 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewSupplierButton_IncomeOrderUC_Click(object sender, RoutedEventArgs e)
        {
            CreateSupplierUC createSupplierUC = new CreateSupplierUC();
            Window window = new Window
            {
                Title = "Add Supplier",
                Content = createSupplierUC,
                SizeToContent = SizeToContent.WidthAndHeight,
                ResizeMode = ResizeMode.NoResize
            };
            window.ShowDialog();
            SetInitialValues();
        }

        private void ClearSupplierButton_IncomeOrderUC_Click(object sender, RoutedEventArgs e)
        {
            ClearSupplierInfo();
        }


        #endregion

        #region RecentlyAdded Products GroupBox

        private void RecentlyAddedProductsList_IncomeOrderUC_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ProductModel product = (ProductModel)RecentlyAddedProductsList_IncomeOrderUC.SelectedItem;
            if (product != null)
            {
               ProductValue_IncomeOrderUC.SelectedIndex = Get_ProductValue_IncomeOrderUC_Index(product);
               UpdateProductInfo(product);
            }
        }

        #endregion

        #region Choose Product GroupBox Events

        /// <summary>
        /// Private event called when CategoryValue_IncomeOrderUC combobox OR BrandValue_IncomeOrderUC combobox sellection  changed to filter the ProductValue_IncomeOrderUC gridView by selected category or brand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FilterProductsByCategoryAndBrand(object sender, SelectionChangedEventArgs e)
        {
            if (CanFilterProducts)
            {
                FProducts = GlobalConfig.Connection.GetProductsByCategoryAndBrand(Products, (CategoryModel)CategoryValue_IncomeOrderUC.SelectedItem, (BrandModel)BrandValue_IncomeOrderUC.SelectedItem);

                ProductValue_IncomeOrderUC.ItemsSource = null;
                ProductValue_IncomeOrderUC.ItemsSource = FProducts;
                ProductValue_IncomeOrderUC.DisplayMemberPath = "Name";
            }
            


        }

        /// <summary>
        /// Each selection change if it not null update the info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProductValue_IncomeOrderUC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Product = (ProductModel)ProductValue_IncomeOrderUC.SelectedItem;

            if (Product != null)
            {
                UpdateProductInfo(Product);
            }
            else
            {
                ClearProductInfo();
            }

        }


        /// <summary>
        /// Update the product data in the gui
        /// check if it in stocks and update InStockValue
        /// </summary>
        /// <param name="product"></param>
        private void UpdateProductInfo(ProductModel product)
        {
            ClearProductInfo();

            CanFilterProducts = false;
            CategoryValue_IncomeOrderUC.SelectedIndex = Get_CategoryValue_IncomeOrderUC_Index(Product.Category);
            BrandValue_IncomeOrderUC.SelectedIndex = Get_BrandValue_IncomeOrderUC_Index(Product.Brand);
            CanFilterProducts = true;

            BarCodeValue_IncomeOrderUC.Text = product.BarCode;
            SerialNumberValue_IncomeOrderUC.Text = Product.SerialNumber;
            SerialNumber2Value_IncomeOrderUC.Text = product.SerialNumber2;
            SizeValue_IncomeOrderUC.Text = product.Size;
            SalePriceValue_IncomeOrderUC.Text = Product.SalePrice.ToString();
            IncomeValue_IncomeOrderUC.Text = Product.IncomePrice.ToString();
            ProductDetailsValue_IncomeOrderUC.Text = product.Details;
            QuantityValue_IncomeOrderUC.Text = "0";
            TotalProductPriceValue_IncomeOrderUC.Text = "0";

            List<StockModel> productStock = new List<StockModel>();
            productStock = GlobalConfig.Connection.GetStocksByProduct(LogedInStoreStocks, Product);
            if (productStock.Count > 0)
            {
                foreach (StockModel stock in productStock)
                {
                    InStockValue_IncomeOrderUC.Text = stock.Quantity.ToString();
                }
            }
            else
            {
                InStockValue_IncomeOrderUC.Text = "0";
            }

        }

        /// <summary>
        /// Clear the product info in the gui
        /// </summary>
        private void ClearProductInfo()
        {
            BarCodeValue_IncomeOrderUC.Text = "";
            SerialNumberValue_IncomeOrderUC.Text = "";
            SerialNumber2Value_IncomeOrderUC.Text = "";
            SizeValue_IncomeOrderUC.Text = "";
            SalePriceValue_IncomeOrderUC.Text = "";
            IncomeValue_IncomeOrderUC.Text = "";
            QuantityValue_IncomeOrderUC.Text = "";
            TotalProductPriceValue_IncomeOrderUC.Text = "";
            ProductDetailsValue_IncomeOrderUC.Text = "";
         
           InStockValue_IncomeOrderUC.Text = "";
            
        }


        /// <summary>
        /// get the index of brand if it in the BrandValue_IncomeOrderUC
        /// </summary>
        /// <param name="brand"></param>
        /// <returns> index of this brand </returns>
        private int Get_BrandValue_IncomeOrderUC_Index(BrandModel brand)
        {
            int i = 0;
            var lst = BrandValue_IncomeOrderUC.Items.Cast<BrandModel>();
            foreach (var s in lst)
            {
                if (s.Id == brand.Id)
                    return i;

                i++;
            }
            return 0;
        }

        /// <summary>
        /// get the index of categry if it in the CategoryValue_IncomeOrderUC
        /// </summary>
        /// <param name="category"></param>
        /// <returns> index of this category </returns>
        private int Get_CategoryValue_IncomeOrderUC_Index(CategoryModel category)
        {
            int i = 0;
            var lst = CategoryValue_IncomeOrderUC.Items.Cast<CategoryModel>();
            foreach (var s in lst)
            {
                if (s.Id == category.Id)
                    return i;

                i++;
            }
            return 0;
        }

        /// <summary>
        /// get the index of Product if it in the ProductValue_IncomeOrderUC
        /// </summary>
        /// <param name="category"></param>
        /// <returns> index of this category </returns>
        private int Get_ProductValue_IncomeOrderUC_Index(ProductModel product)
        {
            int i = 0;
            var lst = ProductValue_IncomeOrderUC.Items.Cast<ProductModel>();
            foreach (var s in lst)
            {
                if (s.Id == product.Id)
                    return i;

                i++;
            }
            return 0;
        }

        /// <summary>
        /// Enter key Pressed while selecting SerialNumberValue_IncomeOrderUC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SerialNumberValue_IncomeOrderUC_EventHundler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ProductModel product = GlobalConfig.Connection.GetProductBySerialNumber(Products, SerialNumberValue_IncomeOrderUC.Text);
                if (product == null)
                {
                    MessageBox.Show("This Serial Number Not Exist");
                }
                else
                {
                    ProductValue_IncomeOrderUC.SelectedItem = product;
                }
            }
        }


        private void ClearProductButton_IncomeOrderUC_Click(object sender, RoutedEventArgs e)
        {
            ClearProductInfo();
        }


        private void CreateNewProductButton_IncomeOrderUC_Click(object sender, RoutedEventArgs e)
        {
            CreateProductUC createProduct = new CreateProductUC();
            Window window = new Window
            {
                Title = "Create Product",
                Content = createProduct,
                SizeToContent = SizeToContent.WidthAndHeight,
                ResizeMode = ResizeMode.NoResize
            };
            window.ShowDialog();
            SetInitialValues();
        }



        /// <summary>
        /// Check choose product valus if it vaild or not
        /// </summary>
        /// <returns> 
        /// true if vaild 
        /// false if not </returns>
        private bool ChooseProduct_IsValid()
        {
            if (Product != null)
            {
                decimal salePrice = new decimal();
                if(decimal.TryParse(SalePriceValue_IncomeOrderUC.Text,out salePrice))
                {
                    if(salePrice > 0 )
                    {
                        decimal incomePrice = new decimal();
                        
                        if (decimal.TryParse(IncomeValue_IncomeOrderUC.Text, out incomePrice))
                        {
                            if (incomePrice > 0 )
                            {
                                int quantity = new int();
                                if (int.TryParse(QuantityValue_IncomeOrderUC.Text, out quantity))
                                {
                                    if (quantity > 0)
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Quantity can't be less than 1");
                                        QuantityValue_IncomeOrderUC.Text = "0";
                                        return false;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Quantity should be a number");
                                    QuantityValue_IncomeOrderUC.Text = "0";
                                    return false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Income Price Can't be less than 0.001");
                                IncomeValue_IncomeOrderUC.Text = Product.IncomePrice.ToString();
                                return false;
                            }

                        }
                        else
                        {
                            MessageBox.Show("Income Price Should be a number !");
                            IncomeValue_IncomeOrderUC.Text = Product.IncomePrice.ToString();
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sale Price Can't be less than 0.001");
                        SalePriceValue_IncomeOrderUC.Text = Product.SalePrice.ToString();
                        return false;
                    }

                }
                else
                {
                    MessageBox.Show("Sale Price value should be a number");
                    SalePriceValue_IncomeOrderUC.Text = Product.SalePrice.ToString();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Choose product , If it not exist press Create new Product");
                return false;
            }

        }

        private void IncomeValue_IncomeOrderUC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (ChooseProduct_IsValid())
                {
                    TotalProductPriceValue_IncomeOrderUC.Text =
                        GlobalConfig.Connection.GetTotalPriceValue(decimal.Parse(IncomeValue_IncomeOrderUC.Text), int.Parse(QuantityValue_IncomeOrderUC.Text)).ToString();
                }
            }
        }

        private void QuantityValue_IncomeOrderUC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (ChooseProduct_IsValid())
                {
                    TotalProductPriceValue_IncomeOrderUC.Text =
                        GlobalConfig.Connection.GetTotalPriceValue(decimal.Parse(IncomeValue_IncomeOrderUC.Text), int.Parse(QuantityValue_IncomeOrderUC.Text)).ToString();
                }
            }
        }

        private void SalePriceValue_IncomeOrderUC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ChooseProduct_IsValid();
                
            }
        }


        private void AddProductButton_IncomeOrderUC_Click(object sender, RoutedEventArgs e)
        {
            if (ChooseProduct_IsValid())
            {
                Product.IncomePrice = decimal.Parse(IncomeValue_IncomeOrderUC.Text);
                Product.SalePrice = decimal.Parse(SalePriceValue_IncomeOrderUC.Text);
                
                IncomeOrderProductModel incomeOrderProduct = new IncomeOrderProductModel();
                incomeOrderProduct.Product = Product;
                incomeOrderProduct.IncomePrice = Product.IncomePrice;
                incomeOrderProduct.Quantity = int.Parse(QuantityValue_IncomeOrderUC.Text);
                

                IncomeOrderProducts.Add(incomeOrderProduct);

                StocksList_IncomeOrderUC.ItemsSource = null;
                StocksList_IncomeOrderUC.ItemsSource = IncomeOrderProducts;

                SetTheTotalPriceValue();


            }
        }


        #endregion

        #region Hole Form Events

        private void RemoveSelectedStockButton_IncomeOrderUC_Click(object sender, RoutedEventArgs e)
        {
            IncomeOrderProductModel incomeOrderProduct = new IncomeOrderProductModel();
            incomeOrderProduct = (IncomeOrderProductModel)StocksList_IncomeOrderUC.SelectedItem;
            if (incomeOrderProduct != null)
            {
                IncomeOrderProducts.Remove(incomeOrderProduct);
                StocksList_IncomeOrderUC.ItemsSource = null;
                StocksList_IncomeOrderUC.ItemsSource = IncomeOrderProducts;
            }
            else
            {
                MessageBox.Show("There is no product selected !!");
            }

            SetTheTotalPriceValue();

        }

        /// <summary>
        /// Calculate the total Price without the shipping expenses
        /// </summary>
        private void SetTheTotalPriceValue()
        {

            decimal totalPrice = new decimal();
            totalPrice = 0;

            /*if (IncomeOrder.ShippingExpenses > 0)
            {
                totalPrice += IncomeOrder.ShippingExpenses;
            }*/
            foreach(IncomeOrderProductModel incomeOrderProduct in IncomeOrderProducts)
            {
                totalPrice += incomeOrderProduct.Product.IncomePrice * incomeOrderProduct.Quantity;
            }
            TotalPriceValue_IncomeOrderUC.Text = totalPrice.ToString();

        }
       
        private bool HoleForm_IsValid()
        {
            if(BillNumberValue_IncomeOrderUC.Text.Length > 0)
            {
                string billNumber = BillNumberValue_IncomeOrderUC.Text;
                if (GlobalConfig.Connection.IsBillNumberUnique(PublicVariables.IncomeOrders, billNumber))
                {
                    IncomeOrder.BillNumber = billNumber;
                }
                else
                {
                    if (MessageBox.Show("This bill Number is used before !", "Do you want to continue ?", MessageBoxButton.YesNo) == MessageBoxResult.No)
                    {
                        return false;
                    }
                    else
                    {
                        IncomeOrder.BillNumber = billNumber;
                    }
                }
            }
            else
            {
                if(MessageBox.Show("You didn't enter a Bill Number !", "Do you want to continue ?", MessageBoxButton.YesNo) == MessageBoxResult.No)
                {
                    return false;
                } 
            }
            if(ShippingExpensesValue_IncomeOrderUC.Text.Length > 0)
            {
                decimal shippingExpenses = new decimal();
                if (decimal.TryParse(ShippingExpensesValue_IncomeOrderUC.Text,out shippingExpenses))
                {
                    if(shippingExpenses >= 0)
                    {
                        ShopBill.TotalMoney = shippingExpenses;
                    }
                    else
                    {
                        MessageBox.Show("Shipping expenses Can't be less than 0");
                        ShippingExpensesValue_IncomeOrderUC.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("The shippling expenses should be a number !");
                    ShippingExpensesValue_IncomeOrderUC.Text = "";
                }
            }
            else
            {
                if (MessageBox.Show("You didn't enter the Shipping expenses !", "Do you want to continue ?", MessageBoxButton.YesNo) == MessageBoxResult.No)
                {
                    return false;
                }
            }

            if(IncomeOrderProducts.Count > 0)
            {
                
            }
            else
            {
                MessageBox.Show("You should add at least 1 product to make this order");
                return false;
            }
            if (string.IsNullOrWhiteSpace( SupplierNameValue_IncomeOrderUC.Text )== false && Supplier.Id != 0)
            {

            }
            else
            {
                MessageBox.Show("You didn't select a supplier !! ,  you can search for the default supplier");
                return false;
            }

            SetTheTotalPriceValue();


            return true;
        }


        /// <summary>
        /// Check if the form valid and set the income order values if it is !!
        /// - get empty IncomeOrder From the database
        /// - loop throw each product - IncomeOrderProduct - 
        ///  -- if the product not in the stock of the logedin shop  -> Create new stock with the new quantity
        ///  -- if the product in the stock of the logedin shop -> increase the quantity in the stock
        ///  -- Update the product Values {Sale Price and income Price}
        /// - save the list of the products - IncomeOrderProduct Models -  in the database
        /// 
        /// Set the INitial values
        /// Reset the thing and prepare it to the next new incomeorder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfirmButton_IncomeOrderUC_Click(object sender, RoutedEventArgs e)
        {
            if (HoleForm_IsValid())
            {
                IncomeOrder.Products = IncomeOrderProducts;
                IncomeOrder.Supplier = Supplier;
                IncomeOrder.BillNumber = BillNumberValue_IncomeOrderUC.Text;

                // Setting the dateTime
                int hours = DateTime.Now.Hour;
                int minutes = DateTime.Now.Minute;
                int second = DateTime.Now.Second;

                DateTime selectedDate = new DateTime();
                selectedDate = (DateTime)DateValue_IncomeOrderUC.SelectedDate;

                DateTime orderDateTime = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, hours, minutes, second);

                IncomeOrder.Date = orderDateTime;

                IncomeOrder.Store = PublicVariables.Store;
                IncomeOrder.Staff = PublicVariables.Staff;
                IncomeOrder.TotalPrice = decimal.Parse(TotalPriceValue_IncomeOrderUC.Text);
                IncomeOrder.Details = OrderDetailsValue_IncomeOrderUC.Text;
              
                

                // Get empty IncomeOrder From the database
                IncomeOrder = GlobalConfig.Connection.GetEmptyIncomeOrderFromTheDatabase(IncomeOrder);

                /*
                 * - loop throw each product - IncomeOrderProduct - 
                 *  -- if the product not in the stock of the logedin shop  -> Create new stock with the new quantity
                 *  -- if the product in the stock of the logedin shop -> increase the quantity in the stock
                 */
                foreach (IncomeOrderProductModel incomeOrderProduct in IncomeOrder.Products)
                {

                    List<StockModel> productStock = new List<StockModel>();
                    productStock = GlobalConfig.Connection.GetStocksByProduct(LogedInStoreStocks, incomeOrderProduct.Product);
                    if (productStock.Count > 0)
                    {
                        foreach (StockModel stock in productStock)
                        {
                            // increase the number  of this stock by the quantity

                            GlobalConfig.Connection.IncreaseStock(stock, incomeOrderProduct.Quantity);
                            
                        }
                    }
                    else
                    {
                        // Create new stock with the new quantity

                        StockModel NewStock = new StockModel();
                        NewStock.Product = incomeOrderProduct.Product;
                        NewStock.Quantity = incomeOrderProduct.Quantity;
                        NewStock.Store = IncomeOrder.Store;

                        // Save the stock to the database
                        GlobalConfig.Connection.AddStockToTheDatabase(NewStock);
                    }

                    // Update the product data
                    GlobalConfig.Connection.UpdateProdcutData(incomeOrderProduct.Product);

                }

                // save the list of the products - IncomeOrderProduct Models -  in the database

                GlobalConfig.Connection.SaveIncomeOrderProductListToTheDatabase(IncomeOrder);

                // Create Operation and save it to the database
                OperationModel incomeOrderoperation = new OperationModel();
                incomeOrderoperation.IncomeOrder = IncomeOrder;
                incomeOrderoperation.Date = IncomeOrder.Date;
                incomeOrderoperation.AmountOfMoney = IncomeOrder.TotalPrice;

                GlobalConfig.Connection.AddOperationToDatabase(incomeOrderoperation);

                if(ShopBill.TotalMoney > 0)
                {
                    ShopBill.Staff = PublicVariables.Staff;
                    ShopBill.Store = PublicVariables.Store;
                    ShopBill.Date = IncomeOrder.Date;
                    ShopBill.Details = "Shopping expenses of the order number: " + IncomeOrder.Id + " .";

                    ShopBill = GlobalConfig.Connection.AddShopBillToTheDatabase(ShopBill);

                    OperationModel shopOrderOperation = new OperationModel();


                    shopOrderOperation.ShopBill = ShopBill;
                    shopOrderOperation.Date = IncomeOrder.Date;
                    shopOrderOperation.AmountOfMoney = ShopBill.TotalMoney;
                    GlobalConfig.Connection.AddOperationToDatabase(shopOrderOperation);

                }



                PublicVariables.LoginStoreStocks = GlobalConfig.Connection.FilterStocksByStore(PublicVariables.Store);

                PublicVariables.Operations = GlobalConfig.Connection.GetOperations();

                IncomeOrderProducts = new List<IncomeOrderProductModel>();
                StocksList_IncomeOrderUC.ItemsSource = null;
                IncomeOrder = new IncomeOrderModel();
                BillNumberValue_IncomeOrderUC.Text = "";
                ShippingExpensesValue_IncomeOrderUC.Text = "";
                Supplier = new SupplierModel();
                SupplierNameValue_IncomeOrderUC.Text = "";
                PhoneNumberValue_IncomeOrderUC.Text = "";
                NationalNumberValue_IncomeOrderUC.Text = "";
                CompanyNameValue_IncomeOrderUC.Text = "";
                TotalPriceValue_IncomeOrderUC.Text = "";
                OrderDetailsValue_IncomeOrderUC.Text = "";
                
                ShopBill = new ShopBillModel();

                SetInitialValues();

            }
            else
            {
                 
            }

            
        }

        private void ShippingExpensesValue_IncomeOrderUC_KeyDown(object sender, KeyEventArgs e)
        {
             if (e.Key == Key.Enter)
            {
                if (ShippingExpensesValue_IncomeOrderUC.Text.Length > 0)
                {
                    decimal shippingExpenses = new decimal();
                    if (decimal.TryParse(ShippingExpensesValue_IncomeOrderUC.Text, out shippingExpenses))
                    {
                        if (shippingExpenses >= 0)
                        {
                            ShopBill.TotalMoney = shippingExpenses;
                            SetTheTotalPriceValue();
                        }
                        else
                        {
                            MessageBox.Show("Shipping expenses Can't be less than 0");
                            ShippingExpensesValue_IncomeOrderUC.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("The shippling expenses should be a number !");
                        ShippingExpensesValue_IncomeOrderUC.Text = "";
                    }
                }
            }
        }

        private void RefreshButton_IncomeOrderUC_Click(object sender, RoutedEventArgs e)
        {
            SetInitialValues();
        }

        private void SupplierSwichGBButton_IncomeOrderUC_Click(object sender, RoutedEventArgs e)
        {
            RecentlyAddedGB_IncomeOrderUC.Visibility = Visibility.Collapsed;
            ChooseSupplierGB_IncomeOrderUC.Visibility = Visibility.Visible;
        }

        private void RecentAddedProductsSwichGBButton_IncomeOrderUC_Click(object sender, RoutedEventArgs e)
        {
            RecentlyAddedGB_IncomeOrderUC.Visibility = Visibility.Visible;
            ChooseSupplierGB_IncomeOrderUC.Visibility = Visibility.Collapsed;
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

        #endregion


    }
}
