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

namespace WPF_GUI.Orders.In.BillsManagerUC
{
    /// <summary>
    /// Interaction logic for BillsManagerUC.xaml
    /// </summary>
    public partial class BillsManagerUC : UserControl
    {

        #region Main variables

        /// <summary>
        /// All the orders in the database
        /// </summary>
        private List<ShopBillModel> ShopBills = new List<ShopBillModel>();

        #endregion

        public BillsManagerUC()
        {
            InitializeComponent();
        }



        /// <summary>
        /// NotDone
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PayBillButton_BillsManagerUC_Click(object sender, RoutedEventArgs e)
        {
            PayBillUC.PayBillUC payBill = new PayBillUC.PayBillUC();
            Window window = new Window
            {
                Title = "Pay Bill",
                Content = payBill,
                SizeToContent = SizeToContent.WidthAndHeight,
                ResizeMode = ResizeMode.NoResize
            };
            window.ShowDialog();
            
        }
    }
}
