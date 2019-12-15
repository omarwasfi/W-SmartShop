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
using ValidationResult = FluentValidation.Results.ValidationResult;
using Stimulsoft.Report;

namespace WPF_GUI.Orders.Out.OrderUC
{
    /// <summary>
    /// Interaction logic for OrderUC.xaml
    /// </summary>
    public partial class OrderUC : UserControl
    {
        #region Main variables

        /// <summary>
        /// The orignal Order
        /// </summary>
        private OrderModel Order { get; set; }

        /// <summary>
        /// The Modified Order
        /// </summary>
        private OrderModel ModifiedOrder { get; set;}
        #endregion

        #region Help Variables


        /// <summary>
        /// The Removed order Products 
        /// </summary>
        private List<OrderProductModel> RemovedOrderProducts { get; set; } 
        #endregion


        #region set the initianl values


        /// <summary>
        /// The details of the order and option to print or to edit the order
        /// </summary>
        /// <param name="order"></param>
        public OrderUC(OrderModel order)
        {
            InitializeComponent();
            Order = order;
            SetInitialValues();
        }

        private void SetInitialValues()
        {
            ModifiedOrder = CloneObject.CloneObjectSerializable<OrderModel>(Order);

            RemovedOrderProducts = new List<OrderProductModel>();

            // Order info
            OrderIdValue.Text = Order.Id.ToString();
            OrderDateValue.Text = Order.DateTimeOfTheOrder.ToString();
            StaffNameValue.Text = Order.Staff.Person.FullName;
            StoreNameValue.Text = Order.Store.Name;
            CustomerNameValue.Text = Order.Customer.Person.FullName;

            OrderTotalPriceValue.Value = Order.GetTotalPrice;
            TotalPriceAfterChangesValue.Value = Order.GetTotalPrice;

            TotalProfitValue.Value = Order.GetTotalProfit;
            TotalProfitAfterChangesValue.Value = Order.GetTotalProfit;

            OrderDetailsValue.Text = Order.Details;

            // Order Payments
            OrderPaymentsList.ItemsSource = null;
            OrderPaymentsList.ItemsSource = Order.OrderPayments;

            OrderProductList.ItemsSource = null;
            OrderProductList.ItemsSource = ModifiedOrder.OrderProducts;

            RemovedOrderProductList.ItemsSource = null;
            RemovedOrderProductList.ItemsSource = RemovedOrderProducts;

            SelectedOrderProductQuantityValue.Value = 0;

            TotalPaidValue.Value = Order.GetTotalPaid;
            ShoppeeWalletValue.Value = PublicVariables.Store.GetShopeeWallet;

            if (ModifiedOrder.GetOrderState == "DONE")
            {
                CustomerShouldPayValue.Value = 0;
                CustomerShouldReceiveValue.Value = 0;

                StoreWillPayNowValue.Value = 0;
                StoreWillPayLaterValue.Value = 0;

                CustomerWillPayNowValue.Value = 0;
                CustomerWillPayLaterValue.Value = 0;
            }
            else if (ModifiedOrder.GetOrderState == "Customer Should Pay")
            {
                CustomerShouldPayValue.Value = ModifiedOrder.GetTotalNotPaid;
                CustomerShouldReceiveValue.Value = 0;

                CustomerWillPayNowValue.Value = ModifiedOrder.GetTotalNotPaid;
                CustomerWillPayLaterValue.Value = 0;

                StoreWillPayNowValue.Value = 0;
                StoreWillPayLaterValue.Value = 0;
            }
            else if (ModifiedOrder.GetOrderState == "Customer Should Receive")
            {
                CustomerShouldPayValue.Value = 0;
                CustomerShouldReceiveValue.Value = ModifiedOrder.GetCustomerShouldReceive;

                StoreWillPayNowValue.Value = ModifiedOrder.GetCustomerShouldReceive;
                StoreWillPayLaterValue.Value = 0;

                CustomerWillPayNowValue.Value = 0;
                CustomerWillPayLaterValue.Value = 0;
            }
            else
            {
                CustomerShouldPayValue.Value = 0;

                CustomerShouldReceiveValue.Value = 0;
            }



        }
        
        #endregion

        #region Hole User Grid Functions & Events

        private void UpdateOrderProducts()
        {
            OrderProductList.ItemsSource = null;
            OrderProductList.ItemsSource = ModifiedOrder.OrderProducts;

            RemovedOrderProductList.ItemsSource = null;
            RemovedOrderProductList.ItemsSource = RemovedOrderProducts;

            SelectedOrderProductQuantityValue.Value = 0;

            if (ModifiedOrder.GetOrderState == "DONE")
            {
                CustomerShouldPayValue.Value = 0;
                CustomerShouldReceiveValue.Value = 0;

                StoreWillPayNowValue.Value = 0;
                StoreWillPayLaterValue.Value = 0;

                CustomerWillPayNowValue.Value = 0;
                CustomerWillPayLaterValue.Value = 0;
            }
            else if (ModifiedOrder.GetOrderState == "Customer Should Pay")
            {
                CustomerShouldPayValue.Value = ModifiedOrder.GetTotalNotPaid;
                CustomerShouldReceiveValue.Value = 0;

                CustomerWillPayNowValue.Value = ModifiedOrder.GetTotalNotPaid;
                CustomerWillPayLaterValue.Value = 0;

                StoreWillPayNowValue.Value = 0;
                StoreWillPayLaterValue.Value = 0;
            }
            else if (ModifiedOrder.GetOrderState == "Customer Should Receive")
            {
                CustomerShouldPayValue.Value = 0;
                CustomerShouldReceiveValue.Value = ModifiedOrder.GetCustomerShouldReceive;

                StoreWillPayNowValue.Value = ModifiedOrder.GetCustomerShouldReceive;
                StoreWillPayLaterValue.Value = 0;

                CustomerWillPayNowValue.Value = 0;
                CustomerWillPayLaterValue.Value = 0;
            }
            else
            {
                CustomerShouldPayValue.Value = 0;

                CustomerShouldReceiveValue.Value = 0;
            }

            TotalPriceAfterChangesValue.Value = ModifiedOrder.GetTotalPrice;
            TotalProfitAfterChangesValue.Value = ModifiedOrder.GetTotalProfit;
        }

    
        /// <summary>
        ///  save to the database , Opens the printing tab
        /// </summary>
        private void SaveTheOrder()
        {

            if(RemovedOrderProducts.Count == 0)
            {

                if (CustomerWillPayNowValue.Value > 0)
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

                    }
                    else
                    {
                        GlobalConfig.Connection.AddOrderPaymentToTheDatabase(Order, orderPayment);
                        if (MessageBox.Show("Do you want to print the order ?", "Printing...", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            PrintTheOrder();
                        }


                    }
                }
                else if (StoreWillPayNowValue.Value > 0)
                {
                    GlobalConfig.Connection.StorePayment(Order, StoreWillPayNowValue.Value.Value);
                }

                SetInitialValues();
            }
            else
            {

                if (CustomerWillPayNowValue.Value > 0)
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

                    }
                    else
                    {

                        GlobalConfig.Connection.AddOrderPaymentToTheDatabase(Order, orderPayment);

                        if (MessageBox.Show("Do you want to print the order ?", "Printing...", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            PrintTheOrder();
                        }

                    }
                }
                else if(StoreWillPayNowValue.Value > 0)
                {

                    GlobalConfig.Connection.StorePayment(Order, StoreWillPayNowValue.Value.Value);
                }

                GlobalConfig.Connection.UpdateOrder(Order, RemovedOrderProducts);

                

                SetInitialValues();

            }


        }

        /// <summary>
        /// Opens the printing tab and fill the prining info
        /// </summary>
        private void PrintTheOrder()
        {
            if(Order.OrderProducts.Count > 0)
            {
                UserGrid.Visibility = Visibility.Collapsed;
                PrintingGrid.Visibility = Visibility.Visible;


                StiReport report = new StiReport();
                // add the data to the datastore
                report.Load(@"SellOrderReportARforEMG.mrt");

                report.Compile();

                report["OrganizationName"] = PublicVariables.Organization.Name;
                report["OrganizationAddress"] = PublicVariables.Organization.Address;
                report["OrganizationPhoneNumber"] = PublicVariables.Organization.PhoneNumber;

                report["DateTime"] = Order.DateTimeOfTheOrder.ToShortTimeString();
                report["StaffName"] = Order.Staff.Person.FullName;
                report["StoreName"] = Order.Store.Name;
                report["StorePhoneNumber"] = Order.Store.PhoneNumber;
                report["StoreAddress"] = Order.Store.Address;
                report["OrderId"] = Order.Id;



                report["CustomerName"] = Order.Customer.Person.FullName;
                report["CustomerPhoneNumber"] = Order.Customer.Person.PhoneNumber;
                report["CustomerNationalNumber"] = Order.Customer.Person.NationalNumber;
                report["CustomerAddress"] = Order.Customer.Person.Address;


                report["OrderDetails"] = Order.Details;
                report["TotalPrice"] = Order.GetTotalPrice.ToString("G29");
                report["TotalPaid"] = Order.GetTotalPaid.ToString("G29");
                report["TotalOrderProduct"] = Order.GetTheNumberOfOrderProducts.ToString();


                string printLast = "";
                if (Order.GetTotalPaid < Order.GetTotalPrice)
                {
                    printLast += "Payment due within 30 days from date of invoice\n";
                }

                printLast += "Thank you for your business!";
                report["PrintLast"] = printLast;


                report.Render();

                SellOrderReportPrint.Report = report;
            }
            else
            {
                MessageBox.Show("The order Is Empty !");
            }

         
        }



        #region Events
        private void CustomerWillPayNowValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            decimal payNow = CustomerWillPayNowValue.Value.Value;

            if (payNow > CustomerShouldPayValue.Value)
            {
                CustomerWillPayNowValue.Value = CustomerShouldPayValue.Value;
                CustomerWillPayLaterValue.Value = 0;

            }
            else if (payNow == 0)
            {
                CustomerWillPayNowValue.Value = 0;
                CustomerWillPayLaterValue.Value = CustomerShouldPayValue.Value;
            }
            else
            {
                CustomerWillPayLaterValue.Value = CustomerShouldPayValue.Value - payNow;
            }
        }

        private void CustomerWillPayLaterValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            decimal payLater = CustomerWillPayLaterValue.Value.Value;

            if (payLater > CustomerShouldPayValue.Value)
            {
                CustomerWillPayLaterValue.Value = CustomerShouldPayValue.Value;
                CustomerWillPayNowValue.Value = 0;
            }
            else if (payLater == 0)
            {
                CustomerWillPayLaterValue.Value = 0;
                CustomerWillPayNowValue.Value = CustomerShouldPayValue.Value;
            }
            else
            {
                CustomerWillPayNowValue.Value = CustomerShouldPayValue.Value - payLater;
            }
        }

        private void ConfitmButton_Click(object sender, RoutedEventArgs e)
        {
            SaveTheOrder();
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            if(CustomerWillPayNowValue.Value > 0)
            {
                if (MessageBox.Show("Do you want to Save the order  ?", "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    SaveTheOrder();
                }
            }
            else
            {
                PrintTheOrder();
            }

            
        }
        private void BackToNormalGridButton_FromPrintGrid_Click(object sender, RoutedEventArgs e)
        {
            UserGrid.Visibility = Visibility.Visible;
            PrintingGrid.Visibility = Visibility.Collapsed;

            SetInitialValues();
        }

        private void StoreWillPayNowValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            decimal payNow = StoreWillPayNowValue.Value.Value;

            if (payNow > CustomerShouldReceiveValue.Value)
            {
                StoreWillPayNowValue.Value = CustomerShouldReceiveValue.Value;
                StoreWillPayLaterValue.Value = 0;

            }
            else if (payNow == 0)
            {
                StoreWillPayNowValue.Value = 0;
                StoreWillPayLaterValue.Value = CustomerShouldReceiveValue.Value;
            }
            else if (payNow > ShoppeeWalletValue.Value.Value)
            {
                StoreWillPayNowValue.Value = ShoppeeWalletValue.Value.Value;
                StoreWillPayLaterValue.Value = CustomerShouldReceiveValue.Value - ShoppeeWalletValue.Value.Value;
            }
            else
            {
                StoreWillPayLaterValue.Value = CustomerShouldReceiveValue.Value - payNow;
            }
        }

        private void StoreWillPayLaterValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            decimal payLater = StoreWillPayLaterValue.Value.Value;

            if (payLater > CustomerShouldReceiveValue.Value)
            {
                StoreWillPayLaterValue.Value = CustomerShouldReceiveValue.Value;
                StoreWillPayNowValue.Value = 0;


            }
            else if (payLater == 0)
            {
                StoreWillPayLaterValue.Value = 0;
                StoreWillPayNowValue.Value = CustomerShouldReceiveValue.Value;
            }
            else
            {
                StoreWillPayNowValue.Value = CustomerShouldReceiveValue.Value - payLater;
            }
        }

        private void OrderProductList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OrderProductModel orderProduct = (OrderProductModel)OrderProductList.SelectedItem;
            if (orderProduct != null)
            {
                SelectedOrderProductQuantityValue.Value = orderProduct.Quantity;
            }
        }

        private void SelectedOrderProductQuantityValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            OrderProductModel orderProduct = (OrderProductModel)OrderProductList.SelectedItem;
            if (orderProduct != null)
            {
                if (SelectedOrderProductQuantityValue.Value > orderProduct.Quantity)
                {
                    SelectedOrderProductQuantityValue.Value = orderProduct.Quantity;
                }

            }
            else
            {
                SelectedOrderProductQuantityValue.Value = 0;
            }
        }

        private void MoveSelectedToRemovedProductsGridButton_Click(object sender, RoutedEventArgs e)
        {
            OrderProductModel orderProduct = (OrderProductModel)OrderProductList.SelectedItem;
            if (orderProduct != null)
            {
                if (SelectedOrderProductQuantityValue.Value > 0)
                {
                    OrderProductModel orderProductModel = new OrderProductModel();
                    orderProductModel = orderProduct.CloneObjectSerializable();
                    orderProductModel.Quantity = (float)SelectedOrderProductQuantityValue.Value;
                    
                    if(RemovedOrderProducts.Exists(x=>x.Product.Id == orderProductModel.Product.Id))
                    {
                        RemovedOrderProducts.Find(x => x.Product.Id == orderProductModel.Product.Id).Quantity += orderProductModel.Quantity;
                    }
                    else
                    {
                        RemovedOrderProducts.Add(orderProductModel);
                    }
                    

                    orderProduct.Quantity -= orderProductModel.Quantity;
                    if (orderProduct.Quantity == 0)
                    {
                        ModifiedOrder.OrderProducts.Remove(orderProduct);
                    }

                    UpdateOrderProducts();
                }

            }

        }

        private void MoveSelectedToNotRemovedProductsButton_Click(object sender, RoutedEventArgs e)
        {
            OrderProductModel orderProduct = (OrderProductModel)RemovedOrderProductList.SelectedItem;
            if (orderProduct != null)
            {
                
                    OrderProductModel orderProductModel = new OrderProductModel();
                    orderProductModel = orderProduct.CloneObjectSerializable();


                    if (ModifiedOrder.OrderProducts.Exists(x => x.Product.Id == orderProductModel.Product.Id))
                    {
                        ModifiedOrder.OrderProducts.Find(x => x.Product.Id == orderProductModel.Product.Id).Quantity += orderProductModel.Quantity;
                    }
                    else
                    {
                        ModifiedOrder.OrderProducts.Add(orderProductModel);
                    }


                    orderProduct.Quantity -= orderProductModel.Quantity;
                    if (orderProduct.Quantity == 0)
                    {
                        RemovedOrderProducts.Remove(orderProduct);
                    }

                    UpdateOrderProducts();
                

            }
        }

        private void MoveAllProductsToRemovedProductsGridButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (OrderProductModel orderProductModel in ModifiedOrder.OrderProducts)
            {
                if (RemovedOrderProducts.Exists(x => x.Product.Id == orderProductModel.Product.Id))
                {
                    RemovedOrderProducts.Find(x => x.Product.Id == orderProductModel.Product.Id).Quantity += orderProductModel.Quantity;
                    ModifiedOrder.OrderProducts.Remove(orderProductModel);
                }
                else
                {
                    RemovedOrderProducts.Add(orderProductModel);
                    ModifiedOrder.OrderProducts.Remove(orderProductModel);
                }
                if (ModifiedOrder.OrderProducts.Count == 0)
                {
                    break;
                }
            }
            UpdateOrderProducts();

        }

        private void ResetListsButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (OrderProductModel orderProductModel in RemovedOrderProducts)
            {
                if (ModifiedOrder.OrderProducts.Exists(x => x.Product.Id == orderProductModel.Product.Id))
                {
                    ModifiedOrder.OrderProducts.Find(x => x.Product.Id == orderProductModel.Product.Id).Quantity += orderProductModel.Quantity;
                    RemovedOrderProducts.Remove(orderProductModel);
                }
                else
                {
                    ModifiedOrder.OrderProducts.Add(orderProductModel);
                    RemovedOrderProducts.Remove(orderProductModel);
                }
                if (RemovedOrderProducts.Count == 0)
                {
                    break;
                }
            }
            UpdateOrderProducts();

        }

        #endregion

        #endregion


    }
}
