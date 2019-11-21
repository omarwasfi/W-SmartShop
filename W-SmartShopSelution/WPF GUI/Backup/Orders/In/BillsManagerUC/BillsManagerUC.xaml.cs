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

        /// <summary>
        /// All the orders in the database
        /// </summary>
        private List<ShopBillModel> ShopBills = new List<ShopBillModel>();

        #endregion

        #region Help Variables

        /// <summary>
        /// The filtered shopBills
        /// </summary>
        private List<ShopBillModel> FShopBills { get; set; } = new List<ShopBillModel>();

        #endregion

        #region set the initianl values


        public BillsManagerUC()
        {
            InitializeComponent();
            SetInitialValues();

        }

        public void SetInitialValues()
        {
            UpdateTheShopBillsFromThePublicVariables();

            BillsList_BillsManagerUC.ItemsSource = null;
            BillsList_BillsManagerUC.ItemsSource = ShopBills;
        }


        /// <summary>
        /// Update And get the shopBills From the publicVariables
        /// </summary>
        private void UpdateTheShopBillsFromThePublicVariables()
        {
            PublicVariables.ShopBills = GlobalConfig.Connection.GetShopBills();
            ShopBills = null;
            ShopBills = PublicVariables.ShopBills;
        }


        #endregion

        #region Hole form events , functions




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
            SetInitialValues();

        }

        private void ReloadTabButton_BillsManagerUC_Click(object sender, RoutedEventArgs e)
        {
            SetInitialValues();
        }


        private void BillsList_BillsManagerUC_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (BillsList_BillsManagerUC.SelectedItem != null)
            {
                ShopBillModel shopBill = (ShopBillModel)BillsList_BillsManagerUC.SelectedItem;
                ModifyBillUC modifyBill = new ModifyBillUC(shopBill);

                Window window = new Window
                {
                    Title = "Bill",
                    Content = modifyBill,
                    SizeToContent = SizeToContent.WidthAndHeight,
                    ResizeMode = ResizeMode.NoResize
                };
                window.ShowDialog();
                SetInitialValues();
            }
        }


        private void DateFilterValue_BillsManagerUC_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            FShopBills = new List<ShopBillModel>();
            FShopBills =  GlobalConfig.Connection.FilterShopBillsByDate(ShopBills, (DateTime)DateFilterValue_BillsManagerUC.SelectedDate);

            BillsList_BillsManagerUC.ItemsSource = null;
            BillsList_BillsManagerUC.ItemsSource = FShopBills;
        }

        #endregion


    }
}
