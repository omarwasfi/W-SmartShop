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
using WPF_GUI.Orders.In.ModifyBill;
using Library;

namespace WPF_GUI.Orders.In.BillsManagerUC
{
    /// <summary>
    /// Interaction logic for BillsManagerUC.xaml
    /// </summary>
    public partial class BillsManagerUC : UserControl
    {

        #region Main variables



        #endregion

        #region Help Variables

       

        #endregion

        #region set the initianl values


        public BillsManagerUC()
        {
            InitializeComponent();
            SetInitialValues();

        }

        public void SetInitialValues()
        {
            // Grids
            UserGrid.Visibility = Visibility.Visible;
            PayBillGrid.Visibility = Visibility.Collapsed;

            BillsList.ItemsSource = null;
            BillsList.ItemsSource = PublicVariables.ShopBills;
        }





        #endregion

        #region Hole form events , functions

        private void PayBillButton_Click(object sender, RoutedEventArgs e)
        {
            PayBillGrid.Visibility = Visibility.Visible;
            UserGrid.Visibility = Visibility.Collapsed;
        }

        private void BackToNormalGridButton_FromPayBillGrid_Click(object sender, RoutedEventArgs e)
        {
            UserGrid.Visibility = Visibility.Visible;
            PayBillGrid.Visibility = Visibility.Collapsed;
            SetInitialValues();
        }


        #endregion

       
    }
}
