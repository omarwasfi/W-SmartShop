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
using ValidationResult = FluentValidation.Results.ValidationResult;


namespace WPF_GUI.Sell
{


    /// <summary>
    /// Interaction logic for SellUC.xaml
    /// </summary>
    public partial class SellUC : UserControl 
    {
        #region Main Variables

        /// <summary>
        /// The new incomeorders of the Order
        /// </summary>
        List<OrderProductRecordModel> OrderProductRecords { get; set; }

        #endregion


        #region Help Variables

        /// <summary>
        /// The filterd products(Effected by brand And Category)
        /// </summary>
        private List<ProductModel> FProducts { get; set; }

        /// <summary>
        /// The filtered stocks after the product selected
        /// </summary>
        private List<StockModel> FStocks { get; set; }

        private Boolean CanSearchProduct { get; set; }



        #endregion

        #region set the initianl values


        public SellUC()
        {
            InitializeComponent();
            SetInitialValues();
        }
   
        private void SetInitialValues()
        {
            // Default Grids
            UserGrid.Visibility = Visibility.Visible;
            PrintGrid.Visibility = Visibility.Collapsed;
            CreateCustomerGrid.Visibility = Visibility.Collapsed;
            SelectedCustomerLogGrid.Visibility = Visibility.Collapsed;

            // Choose Product GroupBox
            // Category
            CategoryFilterValue.ItemsSource = null;
            CategoryFilterValue.ItemsSource = PublicVariables.Store.GetExistCategories;
            CategoryFilterValue.DisplayMemberPath = "Name";

            //Brand
            BrandFilterValue.ItemsSource = null;
            BrandFilterValue.ItemsSource = PublicVariables.Store.GetExistBrands;
            BrandFilterValue.DisplayMemberPath = "Name";

            //Product
            CanSearchProduct = true;
            FProducts = new List<ProductModel>();
            FStocks = new List<StockModel>();


            ProductNameSearchValue.ItemsSource = null;
            ProductNameSearchValue.ItemsSource = PublicVariables.Store.GetExistProducts;
            ProductNameSearchValue.SearchCondition = Syncfusion.UI.Xaml.Grid.SearchCondition.Contains;
            ProductNameSearchValue.DisplayMember = "Name";

            ProductNameFilterValue.ItemsSource = null;
            ProductNameFilterValue.ItemsSource = FProducts;
            ProductNameFilterValue.DisplayMemberPath = "Name";

            // Barcode
            ProductBarCodeSearchValue.AutoCompleteSource = null;
            ProductBarCodeSearchValue.AutoCompleteSource = PublicVariables.Store.GetExistProducts;
            ProductBarCodeSearchValue.SearchItemPath = "BarCode";
            ProductBarCodeSearchValue.AutoCompleteMode = Syncfusion.Windows.Controls.Input.AutoCompleteMode.SuggestAppend;
            ProductBarCodeSearchValue.SuggestionMode = Syncfusion.Windows.Controls.Input.SuggestionMode.Contains;

            // SerialNumber
            ProductSerialNumberSearchValue.AutoCompleteSource = null;
            ProductSerialNumberSearchValue.AutoCompleteSource = PublicVariables.Store.GetExistProducts;
            ProductSerialNumberSearchValue.SearchItemPath = "SerialNumber";
            ProductSerialNumberSearchValue.AutoCompleteMode = Syncfusion.Windows.Controls.Input.AutoCompleteMode.SuggestAppend;
            ProductSerialNumberSearchValue.SuggestionMode = Syncfusion.Windows.Controls.Input.SuggestionMode.Contains;


            // SerialNumber 2
            ProductSerialNumber2SearchValue.AutoCompleteSource = null;
            ProductSerialNumber2SearchValue.AutoCompleteSource = PublicVariables.Store.GetExistProducts;
            ProductSerialNumber2SearchValue.SearchItemPath = "SerialNumber2";
            ProductSerialNumber2SearchValue.AutoCompleteMode = Syncfusion.Windows.Controls.Input.AutoCompleteMode.SuggestAppend;
            ProductSerialNumber2SearchValue.SuggestionMode = Syncfusion.Windows.Controls.Input.SuggestionMode.Contains;


            //Details
            ProductDetailsValue.Text = "";

            //Size
            ProductSizeValue.Text = "";

            //Stock
            //SBarCode
            SBarCodeSearchValue.AutoCompleteSource = null;
            SBarCodeSearchValue.AutoCompleteSource = PublicVariables.Store.GetStocks;
            SBarCodeSearchValue.SearchItemPath = "SBarCode";
            SBarCodeSearchValue.AutoCompleteMode = Syncfusion.Windows.Controls.Input.AutoCompleteMode.SuggestAppend;
            SBarCodeSearchValue.SuggestionMode = Syncfusion.Windows.Controls.Input.SuggestionMode.Contains;

            SBarCodeFilterValue.ItemsSource = null;
            SBarCodeFilterValue.ItemsSource = FStocks;
            SBarCodeFilterValue.DisplayMemberPath = "SBarCode";

            //InStock
            InStockValue.Value = 0;
            InStockFilterValue.ItemsSource = null;
            InStockFilterValue.ItemsSource = FStocks;
            InStockFilterValue.DisplayMemberPath = "Quantity";

            //SalePrice
            StockSalePriceValue.Value = 0;
            StockSalePriceFilterValue.ItemsSource = null;
            StockSalePriceFilterValue.ItemsSource = FStocks;
            StockSalePriceFilterValue.DisplayMemberPath = "SalePrice";

            //IncomePrice
            StockIncomePriceValue.Value = 0;
            StockInomePriceFilterValue.ItemsSource = null;
            StockInomePriceFilterValue.ItemsSource = FStocks;
            StockInomePriceFilterValue.DisplayMemberPath = "IncomePrice";

            //Expiration
            ExpirationValue.Text = "";
            ExpirationFilterValue.ItemsSource = null;
            ExpirationFilterValue.ItemsSource = FStocks;
            ExpirationFilterValue.DisplayMemberPath = "ExpirationState";

            //Discount
            DiscountValue.Value = 0;

            //Discount
            ProfitValue.Value = 0;

            //Quantity
            OrderProductQuantityValue.Value = 0;

            //TotalPrice
            OrderProductTotalPriceValue.Value = 0;

            // Customer
            List<string> customerSearchTypes = new List<string>();
            customerSearchTypes.Add("Name");
            customerSearchTypes.Add("Phone Number");
            customerSearchTypes.Add("National Number");

            CustomerSearchTypeValue.ItemsSource = null;
            CustomerSearchTypeValue.ItemsSource = customerSearchTypes;
            CustomerSearchTypeValue.SelectedIndex = 0;

            CustomerSearchValue.ItemsSource = null;
            CustomerSearchValue.ItemsSource = PublicVariables.Customers;
            CustomerSearchValue.SearchCondition = Syncfusion.UI.Xaml.Grid.SearchCondition.Contains;
            CustomerSearchValue.DisplayMember = "Person.FullName";

            // OrderProduct
            OrderProductRecords = new List<OrderProductRecordModel>();
            OrderProductRecordList.ItemsSource = null;
            OrderProductRecordList.ItemsSource = OrderProductRecords;

            //Payment
            CashRadioButton.IsChecked = true;
            SuspendPayementRadioButton.IsChecked = false;
            CustomerWillPayNowValue.Value = 0;
            CustomerWillPayLaterValue.Value = 0;

            // Order
            OrderTotalPriceValue.Value = 0;
            TotalProfitValue.Value = 0;
            OrderDetailsValue.Text = "";

            //On Start
            CategoryFilterValue.SelectedItem = PublicVariables.DefaultCategory;
            BrandFilterValue.SelectedItem = PublicVariables.DefaultBrand;
        }


        #endregion

        #region Product Groopbox events

        /// <summary>
        /// Update the FProducts and update the Filter lists that depends on the FStock
        /// </summary>
        private void FProductsUpdate()
        {
            BrandModel brand = (BrandModel)BrandFilterValue.SelectedItem;
            CategoryModel category = (CategoryModel)CategoryFilterValue.SelectedItem;

            FProducts = Product.FilterProductsByCategoryAndBrand(PublicVariables.Store.GetExistProducts, category, brand);
            ProductNameFilterValue.ItemsSource = null;
            ProductNameFilterValue.ItemsSource = FProducts;
            ProductNameFilterValue.DisplayMemberPath = "Name";
        }

        private void SetProduct(ProductModel product)
        {

            CanSearchProduct = false;
            if (CategoryFilterValue.SelectedItem != product.Category)
            {
                CategoryFilterValue.SelectedItem = product.Category;
            }
            if (BrandFilterValue.SelectedItem != product.Brand)
            {
                BrandFilterValue.SelectedItem = product.Brand;

            }
            if (ProductNameSearchValue.SelectedItem != product)
            {
                ProductNameSearchValue.SelectedItem = null;

                ProductNameSearchValue.SelectedItem = product;

            }
            if (ProductBarCodeSearchValue.SelectedItem != product)
            {
                ProductBarCodeSearchValue.SelectedItem = null;
                ProductBarCodeSearchValue.SelectedItem = product;
            }
            if (ProductSerialNumberSearchValue.SelectedItem != product)
            {
                ProductSerialNumberSearchValue.SelectedItem = null;

                ProductSerialNumberSearchValue.SelectedItem = product;
            }
            if (ProductSerialNumber2SearchValue.SelectedItem != product)
            {
                ProductSerialNumber2SearchValue.SelectedItem = null;

                ProductSerialNumber2SearchValue.SelectedItem = product;

            }
            if (ProductSizeValue.Text != product.Size)
            {
                ProductSizeValue.Text = "";

                ProductSizeValue.Text = product.Size;
            }
            if (ProductDetailsValue.Text != product.Details)
            {
                ProductDetailsValue.Text = "";

                ProductDetailsValue.Text = product.Details;
            }

            StockModel stock = (StockModel)SBarCodeSearchValue.SelectedItem;
            if (stock != null && stock.Product != product)
            {
                ClearStock();
            }
            CanSearchProduct = true;

            FStocksUpdate(product);
        }

        private void ClearProduct()
        {
            CanSearchProduct = false;

            CategoryFilterValue.SelectedItem = PublicVariables.DefaultCategory;
            BrandFilterValue.SelectedItem = PublicVariables.DefaultBrand;
            ProductNameSearchValue.SelectedItem = null;
            ProductBarCodeSearchValue.SelectedItem = null;
            ProductSerialNumberSearchValue.SelectedItem = null;
            ProductSerialNumber2SearchValue.SelectedItem = null;
            ProductSizeValue.Text = "";
            ProductDetailsValue.Text = "";

            ClearStock();


            CanSearchProduct = true;
        }

        /// <summary>
        /// Update the FStocks and update the filter lists that depends on the FStock
        /// </summary>
        /// <param name="product"></param>
        private void FStocksUpdate(ProductModel product)
        {
            FStocks = Stock.GetStocksByProduct(PublicVariables.Store.GetStocks, product);
            SBarCodeFilterValue.ItemsSource = null;
            SBarCodeFilterValue.ItemsSource = FStocks;
            SBarCodeFilterValue.DisplayMemberPath = "SBarCode";

            InStockFilterValue.ItemsSource = null;
            InStockFilterValue.ItemsSource = FStocks; 
            InStockFilterValue.DisplayMemberPath = "Quantity";

            StockSalePriceFilterValue.ItemsSource = null;
            StockSalePriceFilterValue.ItemsSource = FStocks; 
            StockSalePriceFilterValue.DisplayMemberPath = "SalePrice";

            StockInomePriceFilterValue.ItemsSource = null;
            StockInomePriceFilterValue.ItemsSource = FStocks; 
            StockInomePriceFilterValue.DisplayMemberPath = "IncomePrice";

            ExpirationFilterValue.ItemsSource = null;
            ExpirationFilterValue.ItemsSource = FStocks; 
            ExpirationFilterValue.DisplayMemberPath = "ExpirationState";

            SBarCodeFilterValue.SelectedIndex = 0;
        }
        private void SetStock(StockModel stock)
        {
            SBarCodeSearchValue.SelectedItem = stock;
            InStockValue.Value = stock.Quantity;
            StockIncomePriceValue.Value = stock.IncomePrice;
            StockSalePriceValue.Value = stock.SalePrice;
            ExpirationValue.Text = stock.ExpirationState;
        }

        private void ClearStock()
        {
            SBarCodeSearchValue.SelectedItem = null;
            InStockValue.Value = 0;
            StockIncomePriceValue.Value = 0;
            StockSalePriceValue.Value = 0;
            ExpirationValue.Text = "";
            ProfitValue.Value = 0;
            OrderProductQuantityValue.Value = 0;
            OrderProductTotalPriceValue.Value = 0;
            DiscountValue.Value = 0;
        }

        private bool CheckIfThisStockAddedBefore(OrderProductRecordModel orderProductRecord)
        {
            foreach (OrderProductRecordModel orderProductRecordModel in OrderProductRecords)
            {
                if (orderProductRecordModel.Stock == orderProductRecord.Stock)
                {
                    return true;
                }
            }
            return false;
        }

        #region Events
        private void CategoryOrBrandFilterValue_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FProductsUpdate();
        }
        private void ProductNameFilterValue_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            ProductModel product = (ProductModel)ProductNameFilterValue.SelectedItem;
            if (product != null)
            {
                SetProduct(product);
            }
        }

        /// <summary>
        /// The Main Product selector
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProductNameSearchValue_SelectionChanged(object sender, Syncfusion.UI.Xaml.Grid.SelectionChangedEventArgs e)
        {
            var selectedValue = (sender as Syncfusion.UI.Xaml.Grid.SfMultiColumnDropDownControl).SelectedValue;

            ProductModel product = (ProductModel)selectedValue;
            if (product != null)
            {
                SetProduct(product);
            }
        }

        private void ProductBarCodeSearchValue_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (CanSearchProduct == true)
            {

                ProductModel product = (ProductModel)ProductBarCodeSearchValue.SelectedItem;
                if (product != null)
                {
                    SetProduct(product);
                }

            }

        }

        private void ProductSerialNumberSearchValue_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (CanSearchProduct == true)
            {

                ProductModel product = (ProductModel)ProductSerialNumberSearchValue.SelectedItem;
                if (product != null)
                {
                    SetProduct(product);
                }

            }
        }

        private void ProductSerialNumber2SearchValue_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (CanSearchProduct == true)
            {

                ProductModel product = (ProductModel)ProductSerialNumber2SearchValue.SelectedItem;
                if (product != null)
                {
                    SetProduct(product);
                }

            }
        }

        private void SBarCodeSearchValue_SelectionChanged(object sender, RoutedEventArgs e)
        {

            if (CanSearchProduct == true)
            {

                StockModel stock = (StockModel)SBarCodeSearchValue.SelectedItem;
                if (stock != null)
                {
                    SetProduct(stock.Product);
                    SetStock(stock);
                }

            }
        }

        private void SBarCodeFilterValue_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StockModel stock = (StockModel)SBarCodeFilterValue.SelectedItem;
            if (stock != null)
            {
                SetStock(stock);
            }
        }

        private void InStockFilterValue_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StockModel stock = (StockModel)InStockFilterValue.SelectedItem;
            if (stock != null)
            {
                SetStock(stock);
            }
        }

        private void StockSalePriceFilterValue_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StockModel stock = (StockModel)StockSalePriceFilterValue.SelectedItem;
            if (stock != null)
            {
                SetStock(stock);
            }
        }

        private void StockInomePriceFilterValue_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StockModel stock = (StockModel)StockInomePriceFilterValue.SelectedItem;
            if (stock != null)
            {
                SetStock(stock);
            }
        }

        private void ExpirationFilterValue_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StockModel stock = (StockModel)ExpirationFilterValue.SelectedItem;
            if (stock != null)
            {
                SetStock(stock);
            }
        }

        private void StockSalePriceValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            decimal saleprice = StockSalePriceValue.Value.Value;
            StockModel stock = (StockModel)SBarCodeSearchValue.SelectedItem;
            if (stock != null)
            {
                if (saleprice == 0)
                {
                    DiscountValue.Value = stock.SalePrice;
                    OrderProductTotalPriceValue.Value = saleprice * (decimal)OrderProductQuantityValue.Value.Value;
                    ProfitValue.Value = saleprice - stock.IncomePrice;
                }
                else if(saleprice >= stock.SalePrice)
                {
                    DiscountValue.Value = 0;
                    OrderProductTotalPriceValue.Value = saleprice * (decimal)OrderProductQuantityValue.Value.Value;
                    ProfitValue.Value = saleprice - stock.IncomePrice;

                }
                else if (saleprice < stock.SalePrice)
                {
                    DiscountValue.Value = stock.SalePrice - saleprice;
                    OrderProductTotalPriceValue.Value = saleprice * (decimal)OrderProductQuantityValue.Value.Value;
                    ProfitValue.Value = saleprice - stock.IncomePrice;
                }

            }
        }

        


        private void DiscountValue_ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            decimal discount = DiscountValue.Value.Value;
            StockModel stock = (StockModel)SBarCodeSearchValue.SelectedItem;
            if (stock != null)
            {
                if (discount == 0)
                {
                    StockSalePriceValue.Value = stock.SalePrice;
                    OrderProductTotalPriceValue.Value = StockSalePriceValue.Value * (decimal)OrderProductQuantityValue.Value.Value;
                }
                else if (discount >= stock.SalePrice)
                {
                    DiscountValue.Value = stock.SalePrice;
                    StockSalePriceValue.Value = 0;
                    OrderProductTotalPriceValue.Value = StockSalePriceValue.Value * (decimal)OrderProductQuantityValue.Value.Value;

                }
                else if (discount < stock.SalePrice)
                {
                    StockSalePriceValue.Value = stock.SalePrice - discount;
                    OrderProductTotalPriceValue.Value = StockSalePriceValue.Value * (decimal)OrderProductQuantityValue.Value.Value;
                }

            }
        }

        private void OrderProductQuantityValue_ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (OrderProductQuantityValue.Value != null && StockSalePriceValue.Value != null)
            {
                StockModel stock = (StockModel)SBarCodeSearchValue.SelectedItem;
                if (stock != null)
                {
                    if (OrderProductQuantityValue.Value.Value > stock.Quantity)
                    {
                        OrderProductQuantityValue.Value = stock.Quantity;
                        OrderProductQuantityValue.Text = stock.Quantity.ToString();
                    }
                    OrderProductTotalPriceValue.Value = (decimal)OrderProductQuantityValue.Value * StockSalePriceValue.Value;
                }

            }
        }

        private void ClearOrderProductButton_Click(object sender, RoutedEventArgs e)
        {
            ClearProduct();
        }

        private void AddOrderProductButton_Click(object sender, RoutedEventArgs e)
        {
            
            OrderProductRecordModel orderProductRecord = new OrderProductRecordModel();

            OrderProductModel orderProduct = new OrderProductModel();
            orderProduct.Product = (ProductModel)ProductNameSearchValue.SelectedItem;
            orderProduct.Quantity = (float)OrderProductQuantityValue.Value.Value;
            orderProduct.SalePrice = StockSalePriceValue.Value.Value;

            orderProductRecord.Stock = (StockModel)SBarCodeSearchValue.SelectedItem;
            orderProductRecord.OrderProduct = orderProduct;

            if (CheckIfThisStockAddedBefore(orderProductRecord) == false)
            {

                // Validation
                GlobalConfig.OrderProductRecordValidator = new OrderProductRecordValidator();

                ValidationResult result = GlobalConfig.OrderProductRecordValidator.Validate(orderProductRecord);

                if (result.IsValid == false)
                {

                    MessageBox.Show(result.Errors[0].ErrorMessage);

                }
                else
                {
                    orderProductRecord = OrderProductRecord.DiscountAndProfitCalculations(orderProductRecord);

                    OrderProductRecords.Add(orderProductRecord);
                    UpdateTotalPriceAndTotalProfit();
                }
            }
            else
            {
                MessageBox.Show("This stock is used before in this order if you need to adjust it remove and add again.");
            }




        }

        #endregion


        #endregion


        #region Customer GroupeBox

        private void ClearCustomer()
        {
            CustomerSearchValue.ItemsSource = null;
            CustomerSearchValue.ItemsSource = PublicVariables.Customers;
            CustomerSearchValue.SearchCondition = Syncfusion.UI.Xaml.Grid.SearchCondition.Contains;
            CustomerSearchValue.DisplayMember = "Person.FullName";
        }
        private void ClearCusomerButton_Click(object sender, RoutedEventArgs e)
        {
            ClearCustomer();
        }

        private void CustomerSearchTypeValue_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string type = "";
            type = (string)CustomerSearchTypeValue.SelectedItem;
            if (type == "Name")
            {
                CustomerSearchValue.ItemsSource = null;
                CustomerSearchValue.ItemsSource = PublicVariables.Customers;
                CustomerSearchValue.SearchCondition = Syncfusion.UI.Xaml.Grid.SearchCondition.Contains;
                CustomerSearchValue.DisplayMember = "Person.FullName";
            }
            else if (type == "Phone Number")
            {
                CustomerSearchValue.ItemsSource = null;
                CustomerSearchValue.ItemsSource = PublicVariables.Customers;
                CustomerSearchValue.SearchCondition = Syncfusion.UI.Xaml.Grid.SearchCondition.Contains;
                CustomerSearchValue.DisplayMember = "Person.PhoneNumber";

            }
            else if (type == "National Number")
            {
                CustomerSearchValue.ItemsSource = null;
                CustomerSearchValue.ItemsSource = PublicVariables.Customers;
                CustomerSearchValue.SearchCondition = Syncfusion.UI.Xaml.Grid.SearchCondition.Contains;
                CustomerSearchValue.DisplayMember = "Person.NationalNumber";

            }
            else
            {
                CustomerSearchValue.ItemsSource = null;
                CustomerSearchValue.ItemsSource = PublicVariables.Customers;
                CustomerSearchValue.SearchCondition = Syncfusion.UI.Xaml.Grid.SearchCondition.Contains;
                CustomerSearchValue.DisplayMember = "Person.FullName";
            }
        }

        #endregion

        #region Hole form

        private void UpdateTotalPriceAndTotalProfit()
        {
            OrderProductRecordList.ItemsSource = null;
            OrderProductRecordList.ItemsSource = OrderProductRecords;

            decimal totalPrice = new decimal();
            decimal totalProfit = new decimal();
            foreach(OrderProductRecordModel orderProductRecord in OrderProductRecords)
            {
                totalPrice += orderProductRecord.OrderProduct.GetTotalPrice;
                totalProfit += orderProductRecord.OrderProduct.GetTotalProfit;
            }

            OrderTotalPriceValue.Value = totalPrice;
            TotalProfitValue.Value = totalProfit;

            if (CashRadioButton.IsChecked == true)
            {
                CustomerWillPayNowValue.Value = totalPrice;
                CustomerWillPayLaterValue.Value = 0;

            }
            else
            {
                CustomerWillPayNowValue.Value = 0;
                CustomerWillPayLaterValue.Value = totalPrice;
            }

            // Scrol to the last
            if (OrderProductRecords.Count > 0)
            {
                OrderProductRecordList.ScrollIntoView(OrderProductRecords.Last());
            }

        }

        /// <summary>
        /// Check if the current list of the orderProductRecords still valid
        /// </summary>
        /// <returns></returns>
        private bool CheckIfTheCurrentOrderProductRecordsValid()
        {
            foreach (OrderProductRecordModel orderProductRecord in OrderProductRecords)
            {
                GlobalConfig.OrderProductRecordValidator = new OrderProductRecordValidator();

                ValidationResult result = GlobalConfig.OrderProductRecordValidator.Validate(orderProductRecord);

                if (result.IsValid == false)
                {

                    MessageBox.Show(result.Errors[0].ErrorMessage);
                    return false;
                }
                else
                {

                }
            }
            return true;
        }
        private void SaveTheOrder()
        {
            if(CheckIfTheCurrentOrderProductRecordsValid() == true)
            {
                bool valid = true;

                OrderModel order = new OrderModel();
                order.Customer = (CustomerModel)CustomerSearchValue.SelectedItem;
                order.DateTimeOfTheOrder = DateTime.Now;
                order.Store = PublicVariables.Store;
                order.Staff = PublicVariables.Staff;
                order.OrderPayments = new List<OrderPaymentModel>();
                if(CustomerWillPayNowValue.Value.Value > 0)
                {
                    OrderPaymentModel orderPayment = new OrderPaymentModel();
                    orderPayment.Staff = PublicVariables.Staff;
                    orderPayment.Store = PublicVariables.Store;
                    orderPayment.Paid = CustomerWillPayNowValue.Value.Value;
                    orderPayment.Date = DateTime.Now;

                    GlobalConfig.OrderPaymentValidator = new OrderPaymentValidator();

                    ValidationResult result = GlobalConfig.OrderPaymentValidator.Validate(orderPayment);

                    if (result.IsValid == false)
                    {

                        MessageBox.Show(result.Errors[0].ErrorMessage);
                        valid = false;

                    }
                    else
                    {
                        order.OrderPayments.Add(orderPayment);

                    }
                }
                order.Details = OrderDetailsValue.Text;
                order.OrderProducts = new List<OrderProductModel>();
                foreach (OrderProductRecordModel orderProductRecord in OrderProductRecords)
                {
                    // Validation
                    GlobalConfig.OrderProductRecordValidator = new OrderProductRecordValidator();

                    ValidationResult result = GlobalConfig.OrderProductRecordValidator.Validate(orderProductRecord);

                    if (result.IsValid == false)
                    {

                        MessageBox.Show(result.Errors[0].ErrorMessage);
                        valid = false;

                    }
                    else
                    {
                        order.OrderProducts.Add(orderProductRecord.OrderProduct);
                    }
                   
                }

                GlobalConfig.OrderValidator = new OrderValidator();
                ValidationResult OrderResult = GlobalConfig.OrderValidator.Validate(order);
                if (OrderResult.IsValid == false)
                {

                    MessageBox.Show(OrderResult.Errors[0].ErrorMessage);
                    valid = false;
                }
                else
                {
                    if (valid == true)
                    {

                        order = GlobalConfig.Connection.AddOrderToTheDatabase(order, OrderProductRecords);

                        if(MessageBox.Show("Do you want to print the order ?", "Printing...", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            PrintTheOrder(order);
                        }
                        else
                        {
                            ClearCustomer();
                            ClearProduct();
                            SetInitialValues();
                        }
                        
                       
                    }
                }
            }

        }

        /// <summary>
        /// Opens the printing tab and fill the prining info
        /// </summary>
        private void PrintTheOrder(OrderModel order)
        {
            UserGrid.Visibility = Visibility.Collapsed;
            PrintGrid.Visibility = Visibility.Visible;

            // Set the order Count Values
            OrganizationOrdersCountValue.Text = PublicVariables.Organization.GetOrdersCount.ToString();
            SelectedCustomerOrdersCountValue.Text = order.Customer.GetOrders.Count.ToString();
            OrderCountTodayValue.Text = Store.GetTheOrdersCount(PublicVariables.Store, DateTime.Today, DateTime.Today + new TimeSpan(1,0,0,0)).ToString();
            StaffOrderCountTodayValue.Text = Library.Staff.GetTheOrdersCount(PublicVariables.Staff, DateTime.Today, DateTime.Today + new TimeSpan(1, 0, 0, 0)).ToString();
            StaffNameValue.Text = PublicVariables.Staff.Person.FullName;

            StiReport report = new StiReport();
            // add the data to the datastore
            report.Load(@"SellOrderReportARforEMG.mrt");

            report.Compile();

            report["OrganizationName"] = PublicVariables.Organization.Name;
            report["OrganizationAddress"] = PublicVariables.Organization.Address;
            report["OrganizationPhoneNumber"] = PublicVariables.Organization.PhoneNumber;

            report["DateTime"] = order.DateTimeOfTheOrder.ToShortTimeString();
            report["StaffName"] = order.Staff.Person.FullName;
            report["StoreName"] = order.Store.Name;
            report["StorePhoneNumber"] = order.Store.PhoneNumber;
            report["StoreAddress"] = order.Store.Address;
            report["OrderId"] = order.Id;



            report["CustomerName"] = order.Customer.Person.FullName;
            report["CustomerPhoneNumber"] = order.Customer.Person.PhoneNumber;
            report["CustomerNationalNumber"] = order.Customer.Person.NationalNumber;
            report["CustomerAddress"] = order.Customer.Person.Address;


            report["OrderDetails"] = order.Details;
            report["TotalPrice"] = order.GetTotalPrice.ToString("G29");
            report["TotalPaid"] = order.GetTotalPaid.ToString("G29");
            report["TotalOrderProduct"] = order.GetTheNumberOfOrderProducts.ToString();


            string printLast = "";
            if(order.GetTotalPaid < order.GetTotalPrice)
            {
                printLast += "Payment due within 30 days from date of invoice\n";
            }
            
            printLast += "Thank you for your business!";
            report["PrintLast"] = printLast;


            report.Render();

            SellOrderReportPrint.Report = report;
        }


        #region Events
        private void RemoveSelectedProductButton_Click(object sender, RoutedEventArgs e)
        {
            OrderProductRecordModel orderProductRecord = (OrderProductRecordModel)OrderProductRecordList.SelectedItem;
            if(orderProductRecord != null)
            {
                OrderProductRecords.Remove(orderProductRecord);
                UpdateTotalPriceAndTotalProfit();
            }
        }

        private void CashRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            CustomerWillPayNowValue.Value = OrderTotalPriceValue.Value;
            CustomerWillPayLaterValue.Value = 0;
        }

        private void SuspendPayementRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            CustomerWillPayNowValue.Value = 0;
            CustomerWillPayLaterValue.Value = OrderTotalPriceValue.Value;
        }

        private void CustomerWillPayNowValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            decimal payNow = CustomerWillPayNowValue.Value.Value;

            if (payNow > OrderTotalPriceValue.Value)
            {
                CustomerWillPayNowValue.Value = OrderTotalPriceValue.Value;
                CustomerWillPayLaterValue.Value = 0;

            }
            else if (payNow == 0)
            {
                CustomerWillPayNowValue.Value = 0;
                CustomerWillPayLaterValue.Value = OrderTotalPriceValue.Value;
            }
            else
            {
                CustomerWillPayLaterValue.Value = OrderTotalPriceValue.Value - payNow;
            }
        }

        private void CustomerWillPayLaterValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            decimal payLater = CustomerWillPayLaterValue.Value.Value;

            if (payLater > OrderTotalPriceValue.Value)
            {
                CustomerWillPayLaterValue.Value = OrderTotalPriceValue.Value;
                CustomerWillPayNowValue.Value = 0;
            }
            else if (payLater == 0)
            {
                CustomerWillPayLaterValue.Value = 0;
                CustomerWillPayNowValue.Value = OrderTotalPriceValue.Value;
            }
            else
            {
                CustomerWillPayNowValue.Value = OrderTotalPriceValue.Value - payLater;
            }
        }
       
        private void ReloadTabButton_Click(object sender, RoutedEventArgs e)
        {
            SetInitialValues();
            ClearProduct();
        }
        private void ConfitmButton_Click(object sender, RoutedEventArgs e)
        {
            SaveTheOrder();
        }
        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Do you want to Save the order  ?", "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                SaveTheOrder();
            }
        }

        #endregion

        #endregion

        #region Grid Switch

        private void AddNewCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            UserGrid.Visibility = Visibility.Collapsed;
            CreateCustomerGrid.Visibility = Visibility.Visible;
        }

        private void BackToUserGridButton_FromCreateNewCustomerGrid_Click(object sender, RoutedEventArgs e)
        {

            ClearCustomer();
            UserGrid.Visibility = Visibility.Visible;
            CreateCustomerGrid.Visibility = Visibility.Collapsed;
        }

        private void BackToNormalGridButton_Click(object sender, RoutedEventArgs e)
        {
            ClearProduct();
            SetInitialValues();
            ClearCustomer();
            UserGrid.Visibility = Visibility.Visible;
            PrintGrid.Visibility = Visibility.Collapsed;
        }






        #endregion

      
    }

}

