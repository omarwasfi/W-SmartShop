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
using ValidationResult = FluentValidation.Results.ValidationResult;


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

        private List<IncomeOrderProductRecordModel> IncomeOrderProductRecords { get; set; }


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


        public IncomeOrderUC()
        {
            InitializeComponent();


            SetInitialValues();

        }

        private void SetInitialValues()
        {
            // Default Grids
            UserGrid.Visibility = Visibility.Visible;
            NewProductGrid.Visibility = Visibility.Collapsed;
            NewSupplierGrid.Visibility = Visibility.Collapsed;
            SelectedSupplierLogGrid.Visibility = Visibility.Collapsed;
            RecentlyAddedGrid.Visibility = Visibility.Collapsed;
            ChooseSupplierGB.Visibility = Visibility.Visible;

            // Choose Product GroupBox
            // Category
            CategoryFilterValue.ItemsSource = null;
            CategoryFilterValue.ItemsSource = PublicVariables.Categories;
            CategoryFilterValue.DisplayMemberPath = "Name";

            //Brand
            BrandFilterValue.ItemsSource = null;
            BrandFilterValue.ItemsSource = PublicVariables.Brands;
            BrandFilterValue.DisplayMemberPath = "Name";

            //Product
            CanSearchProduct = true;
            FProducts = new List<ProductModel>();

            ProductNameSearchValue.ItemsSource = null;
            ProductNameSearchValue.ItemsSource = PublicVariables.Products;
            ProductNameSearchValue.DisplayMember = "Name";


            ProductNameFilterValue.ItemsSource = null;
            ProductNameFilterValue.ItemsSource = FProducts;
            ProductNameFilterValue.DisplayMemberPath = "Name";

            // Barcode
            ProductBarCodeSearchValue.AutoCompleteSource = null;
            ProductBarCodeSearchValue.AutoCompleteSource = PublicVariables.Products;
            ProductBarCodeSearchValue.SearchItemPath = "BarCode";
            ProductBarCodeSearchValue.AutoCompleteMode = Syncfusion.Windows.Controls.Input.AutoCompleteMode.SuggestAppend;
            ProductBarCodeSearchValue.SuggestionMode = Syncfusion.Windows.Controls.Input.SuggestionMode.Contains;



            // SerialNumber
            ProductSerialNumberSearchValue.AutoCompleteSource = null;
            ProductSerialNumberSearchValue.AutoCompleteSource = PublicVariables.Products;
            ProductSerialNumberSearchValue.SearchItemPath = "SerialNumber";
            ProductSerialNumberSearchValue.AutoCompleteMode = Syncfusion.Windows.Controls.Input.AutoCompleteMode.SuggestAppend;
            ProductSerialNumberSearchValue.SuggestionMode = Syncfusion.Windows.Controls.Input.SuggestionMode.Contains;


            // SerialNumber 2
            ProductSerialNumber2SearchValue.AutoCompleteSource = null;
            ProductSerialNumber2SearchValue.AutoCompleteSource = PublicVariables.Products;
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

            
            InStockValue.Value = 0;
            StockSalePriceValue.Value = 0;
            StockIncomePriceValue.Value = 0;

            QuantityAlarmCB.IsChecked = false;
            StockQuantityAlarmValue.Value = 5;

            StockExpirationPeriodCB.IsChecked = false;

            StockExpirationPeriodValue.IsEnabled = false;

            StockExpirationDateValue.IsEnabled = false;
            StockExpirationDateValue.DisplayDateStart = DateTime.Now;
            StockExpirationDateValue.SelectedDate = DateTime.Now.Add(new TimeSpan(30,0,0));

            StockExpirationTimeValue.IsEnabled = false;
            StockExpirationTimeValue.Value = "12:00";
            
            NotifyMeAtDateValue.IsEnabled = false;
            NotifyMeAtDateValue.DisplayDateStart = DateTime.Now;
            NotifyMeAtDateValue.SelectedDate = DateTime.Now.Add(new TimeSpan(30, 0, 0));

            NotifyMeAtTime.IsEnabled = false;
            NotifyMeAtTime.Value = "12:00";



            // Supplier GB
            List<string> supplierSearchTypes = new List<string>();
            supplierSearchTypes.Add("Name");
            supplierSearchTypes.Add("Phone Number");
            supplierSearchTypes.Add("National Number");

            SupplierSearchTypeValue.ItemsSource = null;
            SupplierSearchTypeValue.ItemsSource = supplierSearchTypes;
            SupplierSearchTypeValue.SelectedIndex = 0;

            SupplierSearchValue.ItemsSource = null;
            SupplierSearchValue.ItemsSource = PublicVariables.Suppliers;
            SupplierSearchValue.DisplayMember = "Person.FullName";

            //IncomeOrder
            IncomeOrderProductQuantityValue.Value = 0;
            IncomeOrderProductTotalPriceValue.Value = 0;

            // Recently add Products Grid
            RecentlyAddProductsList.ItemsSource = PublicVariables.RecentlyAddProducts;

            //Hole Events
            BillNumberValue.Text = "";
            DateValue.SelectedDate = DateTime.Now;
            ShippingExpensesValue.Value = 0;
            IncomeOrderProductRecords = new List<IncomeOrderProductRecordModel>();
            IncomeOrderProductRecordsList.ItemsSource = null;
            IncomeOrderProductRecordsList.ItemsSource = IncomeOrderProductRecords;
            IncomeOrderTotalPriceValue.Value = 0;
            ShoppeeWalletValue.Value = PublicVariables.Store.GetShopeeWallet;
            IncomeOrderDetailsValue.Text = "";
            CashRadioButton.IsChecked = true;
            SuspendPayementRadioButton.IsChecked = false;
            StoreWillPayNowValue.Value = 0;
            StoreWillPayLaterValue.Value = 0;

            //On Start
            CategoryFilterValue.SelectedItem = PublicVariables.DefaultCategory;
            BrandFilterValue.SelectedItem = PublicVariables.DefaultBrand;

        }




        #endregion



        #region Supplier Group Box Events

        private void ClearSupplier()
        {
            SupplierSearchValue.ItemsSource = null;
            SupplierSearchValue.ItemsSource = PublicVariables.Suppliers;
            SupplierSearchValue.DisplayMember = "Person.FullName";
        }

        private void SupplierSearchTypeValue_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string type = "";
            type = (string)SupplierSearchTypeValue.SelectedItem;
            if (type == "Name")
            {
                SupplierSearchValue.ItemsSource = null;
                SupplierSearchValue.ItemsSource = PublicVariables.Suppliers;
                SupplierSearchValue.DisplayMember = "Person.FullName";
            }
            else if (type == "Phone Number")
            {
                SupplierSearchValue.ItemsSource = null;
                SupplierSearchValue.ItemsSource = PublicVariables.Suppliers;
                SupplierSearchValue.DisplayMember = "Person.PhoneNumber";

            }
            else if (type == "National Number")
            {
                SupplierSearchValue.ItemsSource = null;
                SupplierSearchValue.ItemsSource = PublicVariables.Suppliers;
                SupplierSearchValue.DisplayMember = "Person.NationalNumber";

            }
            else
            {
                SupplierSearchValue.ItemsSource = null;
                SupplierSearchValue.ItemsSource = PublicVariables.Suppliers;
                SupplierSearchValue.DisplayMember  = "Person.FullName";
            }
        }

        private void ClearSupplierSupplier_Click(object sender, RoutedEventArgs e)
        {
            ClearSupplier();
        }

        #endregion

        #region RecentlyAdded Products Grid


        #endregion

        #region Choose Product GroupBox 

        /// <summary>
        /// Update the FProducts 
        /// </summary>
        private void FProductsUpdate()
        {
            BrandModel brand = (BrandModel)BrandFilterValue.SelectedItem;
            CategoryModel category = (CategoryModel)CategoryFilterValue.SelectedItem;

            FProducts = Product.FilterProductsByCategoryAndBrand(category, brand);
            ProductNameFilterValue.ItemsSource = null;
            ProductNameFilterValue.ItemsSource = FProducts;
            ProductNameFilterValue.DisplayMemberPath = "Name";
        }

        private void FStocksUpdate(ProductModel product)
        {
            SBarCodeFilterValue.ItemsSource = null;
            SBarCodeFilterValue.ItemsSource =  Stock.GetStocksByProduct(PublicVariables.Store.GetStocks,product);
            SBarCodeFilterValue.DisplayMemberPath = "SBarCode";
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

            IncomeOrderProductQuantityValue.Value = 0;
            IncomeOrderProductTotalPriceValue.Value = 0;
            CanSearchProduct = true;
        }


        private void SetStock(StockModel stock)
        {
            SBarCodeSearchValue.SelectedItem = stock;
            InStockValue.Value = stock.Quantity;
            StockIncomePriceValue.Value = stock.IncomePrice;
            StockSalePriceValue.Value = stock.SalePrice;
            StockQuantityAlarmValue.Value = stock.AlarmQuantity;
            StockExpirationPeriodValue.Value = stock.GetExpirationPeriod;
        }

        private void ClearStock()
        {
            SBarCodeSearchValue.SelectedItem = null;
            InStockValue.Value = 0;
            StockIncomePriceValue.Value = 0;
            StockSalePriceValue.Value = 0;
            QuantityAlarmCB.IsChecked = false;
            StockQuantityAlarmValue.Value = 5;
            StockExpirationPeriodCB.IsChecked = false;
            //StockExpirationPeriodValue.Value = new TimeSpan(30, 12, 0, 0);
        }

        
        #region Events

        private void CategoryOrBrandFilterValue_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FProductsUpdate();
        }

        private void ProductNameFilterValue_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            ProductModel product  = (ProductModel)ProductNameFilterValue.SelectedItem;
            if(product != null)
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
            if(CanSearchProduct == true) 
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

        private void QuantityAlarmCB_Checked(object sender, RoutedEventArgs e)
        {
            StockQuantityAlarmValue.IsEnabled = true;
        }

        private void QuantityAlarmCB_Unchecked(object sender, RoutedEventArgs e)
        {
            StockQuantityAlarmValue.IsEnabled = false;
        }

        private void StockExpirationPeriodCB_Checked(object sender, RoutedEventArgs e)
        {

            StockExpirationPeriodCB.IsChecked = true;

            StockExpirationPeriodValue.IsEnabled = true;

            StockExpirationDateValue.IsEnabled = true;
            StockExpirationDateValue.DisplayDateStart = DateTime.Now;

            StockExpirationTimeValue.IsEnabled = true;

            NotifyMeAtDateValue.IsEnabled = true;
            NotifyMeAtDateValue.DisplayDateStart = DateTime.Now;

            NotifyMeAtTime.IsEnabled = true;
        }

        private void StockExpirationPeriodCB_Unchecked(object sender, RoutedEventArgs e)
        {
            QuantityAlarmCB.IsChecked = false;
            StockQuantityAlarmValue.Value = 5;

            StockExpirationPeriodCB.IsChecked = false;

            StockExpirationPeriodValue.IsEnabled = false;

            StockExpirationDateValue.IsEnabled = false;
            StockExpirationDateValue.DisplayDateStart = DateTime.Now;
            StockExpirationDateValue.SelectedDate = DateTime.Now.Add(new TimeSpan(30, 0, 0));

            StockExpirationTimeValue.IsEnabled = false;

            NotifyMeAtDateValue.IsEnabled = false;
            NotifyMeAtDateValue.SelectedDate = DateTime.Now.Add(new TimeSpan(30, 0, 0));

            NotifyMeAtTime.IsEnabled = false;
        }

        private void ExpirationDateValue_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime stockExpirationDate = (DateTime)StockExpirationDateValue.SelectedDate;
            if (stockExpirationDate != null)
            {
                DateTime expirationDateTime = new DateTime();
                expirationDateTime = (DateTime)StockExpirationDateValue.SelectedDate;

                DateTime expirationTime = System.Convert.ToDateTime(StockExpirationTimeValue.Value);

              /*  expirationDateTime =  expirationDateTime.AddHours(expirationTime.Hour);
                expirationDateTime = expirationDateTime.AddMinutes(expirationTime.Minute);*/

                TimeSpan expirationPeriod = new TimeSpan();
                expirationPeriod = expirationDateTime - DateTime.Now;

                StockExpirationPeriodValue.Value = expirationPeriod;

                NotifyMeAtDateValue.SelectedDate = (DateTime)StockExpirationDateValue.SelectedDate;
                NotifyMeAtTime.Value = "12:00";
            }

        }

       
        private void ClearIncomeOrderProductButton_Click(object sender, RoutedEventArgs e)
        {
            ClearProduct();
        }

        private void StockIncomePriceValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(IncomeOrderProductQuantityValue.Value!= null && StockIncomePriceValue.Value != null)
            {
                IncomeOrderProductTotalPriceValue.Value = (decimal)IncomeOrderProductQuantityValue.Value * StockIncomePriceValue.Value;
            }
        }

        private void IncomeOrderProductQuantityValue_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (IncomeOrderProductQuantityValue.Value != null && StockIncomePriceValue.Value != null)
            {
                IncomeOrderProductTotalPriceValue.Value = (decimal)IncomeOrderProductQuantityValue.Value * StockIncomePriceValue.Value;

            }        
        }

        private void IncomeOrderProductButton_Click(object sender, RoutedEventArgs e)
        {
            IncomeOrderProductRecordModel incomeOrderProductRecord = new IncomeOrderProductRecordModel();

            StockModel stock = new StockModel();
            stock.Store = PublicVariables.Store;
            stock.Product = (ProductModel)ProductBarCodeSearchValue.SelectedItem;
            stock.IncomePrice = (decimal)StockIncomePriceValue.Value;
            stock.SalePrice = (decimal)StockSalePriceValue.Value;
            stock.Date = DateTime.Now;
            if (StockExpirationPeriodCB.IsChecked == true)
            {
                DateTime expirationDate = new DateTime();
                expirationDate = (DateTime)StockExpirationDateValue.SelectedDate;
                
                DateTime notifyDate = new DateTime();
                notifyDate = (DateTime)NotifyMeAtDateValue.SelectedDate;

                stock.NotificationDate = notifyDate;


                stock.ExpirationAlarmEnabled = true;
                stock.ExpirationDate = expirationDate;

            }
            if (QuantityAlarmCB.IsChecked == true)
            {
                stock.QuantityAlarmEnabled = true;
                stock.AlarmQuantity = (int)StockQuantityAlarmValue.Value.Value;
            }
            stock.Quantity = (float)IncomeOrderProductQuantityValue.Value.Value;



            IncomeOrderProductModel incomeOrderProduct = new IncomeOrderProductModel();
            incomeOrderProduct.Product = (ProductModel)ProductBarCodeSearchValue.SelectedItem;
            incomeOrderProduct.IncomePrice = (decimal)StockIncomePriceValue.Value;
            incomeOrderProduct.Quantity = (float)IncomeOrderProductQuantityValue.Value.Value;



            incomeOrderProductRecord.Stock = stock;
            incomeOrderProductRecord.IncomeOrderProduct = incomeOrderProduct;

            GlobalConfig.IncomeOrderProductRecordValidator = new IncomeOrderProductRecordValidator();

            ValidationResult result = GlobalConfig.IncomeOrderProductRecordValidator.Validate(incomeOrderProductRecord);

            if (result.IsValid == false)
            {

                MessageBox.Show(result.Errors[0].ErrorMessage);

            }
            else
            {
                IncomeOrderProductRecords.Add(incomeOrderProductRecord);
                IncomeOrderProductRecordsList.ItemsSource = null;
                IncomeOrderProductRecordsList.ItemsSource = IncomeOrderProductRecords;

                SetTheTotalPriceValue();
            }

        }


        #endregion

        #endregion

        #region Hole Form Events

        /// <summary>
        /// Calculate the total Price without the shipping expenses
        /// </summary>
        private void SetTheTotalPriceValue()
        {
            decimal totalPrice = new decimal();
            decimal shippingExpenses = ShippingExpensesValue.Value.Value;
            foreach (IncomeOrderProductRecordModel incomeOrderProductRecord in IncomeOrderProductRecords)
            {
                totalPrice += incomeOrderProductRecord.IncomeOrderProduct.GetTotalProductPrice;
            }
            totalPrice += shippingExpenses;
            IncomeOrderTotalPriceValue.Value = totalPrice;

           if(CashRadioButton.IsChecked == true)
            {
                StoreWillPayNowValue.Value = totalPrice;
                StoreWillPayLaterValue.Value = 0;

            }
            else
            {
                StoreWillPayNowValue.Value = 0;
                StoreWillPayLaterValue.Value = totalPrice;
            }
        }

        private void CashRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            StoreWillPayNowValue.Value = IncomeOrderTotalPriceValue.Value;
            StoreWillPayLaterValue.Value = 0;
        }
        private void SuspendPayementRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            StoreWillPayNowValue.Value = 0;
            StoreWillPayLaterValue.Value = IncomeOrderTotalPriceValue.Value;
        }
        private void StoreWillPayNowValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            decimal payNow = StoreWillPayNowValue.Value.Value;
            //decimal payLater = StoreWillPayLaterValue.Value.Value;

            if (payNow > IncomeOrderTotalPriceValue.Value)
            {
                StoreWillPayNowValue.Value = IncomeOrderTotalPriceValue.Value;
                StoreWillPayLaterValue.Value = 0;

            }
            else if (payNow == 0)
            {
                StoreWillPayNowValue.Value = 0;
                StoreWillPayLaterValue.Value = IncomeOrderTotalPriceValue.Value;
            }
            else if(payNow > ShoppeeWalletValue.Value.Value)
            {
                StoreWillPayNowValue.Value = ShoppeeWalletValue.Value.Value;
                StoreWillPayLaterValue.Value = IncomeOrderTotalPriceValue.Value - ShoppeeWalletValue.Value.Value;
            }
            else
            {
                StoreWillPayLaterValue.Value = IncomeOrderTotalPriceValue.Value - payNow;
            }

        }
        private void StoreWillPayLaterValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            //decimal payNow = StoreWillPayNowValue.Value.Value;
            decimal payLater = StoreWillPayLaterValue.Value.Value;

            if (payLater > IncomeOrderTotalPriceValue.Value)
            {
                StoreWillPayLaterValue.Value = IncomeOrderTotalPriceValue.Value;
                StoreWillPayNowValue.Value = 0;


            }
            else if (payLater == 0)
            {
                StoreWillPayLaterValue.Value = 0;
                StoreWillPayNowValue.Value = IncomeOrderTotalPriceValue.Value;
            }
            else
            {
                StoreWillPayNowValue.Value = IncomeOrderTotalPriceValue.Value - payLater;
            }
        }
        private void ShippingExpensesValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetTheTotalPriceValue();
        }
        private void RemoveSelectedIncomeOrderProductRecormButton_Click(object sender, RoutedEventArgs e)
        {
            IncomeOrderProductRecordModel incomeOrderProductRecord = (IncomeOrderProductRecordModel)IncomeOrderProductRecordsList.SelectedItem;
            if (incomeOrderProductRecord != null)
            {
                IncomeOrderProductRecords.Remove(incomeOrderProductRecord);
                IncomeOrderProductRecordsList.ItemsSource = null;
                IncomeOrderProductRecordsList.ItemsSource = IncomeOrderProductRecords;

                SetTheTotalPriceValue();
            }
        }
        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            bool valid = true;
            List<StockModel> newStocks = new List<StockModel>();
            IncomeOrderModel incomeOrder = new IncomeOrderModel();
            incomeOrder.Supplier = (SupplierModel)SupplierSearchValue.SelectedItem;
            incomeOrder.BillNumber = BillNumberValue.Text;
            incomeOrder.Date = (DateTime)DateValue.SelectedDate;
            incomeOrder.Store = PublicVariables.Store;
            incomeOrder.Staff = PublicVariables.Staff;
            incomeOrder.IncomeOrderPayments = new List<IncomeOrderPaymentModel>();
            if(StoreWillPayNowValue.Value.Value > 0)
            {
                IncomeOrderPaymentModel incomeOrderPayment = new IncomeOrderPaymentModel();
                incomeOrderPayment.Staff = PublicVariables.Staff;
                incomeOrderPayment.Store = PublicVariables.Store;
                incomeOrderPayment.Paid = StoreWillPayNowValue.Value.Value - (decimal)ShippingExpensesValue.Value.Value;
                incomeOrderPayment.Date = DateTime.Now;

                GlobalConfig.IncomeOrderPaymentValidator = new IncomeOrderPaymentValidator();

                ValidationResult result = GlobalConfig.IncomeOrderPaymentValidator.Validate(incomeOrderPayment);

                if (result.IsValid == false)
                {

                    MessageBox.Show(result.Errors[0].ErrorMessage);
                    valid = false;

                }
                else
                {
                    incomeOrder.IncomeOrderPayments.Add(incomeOrderPayment);
                    
                }

            }
            incomeOrder.Details = IncomeOrderDetailsValue.Text;
            incomeOrder.IncomeOrderProducts = new List<IncomeOrderProductModel>();
            foreach(IncomeOrderProductRecordModel incomeOrderProductRecord in IncomeOrderProductRecords)
            {
                GlobalConfig.IncomeOrderProductValidator = new IncomeOrderProductValidator();

                ValidationResult result = GlobalConfig.IncomeOrderProductValidator.Validate(incomeOrderProductRecord.IncomeOrderProduct);

                if (result.IsValid == false)
                {

                    MessageBox.Show(result.Errors[0].ErrorMessage);
                    valid = false;
                }
                else
                {
                    incomeOrder.IncomeOrderProducts.Add(incomeOrderProductRecord.IncomeOrderProduct);
                    newStocks.Add(incomeOrderProductRecord.Stock);
                }
                 
            }

          

            GlobalConfig.IncomeOrderValidator = new IncomeOrderValidator();
            ValidationResult IncomeOrderResult = GlobalConfig.IncomeOrderValidator.Validate(incomeOrder);
            if (IncomeOrderResult.IsValid == false)
            {

                MessageBox.Show(IncomeOrderResult.Errors[0].ErrorMessage);
                valid = false;
            }
            else
            {
                if(valid == true)
                {
                   

                    incomeOrder =  GlobalConfig.Connection.AddIncomeOrderToTheDatabase(incomeOrder, newStocks);
                    if (ShippingExpensesValue.Value.Value > 0)
                    {
                        ShopBillModel shopBill = new ShopBillModel();
                        shopBill.Date = DateTime.Now;
                        shopBill.Staff = PublicVariables.Staff;
                        shopBill.Store = PublicVariables.Store;
                        shopBill.TotalMoney = ShippingExpensesValue.Value.Value;
                        shopBill.Details = "Shipping expense of the income Order ID : " + incomeOrder.Id +" .";

                        GlobalConfig.Connection.AddShopBillToTheDatabase(shopBill);
                    }
                    ClearProduct();
                    SetInitialValues();
                }
            }
            

        }
        #endregion

        #region Grid Switch

        private void CreateNewProductButton_Click(object sender, RoutedEventArgs e)
        {
            UserGrid.Visibility = Visibility.Collapsed;
            NewProductGrid.Visibility = Visibility.Visible;

        }
        private void BackToUserGridButton_FromCreateNewProductGrid_Click(object sender, RoutedEventArgs e)
        {
            NewProductGrid.Visibility = Visibility.Collapsed;
            UserGrid.Visibility = Visibility.Visible;

            ClearProduct();

            // Category
            CategoryFilterValue.ItemsSource = null;
            CategoryFilterValue.ItemsSource = PublicVariables.Categories;
            CategoryFilterValue.DisplayMemberPath = "Name";

            //Brand
            BrandFilterValue.ItemsSource = null;
            BrandFilterValue.ItemsSource = PublicVariables.Brands;
            BrandFilterValue.DisplayMemberPath = "Name";

            //Product
            CanSearchProduct = true;
            FProducts = new List<ProductModel>();

            ProductNameSearchValue.ItemsSource = null;
            ProductNameSearchValue.ItemsSource = PublicVariables.Products;
            ProductNameSearchValue.DisplayMember = "Name";


            ProductNameFilterValue.ItemsSource = null;
            ProductNameFilterValue.ItemsSource = FProducts;
            ProductNameFilterValue.DisplayMemberPath = "Name";

            // Barcode
            ProductBarCodeSearchValue.AutoCompleteSource = null;
            ProductBarCodeSearchValue.AutoCompleteSource = PublicVariables.Products;
            ProductBarCodeSearchValue.SearchItemPath = "BarCode";
            ProductBarCodeSearchValue.AutoCompleteMode = Syncfusion.Windows.Controls.Input.AutoCompleteMode.SuggestAppend;
            ProductBarCodeSearchValue.SuggestionMode = Syncfusion.Windows.Controls.Input.SuggestionMode.Contains;



            // SerialNumber
            ProductSerialNumberSearchValue.AutoCompleteSource = null;
            ProductSerialNumberSearchValue.AutoCompleteSource = PublicVariables.Products;
            ProductSerialNumberSearchValue.SearchItemPath = "SerialNumber";
            ProductSerialNumberSearchValue.AutoCompleteMode = Syncfusion.Windows.Controls.Input.AutoCompleteMode.SuggestAppend;
            ProductSerialNumberSearchValue.SuggestionMode = Syncfusion.Windows.Controls.Input.SuggestionMode.Contains;


            // SerialNumber 2
            ProductSerialNumber2SearchValue.AutoCompleteSource = null;
            ProductSerialNumber2SearchValue.AutoCompleteSource = PublicVariables.Products;
            ProductSerialNumber2SearchValue.SearchItemPath = "SerialNumber2";
            ProductSerialNumber2SearchValue.AutoCompleteMode = Syncfusion.Windows.Controls.Input.AutoCompleteMode.SuggestAppend;
            ProductSerialNumber2SearchValue.SuggestionMode = Syncfusion.Windows.Controls.Input.SuggestionMode.Contains;

            CategoryFilterValue.SelectedItem = PublicVariables.DefaultCategory;
            BrandFilterValue.SelectedItem = PublicVariables.DefaultBrand;

        }

        private void AddNewSupplierButton_Click(object sender, RoutedEventArgs e)
        {
            UserGrid.Visibility = Visibility.Collapsed;
            NewSupplierGrid.Visibility = Visibility.Visible;
        }

        private void BackToUserGridButton_FromCreateNewSupplierGrid_Click(object sender, RoutedEventArgs e)
        {
            UserGrid.Visibility = Visibility.Visible;
            NewSupplierGrid.Visibility = Visibility.Collapsed;

            // Supplier GB
            List<string> supplierSearchTypes = new List<string>();
            supplierSearchTypes.Add("Name");
            supplierSearchTypes.Add("Phone Number");
            supplierSearchTypes.Add("National Number");

            SupplierSearchTypeValue.ItemsSource = null;
            SupplierSearchTypeValue.ItemsSource = supplierSearchTypes;
            SupplierSearchTypeValue.SelectedIndex = 0;

            SupplierSearchValue.ItemsSource = null;
            SupplierSearchValue.ItemsSource = PublicVariables.Suppliers;
            SupplierSearchValue.DisplayMember = "Person.FullName";

        }
         private void SelectedPersonButton_Click(object sender, RoutedEventArgs e)
        {
            SupplierModel supplier = (SupplierModel)SupplierSearchValue.SelectedItem;
            if (supplier != null)
            {
                PersonUC personUC = new PersonUC(supplier.Person);
                SelectedSupplierContentControl.Content = personUC;

                SelectedSupplierLogGrid.Visibility = Visibility.Visible;
                UserGrid.Visibility = Visibility.Collapsed;
            }
        }

        private void BackToUserGridButton_FromSelectedSupplierGrid_Click(object sender, RoutedEventArgs e)
        {
            UserGrid.Visibility = Visibility.Visible;
            SelectedSupplierLogGrid.Visibility = Visibility.Collapsed;

            // Supplier GB
            List<string> supplierSearchTypes = new List<string>();
            supplierSearchTypes.Add("Name");
            supplierSearchTypes.Add("Phone Number");
            supplierSearchTypes.Add("National Number");

            SupplierSearchTypeValue.ItemsSource = null;
            SupplierSearchTypeValue.ItemsSource = supplierSearchTypes;
            SupplierSearchTypeValue.SelectedIndex = 0;

            SupplierSearchValue.ItemsSource = null;
            SupplierSearchValue.ItemsSource = PublicVariables.Suppliers;
            SupplierSearchValue.DisplayMember = "Person.FullName";

        }





        #endregion

        
    }
}
