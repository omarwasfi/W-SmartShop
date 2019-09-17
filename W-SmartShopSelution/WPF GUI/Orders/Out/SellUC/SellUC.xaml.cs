using Library;
using Stimulsoft.Report;
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
using WPF_GUI.CreateCutomer;

namespace WPF_GUI.Sell
{
    // TODO - Close Tab Button 
    // TODO - Print Button
    // TODO - Fix Bug If user press add before conferm the quantity , saleprice or discount

    /// <summary>
    /// Interaction logic for SellUC.xaml
    /// </summary>
    public partial class SellUC : UserControl , ICustomerRequester 
    {
        #region Main Variables


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


        // order chash
        /// <summary>
        /// List Of the new OrderProduct
        /// </summary>
        private List<OrderProductModel> Orders { get; set; } = new List<OrderProductModel>();

        /// <summary>
        /// The New Order
        /// </summary>
        private OrderModel Order { get; set; } = new OrderModel();

        /// <summary>
        /// The Customer Model
        /// </summary>
        private CustomerModel Customer { get; set; } = new CustomerModel();
        // Customer


        #endregion


        #region Help Variables

        /// <summary>
        /// 
        /// All The Customer
        /// </summary>
        private List<CustomerModel> Customers { get; set; }
        private List<string> CustomersFullNames { get; set; } = new List<string>();
        private List<string> CustomersPhoneNumbers { get; set; } = new List<string>();
        private List<string> CustomersNationalNumbers { get; set; } = new List<string>();
        private List<string> AllProductsBarCode { get; set; } = new List<string>();

        private List<StockModel> FStocks { get; set; }


        /// <summary>
        /// Manage If we can Filter Products or not 
        /// Use when user done choose the Stocks
        /// </summary>
        bool CanFilterStocks = true;


#endregion


        public SellUC()
        {
            InitializeComponent();
            SetInitialValues();
            


        }



        #region set tha Main variabels from the database
        /// <summary>
        /// Get All the categories from the PublicVariables
        /// </summary>
        private void GetCategoriesFromPublicVariables()
        {
            PublicVariables.Categories = null;
            PublicVariables.Categories = GlobalConfig.Connection.GetCategories();
            Categories = null;
            Categories = PublicVariables.Categories;
        }

        /// <summary>
        /// Get All brands from the PublicVariables
        /// </summary>
        private void GetBrandsFromPublicVariables()
        {
            PublicVariables.Brands = null;
            PublicVariables.Brands = GlobalConfig.Connection.GetBrands();
            Brands = null;
            Brands = PublicVariables.Brands;
        }

        /// <summary>
        /// Get The Stocks for this store from the PublicVariables
        /// </summary>
        private void GetStocksFormThePublicVariables()
        {
            PublicVariables.LoginStoreStocks = null;
            PublicVariables.LoginStoreStocks = GlobalConfig.Connection.FilterStocksByStore(PublicVariables.Store);
            Stocks = null;
            Stocks = PublicVariables.LoginStoreStocks;
        }

        

        /// <summary>
        /// Get All Customers from the PublicVariables
        /// </summary>
        private void GetCustomersFromPublicVariables()
        {
            PublicVariables.Customers = null;
            PublicVariables.Customers = GlobalConfig.Connection.GetCustomers();
            Customers = null;
            Customers = PublicVariables.Customers;
        }

        /// <summary>
        /// Update All the lists in the UC , 
        /// initialize the uc OR to clear the uc OR Update everything from the database
        /// </summary>
        private void SetInitialValues()
        {

            Update_CategoryValue_Sell();
            Update_BrandValue_Sell();

            // For CustomerNameValue_Sell
            Update_CustomerNamesVariablesAndEvents();

            Update_StocksVariablesAndEvents();

            UserGrid_SellUC.Visibility = Visibility.Visible;
            PrintGrid_SellUC.Visibility = Visibility.Collapsed;

        }

        /// <summary>
        /// Fill the AllProductsBarCode list with all the barcodes, add the search, auto Complete events
        /// </summary>
        private void Update_StocksVariablesAndEvents()
        {

            Update_ProductValue_Sell();
            
            foreach(StockModel stock in Stocks)
            {
                AllProductsBarCode.Add(stock.Product.BarCode);
            }
            BarCodeValue_Sell.PreviewKeyDown += DelPressed_BarCodeValue_Sell;


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
            GetCategoriesFromPublicVariables();
            CategoryValue_Sell.ItemsSource = Categories;
            CategoryValue_Sell.DisplayMemberPath = "Name";
            CategoryValue_Sell.SelectedItem = null;

        }

        /// <summary>
        /// update BrandValue_Sell combobox from the database
        /// </summary>
        private void Update_BrandValue_Sell()
        {
            GetBrandsFromPublicVariables();
            BrandValue_Sell.ItemsSource = Brands;
            BrandValue_Sell.DisplayMemberPath = "Name";
            BrandValue_Sell.SelectedItem = null;
        }

        /// <summary>
        /// update ProductValue_Sell combobox from the database
        /// </summary>
        private void Update_ProductValue_Sell()
        {
            GetStocksFormThePublicVariables();
            ProductValue_Sell.ItemsSource = Stocks;
            ProductValue_Sell.DisplayMemberPath = "Product.Name";
            ProductValue_Sell.SelectedItem = null;
        }
        #endregion

        #region Product Groopbox events


        /// <summary>
        /// Events for BarcodeValue_Sell changes to auto complete
        /// source : https://stackoverflow.com/questions/950770/autocomplete-textbox-in-wpf
        /// </summary>
        private bool InProg_BarCodeValue_Sell;
        private void BarCodeValue_Sell_TextChanged(object sender, TextChangedEventArgs e)
        {
            var change = e.Changes.FirstOrDefault();
            if (!InProg_BarCodeValue_Sell)
            {
                InProg_BarCodeValue_Sell = true;
                var culture = new CultureInfo(CultureInfo.CurrentCulture.Name);
                var source = ((TextBox)sender);
                if (((change.AddedLength - change.RemovedLength) > 0 || source.Text.Length > 0) && !DelKeyPressed_BarCodeValue_Sell)
                {
                    if (AllProductsBarCode.Where(x => x.IndexOf(source.Text, StringComparison.CurrentCultureIgnoreCase) == 0).Count() > 0)
                    {
                        var _appendtxt = AllProductsBarCode.FirstOrDefault(ap => (culture.CompareInfo.IndexOf(ap, source.Text, CompareOptions.IgnoreCase) == 0));
                        _appendtxt = _appendtxt.Remove(0, change.Offset + 1);
                        source.Text += _appendtxt;
                        source.SelectionStart = change.Offset + 1;
                        source.SelectionLength = source.Text.Length;
                    }
                }
                InProg_BarCodeValue_Sell = false;
            }
        }
        private static bool DelKeyPressed_BarCodeValue_Sell;
        internal static void DelPressed_BarCodeValue_Sell(object sender, KeyEventArgs e)
        { if (e.Key == Key.Back) { DelKeyPressed_BarCodeValue_Sell = true; } else { DelKeyPressed_BarCodeValue_Sell = false; } }


        /// <summary>
        /// Trigers when enter key down while selecting PhoneNumberValue_Sell
        /// Compares the current value of the PhoneNumberValue_Sell with customersPhones  list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BarCodeValue_Sell_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {

                foreach (StockModel stock in Stocks)
                {
                    
                   if (stock.Product.BarCode.Equals(BarCodeValue_Sell.Text, StringComparison.OrdinalIgnoreCase))
                   {
                        
                        ProductValue_Sell.SelectedItem = stock;
                        break;

                    }
                    
                    

                }
            }
        }

        /// <summary>
        /// Private event called when CategoryValue_Sell combobox OR BrandValue_Sell combobox sellection  changed to filter the products combobox by selected category or brand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FilterProductsByCategoryAndBrand(object sender, SelectionChangedEventArgs e)
        {
            if (CanFilterStocks)
            {
                FStocks = GlobalConfig.Connection.FilterStocksByCategoryAndBrand(Stocks, (CategoryModel)CategoryValue_Sell.SelectedItem, (BrandModel)BrandValue_Sell.SelectedItem);
                
                    ProductValue_Sell.ItemsSource = null;
                    ProductValue_Sell.ItemsSource = FStocks;
                    ProductValue_Sell.DisplayMemberPath = "Product.Name";
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
            StockModel product = (StockModel)ProductValue_Sell.SelectedItem;
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
        private void UpdateProductInfo(StockModel product)
        {
            InProg_BarCodeValue_Sell = true;

            BarCodeValue_Sell.Text = product.Product.BarCode;


            SerialNumberValue_Sell.Text = product.Product.SerialNumber;
            SerialNumber2Value_Sell.Text = product.Product.SerialNumber2;

            InStockValue_Sell.Text = product.Quantity.ToString();

            PriceValue_Sell.IsEnabled = true;
            PriceValue_Sell.Text = product.Product.SalePrice.ToString();

            DetailsValue_Sell.Text = product.Product.Details;

            DiscountValue_Sell.IsEnabled = true;
            DiscountValue_Sell.Text = "0";

            QuantityValue_Sell.IsEnabled = true;
            QuantityValue_Sell.Text = "1";

            TotalProductPriceValue_Sell.Text = product.Product.SalePrice.ToString();
            

            CanFilterStocks = false;
            CategoryValue_Sell.SelectedIndex = Get_CategoryValue_Sell_Index(product.Product.Category);
            BrandValue_Sell.SelectedIndex = Get_BrandValue_Sell_Index(product.Product.Brand);
            CanFilterStocks = true;


            InProg_BarCodeValue_Sell = false;
        }

        /// <summary>
        /// Clear product info
        /// Serial Number , Sale Price
        /// </summary>
        private void ClearProductInfo()
        {
            InProg_BarCodeValue_Sell = true;

            BarCodeValue_Sell.Text = "";

            SerialNumberValue_Sell.Text = "";
            SerialNumber2Value_Sell.Text = "";

            DetailsValue_Sell.Text = "";

            InStockValue_Sell.Text = "";


            PriceValue_Sell.IsEnabled = false;
            PriceValue_Sell.Text = "";

            DiscountValue_Sell.IsEnabled = false;
            DiscountValue_Sell.Text = "";

            QuantityValue_Sell.IsEnabled = false;
            QuantityValue_Sell.Text = "";


            TotalProductPriceValue_Sell.Text = "";

            InProg_BarCodeValue_Sell = false;
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
                StockModel stock = GlobalConfig.Connection.GetStockBySerialNumber(Stocks, SerialNumberValue_Sell.Text);
                if(stock == null)
                {
                    MessageBox.Show("This Serial Number Not Exist");
                }
                else
                {
                    ProductValue_Sell.SelectedItem = stock;
                }
            }
        }

        /// <summary>
        /// Enter key Pressed while selecting SerialNumber2Value_Sell
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SerialNumber2Value_Sell_EventHundler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                StockModel stock = GlobalConfig.Connection.GetStockBySerialNumber(Stocks, SerialNumber2Value_Sell.Text);
                if (stock == null)
                {
                    MessageBox.Show("This Serial Number Not Exist");
                }
                else
                {
                    ProductValue_Sell.SelectedItem = stock;
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

                StockModel stock = (StockModel)ProductValue_Sell.SelectedItem;

                if (ChooseStock_IsValid())
                {
                    TotalProductPriceValue_Sell.Text =
                        GlobalConfig.Connection.GetTotalPriceValue(decimal.Parse(PriceValue_Sell.Text), int.Parse(QuantityValue_Sell.Text)).ToString();

                }

                /*StockModel stock = (StockModel)ProductValue_Sell.SelectedItem;
                decimal price = new decimal();
                int quantity = new int();
                if (int.TryParse(QuantityValue_Sell.Text, out quantity))
                {
                    if(quantity > int.Parse(InStockValue_Sell.Text))
                    {

                        MessageBox.Show("No enough peaces in the stock");

                       
                    }
                    else
                    {
                        if (decimal.TryParse(PriceValue_Sell.Text, out price))
                        {
                            TotalProductPriceValue_Sell.Text = GlobalConfig.Connection.GetTotalPriceValue(price, quantity).ToString();
                        }
                        else
                        {
                            MessageBox.Show("Price is not valid");
                            PriceValue_Sell.Text = stock.Product.SalePrice.ToString();
                        }
                    }
                   
                }
                else
                {
                    MessageBox.Show("Quantity is not Valid");
                    QuantityValue_Sell.Text = "1";
                }*/

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
                StockModel stock = (StockModel)ProductValue_Sell.SelectedItem;

                if (ChooseStock_IsValid())
                {
                    PriceValue_Sell.Text = GlobalConfig.Connection.GetPriceValue(decimal.Parse(DiscountValue_Sell.Text), stock.Product).ToString();
                    TotalProductPriceValue_Sell.Text =
                        GlobalConfig.Connection.GetTotalPriceValue(decimal.Parse(PriceValue_Sell.Text), int.Parse(QuantityValue_Sell.Text)).ToString();

                }

                /*StockModel stock = (StockModel)ProductValue_Sell.SelectedItem;
                decimal price = stock.Product.SalePrice;
                decimal discount = new decimal();
                int quantity = new int();
                if (int.TryParse(QuantityValue_Sell.Text, out quantity))
                {
                    if (decimal.TryParse(DiscountValue_Sell.Text, out discount))
                    {
                        price = GlobalConfig.Connection.GetPriceValue(discount, stock.Product);
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
                }*/

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


               

                StockModel stock = (StockModel)ProductValue_Sell.SelectedItem;
                if (ChooseStock_IsValid())
                {
                    DiscountValue_Sell.Text = GlobalConfig.Connection.GetDiscountValue(decimal.Parse(PriceValue_Sell.Text), stock.Product).ToString();
                    TotalProductPriceValue_Sell.Text =
                        GlobalConfig.Connection.GetTotalPriceValue(decimal.Parse(PriceValue_Sell.Text), int.Parse(QuantityValue_Sell.Text)).ToString();
                }

                /*
                decimal price = new decimal();
                decimal discount = new decimal();
                int quantity = new int();

                if (int.TryParse(QuantityValue_Sell.Text, out quantity))
                {
                    if (decimal.TryParse(PriceValue_Sell.Text,out price))
                    {
                        discount = GlobalConfig.Connection.GetDiscountValue(price, stock.Product);
                        if(discount == -1)
                        {
                            MessageBox.Show("Price is less than 0");
                            PriceValue_Sell.Text = stock.Product.SalePrice.ToString();
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
                        PriceValue_Sell.Text = stock.Product.SalePrice.ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Quantity is not valid");
                    QuantityValue_Sell.Text = "1";
                }*/

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
        /// Check each senario of error and send message box to ask the guid the user
        /// Add button clicked 
        /// Craete orderproduct model and add it to orders list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddProductButton_Sell_Click(object sender, RoutedEventArgs e)
        {

            // bool Save = true;
            // check each case

            /* if (stock == null)
             {
                 MessageBox.Show("Select Product First");
             }

             else
             {
                 decimal salePrice = new decimal();
                 decimal discount = new decimal();
                 int quantity = new int();

                 if(int.TryParse(QuantityValue_Sell.Text, out quantity))
                 {
                     if(quantity > 0)
                     {
                         if(quantity > int.Parse(InStockValue_Sell.Text))
                         {
                             MessageBox.Show("No enough in the stock , reduse the number of quantity");
                             MessageBox.Show("Make Sure to confirm by Press {enter} after Change any of (Price , Discount , Quantity)");
                         }
                         else
                         {
                             if (decimal.TryParse(PriceValue_Sell.Text, out salePrice))
                             {
                                 if (salePrice >= 0)
                                 {
                                     if (decimal.TryParse(DiscountValue_Sell.Text, out discount))
                                     {
                                         if (discount > stock.Product.SalePrice)
                                         {
                                             MessageBox.Show("Discount Invalid");
                                             MessageBox.Show("Make Sure to confirm by Press {enter} after Change any of (Price , Discount , Quantity)");
                                             Save = false;
                                         }
                                         else
                                         {

                                         }
                                     }
                                     else
                                     {
                                         MessageBox.Show("Discount Invalid");
                                         MessageBox.Show("Make Sure to confirm by Press {enter} after Change any of (Price , Discount , Quantity)");
                                         Save = false;
                                     }
                                 }
                                 else
                                 {
                                     MessageBox.Show("Price less than 0");
                                     MessageBox.Show("Make Sure to confirm by Press {enter} after Change any of (Price , Discount , Quantity)");
                                     Save = false;
                                 }

                             }
                             else
                             {
                                 MessageBox.Show("Price Invalid");
                                 MessageBox.Show("Make Sure to confirm by Press {enter} after Change any of (Price , Discount , Quantity)");
                                 Save = false;
                             }
                         }

                     }
                     else
                     {
                         MessageBox.Show("Quantity Is less than 1");
                         MessageBox.Show("Make Sure to confirm by Press {enter} after Change any of (Price , Discount , Quantity)");
                         Save = false;
                     }
                 }
                 else
                 {
                     MessageBox.Show("Quantity Invalid");
                     MessageBox.Show("Make Sure to confirm by Press {enter} after Change any of (Price , Discount , Quantity)");
                     Save = false;
                 }


             }*/

            StockModel stock = (StockModel)ProductValue_Sell.SelectedItem;


            if (ChooseStock_IsValid())
            {
                OrderProductModel orderProduct = new OrderProductModel();
                orderProduct.Stock = stock;
                orderProduct.Product = stock.Product;
                orderProduct.SalePrice = decimal.Parse(PriceValue_Sell.Text);
                orderProduct.Discount = decimal.Parse(DiscountValue_Sell.Text);
                orderProduct.Profit = orderProduct.GetProfit;
                orderProduct.Quantity = int.Parse(QuantityValue_Sell.Text);
                orderProduct.TotalProductPrice = decimal.Parse(TotalProductPriceValue_Sell.Text);
                Orders.Add(orderProduct);
                // Update Choosen product list datagrid
                UpadateChoosenProductList_Sell();
            }
            

        }


        /// <summary>
        /// Check choose stock valus if it vaild or not
        /// </summary>
        /// <returns> 
        /// true if vaild 
        /// false if not </returns>
        private bool ChooseStock_IsValid()
        {
            StockModel stock = (StockModel)ProductValue_Sell.SelectedItem;

            if (stock != null)
            {
                decimal salePrice = new decimal();
                if (decimal.TryParse(PriceValue_Sell.Text, out salePrice))
                {
                    if (salePrice > 0)
                    {
                        decimal discount = new decimal();

                        if (decimal.TryParse(DiscountValue_Sell.Text, out discount))
                        {
                            if (discount >= 0 && discount < stock.Product.SalePrice)
                            {
                                int quantity = new int();
                                if (int.TryParse(QuantityValue_Sell.Text, out quantity))
                                {
                                    if (quantity > 0 && quantity <= stock.Quantity)
                                    {


                                        foreach (OrderProductModel order in Orders)
                                        {
                                            if (order.Product.Id == stock.Product.Id)
                                            {
                                                MessageBox.Show("This product is in the the list , please remove it and add again with the new info");
                                                return false;
                                            }
                                        }

                                        return true;


                                    }
                                    else
                                    {
                                        MessageBox.Show("Quantity can't be less than 1 OR more than the number of stock quantity");
                                        QuantityValue_Sell.Text = "0";
                                        return false;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Quantity should be a number");
                                    QuantityValue_Sell.Text = "0";
                                    return false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Income Price Can't be less than 0.001 And Can't be more than the product sale Price");
                                DiscountValue_Sell.Text = "";
                                return false;
                            }

                        }
                        else
                        {
                            MessageBox.Show("Discount Should be a number !");
                            DiscountValue_Sell.Text = "";
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sale Price Can't be less than 0.001");
                        PriceValue_Sell.Text = stock.Product.SalePrice.ToString();
                        return false;
                    }

                }
                else
                {
                    MessageBox.Show("Sale Price value should be a number");
                    PriceValue_Sell.Text = stock.Product.SalePrice.ToString();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Choose product , If it not exist press Create new Product");
                return false;
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
            UpdateTotalPriceAndTotalProfit();
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


        private bool InProg_CustomerNameValue_Sell;
        /// <summary>
        /// Events for CustomerValue changes to auto complete
        /// source : https://stackoverflow.com/questions/950770/autocomplete-textbox-in-wpf
        /// </summary>
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
        private void UpdateTotalPriceAndTotalProfit()
        {
            decimal TotalPrice = new decimal();
            decimal TotalOrderProfit = new decimal();
            foreach (OrderProductModel orderProduct in Orders)
            {
                TotalPrice += orderProduct.TotalProductPrice;
                
                TotalOrderProfit += orderProduct.GetTotalProfit;
            }
            TotalPriceValue_Sell.Text = TotalPrice.ToString();
            TotalOrderProfitValue_Sell.Text = TotalOrderProfit.ToString();
            

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

            SaveTheOrder();

           

        }

        /// <summary>
        /// Check if the order vaild , it it's -> save to the database , Opens the printing tab
        /// </summary>
        private void SaveTheOrder()
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
                    Order.Details = OrderDetailsValue_Sell.Text;

                    GlobalConfig.Connection.SaveOrderToDatabase(Order);


                    foreach (OrderProductModel orderProduct in Orders)
                    {
                        GlobalConfig.Connection.ReduseStock(orderProduct.Stock, orderProduct.Quantity);
                    }

                    PublicVariables.LoginStoreStocks = GlobalConfig.Connection.FilterStocksByStore(Store);

                    if (MessageBox.Show("Do you want to print the order ?", "Printing...", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        PrintTheOrder();

                    }
                }




            }
        }


        /// <summary>
        /// Clear the product info and the customer info
        /// reset the choosen products datagrid
        /// </summary>
        private void ResetSellUC()
        {
            ClearCustomerInfo();
            Stocks = PublicVariables.LoginStoreStocks;
            CategoryValue_Sell.SelectedItem = null;
            BrandValue_Sell.SelectedItem = null;
            Orders = new List<OrderProductModel>();
            ChoosenProductList_Sell.ItemsSource = null;
            TotalPriceValue_Sell.Text = "";

            PublicVariables.Orders = GlobalConfig.Connection.GetOrders();
        }


        /// <summary>
        /// Show the user Control in a new window 
        /// source: https://stackoverflow.com/questions/1262115/how-do-you-display-a-custom-usercontrol-as-a-dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewCustomerButton_Sell_Click(object sender, RoutedEventArgs e)
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



        private void SelectedCustomerLogButton_Sell_Click(object sender, RoutedEventArgs e)
        {

            CustomerLogUC.CustomerLogUC customerLogUC = new CustomerLogUC.CustomerLogUC( Customer);
            Window window = new Window
            {
                Title = "Customer Log",
                Content = customerLogUC,
                SizeToContent = SizeToContent.WidthAndHeight,
                ResizeMode = ResizeMode.NoResize
            };
            window.ShowDialog();
            
        }



        private void ReloadTabButton_SellUC_Click(object sender, RoutedEventArgs e)
        {
            SetInitialValues();
            ResetSellUC();

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
        /// Money validation for any text accepts money
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IntergerValidation(object sender, TextCompositionEventArgs e)
        {
            GlobalConfig.NumberValidation.IntegerValidationTextBox(sender, e);
        }



        private void PrintButton_SellUC_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Do you want to save the order ?" , "Are you sure ?" , MessageBoxButton.YesNo,MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                SaveTheOrder();
                
            }

            

        }

        /// <summary>
        /// Opens the printing tab and fill the prining info
        /// </summary>
        private void PrintTheOrder()
        {
            UserGrid_SellUC.Visibility = Visibility.Collapsed;
            PrintGrid_SellUC.Visibility = Visibility.Visible;


            StiReport report = new StiReport();
            // add the data to the datastore
            report.Load(@"SellOrderReport.mrt");

            report.Compile();

            report["OrganizationName"] = PublicVariables.OrganizationName;
            report["OrganizationAddress"] = PublicVariables.OrganizationAddress;
            report["OrganizationPhoneNumber"] = PublicVariables.OrganizationPhoneNumber;

            report["DateTime"] = Order.DateTimeOfTheOrder.ToShortTimeString();
            report["StaffName"] = Order.Staff.Person.FullName;
            report["StoreName"] = Order.Store.Name;
            report["StorePhoneNumber"] = Order.Store.PhoneNumber;
            report["StoreAddress"] = Order.Store.Address;
            report["OrderId"] = Order.Id;



            report["CustomerName"] = Order.Customer.Person.FullName;
            report["CustomerPhoneNumber"] = Order.Customer.Person.PhoneNumber;
            report["CustomerNationalNumber"] = Order.Customer.Person.NationalNumber;

            report["OrderDetails"] = Order.Details;
            report["TotalPrice"] = Order.TotalPrice.ToString();

            report.Render();

            SellOrderReportPrint_SellUC.Report = report;
        }


        #endregion

        #region Print Grid

        private void BackToNormalGridButton_SellUC_Click(object sender, RoutedEventArgs e)
        {
            SetInitialValues();
            ResetSellUC();
        }


        #endregion

        
    }

}

