using Library;
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

namespace WPF_GUI.CustomerLogUC
{
    /// <summary>
    /// Interaction logic for CustomerLogUC.xaml
    /// </summary>
    public partial class CustomerLogUC : UserControl
    {

        #region Main Variables

        /// <summary>
        /// Customer that we need to see his orders
        /// </summary>
        private CustomerModel Customer { get; set; }

        private List<OrderModel> CustomerOrders { get; set; }

        #endregion

        /// <summary>
        /// Get a customer model that we need to see his log
        /// </summary>
        /// <param name="customer"></param>
        public CustomerLogUC(CustomerModel customer)
        {
            InitializeComponent();

            Customer = customer;

            SetInitialValues();




        }

        /// <summary>
        /// set teh inital values
        /// </summary>
        private void SetInitialValues()
        {

            CustomerOrders = GlobalConfig.Connection.FilterOrdersByCustomer(PublicVariables.Orders, Customer);

            SetGuiDefaultValues();
        

        }

        /// <summary>
        /// Set the OrdersList_CustomerLogUC
        /// </summary>
        private void SetGuiDefaultValues()
        {
            OrdersList_CustomerLogUC.ItemsSource = null;
            OrdersList_CustomerLogUC.ItemsSource = CustomerOrders;
        }

        /// <summary>
        /// Close the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_CustomerLogUC_Click(object sender, RoutedEventArgs e)
        {
            var parent = this.Parent as Window;
            if (parent != null) { parent.DialogResult = true; parent.Close(); }
        }
    }
}
