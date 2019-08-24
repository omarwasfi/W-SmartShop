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
using WPF_GUI.CreateCutomer;

namespace WPF_GUI
{
    /// <summary>
    /// Interaction logic for InstallmentOrderUC.xaml
    /// 
    /// load the customer and products group box , make them easy and useable 
    /// after the user choose a product and press { ADD } in the products group box
    /// - Create new installmentProduct -> Add to the list
    /// - update the installment values : 
    ///     -- Calculate TotalPriceAfterInstallment , calculate the EMI
    ///     -- diposit , number of months , RateOfInterest , totalPriceBeforeInstallment , TotalPriceAfterInstallment , LoanAmount ,  EMI , PaymentsStartDate
    /// 
    /// </summary>
    public partial class InstallmentOrderUC : UserControl ,ICustomerRequester
    {
        #region Main Variables

        InstallmentModel Installment { get; set; } = new InstallmentModel();


        List<InstallmentProductModel> InstallmentProducts = new List<InstallmentProductModel>();


        /// <summary>
        /// The logedIn Store
        /// </summary>
        private StoreModel Store { get; set; } = PublicVariables.Store;

        /// <summary>
        /// The Login Staff Member
        /// </summary>
        private StaffModel Staff { get; set; } = PublicVariables.Staff;

        /// <summary>
        /// All the categories
        /// </summary>
        private List<CategoryModel> Categories { get; set; }

        /// <summary>
        /// All The brands
        /// </summary>
        private List<BrandModel> Brands { get; set; }

        /// <summary>
        /// The LogedIN Store Stocks
        /// </summary>
        private List<StockModel> Stocks { get; set; }

        /// <summary>
        /// The Customer Model
        /// </summary>
        private CustomerModel Customer { get; set; } = new CustomerModel();



        #endregion

        #region Help Variables

        private StockModel Stock = new StockModel();

        /// <summary>
        /// 
        /// All The Customer
        /// </summary>
        private List<CustomerModel> Customers { get; set; }
        private List<string> CustomersFullNames { get; set; } = new List<string>();
        private List<string> CustomersPhoneNumbers { get; set; } = new List<string>();
        private List<string> CustomersNationalNumbers { get; set; } = new List<string>();

        /// <summary>
        /// List OF the Stocks After Filtring
        /// </summary>
        private List<StockModel> FStocks { get; set; }

        /// <summary>
        /// Manage If we can Filter Products or not 
        /// Use when user done choose the product
        /// </summary>
        bool CanFilterStocks = true;



        #endregion





        #region set the initianl values


        public InstallmentOrderUC()
        {
            InitializeComponent();

            SetInitialValues();
        }

      
        private void SetInitialValues()
        {

            Update_CustomerNamesVariablesAndEvents();

            UpdateTheCategoriesFromThePublicVariables();
            CategoryValue_InstallmentOrderUC.ItemsSource = Categories;
            CategoryValue_InstallmentOrderUC.DisplayMemberPath = "Name";
            CategoryValue_InstallmentOrderUC.SelectedItem = null;

            UpdateTheBrandsFromThePublicVariables();
            BrandValue_InstallmentOrderUC.ItemsSource = Brands;
            BrandValue_InstallmentOrderUC.DisplayMemberPath = "Name";
            BrandValue_InstallmentOrderUC.SelectedItem = null;

            GetStocksFormThePublicVariables();
            ProductValue_InstallmentOrderUC.ItemsSource = Stocks;
            ProductValue_InstallmentOrderUC.DisplayMemberPath = "Product.Name";
            ProductValue_InstallmentOrderUC.SelectedItem = null;

            ClearStockInfo();

            // Set the default installment valus
            Installment.Date = DateTime.Now;
            Installment.NumberOfMonths = 1;
            NumberOfMonthsValue_InstallmentOrderUC.Text = Installment.NumberOfMonths.ToString();
            Installment.Deposit = 0;
            DipositValue_InstallmentOrderUC.Text = Installment.Deposit.ToString();
            Installment.RateOfInterest = 1.1;
            RateOfInterestValue_InstallmentOrderUC.Text = Installment.RateOfInterest.ToString();




            UpdateInstallmentValues();

        }


        /// <summary>
        /// Add Customers full Names into 1 list 
        /// Add customers PhoneNumbers into 1 list
        /// Add Customers NationalNumbers into 1 list
        /// Add delete pressed event for CustomerNameValue_Sell
        /// </summary>
        private void Update_CustomerNamesVariablesAndEvents()
        {
            GetCustomersFromPublicVariables();
            foreach (CustomerModel customer in Customers)
            {

                CustomersFullNames.Add(customer.Person.FullName);

                if (customer.Person.PhoneNumber != null)
                    CustomersPhoneNumbers.Add(customer.Person.PhoneNumber);

                if (customer.Person.NationalNumber != null)
                    CustomersNationalNumbers.Add(customer.Person.NationalNumber);

            }

            CustomerNameValue_InstallmentOrderUC.PreviewKeyDown += DelPressed_CustomerNameValue_InstallmentOrderUC;
            PhoneNumberValue_InstallmentOrderUC.PreviewKeyDown += DelPressed_PhoneNumberValue_InstallmentOrderUC;
            NationalNumberValue_InstallmentOrderUC.PreviewKeyDown += DelPressed_NationalNumberValue_InstallmentOrderUC;



            UpdateCustomerInfo(GlobalConfig.Connection.GetDefaultCustomer());
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

        /// <summary>
        /// Update And Get All Customers from the PublicVariables
        /// </summary>
        private void GetCustomersFromPublicVariables()
        {
            PublicVariables.Customers = null;
            PublicVariables.Customers = GlobalConfig.Connection.GetCustomers();
            Customers = null;
            Customers = PublicVariables.Customers;
        }

        /// <summary>
        /// Update and Get The Stocks for this store from the PublicVariables
        /// </summary>
        private void GetStocksFormThePublicVariables()
        {
            PublicVariables.LoginStoreStocks = null;
            PublicVariables.LoginStoreStocks = GlobalConfig.Connection.FilterStocksByStore(PublicVariables.Store);
            Stocks = null;
            Stocks = PublicVariables.LoginStoreStocks;
        }

        #endregion


        #region Customer Group Box Events

        private bool InProg_CustomerNameValue_InstallmentOrderUC;
        /// <summary>
        /// Events for CustomerValue changes to auto complete
        /// source : https://stackoverflow.com/questions/950770/autocomplete-textbox-in-wpf
        /// </summary>
        private void CustomerNameValue_InstallmentOrderUC_TextChanged(object sender, TextChangedEventArgs e)
        {
            var change = e.Changes.FirstOrDefault();
            if (!InProg_CustomerNameValue_InstallmentOrderUC)
            {
                InProg_CustomerNameValue_InstallmentOrderUC = true;
                var culture = new CultureInfo(CultureInfo.CurrentCulture.Name);
                var source = ((TextBox)sender);
                if (((change.AddedLength - change.RemovedLength) > 0 || source.Text.Length > 0) && !DelKeyPressed_CustomerNameValue_InstallmentOrderUC)
                {
                    if (CustomersFullNames.Where(x => x.IndexOf(source.Text, StringComparison.CurrentCultureIgnoreCase) == 0).Count() > 0)
                    {
                        var _appendtxt = CustomersFullNames.FirstOrDefault(ap => (culture.CompareInfo.IndexOf(ap, source.Text, CompareOptions.IgnoreCase) == 0));
                        _appendtxt = _appendtxt.Remove(0, change.Offset + 1);
                        source.Text += _appendtxt;
                        source.SelectionStart = change.Offset + 1;
                        source.SelectionLength = source.Text.Length;
                    }
                }
                InProg_CustomerNameValue_InstallmentOrderUC = false;
            }

        }
        private static bool DelKeyPressed_CustomerNameValue_InstallmentOrderUC;
        internal static void DelPressed_CustomerNameValue_InstallmentOrderUC(object sender, KeyEventArgs e)
        { if (e.Key == Key.Back) { DelKeyPressed_CustomerNameValue_InstallmentOrderUC = true; } else { DelKeyPressed_CustomerNameValue_InstallmentOrderUC = false; } }

        /// <summary>
        /// Trigers when enter key down while selecting customerNameValue
        /// Compares the current value of the customerNameValue with customers list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomerNameValue_InstallmentOrderUC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {

                foreach (CustomerModel c in Customers)
                {
                    if (c.Person.FullName.Equals(CustomerNameValue_InstallmentOrderUC.Text, StringComparison.OrdinalIgnoreCase))
                    {
                        UpdateCustomerInfo(c);

                    }

                }
            }
        }



        private bool InProg_PhoneNumberValue_InstallmentOrderUC;
        /// <summary>
        /// Events for PhoneNumberValue_Sell changes to auto complete
        /// source : https://stackoverflow.com/questions/950770/autocomplete-textbox-in-wpf
        /// </summary>
        private void PhoneNumberValue_InstallmentOrderUC_TextChanged(object sender, TextChangedEventArgs e)
        {
            var change = e.Changes.FirstOrDefault();
            if (!InProg_PhoneNumberValue_InstallmentOrderUC)
            {
                InProg_PhoneNumberValue_InstallmentOrderUC = true;
                var culture = new CultureInfo(CultureInfo.CurrentCulture.Name);
                var source = ((TextBox)sender);
                if (((change.AddedLength - change.RemovedLength) > 0 || source.Text.Length > 0) && !DelKeyPressed_PhoneNumberValue_InstallmentOrderUC)
                {
                    if (CustomersPhoneNumbers.Where(x => x.IndexOf(source.Text, StringComparison.CurrentCultureIgnoreCase) == 0).Count() > 0)
                    {
                        var _appendtxt = CustomersPhoneNumbers.FirstOrDefault(ap => (culture.CompareInfo.IndexOf(ap, source.Text, CompareOptions.IgnoreCase) == 0));
                        _appendtxt = _appendtxt.Remove(0, change.Offset + 1);
                        source.Text += _appendtxt;
                        source.SelectionStart = change.Offset + 1;
                        source.SelectionLength = source.Text.Length;
                    }
                }
                InProg_PhoneNumberValue_InstallmentOrderUC = false;
            }
        }
        private static bool DelKeyPressed_PhoneNumberValue_InstallmentOrderUC;
        internal static void DelPressed_PhoneNumberValue_InstallmentOrderUC(object sender, KeyEventArgs e)
        { if (e.Key == Key.Back) { DelKeyPressed_PhoneNumberValue_InstallmentOrderUC = true; } else { DelKeyPressed_PhoneNumberValue_InstallmentOrderUC = false; } }


        /// <summary>
        /// Trigers when enter key down while selecting PhoneNumberValue_Sell
        /// Compares the current value of the PhoneNumberValue_Sell with customersPhones  list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PhoneNumberValue_InstallmentOrderUC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {

                foreach (CustomerModel customer in Customers)
                {
                    if (customer.Person.PhoneNumber != null)
                    {
                        if (customer.Person.PhoneNumber.Equals(PhoneNumberValue_InstallmentOrderUC.Text))
                        {
                            UpdateCustomerInfo(customer);

                        }
                    }

                }
            }
        }

        private bool InProg_NationalNumberValue_InstallmentOrderUC;
        /// <summary>
        /// Events for PhoneNumberValue_Sell changes to auto complete
        /// source : https://stackoverflow.com/questions/950770/autocomplete-textbox-in-wpf
        /// </summary>
        private void NationalNumberValue_InstallmentOrderUC_TextChanged(object sender, TextChangedEventArgs e)
        {
            var change = e.Changes.FirstOrDefault();
            if (!InProg_NationalNumberValue_InstallmentOrderUC)
            {
                InProg_NationalNumberValue_InstallmentOrderUC = true;
                var culture = new CultureInfo(CultureInfo.CurrentCulture.Name);
                var source = ((TextBox)sender);
                if (((change.AddedLength - change.RemovedLength) > 0 || source.Text.Length > 0) && !DelKeyPressed_NationalNumberValue_InstallmentOrderUC)
                {
                    if (CustomersNationalNumbers.Where(x => x.IndexOf(source.Text, StringComparison.CurrentCultureIgnoreCase) == 0).Count() > 0)
                    {
                        var _appendtxt = CustomersNationalNumbers.FirstOrDefault(ap => (culture.CompareInfo.IndexOf(ap, source.Text, CompareOptions.IgnoreCase) == 0));
                        _appendtxt = _appendtxt.Remove(0, change.Offset + 1);
                        source.Text += _appendtxt;
                        source.SelectionStart = change.Offset + 1;
                        source.SelectionLength = source.Text.Length;
                    }
                }
                InProg_NationalNumberValue_InstallmentOrderUC = false;
            }
        }
        private static bool DelKeyPressed_NationalNumberValue_InstallmentOrderUC;
        internal static void DelPressed_NationalNumberValue_InstallmentOrderUC(object sender, KeyEventArgs e)
        { if (e.Key == Key.Back) { DelKeyPressed_NationalNumberValue_InstallmentOrderUC = true; } else { DelKeyPressed_NationalNumberValue_InstallmentOrderUC = false; } }

        /// <summary>
        /// Trigers when enter key down while selecting NationalNumberValue_Sell
        /// Compares the current value of the NationalNumberValue_Sell with customersNationalNumbers  list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NationalNumberValue_InstallmentOrderUC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {

                foreach (CustomerModel customer in Customers)
                {
                    if (customer.Person.NationalNumber != null)
                    {
                        if (customer.Person.NationalNumber.Equals(NationalNumberValue_InstallmentOrderUC.Text))
                        {
                            UpdateCustomerInfo(customer);

                        }
                    }

                }
            }
        }

        /// <summary>
        /// Cleare Customer button event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearCustomerButton_InstallmentOrderUC_Click(object sender, RoutedEventArgs e)
        {
            ClearCustomerInfo();
        }

        /// <summary>
        /// Called when customer changes to update his info
        /// </summary>
        /// <param name="customer"></param>
        private void UpdateCustomerInfo(CustomerModel customer)
        {
            Customer = customer;
            ClearCustomerInfo();
            InProg_CustomerNameValue_InstallmentOrderUC = true;
            InProg_PhoneNumberValue_InstallmentOrderUC = true;
            InProg_NationalNumberValue_InstallmentOrderUC = true;

            CustomerNameValue_InstallmentOrderUC.Text = customer.Person.FullName;

            if (customer.Person.PhoneNumber != null)
                PhoneNumberValue_InstallmentOrderUC.Text = customer.Person.PhoneNumber;
            if (customer.Person.NationalNumber != null)
                NationalNumberValue_InstallmentOrderUC.Text = customer.Person.NationalNumber;

            InProg_CustomerNameValue_InstallmentOrderUC = false;
            InProg_PhoneNumberValue_InstallmentOrderUC = false;
            InProg_NationalNumberValue_InstallmentOrderUC = false;


        }

        /// <summary>
        /// Cleare customer  Customer data from the customer groupbox
        /// </summary>
        private void ClearCustomerInfo()
        {
            InProg_CustomerNameValue_InstallmentOrderUC = true;
            InProg_PhoneNumberValue_InstallmentOrderUC = true;
            InProg_NationalNumberValue_InstallmentOrderUC = true;

            CustomerNameValue_InstallmentOrderUC.Text = "";
            PhoneNumberValue_InstallmentOrderUC.Text = "";
            NationalNumberValue_InstallmentOrderUC.Text = "";

            InProg_CustomerNameValue_InstallmentOrderUC = false;
            InProg_PhoneNumberValue_InstallmentOrderUC = false;
            InProg_NationalNumberValue_InstallmentOrderUC = false;

        }

      
        private void SelectedCustomerLogButton_InstallmentOrderUC_Click(object sender, RoutedEventArgs e)
        {

            CustomerLogUC.CustomerLogUC customerLogUC = new CustomerLogUC.CustomerLogUC(Customer);
            Window window = new Window
            {
                Title = "Customer Log",
                Content = customerLogUC,
                SizeToContent = SizeToContent.WidthAndHeight,
                ResizeMode = ResizeMode.NoResize
            };
            window.ShowDialog();

            SetInitialValues();

        }


        /// <summary>
        /// Show the user Control in a new window 
        /// source: https://stackoverflow.com/questions/1262115/how-do-you-display-a-custom-usercontrol-as-a-dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewCustomerButton_InstallmentOrderUC_Click(object sender, RoutedEventArgs e)
        {

            CreateCustomerUC createCustomer = new CreateCustomerUC(this);
            Window window = new Window
            {
                Title = "Create User",
                Content = createCustomer,
                SizeToContent = SizeToContent.WidthAndHeight,
                ResizeMode = ResizeMode.NoResize
            };
            window.ShowDialog();
        }

        /// <summary>
        /// Implemnted from interface to set the customer If this Customer is new
        /// </summary>
        /// <param name="customer"></param>
        public void CustomerComplete(CustomerModel customer)
        {
            Customers.Add(customer);
            CustomersFullNames.Add(customer.Person.FullName);
            UpdateCustomerInfo(customer);
        }


        #endregion

        #region Product Group Box Events

        /// <summary>
        /// Private event called when CategoryValue_InstallmentOrderUC combobox OR CategoryValue_InstallmentOrderUC combobox sellection  changed to filter the ProductValue_InstallmentOrderUC gridView by selected category or brand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FilterStocksByCategoryAndBrand(object sender, SelectionChangedEventArgs e)
        {
            if (CanFilterStocks)
            {
                FStocks = GlobalConfig.Connection.FilterStocksByCategoryAndBrand(Stocks, (CategoryModel)CategoryValue_InstallmentOrderUC.SelectedItem, (BrandModel)BrandValue_InstallmentOrderUC.SelectedItem);

                ProductValue_InstallmentOrderUC.ItemsSource = null;
                ProductValue_InstallmentOrderUC.ItemsSource = FStocks;
                ProductValue_InstallmentOrderUC.DisplayMemberPath = "Product.Name";
                ProductValue_InstallmentOrderUC.SelectedItem = null;

            }
        }

        /// <summary>
        /// Each selection change if it not null update the info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProductValue_InstallmentOrderUC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Stock = (StockModel)ProductValue_InstallmentOrderUC.SelectedItem;

            if (Stock == null)
            {
                ClearStockInfo();
            }
            else
            {
                UpdateStockInfo(Stock);
            }

        }



        private void SerialNumberValue_InstallmentOrderUC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Stock  = GlobalConfig.Connection.GetStockBySerialNumber(Stocks, SerialNumberValue_InstallmentOrderUC.Text);
                if (Stock == null)
                {
                    MessageBox.Show("This Serial Number Not Exist");
                }
                else
                {
                    ProductValue_InstallmentOrderUC.SelectedItem = null;
                    ProductValue_InstallmentOrderUC.SelectedItem = Stock;
                }
            }
        }

        /// <summary>
        /// Update product info Called after User choose the product
        /// Category , Brand ,  Serial Number , Sale Price , discount , quantity Total Price
        /// </summary>
        /// <param name="product"></param>
        private void UpdateStockInfo(StockModel stock)
        {
            ClearStockInfo();

            CanFilterStocks = false;
            CategoryValue_InstallmentOrderUC.SelectedIndex = Get_CategoryValue_InstallmentOrderUC_Index(stock.Product.Category);
            BrandValue_InstallmentOrderUC.SelectedIndex = Get_BrandValue_InstallmentOrderUC_Index(stock.Product.Brand);
            CanFilterStocks = true;

            SerialNumberValue_InstallmentOrderUC.Text = stock.Product.SerialNumber;
            InStockValue_InstallmentOrderUC.Text = stock.Quantity.ToString();
            SalePriceValue_InstallmentOrderUC.Text = stock.Product.SalePrice.ToString();
            DiscountValue_InstallmentOrderUC.Text = "0";
            QuantityValue_InstallmentOrderUC.Text = "1";
            TotalProductPriceValue_InstallmentOrderUC.Text = stock.Product.SalePrice.ToString();




        }


        private void ClearStockInfo()
        {


            SerialNumberValue_InstallmentOrderUC.Text = "";
            InStockValue_InstallmentOrderUC.Text = "";
            SalePriceValue_InstallmentOrderUC.Text = "";
            DiscountValue_InstallmentOrderUC.Text = "";
            QuantityValue_InstallmentOrderUC.Text = "";
            TotalProductPriceValue_InstallmentOrderUC.Text = "";


        }

        /// <summary>
        /// get the index of brand if it in the BrandValue_IncomeOrderUC
        /// </summary>
        /// <param name="brand"></param>
        /// <returns> index of this brand </returns>
        private int Get_BrandValue_InstallmentOrderUC_Index(BrandModel brand)
        {
            int i = 0;
            var lst = BrandValue_InstallmentOrderUC.Items.Cast<BrandModel>();
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
        private int Get_CategoryValue_InstallmentOrderUC_Index(CategoryModel category)
        {
            int i = 0;
            var lst = CategoryValue_InstallmentOrderUC.Items.Cast<CategoryModel>();
            foreach (var s in lst)
            {
                if (s.Id == category.Id)
                    return i;

                i++;
            }
            return 0;
        }


        private void ClearProductButton_InstallmentOrderUC_Click(object sender, RoutedEventArgs e)
        {
            ClearStockInfo();
        }


        /// <summary>
        /// Check choose stock valus if it vaild or not
        /// </summary>
        /// <returns> 
        /// true if vaild 
        /// false if not </returns>
        private bool ChooseStock_IsValid()
        {
            if (Stock != null)
            {
                decimal salePrice = new decimal();
                if (decimal.TryParse(SalePriceValue_InstallmentOrderUC.Text, out salePrice))
                {
                    if (salePrice > 0)
                    {
                        decimal discount = new decimal();

                        if (decimal.TryParse(DiscountValue_InstallmentOrderUC.Text, out discount))
                        {
                            if (discount >= 0 && discount < Stock.Product.SalePrice)
                            {
                                int quantity = new int();
                                if (int.TryParse(QuantityValue_InstallmentOrderUC.Text, out quantity))
                                {
                                    if (quantity > 0 && quantity <= Stock.Quantity)
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Quantity can't be less than 1 OR more than the number of stock quantity");
                                        QuantityValue_InstallmentOrderUC.Text = "0";
                                        return false;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Quantity should be a number");
                                    QuantityValue_InstallmentOrderUC.Text = "0";
                                    return false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Income Price Can't be less than 0.001 And Can't be more than the product sale Price");
                                DiscountValue_InstallmentOrderUC.Text = "";
                                return false;
                            }

                        }
                        else
                        {
                            MessageBox.Show("Discount Should be a number !");
                            DiscountValue_InstallmentOrderUC.Text = "";
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sale Price Can't be less than 0.001");
                        SalePriceValue_InstallmentOrderUC.Text = Stock.Product.SalePrice.ToString();
                        return false;
                    }

                }
                else
                {
                    MessageBox.Show("Sale Price value should be a number");
                    SalePriceValue_InstallmentOrderUC.Text = Stock.Product.SalePrice.ToString();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Choose product , If it not exist press Create new Product");
                return false;
            }

        }


        private void SalePriceValue_InstallmentOrderUC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (ChooseStock_IsValid())
                {
                    DiscountValue_InstallmentOrderUC.Text = GlobalConfig.Connection.GetDiscountValue(decimal.Parse(SalePriceValue_InstallmentOrderUC.Text), Stock.Product).ToString();
                    TotalProductPriceValue_InstallmentOrderUC.Text =
                        GlobalConfig.Connection.GetTotalPriceValue(decimal.Parse(SalePriceValue_InstallmentOrderUC.Text), int.Parse(QuantityValue_InstallmentOrderUC.Text)).ToString();
                }
            }
        }


        private void DiscountValue_InstallmentOrderUC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (ChooseStock_IsValid())
                {
                    SalePriceValue_InstallmentOrderUC.Text = GlobalConfig.Connection.GetPriceValue(decimal.Parse(DiscountValue_InstallmentOrderUC.Text), Stock.Product).ToString();
                    TotalProductPriceValue_InstallmentOrderUC.Text =
                        GlobalConfig.Connection.GetTotalPriceValue(decimal.Parse(SalePriceValue_InstallmentOrderUC.Text), int.Parse(QuantityValue_InstallmentOrderUC.Text)).ToString();
                }
            }
        }


        private void QuantityValue_InstallmentOrderUC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (ChooseStock_IsValid())
                {
                    TotalProductPriceValue_InstallmentOrderUC.Text =
                        GlobalConfig.Connection.GetTotalPriceValue(decimal.Parse(SalePriceValue_InstallmentOrderUC.Text), int.Parse(QuantityValue_InstallmentOrderUC.Text)).ToString();
                }
            }
        }


        private void AddProductButton_InstallmentOrderUC_Click(object sender, RoutedEventArgs e)
        {
            if (ChooseStock_IsValid())
            {
                InstallmentProductModel installmentProduct = new InstallmentProductModel();
                installmentProduct.Product = Stock.Product;
                installmentProduct.Quantity = int.Parse(QuantityValue_InstallmentOrderUC.Text);
                installmentProduct.InstallmentPrice = decimal.Parse(SalePriceValue_InstallmentOrderUC.Text);
                installmentProduct.Discount = decimal.Parse(DiscountValue_InstallmentOrderUC.Text);

                InstallmentProducts.Add(installmentProduct);

                ChoosenProductList_InstallmentOrderUC.ItemsSource = null;
                ChoosenProductList_InstallmentOrderUC.ItemsSource = InstallmentProducts;


                UpdateInstallmentValues();


            }

        }


        #endregion

        #region Hole Form Events

        private void UpdateInstallmentValues()
        {
            decimal totalPriceBeforeInstallment = new decimal();

            foreach (InstallmentProductModel installmentProduct in InstallmentProducts)
            {
                totalPriceBeforeInstallment += installmentProduct.GetTotalInstallmentPrice;
            }
            TotalPriceBeforeInstallmentValue_InstallmentOrderUC.Text = totalPriceBeforeInstallment.ToString();


            if (InstallmentValues_IsValid())
            {
              


                InstallmentCalculations();

                PaymentsStartDate_InstallmentOrderUC.DisplayDateStart = DateTime.Now;


                if (Installment.Date >= DateTime.Now)
                {
                    PaymentsStartDate_InstallmentOrderUC.SelectedDate = Installment.Date;
                }
                else
                {
                    Installment.Date = DateTime.Now;
                    PaymentsStartDate_InstallmentOrderUC.SelectedDate = Installment.Date;
                }


                DipositValue_InstallmentOrderUC.Text = Installment.Deposit.ToString();
                NumberOfMonthsValue_InstallmentOrderUC.Text = Installment.NumberOfMonths.ToString();
                RateOfInterestValue_InstallmentOrderUC.Text = Installment.RateOfInterest.ToString();
                LoanAmountValue_InstallmentOrderUC.Text = Installment.LoanAmount.ToString();
                EMIValue_InstallmentOrderUC.Text = Installment.EMI.ToString();
                TotalPriceAfterInstallmentValue_InstallmentOrderUC.Text = Installment.TotaInstallmentPrice.ToString();
            }

            

           
            
        }

        /// <summary>
        /// Update and calculate everything in the installment 
        /// in : Total Price Before installment , diposit ,  numberOfMonths , rateOf Insterest
        /// Update : LoanAmount , EMI , TotalPriceAfterInstallment
        /// </summary>
        private void InstallmentCalculations()
        {
           
            
                Installment.LoanAmount = decimal.Parse(TotalPriceBeforeInstallmentValue_InstallmentOrderUC.Text) - Installment.Deposit;
                Installment.EMI = GlobalConfig.Connection.CalculateTheEMI_RateOfInterestByYear(Installment.LoanAmount, Installment.RateOfInterest, Installment.NumberOfMonths);
                Installment.TotaInstallmentPrice = Installment.EMI * Installment.NumberOfMonths ;
            Installment.TotaInstallmentPrice += Installment.Deposit;
            
           
        }


        /// <summary>
        /// check if installment values valid
        /// true = yes , false = no
        /// check diposit , numberOfMonths , RateOfInterest
        /// </summary>
        /// <returns></returns>
        private bool InstallmentValues_IsValid()
        {
            if(DipositValue_InstallmentOrderUC.Text.Length > 0)
            {
                decimal diposit = new decimal();
                if(decimal.TryParse(DipositValue_InstallmentOrderUC.Text , out diposit))
                {
                    if(diposit >= 0 && diposit <= decimal.Parse(TotalPriceBeforeInstallmentValue_InstallmentOrderUC.Text) )
                    {
                        Installment.Deposit = diposit;

                        if(NumberOfMonthsValue_InstallmentOrderUC.Text.Length > 0)
                        {
                            int numberOfMonths = new int();
                            if(int.TryParse(NumberOfMonthsValue_InstallmentOrderUC.Text , out numberOfMonths))
                            {

                                if(numberOfMonths >= 1)
                                {
                                    Installment.NumberOfMonths = numberOfMonths;

                                    if(RateOfInterestValue_InstallmentOrderUC.Text.Length > 0)
                                    {
                                        double rateOfInterest = new double();
                                        if (double.TryParse(RateOfInterestValue_InstallmentOrderUC.Text ,out rateOfInterest))
                                        {
                                            if(rateOfInterest > 1)
                                            {
                                                Installment.RateOfInterest = rateOfInterest;
                                            }
                                            else
                                            {
                                                MessageBox.Show("Rate Of interest should be more than 1 ");
                                                RateOfInterestValue_InstallmentOrderUC.Text = "1.1";
                                                return false;
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Rate of interest should be a number");
                                            RateOfInterestValue_InstallmentOrderUC.Text = "1.1";
                                            return false;

                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Rate Of intereset EMPTY !");
                                        RateOfInterestValue_InstallmentOrderUC.Text = "1.1";
                                        return false;
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("Number OF months should be more 1 or more");
                                    NumberOfMonthsValue_InstallmentOrderUC.Text = "1";
                                    return false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Enter a valid Number Of months");
                                NumberOfMonthsValue_InstallmentOrderUC.Text = "1";
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Number Of Months Value is empty !");
                            NumberOfMonthsValue_InstallmentOrderUC.Text = "1";
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Diposit value Should be more than 0 And less Than Total price before installment ");
                        DipositValue_InstallmentOrderUC.Text = "0";
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Diposit Value should be a number");
                    DipositValue_InstallmentOrderUC.Text = "0";
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Diposit Value is empty !");
                DipositValue_InstallmentOrderUC.Text = "0";
                return false;
            }

         
            return true;
        }


        private void DipositValue_InstallmentOrderUC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                UpdateInstallmentValues();
            }
                
        }
        private void NumberOfMonthsValue_InstallmentOrderUC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                UpdateInstallmentValues();
            }
        }

        private void RateOfInterestValue_InstallmentOrderUC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                UpdateInstallmentValues();
            }
        }


        private void RemoveSelectedProductButton_InstallmentOrderUC_Click(object sender, RoutedEventArgs e)
        {
            InstallmentProductModel installmentProduct = (InstallmentProductModel)ChoosenProductList_InstallmentOrderUC.SelectedItem;
            if (installmentProduct != null)
            {
                InstallmentProducts.Remove(installmentProduct);
                ChoosenProductList_InstallmentOrderUC.ItemsSource = null;
                ChoosenProductList_InstallmentOrderUC.ItemsSource = InstallmentProducts;
                UpdateInstallmentValues();
            }
            else
            {
                MessageBox.Show("Select a Product to remove from the list !");
            }
        }

        #endregion


    }
}
