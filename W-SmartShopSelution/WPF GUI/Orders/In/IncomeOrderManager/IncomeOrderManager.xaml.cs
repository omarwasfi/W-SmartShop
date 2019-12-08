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

namespace WPF_GUI.Orders.In.IncomeOrderManager
{
    /// <summary>
    /// Interaction logic for IncomeOrderManager.xaml
    /// </summary>
    public partial class IncomeOrderManagerUC : UserControl
    {
        #region set the initianl values


        public IncomeOrderManagerUC()
        {
            InitializeComponent();
            SetInitialValues();
        }

        private void SetInitialValues()
        {

            IncomeOrdersList.ItemsSource = null;
            IncomeOrdersList.ItemsSource = PublicVariables.IncomeOrders;

        }

        #endregion
        #region Events

        private void ReloadTabButton_Click(object sender, RoutedEventArgs e)
        {
            SetInitialValues();
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

    }
}
