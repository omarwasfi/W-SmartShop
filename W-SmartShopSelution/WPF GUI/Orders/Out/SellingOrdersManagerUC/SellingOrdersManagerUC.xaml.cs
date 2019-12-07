using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
using Stimulsoft.Base;
using Stimulsoft.Base.Drawing;
using Stimulsoft.Report;
using Stimulsoft.Report.Components;

namespace WPF_GUI.Orders.Out.SellingOrdersManagerUC
{
    /// <summary>
    /// Interaction logic for SellingOrdersManagerUC.xaml
    /// </summary>
    public partial class SellingOrdersManagerUC : UserControl
    {





        #region set the initianl values

        public SellingOrdersManagerUC()
        {
            InitializeComponent();
            SetInitialValues();
        }


        private void SetInitialValues()
        {

            OrdersList.ItemsSource = null;
            OrdersList.ItemsSource = PublicVariables.Orders;
            
        }

        #endregion


        #region Events

        /// <summary>
        /// swithch from the user grid to the print grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            if ((OrderModel)OrdersList.SelectedItem != null)
            {
                OrderModel order = (OrderModel)OrdersList.SelectedItem;

                UserGrid.Visibility = Visibility.Collapsed;
                PrintGrid.Visibility = Visibility.Visible;


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
                if (order.GetTotalPaid < order.GetTotalPrice)
                {
                    printLast += "Payment due within 30 days from date of invoice\n";
                }

                printLast += "Thank you for your business!";
                report["PrintLast"] = printLast;


                report.Render();

                OrdersPrint.Report = report;


            }
            else
            {
                MessageBox.Show("Select Order to print !");
            }
        }

        private void BackToNormalGridButton_FromPrintGrid_Click(object sender, RoutedEventArgs e)
        {
            PrintGrid.Visibility = Visibility.Collapsed;
            UserGrid.Visibility = Visibility.Visible;
        }

        private void BackToNormalGridButton_FromOrderGrid_Click(object sender, RoutedEventArgs e)
        {
            OrderGrid.Visibility = Visibility.Collapsed;
            UserGrid.Visibility = Visibility.Visible;
            SetInitialValues();
        }

        private void OrdersList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if ((OrderModel)OrdersList.SelectedItem != null)
            {
                OrderModel order = (OrderModel)OrdersList.SelectedItem;
                UserGrid.Visibility = Visibility.Collapsed;
                OrderGrid.Visibility = Visibility.Visible;
                OrderUC.OrderUC orderUC = new OrderUC.OrderUC(order);
                OrderUCContant.Content = orderUC;

            }
        }

        private void ReloadTabButton_Click(object sender, RoutedEventArgs e)
        {
            SetInitialValues();
        }



        #endregion


    }
}
