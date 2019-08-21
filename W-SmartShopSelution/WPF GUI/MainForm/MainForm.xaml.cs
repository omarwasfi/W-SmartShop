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
using System.Windows.Shapes;
using WPF_GUI.CreateProduct;
using WPF_GUI.Inventory;
using WPF_GUI.ProductManager;
using WPF_GUI.Sell;
using WPF_GUI.Staff.StaffsManagerUC;

namespace WPF_GUI
{


    /// <summary>
    /// Interaction logic for MainForm.xaml
    /// </summary>
    public partial class MainForm : Window
    {
        #region Main Variables
        /// <summary>
        /// The staff memeber who uses the program
        /// </summary>
        private StaffModel Staff { get; set; } = PublicVariables.Staff;

        #endregion


        public MainForm()
        {
            InitializeComponent();

            FillStartupData();

            InitialViewItems(Staff);
        }

        /// <summary>
        /// - set the staffButton contant to the staff FullName
        /// </summary>
        private void FillStartupData()
        {
            StaffButton_MainForm.Content = Staff.Person.FullName;

        }

        /// <summary>
        /// Initial the ViewItems Or the button that the user can perss to open the uc
        /// </summary>
        private void InitialViewItems(StaffModel staff)
        {
            if (staff.Permission.CanSellUC)
            {
                SellViewItem.Visibility = Visibility.Visible;
            }
            if (staff.Permission.CanInventoryUC)
            {
                InventoryViewItem.Visibility = Visibility.Visible;
            }
            if (staff.Permission.CanGlobalInventory)
            {
                GlobalInventoryViewItem.Visibility = Visibility.Visible;
            }
            if (staff.Permission.CanIncomeOrderUC)
            {
                IncomeOrderViewItem.Visibility = Visibility.Visible;
            }
            if (staff.Permission.CanProductManagerUC)
            {
                ProductsManagerViewItem.Visibility = Visibility.Visible;
            }
            if (staff.Permission.CanStaffsManagerUC)
            {
                StaffsManagerViewItem.Visibility = Visibility.Visible;
            }
            if (staff.Permission.CanInstallmentOrderUC)
            {
                InstallmentOrderViewItem.Visibility = Visibility.Visible;
            }

        }
        
       /// <summary>
       ///  close the application
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }



        #region Menu Events

        /*
         * Adding any new ViewItem requaries:
         * - Change the permissionModel
         * - Change the spStaff_GetPermissionByStaffId PROCEDURE in the database
         * - change the Permission table in the database
         */

        private void SellViewItem_Selected(object sender, RoutedEventArgs e)
        {
            SellUC sellUc = new SellUC();
            TabItem sellTab = new TabItem { Header = "Sell Tab" };
            sellTab.Content = sellUc;
            MainTab.Items.Add(sellTab);
        }

        private void InventoryViewItem_Selected(object sender, RoutedEventArgs e)
        {
            InventoryUC inventoryUC = new InventoryUC();
            TabItem inventoryTab = new TabItem { Header = "Inventory Tab" };
            inventoryTab.Content = inventoryUC;
            MainTab.Items.Add(inventoryTab);
        }

        private void GlobalInventoryViewItem_Selected(object sender, RoutedEventArgs e)
        {
            GlobalInventoryUC globalInventoryUC = new GlobalInventoryUC();
            TabItem globalInventoryTab  = new TabItem { Header = "Global Inventory Tab" };
            globalInventoryTab.Content = globalInventoryUC;
            MainTab.Items.Add(globalInventoryTab);
        }

        private void ProductsViewItem_Selected(object sender, RoutedEventArgs e)
        {
            ProductManagerUC productManagerUC = new ProductManagerUC();
            TabItem productManagerTab = new TabItem { Header = "Products Tab" };
            productManagerTab.Content = productManagerUC;
            MainTab.Items.Add(productManagerTab);
        }

        private void StaffsManagerViewItem_Selected(object sender, RoutedEventArgs e)
        {
            StaffsManagerUC staffsManagerUC = new StaffsManagerUC();
            TabItem staffsManagerTab = new TabItem { Header = "Staffs Manager" };
            staffsManagerTab.Content = staffsManagerUC;
            MainTab.Items.Add(staffsManagerTab);
        }

        private void IncomeOrderViewItem_Selected(object sender, RoutedEventArgs e)
        {
            IncomeOrderUC incomeOrderUC = new IncomeOrderUC();
            TabItem incomeOrderTab = new TabItem { Header = "Income Order" };
            incomeOrderTab.Content = incomeOrderUC;
            MainTab.Items.Add(incomeOrderTab);
        }

        private void InstallmentOrderViewItem_Selected(object sender, RoutedEventArgs e)
        {
            InstallmentOrderUC installmentOrderUC = new InstallmentOrderUC();
            TabItem installmentOrderTab = new TabItem { Header = "Installment" };
            installmentOrderTab.Content = installmentOrderUC;
            MainTab.Items.Add(installmentOrderTab);
        }
        #endregion


    }
}
