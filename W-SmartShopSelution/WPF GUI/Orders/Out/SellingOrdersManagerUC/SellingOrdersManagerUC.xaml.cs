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
        #region UserGrid

        #region Main variables

        /// <summary>
        /// All the orders in the database
        /// </summary>
        private List<OrderModel> Orders = new List<OrderModel>();

        #endregion

        #region Help Variables

        private List<string> SearchTypes { get; set; } = new List<string>() { "Order" , "Customer Name"};

        private List<OrderModel> FOrders { get; set; } = new List<OrderModel>();

        #endregion


        #region set the initianl values

        public SellingOrdersManagerUC()
        {
            InitializeComponent();
            SetInitialValues();
        }


        private void SetInitialValues()
        {
            UpdateTheOrdersFromTheDatabase();

            UserGrid_SellingOrdersManagerUC.Visibility = Visibility.Visible;
            PrintGrid_SellingOrdersManagerUC.Visibility = Visibility.Collapsed;

            // Set the search types
            OrderSearchType_SellingOrdersManagerUC.ItemsSource = null;
            OrderSearchType_SellingOrdersManagerUC.ItemsSource = SearchTypes;

            // set the calender to today's date
            DateFilterValue_SellingOrdersManagerUC.SelectedDate = DateTime.Now;
            DateFilterValue_SellingOrdersManagerUC.DisplayDateEnd = DateTime.Now;

            
        }

        /// <summary>
        /// Update and get the orders from the public variables
        /// </summary>
        private void UpdateTheOrdersFromTheDatabase()
        {
            PublicVariables.Orders = GlobalConfig.Connection.GetOrders();
            Orders = null;
            Orders = PublicVariables.Orders;
        }






        #endregion

        #region Hole User Grid Events

        /// <summary>
        /// Set the FOrders list with the new date
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateFilterValue_SellingOrdersManagerUC_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            FOrders = GlobalConfig.Connection.FilterOrdersByDate(Orders, DateFilterValue_SellingOrdersManagerUC.SelectedDate.Value);
            OrdersList_SellingOrdersManagerUC.ItemsSource = null;
            OrdersList_SellingOrdersManagerUC.ItemsSource = FOrders;
        }

        private void OrderSearchButton_SellingOrdersManagerUC_Click(object sender, RoutedEventArgs e)
        {
            if (OrderSearchType_SellingOrdersManagerUC.Text == "Order")
            {
                FOrders = GlobalConfig.Connection.FilterOrdersByOrderId(Orders, OrderSearchValue_SellingOrdersManagerUC.Text);
                OrdersList_SellingOrdersManagerUC.ItemsSource = null;
                OrdersList_SellingOrdersManagerUC.ItemsSource = FOrders;

            }
            else if (OrderSearchType_SellingOrdersManagerUC.Text == "Customer Name")
            {
                FOrders = GlobalConfig.Connection.FilterOrdersByCustomerName(Orders, OrderSearchValue_SellingOrdersManagerUC.Text);
                OrdersList_SellingOrdersManagerUC.ItemsSource = null;
                OrdersList_SellingOrdersManagerUC.ItemsSource = FOrders;
            }
            else
            {
                MessageBox.Show("Select the search type !");
            }

        }

        /// <summary>
        /// swithch from the user grid to the print grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrintButton_SellingOrdersManagerUC_Click(object sender, RoutedEventArgs e)
        {
            UserGrid_SellingOrdersManagerUC.Visibility = Visibility.Collapsed;
            PrintGrid_SellingOrdersManagerUC.Visibility = Visibility.Visible;

         

            StiReport report = new StiReport();


            // add the data to the datastore
            report.Load(@"SellingOrdersManagerReport.mrt");
            report.Compile();
            report["Id"] = 654;
            report.Render();



            OrdersPrint_SellingOrdersManagerUC.Report = report;
            OrdersPrint_SellingOrdersManagerUC.Refresh();

        }

        /// <summary>
        /// Reload the hole form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReloadTabButton_SellingOrdersManagerUC_Click(object sender, RoutedEventArgs e)
        {
            SetInitialValues();
        }



        #endregion

        #endregion

        #region UserGrid

        #region Hole User Grid Events

        /// <summary>
        /// Go from the print grid to the user grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackToNormalGridButton_SellingOrdersManagerUC_Click(object sender, RoutedEventArgs e)
        {
            PrintGrid_SellingOrdersManagerUC.Visibility = Visibility.Collapsed;
            UserGrid_SellingOrdersManagerUC.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Open the order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OrdersList_SellingOrdersManagerUC_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(OrdersList_SellingOrdersManagerUC.SelectedItem != null)
            {

                OrderUC.OrderUC orderUC = new OrderUC.OrderUC((OrderModel)OrdersList_SellingOrdersManagerUC.SelectedItem);
                Window window = new Window
                {
                    Title = "Order",
                    Content = orderUC,
                    SizeToContent = SizeToContent.WidthAndHeight,
                    ResizeMode = ResizeMode.NoResize
                };
                window.ShowDialog();
                SetInitialValues();
            }
        }


        #endregion

        #endregion

    }
}
