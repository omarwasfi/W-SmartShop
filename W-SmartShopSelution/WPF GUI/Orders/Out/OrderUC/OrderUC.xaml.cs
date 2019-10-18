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
using Stimulsoft.Report;

namespace WPF_GUI.Orders.Out.OrderUC
{
    /// <summary>
    /// Interaction logic for OrderUC.xaml
    /// </summary>
    public partial class OrderUC : UserControl
    {
        #region Main variables

        private OrderModel OrignalOrder { get; set; }
        private OrderModel Order { get; set; } = new OrderModel();
        private List<OrderProductModel> OrderProducts { get; set; } = new List<OrderProductModel>();

        private List<StockModel> NewStocks { get; set; } = new List<StockModel>();

        #endregion

        #region Help Variables

        private List<StockModel> Stocks { get; set; } = new List<StockModel>();
        private List<OrderProductModel> RemovedOrderProducts { get; set; } = new List<OrderProductModel>();

        #endregion


        #region set the initianl values


        /// <summary>
        /// The details of the order and option to print or to edit the order
        /// </summary>
        /// <param name="order"></param>
        public OrderUC(OrderModel order)
        {
            InitializeComponent();
            OrignalOrder = order;
            SetInitialValues();
        }

        private void SetInitialValues()
        {

            Order = OrignalOrder;
            OrderProducts = Order.Products;
            // Set the GUI values
            OrderIdValue_OrderUC.Text = Order.Id.ToString();
            TotalPriceValue_OrderUC.Text = Order.TotalPrice.ToString();
            TotalOrderProfitValue_OrderUC.Text = Order.GetTotalProfit.ToString();
            TotalPriceAfterChangesValue_OrderUC.Text = Order.TotalPrice.ToString();
            TotalOrderProfitValue_OrderUC.Text = Order.GetTotalProfit.ToString();
            TotalOrderProfitAfterChangesValue_OrderUC.Text = Order.GetTotalProfit.ToString();
            OrderDetailsValue_OrderUC.Text = Order.Details;
            OrderDateValue_OrderUC.Text = Order.DateTimeOfTheOrder.ToString();
            StaffNameValue_OrderUC.Text = Order.Staff.Person.FullName.ToString();
            StoreNameValue_OrderUC.Text = Order.Store.Name.ToString();
            CustomerNameValue_OrderUC.Text = Order.Customer.Person.FullName;
            CustomerPhoneNumberValue_OrderUC.Text = Order.Customer.Person.PhoneNumber;
            CustomerNationalNumberValue_OrderUC.Text = Order.Customer.Person.NationalNumber;
            OrderProductList_OrderUC.ItemsSource = OrderProducts;

            NewStocks = new List<StockModel>();
            RemovedOrderProducts = new List<OrderProductModel>();

            UpdateTheStocksFromThePublicVariables();
            UpdateTheOperationsFromThePublicVariables();
        }

        /// <summary>
        /// Update and gets the stocks from the public variables
        /// </summary>
        private void UpdateTheStocksFromThePublicVariables()
        {
            PublicVariables.LoginStoreStocks = GlobalConfig.Connection.FilterStocksByStore(PublicVariables.Store);
            Stocks = null;
            Stocks = PublicVariables.LoginStoreStocks;
        }

        /// <summary>
        /// Update and gets the operation from the public variables
        /// </summary>
        private void UpdateTheOperationsFromThePublicVariables()
        {
            PublicVariables.Operations = GlobalConfig.Connection.GetOperations();
        }


        #endregion

        #region Hole User Grid Events

        private void RemoveSelectedProductButton_OrderUC_Click(object sender, RoutedEventArgs e)
        {
            
            OrderProductModel selectedItem = (OrderProductModel)OrderProductList_OrderUC.SelectedItem;
            if (selectedItem != null)
            {
                if(OrderProducts.Count > 1)
                {
                    RemovedOrderProducts.Add(selectedItem);
                    OrderProducts.Remove(selectedItem);



                    UpadatOrderProductsList_OrderUC();



                }
                else
                {
                    MessageBox.Show("The Order can't be empty , Delete the order instead");
                }
               
                

            }
            else
            {
                MessageBox.Show("Select a product !");
            }
        }


        /// <summary>
        /// update the choosen product list with orders list
        /// </summary>
        private void UpadatOrderProductsList_OrderUC()
        {
            OrderProductList_OrderUC.ItemsSource = null;
            OrderProductList_OrderUC.ItemsSource = OrderProducts;

            // Updates Total Price
            UpdateTotalPriceTotalProfitAndCustomerShouldReceive();
       }

        /// <summary>
        /// Updates Total Price called by UpadatOrderProductsList_OrderUC
        /// gets order list and calculate the total price
        /// </summary>
        private void UpdateTotalPriceTotalProfitAndCustomerShouldReceive()
        {
            decimal TotalPrice = new decimal();
            decimal TotalOrderProfit = new decimal();
            foreach (OrderProductModel orderProduct in OrderProducts)
            {
                TotalPrice += orderProduct.GetTotalPrice;

                TotalOrderProfit += orderProduct.GetTotalProfit;
            }
            TotalPriceAfterChangesValue_OrderUC.Text = TotalPrice.ToString();
            TotalOrderProfitAfterChangesValue_OrderUC.Text = TotalOrderProfit.ToString();

            CustomerShouldReceiveValue_OrderUC.Text = (decimal.Parse(TotalPriceValue_OrderUC.Text) - TotalPrice).ToString();

        }

        private void ConfitmButton_OrderUC_Click(object sender, RoutedEventArgs e)
        {
            SaveTheOrder();

            
        }

        /// <summary>
        ///  save to the database , Opens the printing tab
        /// </summary>
        private void SaveTheOrder()
        {
            foreach (OrderProductModel orderProduct in RemovedOrderProducts)
            {
                List<StockModel> stocks = GlobalConfig.Connection.GetStocksByProduct(Stocks, orderProduct.Product);
                if (stocks.Count > 0)
                {
                    GlobalConfig.Connection.IncreaseStock(stocks[0], orderProduct.Quantity);
                }
                else
                {
                    StockModel stock = new StockModel();
                    stock.Product = orderProduct.Product;
                    stock.Quantity = orderProduct.Quantity;
                    stock.Store = PublicVariables.Store;
                    GlobalConfig.Connection.AddStockToTheDatabase(stock);
                }

                //Order.Products.Remove(orderProduct);

                GlobalConfig.Connection.RemoveOrderProduct(orderProduct);
            }

            Order.Details = OrderDetailsValue_OrderUC.Text;
            Order.TotalPrice = decimal.Parse(TotalPriceAfterChangesValue_OrderUC.Text);

            GlobalConfig.Connection.UpdateOrderData(Order);

            // Updating the operation data
            OperationModel operation = new OperationModel();
            operation = GlobalConfig.Connection.GetOperationByOrder(Order, PublicVariables.Operations);
            operation.AmountOfMoney = Order.TotalPrice;
            GlobalConfig.Connection.UpdateOperationData(operation);
            


            if (MessageBox.Show("Do you want to print the order ?", "Printing...", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                PrintTheOrder();

            }
            else
            {
                var parent = this.Parent as Window;
                if (parent != null) { parent.DialogResult = true; parent.Close(); }
            }

        }


        private void DeleteOrderButton_OrderUC_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("this Order will be Deleted Complitly, the customer should get "+ Order.GetTotalPrice.ToString() +"  !", "Are you sure ?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach(OrderProductModel orderProduct in OrderProducts)
                {
                    RemovedOrderProducts.Add(orderProduct);
                }


                foreach (OrderProductModel orderProduct in RemovedOrderProducts)
                {
                    List<StockModel> stocks = GlobalConfig.Connection.GetStocksByProduct(Stocks, orderProduct.Product);
                    if (stocks.Count > 0)
                    {
                        GlobalConfig.Connection.IncreaseStock(stocks[0], orderProduct.Quantity);
                    }
                    else
                    {
                        StockModel stock = new StockModel();
                        stock.Product = orderProduct.Product;
                        stock.Quantity = orderProduct.Quantity;
                        stock.Store = PublicVariables.Store;
                        GlobalConfig.Connection.AddStockToTheDatabase(stock);
                    }

                    GlobalConfig.Connection.RemoveOrderProduct(orderProduct);

                }




                OperationModel operation = new OperationModel();
                operation = GlobalConfig.Connection.GetOperationByOrder(Order, PublicVariables.Operations);
                
                GlobalConfig.Connection.RemoveOperation(operation);

                GlobalConfig.Connection.RemoveOrder(Order);


                var parent = this.Parent as Window;
                if (parent != null) { parent.DialogResult = true; parent.Close(); }
            }
        }



        private void PrintButton_OrderUC_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to save the order ?", "Are you sure ?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                SaveTheOrder();

            }
        }

        /// <summary>
        /// Opens the printing tab and fill the prining info
        /// </summary>
        private void PrintTheOrder()
        {
            UserGrid_OrderUC.Visibility = Visibility.Collapsed;
            PrintingGrid_OrderUC.Visibility = Visibility.Visible;


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

            SellOrderReportPrint_OrderUC.Report = report;
        }

        private void BackToNormalGridButton_OrderUC_Click(object sender, RoutedEventArgs e)
        {
            var parent = this.Parent as Window;
            if (parent != null) { parent.DialogResult = true; parent.Close(); }

        }

        #endregion


    }
}
