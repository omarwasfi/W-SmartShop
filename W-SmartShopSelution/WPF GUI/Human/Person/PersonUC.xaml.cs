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

namespace WPF_GUI
{
    /// <summary>
    /// Interaction logic for PersonUC.xaml
    /// </summary>
    public partial class PersonUC : UserControl
    {

        public PersonModel Person { get; set; }

        #region Set the initial values
        public PersonUC(PersonModel person)
        {
            InitializeComponent();
            Person = person;
            SetInitialValues();
        }

        private void SetInitialValues()
        {
            PersonFullNameValue.Text = Person.FullName;

            CustomerSwichButton.IsEnabled = false;
            SupplierSwichButton.IsEnabled = false;
            StaffSwichButton.IsEnabled = false;
            OwnerSwichButton.IsEnabled = false;

            if (Person.GetThePersonProperties.Contains("Customer"))
            {
                CustomerSwichButton.IsEnabled = true;
                OrdersList.ItemsSource = null;
                OrdersList.ItemsSource = Person.GetAsACustomer.GetOrders;
                
                OrdersGrid.Visibility = Visibility.Visible;
                IncomeOrdersGrid.Visibility = Visibility.Collapsed;
                OperationsGrid.Visibility = Visibility.Collapsed;
                OwnerGrid.Visibility = Visibility.Collapsed;
            }
            if (Person.GetThePersonProperties.Contains("Supplier"))
            {
                SupplierSwichButton.IsEnabled = true;
                IncomeOrdersList.ItemsSource = null;
                IncomeOrdersList.ItemsSource = Person.GetAsASupplier.GetIncomeOrders;
            }
            if (Person.GetThePersonProperties.Contains("Staff"))
            {
                StaffSwichButton.IsEnabled = true;
                OperationsList.ItemsSource = null;
                OperationsList.ItemsSource = Person.GetAsAStaff.GetOperations;
            }

            if (Person.GetThePersonProperties.Contains("Owner"))
            {
                OwnerSwichButton.IsEnabled = true;
                InvestList.ItemsSource = null;
                InvestList.ItemsSource = Person.GetAsOwner.Investments;
                RevenueList.ItemsSource = null;
                RevenueList.ItemsSource = Person.GetAsOwner.Revenues;
            }

        }

        #endregion

        #region Grid Switch
        private void EditTabButton_Click(object sender, RoutedEventArgs e)
        {
            UserGrid.Visibility = Visibility.Collapsed;
            EditGrid.Visibility = Visibility.Visible;

            ModifyPersonUC.ModifyPersonUC modifyPerson = new ModifyPersonUC.ModifyPersonUC(Person);
            EditPersonContentControl.Content = modifyPerson;
        }

        private void BackToNormalGridButton_FromEditPersonGrid_Click(object sender, RoutedEventArgs e)
        {
            UserGrid.Visibility = Visibility.Visible;
            EditGrid.Visibility = Visibility.Collapsed;

            SetInitialValues();
        }

        private void ReloadTabButton_Click(object sender, RoutedEventArgs e)
        {
            SetInitialValues();
        }

        private void CustomerSwichButton_Click(object sender, RoutedEventArgs e)
        {
            OrdersGrid.Visibility = Visibility.Visible;
            IncomeOrdersGrid.Visibility = Visibility.Collapsed;
            OperationsGrid.Visibility = Visibility.Collapsed;
            OwnerGrid.Visibility = Visibility.Collapsed;
        }

        private void SupplierSwichButton_Click(object sender, RoutedEventArgs e)
        {
            OrdersGrid.Visibility = Visibility.Collapsed;
            IncomeOrdersGrid.Visibility = Visibility.Visible;
            OperationsGrid.Visibility = Visibility.Collapsed;
            OwnerGrid.Visibility = Visibility.Collapsed;
        }

        private void StaffSwichButton_Click(object sender, RoutedEventArgs e)
        {
            OrdersGrid.Visibility = Visibility.Collapsed;
            IncomeOrdersGrid.Visibility = Visibility.Collapsed;
            OperationsGrid.Visibility = Visibility.Visible;
            OwnerGrid.Visibility = Visibility.Collapsed;
        }

        private void OwnerSwichButton_Click(object sender, RoutedEventArgs e)
        {
            OrdersGrid.Visibility = Visibility.Collapsed;
            IncomeOrdersGrid.Visibility = Visibility.Collapsed;
            OperationsGrid.Visibility = Visibility.Collapsed;
            OwnerGrid.Visibility = Visibility.Visible;
        }

        #endregion


    }
}
