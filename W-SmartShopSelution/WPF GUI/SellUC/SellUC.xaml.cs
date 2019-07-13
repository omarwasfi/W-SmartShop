using Library;
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


namespace WPF_GUI.Sell
{
    // TODO - Close Tab Button 
    // TODO - Print Button
    // TODO - In customer group box Create new customer button ,  Selected customer log button

    /// <summary>
    /// Interaction logic for SellUC.xaml
    /// </summary>
    public partial class SellUC : UserControl
    {
        #region Main Variabels

        // TODO - Set the store the Current store
        // Store
        public StoreModel Store { get; set; } = new StoreModel { Id = 500, Name = "Default" };

        // TODO - Set the current staff
        // Staff
        public StaffModel Staff { get; set; } = new StaffModel { Id = 1000 };

        // Goods
        public List<CategoryModel> Categories { get; set; }
        public List<BrandModel> Brands { get; set; }
        public List<ProductModel> Products { get; set; }

        // order chash
        public List<OrderProductModel> Orders { get; set; } = new List<OrderProductModel>();
        public OrderModel Order { get; set; } = new OrderModel();
        public CustomerModel Customer { get; set; } = new CustomerModel();
        // Customer

        public List<CustomerModel>  Customers { get; set; }
        public List<string> CustomersFullNames { get; set; } = new List<string>();
        public List<string> CustomersPhoneNumbers { get; set; } = new List<string>();
        public List<string> CustomersNationalNumbers { get; set; } = new List<string>();
        #endregion


        #region Helpfull variabels
        /// <summary>
        /// List Of Products after Filtring
        /// </summary>
        public List<ProductModel> FProducts { get; set; }

        /// <summary>
        /// Manage If we can Filter Products or not 
        /// Use when user done choose the product
        /// </summary>
        bool CanFilterProducts = true;

#endregion


        public SellUC()
        {
            InitializeComponent();
            FillStartupData();
            


        }

       

#region set tha Main variabels from the database
        /// <summary>
        /// Get All the categories from the Database`
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
        /// Get All Customers from the database
        /// </summary>
        private void GetCustomersFromDatabase()
        {
            // TODO - Get Customers from database
            Customers = GlobalConfig.Connection.GetCustomers();
        }

        /// <summary>
        /// Update All the lists in the UC , 
        /// initialize the uc OR to clear the uc OR Update everything from the database
        /// </summary>
        private void FillStartupData()
        {
            Update_CategoryValue_Sell();
            Update_BrandValue_Sell();
            Update_ProductValue_Sell();

            // For CustomerNameValue_Sell
            Update_CustomerNamesVariablesAndEvents();



        }

        /// <summary>
        /// Add Customers full Names into 1 list 
        /// Add customers PhoneNumbers into 1 list
        /// Add Customers NationalNumbers into 1 list
        /// Add delete pressed event for CustomerNameValue_Sell
        /// </summary>
        private void Update_CustomerNamesVariablesAndEvents()
        {
            GetCustomersFromDatabase();
            foreach (CustomerModel customer in Customers)
            {

                CustomersFullNames.Add(customer.Person.FullName);

                if (customer.Person.PhoneNumber != null)
                    CustomersPhoneNumbers.Add(customer.Person.PhoneNumber);

                if (customer.Person.NationalNumber != null)
                    CustomersNationalNumbers.Add(customer.Person.NationalNumber);
               
            }
            CustomerNameValue_Sell.PreviewKeyDown +=DelPressed_CustomerNameValue_Sell ;
            PhoneNumberValue_Sell.PreviewKeyDown += DelPressed_PhoneNumberValue_Sell;
            NationalNumberValue_Sell.PreviewKeyDown += DelPressed_NationalNumberValue_Sell;

            

            UpdateCustomerInfo(GlobalConfig.Connection.GetDefaultCustomer());
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
        #endregion

        #region Product Groopbox events

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
        /// Update product info Called after User choose the product
        /// Category , Brand ,  Serial Number , Sale Price , discount , quantity Total Price
        /// </summary>
        /// <param name="product"></param>
        private void UpdateProductInfo(ProductModel product)
        {
            SerialNumberValue_Sell.Text = product.SerialNumber;

            PriceValue_Sell.IsEnabled = true;
            PriceValue_Sell.Text = product.SalePrice.ToString();

            DiscountValue_Sell.IsEnabled = true;
            DiscountValue_Sell.Text = "0";

            QuantityValue_Sell.IsEnabled = true;
            QuantityValue_Sell.Text = "1";

            TotalProductPriceValue_Sell.Text = product.SalePrice.ToString();

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

            PriceValue_Sell.IsEnabled = false;
            PriceValue_Sell.Text = "";

            DiscountValue_Sell.IsEnabled = false;
            DiscountValue_Sell.Text = "";

            QuantityValue_Sell.IsEnabled = false;
            QuantityValue_Sell.Text = "";

            TotalProductPriceValue_Sell.Text = "";
        }

        
        /// <summary>
        /// Enter key Pressed while selecting SerialNumberValue_Sell
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SerialNumberValue_Sell_EventHundler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ProductModel product = GlobalConfig.Connection.GetProductBySerialNumber(Products, SerialNumberValue_Sell.Text);
                if(product == null)
                {
                    MessageBox.Show("This Serial Number Not Exist");
                }
                else
                {
                    ProductValue_Sell.SelectedItem = product;
                }
            }
        }


        /// <summary>
        /// Triggers after Enter key down while selecting QuantityValue_Sell.
        /// Update the Total Price Product value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuantityValue_Sell_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ProductModel product = (ProductModel)ProductValue_Sell.SelectedItem;
                decimal price = new decimal();
                int quantity = new int();
                if (int.TryParse(QuantityValue_Sell.Text, out quantity))
                {
                    if (decimal.TryParse(PriceValue_Sell.Text, out price))
                    {
                        TotalProductPriceValue_Sell.Text =  GlobalConfig.Connection.GetTotalPriceValue(price, quantity).ToString();
                    }
                    else
                    {
                        MessageBox.Show("Price is not valid");
                        PriceValue_Sell.Text = product.SalePrice.ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Quantity is not Valid");
                    QuantityValue_Sell.Text = "1";
                }
                
            }

        }


        /// <summary>
        /// Triggers after Enter key down while selecting DiscountValue_Sell.
        /// Update the Total Price Product value and Price value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DiscountValue_Sell_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ProductModel product = (ProductModel)ProductValue_Sell.SelectedItem;
                decimal price = product.SalePrice;
                decimal discount = new decimal();
                int quantity = new int();
                if (int.TryParse(QuantityValue_Sell.Text, out quantity))
                {
                    if (decimal.TryParse(DiscountValue_Sell.Text, out discount))
                    {
                        price = GlobalConfig.Connection.GetPriceValue(discount, product);
                        if (price == -1)
                        {
                            MessageBox.Show("Discount is Not valid");
                        }
                        else
                        {
                            PriceValue_Sell.Text = price.ToString();
                            TotalProductPriceValue_Sell.Text = GlobalConfig.Connection.GetTotalPriceValue(price,quantity ).ToString();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Discount is not valid");
                        DiscountValue_Sell.Text = "0";
                    }
                }
                else
                {
                    MessageBox.Show("Quantity is not valid");
                    QuantityValue_Sell.Text = "1";
                }

            }
        }

        /// <summary>
        /// Triggers when enter key down while selecting pricevalue to update the discount value and total product price value 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PriceValue_Sell_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ProductModel product = (ProductModel)ProductValue_Sell.SelectedItem;
                decimal price = new decimal();
                decimal discount = new decimal();
                int quantity = new int();

                if (int.TryParse(QuantityValue_Sell.Text, out quantity))
                {
                    if (decimal.TryParse(PriceValue_Sell.Text,out price))
                    {
                        discount = GlobalConfig.Connection.GetDiscountValue(price, product);
                        if(discount == -1)
                        {
                            MessageBox.Show("Price is less than 0");
                            PriceValue_Sell.Text = product.SalePrice.ToString();
                        }
                        else
                        {
                            DiscountValue_Sell.Text = discount.ToString();
                            TotalProductPriceValue_Sell.Text = GlobalConfig.Connection.GetTotalPriceValue(price,quantity).ToString();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Price is not valid");
                        PriceValue_Sell.Text = product.SalePrice.ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Quantity is not valid");
                    QuantityValue_Sell.Text = "1";
                }

            }
        }

        /// <summary>
        /// Reset Choose Product groupe box By set category and brand to null
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearProductButton_Sell_Click(object sender, RoutedEventArgs e)
        {
            CategoryValue_Sell.SelectedItem = null;
            BrandValue_Sell.SelectedItem = null;
        }



        

        /// <summary>
        /// Add button clicked 
        /// Craete orderproduct model and add it to orders list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddProductButton_Sell_Click(object sender, RoutedEventArgs e)
        {
            ProductModel product = (ProductModel)ProductValue_Sell.SelectedItem;
            if (product == null)
            {
                MessageBox.Show("Select Product First");
            }
            else
            {
                OrderProductModel orderProduct = new OrderProductModel();
                orderProduct.Product = product;
                orderProduct.SalePrice = decimal.Parse(PriceValue_Sell.Text);
                orderProduct.Discount = decimal.Parse(DiscountValue_Sell.Text);
                orderProduct.Quantity = int.Parse(QuantityValue_Sell.Text);
                orderProduct.TotalProductPrice = decimal.Parse(TotalProductPriceValue_Sell.Text);
                Orders.Add(orderProduct);
                // Update Choosen product list datagrid
                UpadateChoosenProductList_Sell();
            }

        }
        #endregion

        #region ChoosenProductList_Sell Data Grid

        /// <summary>
        /// update the choosen product list with orders list
        /// </summary>
        private void UpadateChoosenProductList_Sell()
        {
            ChoosenProductList_Sell.ItemsSource = null;
            ChoosenProductList_Sell.ItemsSource = Orders;

            // Updates Total Price
            UpdateTotalPrice();
        }

        /// <summary>
        /// Remove selected ordermodel from the orders list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveSelectedProductButton_Sell_Click(object sender, RoutedEventArgs e)
        {
            OrderProductModel orderProduct;
            orderProduct = (OrderProductModel)ChoosenProductList_Sell.SelectedItem;
            Orders.Remove(orderProduct);
            UpadateChoosenProductList_Sell();
        }


        #endregion

        
        #region Customer GroupeBox


        /// <summary>
        /// Events for CustomerValue changes to auto complete
        /// source : https://stackoverflow.com/questions/950770/autocomplete-textbox-in-wpf
        /// </summary>
        private bool InProg_CustomerNameValue_Sell;
        private void CustomerNameValue_Sell_TextChanged(object sender, TextChangedEventArgs e)
        {
            var change = e.Changes.FirstOrDefault();
            if (!InProg_CustomerNameValue_Sell)
            {
                InProg_CustomerNameValue_Sell = true;
                var culture = new CultureInfo(CultureInfo.CurrentCulture.Name);
                var source = ((TextBox)sender);
                if (((change.AddedLength - change.RemovedLength) > 0 || source.Text.Length > 0) && !DelKeyPressed_CustomerNameValue_Sell)
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
                InProg_CustomerNameValue_Sell = false;
            }
        }
        private static bool DelKeyPressed_CustomerNameValue_Sell;
        internal static void DelPressed_CustomerNameValue_Sell(object sender, KeyEventArgs e)
        { if (e.Key == Key.Back) { DelKeyPressed_CustomerNameValue_Sell = true; } else { DelKeyPressed_CustomerNameValue_Sell = false; } }


        /// <summary>
        /// Events for PhoneNumberValue_Sell changes to auto complete
        /// source : https://stackoverflow.com/questions/950770/autocomplete-textbox-in-wpf
        /// </summary>
        private bool InProg_PhoneNumberValue_Sell;
        private void PhoneNumberValue_Sell_TextChanged(object sender, TextChangedEventArgs e)
        {
            var change = e.Changes.FirstOrDefault();
            if (!InProg_PhoneNumberValue_Sell)
            {
                InProg_PhoneNumberValue_Sell = true;
                var culture = new CultureInfo(CultureInfo.CurrentCulture.Name);
                var source = ((TextBox)sender);
                if (((change.AddedLength - change.RemovedLength) > 0 || source.Text.Length > 0) && !DelKeyPressed_PhoneNumberValue_Sell)
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
                InProg_PhoneNumberValue_Sell = false;
            }
        }
        private static bool DelKeyPressed_PhoneNumberValue_Sell;
        internal static void DelPressed_PhoneNumberValue_Sell(object sender, KeyEventArgs e)
        { if (e.Key == Key.Back) { DelKeyPressed_PhoneNumberValue_Sell = true; } else { DelKeyPressed_PhoneNumberValue_Sell = false; } }

        /// <summary>
        /// Events for PhoneNumberValue_Sell changes to auto complete
        /// source : https://stackoverflow.com/questions/950770/autocomplete-textbox-in-wpf
        /// </summary>
        private bool InProg_NationalNumberValue_Sell;
        private void NationalNumberValue_Sell_TextChanged(object sender, TextChangedEventArgs e)
        {
            var change = e.Changes.FirstOrDefault();
            if (!InProg_NationalNumberValue_Sell)
            {
                InProg_NationalNumberValue_Sell = true;
                var culture = new CultureInfo(CultureInfo.CurrentCulture.Name);
                var source = ((TextBox)sender);
                if (((change.AddedLength - change.RemovedLength) > 0 || source.Text.Length > 0) && !DelKeyPressed_NationalNumberValue_Sell)
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
                InProg_NationalNumberValue_Sell = false;
            }
        }
        private static bool DelKeyPressed_NationalNumberValue_Sell;
        internal static void DelPressed_NationalNumberValue_Sell(object sender, KeyEventArgs e)
        { if (e.Key == Key.Back) { DelKeyPressed_NationalNumberValue_Sell = true; } else { DelKeyPressed_NationalNumberValue_Sell = false; } }

        /// <summary>
        /// Trigers when enter key down while selecting customerNameValue
        /// Compares the current value of the customerNameValue with customers list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomerNameValue_Sell_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                
                foreach(CustomerModel c in Customers)
                {
                    if(c.Person.FullName.Equals(CustomerNameValue_Sell.Text,StringComparison.OrdinalIgnoreCase))
                    {
                        UpdateCustomerInfo(c);
                        
                    }
                    
                }
            }
        }

        /// <summary>
        /// Trigers when enter key down while selecting PhoneNumberValue_Sell
        /// Compares the current value of the PhoneNumberValue_Sell with customersPhones  list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PhoneNumberValue_Sell_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {

                foreach (CustomerModel customer in Customers)
                {
                    if (customer.Person.PhoneNumber != null)
                    {
                        if (customer.Person.PhoneNumber.Equals(PhoneNumberValue_Sell.Text))
                        {
                            UpdateCustomerInfo(customer);

                        }
                    }

                }
            }
        }

        /// <summary>
        /// Trigers when enter key down while selecting NationalNumberValue_Sell
        /// Compares the current value of the NationalNumberValue_Sell with customersNationalNumbers  list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NationalNumberValue_Sell_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {

                foreach (CustomerModel customer in Customers)
                {
                    if (customer.Person.NationalNumber != null)
                    {
                        if (customer.Person.NationalNumber.Equals(NationalNumberValue_Sell.Text))
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
        private void ClearCustomerButton_Sell_Click(object sender, RoutedEventArgs e)
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
            InProg_CustomerNameValue_Sell = true;
            InProg_PhoneNumberValue_Sell = true;
            InProg_NationalNumberValue_Sell = true;

            CustomerNameValue_Sell.Text = customer.Person.FullName;

            if(customer.Person.PhoneNumber != null)
                PhoneNumberValue_Sell.Text = customer.Person.PhoneNumber;
            if (customer.Person.NationalNumber != null)
                NationalNumberValue_Sell.Text = customer.Person.NationalNumber;

            InProg_CustomerNameValue_Sell = false;
            InProg_PhoneNumberValue_Sell = false;
            InProg_NationalNumberValue_Sell = false;

        }

        /// <summary>
        /// Cleare customer  Customer data from the customer groupbox
        /// </summary>
        private void ClearCustomerInfo()
        {
            InProg_CustomerNameValue_Sell = true;
            InProg_PhoneNumberValue_Sell = true;
            InProg_NationalNumberValue_Sell = true;

            CustomerNameValue_Sell.Text = "";
            PhoneNumberValue_Sell.Text = "";
            NationalNumberValue_Sell.Text = "";

            InProg_CustomerNameValue_Sell = false;
            InProg_PhoneNumberValue_Sell = false;
            InProg_NationalNumberValue_Sell = false;

        }
        #endregion

        #region Hole form

        /// <summary>
        /// Updates Total Price called by UpadateChoosenProductList_Sell
        /// gets order list and calculate the total price
        /// </summary>
        private void UpdateTotalPrice()
        {
            decimal TotalPrice = new decimal();
            foreach (OrderProductModel orderProduct in Orders)
            {
                TotalPrice += orderProduct.TotalProductPrice;
            }
            TotalPriceValue_Sell.Text = TotalPrice.ToString();

        }


        /// <summary>
        /// Make sure that customer and ordercount is not null
        /// Create the order and save it to the database
        /// reset the form at the end
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfirmButton_UC_Click(object sender, RoutedEventArgs e)
        {
            if (Customer == null)
            {
                MessageBox.Show("choose Customer first");

            }
            else
            {
                if (Orders.Count < 1)
                {
                    MessageBox.Show("Add Products to the order");
                }
                else
                {
                    Order.Staff = Staff;
                    Order.Store = Store;
                    Order.Products = Orders;
                    Order.Customer = Customer;
                    Order.DateTimeOfTheOrder = DateTime.Now;
                    Order.TotalPrice = decimal.Parse(TotalPriceValue_Sell.Text);

                    GlobalConfig.Connection.SaveOrderToDatabase(Order);
                    ResetSellUC();
                }

                
            }
            

        }

        /// <summary>
        /// event to reset the uc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearButton_UC_Click(object sender, RoutedEventArgs e)
        {
            ResetSellUC();

        }

        /// <summary>
        /// Clear the product info and the customer info
        /// reset the choosen products datagrid
        /// </summary>
        private void ResetSellUC()
        {
            ClearCustomerInfo();
            CategoryValue_Sell.SelectedItem = null;
            BrandValue_Sell.SelectedItem = null;
            Orders = new List<OrderProductModel>();
            ChoosenProductList_Sell.ItemsSource = null;
            TotalPriceValue_Sell.Text = "";
        }



        #endregion

        
    }

}

