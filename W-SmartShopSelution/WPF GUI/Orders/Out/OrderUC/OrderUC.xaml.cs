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
        /// The Order
        /// </summary>
        private OrderModel Order { get; set; }

        #endregion

        #region Help Variables

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
            OrderIdValue.Text = Order.Id.ToString();
            OrderDateValue.Text = Order.DateTimeOfTheOrder.ToString();
            StaffNameValue.Text = Order.Staff.Person.FullName;
            StoreNameValue.Text = Order.Store.Name;

            OrderTotalPriceValue.Value = Order.GetTotalPrice;
            TotalPriceAfterChangesValue.Value = Order.GetTotalPrice;

            TotalProfitValue.Value = Order.GetTotalProfit;
            TotalProfitAfterChangesValue.Value = Order.GetTotalProfit;

            OrderDetailsValue.Text = Order.Details;

            CustomerNameValue.Text = Order.Customer.Person.FullName;
            CustomerPhoneNumberValue.Text = Order.Customer.Person.PhoneNumber;
            CustomerNationalNumberValue.Text = Order.Customer.Person.NationalNumber;

            OrderProductList.ItemsSource = null;
            OrderProductList.ItemsSource = Order.OrderProducts;

            OrderPaymentsList.ItemsSource = null;
            OrderPaymentsList.ItemsSource = Order.OrderPayments;

            TotalPaidValue.Value = Order.GetTotalPaid;

            CustomerShouldPayValue.Value = Order.GetTotalNotPaid;

            CustomerShouldReceiveValue.Value = 0;

            CustomerWillPayNowValue.Value = Order.GetTotalNotPaid;
            CustomerWillPayLaterValue.Value = 0;

        }

       


        #endregion

        #region Hole User Grid Events

      /*  private void RemoveSelectedProductButton_OrderUC_Click(object sender, RoutedEventArgs e)
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
        }*/


      /*  /// <summary>
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

            decimal customerShouldReceive = new decimal();
            //customerShouldReceive = OrignalOrder.Paid - TotalPrice;
            if(customerShouldReceive < 0)
            {
                //CustomerShouldPayValue_OrderUC.Text =( TotalPrice - OrignalOrder.Paid).ToString();
                CustomerWillPayNowValue_OrderUC.Text = CustomerShouldPayValue_OrderUC.Text;
                CustomerWillPayLaterValue_OrderUC.Text = "";

            }
            else
            {
                CustomerShouldReceiveValue_OrderUC.Text = customerShouldReceive.ToString();
                CustomerShouldPayValue_OrderUC.Text = "";
                CustomerWillPayNowValue_OrderUC.Text ="";
                CustomerWillPayLaterValue_OrderUC.Text = "";


            }


        }*/

        /// <summary>
        ///  save to the database , Opens the printing tab
        /// </summary>
        private void SaveTheOrder()
        {

            if(CustomerWillPayNowValue.Value > 0)
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
                    else
                    {

                        SetInitialValues();
                    }

                }
            }

           


        }

        /// <summary>
        /// Opens the printing tab and fill the prining info
        /// </summary>
        private void PrintTheOrder()
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


        #endregion

        #endregion


    }
}
