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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF_GUI.CreateProduct;
using WPF_GUI.Inventory;
using WPF_GUI.Orders.In.BillsManagerUC;
using WPF_GUI.Orders.In.IncomeOrderManager;
using WPF_GUI.Orders.Out.SellingOrdersManagerUC;
using WPF_GUI.PriceListUC;
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
            if (staff.Permission.CanSellingOrdersManagerUC)
            {
                SellingOrdersManagerViewItem.Visibility = Visibility.Visible;
            }
            if (staff.Permission.CanInventoryUC)
            {
                InventoryViewItem.Visibility = Visibility.Visible;
            }
            if (staff.Permission.CanGlobalInventoryUC)
            {
                GlobalInventoryViewItem.Visibility = Visibility.Collapsed;
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
                StaffsManagerViewItem.Visibility = Visibility.Collapsed;
            }
            if (staff.Permission.CanInstallmentOrderUC)
            {
                InstallmentOrderViewItem.Visibility = Visibility.Collapsed;
            }
            if (staff.Permission.CanCashFlowUC)
            {
                CashUCViewItem.Visibility = Visibility.Visible;
            }
            if (staff.Permission.CanBillManagerUC)
            {
                BillsManagerViewItem.Visibility = Visibility.Visible;
            }
            if (staff.Permission.CanPriceListUC)
            {
                PriceListViewItem.Visibility = Visibility.Collapsed;
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
            CloseMenu_BeginStoryboard.Storyboard.Begin();

            SellUC sellUc = new SellUC();
            TabItem sellTab = new TabItem { Header = "Sell Tab" };
            sellTab.Content = sellUc;
            MainTab.Items.Add(sellTab);

        }

        private void OrderManagerViewItem_Selected(object sender, RoutedEventArgs e)
        {

            CloseMenu_BeginStoryboard.Storyboard.Begin();

            SellingOrdersManagerUC sellOrdersManagerUc = new SellingOrdersManagerUC();
            TabItem sellOrdersManagerTab = new TabItem { Header = "Selling Orders Manager Tab" };
            sellOrdersManagerTab.Content = sellOrdersManagerUc;
            MainTab.Items.Add(sellOrdersManagerTab);


        }

        private void InventoryViewItem_Selected(object sender, RoutedEventArgs e)
        {

            CloseMenu_BeginStoryboard.Storyboard.Begin();

            InventoryUC inventoryUC = new InventoryUC();
            TabItem inventoryTab = new TabItem { Header = "Inventory Tab" };
            inventoryTab.Content = inventoryUC;
            MainTab.Items.Add(inventoryTab);


        }

        private void GlobalInventoryViewItem_Selected(object sender, RoutedEventArgs e)
        {
            CloseMenu_BeginStoryboard.Storyboard.Begin();

            GlobalInventoryUC globalInventoryUC = new GlobalInventoryUC();
            TabItem globalInventoryTab  = new TabItem { Header = "Global Inventory Tab" };
            globalInventoryTab.Content = globalInventoryUC;
            MainTab.Items.Add(globalInventoryTab);


        }

        private void ProductsViewItem_Selected(object sender, RoutedEventArgs e)
        {
            CloseMenu_BeginStoryboard.Storyboard.Begin();

            ProductManagerUC productManagerUC = new ProductManagerUC();
            TabItem productManagerTab = new TabItem { Header = "Products Tab" };
            productManagerTab.Content = productManagerUC;
            MainTab.Items.Add(productManagerTab);

            
        }

        private void StaffsManagerViewItem_Selected(object sender, RoutedEventArgs e)
        {
            CloseMenu_BeginStoryboard.Storyboard.Begin();

            StaffsManagerUC staffsManagerUC = new StaffsManagerUC();
            TabItem staffsManagerTab = new TabItem { Header = "Staffs Manager" };
            staffsManagerTab.Content = staffsManagerUC;
            MainTab.Items.Add(staffsManagerTab);


        }

        private void CashUCViewItem_Selected(object sender, RoutedEventArgs e)
        {
            CloseMenu_BeginStoryboard.Storyboard.Begin();

            CashUC cashUC = new CashUC();
            TabItem cashTab = new TabItem { Header = "Cash Flow" };
            cashTab.Content = cashUC;
            MainTab.Items.Add(cashTab);


        }

        private void ManagerViewItem_Selected(object sender, RoutedEventArgs e)
        {
            CloseMenu_BeginStoryboard.Storyboard.Begin();
            ManagerUC managerUC = new ManagerUC();
            TabItem managerTab = new TabItem { Header = "Manager" };
            managerTab.Content = managerUC;
            MainTab.Items.Add(managerTab);
        }

        private void IncomeOrderViewItem_Selected(object sender, RoutedEventArgs e)
        {
            CloseMenu_BeginStoryboard.Storyboard.Begin();

            IncomeOrderUC incomeOrderUC = new IncomeOrderUC();
            TabItem incomeOrderTab = new TabItem { Header = "Income Order" };
            incomeOrderTab.Content = incomeOrderUC;
            MainTab.Items.Add(incomeOrderTab);


        }

        private void IncomeOrderManagerViewItem_Selected(object sender, RoutedEventArgs e)
        {
            CloseMenu_BeginStoryboard.Storyboard.Begin();

            IncomeOrderManagerUC incomeOrderManagerUC = new IncomeOrderManagerUC();
            TabItem incomeOrderMangerTab = new TabItem { Header = "Income Order Manager" };
            incomeOrderMangerTab.Content = incomeOrderManagerUC;
            MainTab.Items.Add(incomeOrderMangerTab);
        }

        private void InstallmentOrderViewItem_Selected(object sender, RoutedEventArgs e)
        {
            InstallmentOrderUC installmentOrderUC = new InstallmentOrderUC();
            TabItem installmentOrderTab = new TabItem { Header = "Installment" };
            installmentOrderTab.Content = installmentOrderUC;
            MainTab.Items.Add(installmentOrderTab);

            CloseMenu_BeginStoryboard.Storyboard.Begin();

        }

        private void BillsManagerViewItem_Selected(object sender, RoutedEventArgs e)
        {
            CloseMenu_BeginStoryboard.Storyboard.Begin();


            BillsManagerUC billsManagerUC = new BillsManagerUC();
            TabItem billsManagerTab = new TabItem { Header = "Bills" };
            billsManagerTab.Content = billsManagerUC;
            MainTab.Items.Add(billsManagerTab);


        }

        private void StaffSalaryManagerViewItem_Selected(object sender, RoutedEventArgs e)
        {
            CloseMenu_BeginStoryboard.Storyboard.Begin();


            StaffSalaryManagerUC staffSalaryManagerUC  = new StaffSalaryManagerUC();
            TabItem staffSalaryManagerTab = new TabItem { Header = "Staff Salary Manager" };
            staffSalaryManagerTab.Content = staffSalaryManagerUC;
            MainTab.Items.Add(staffSalaryManagerTab);
        }

        private void PeopleViewItem_Selected(object sender, RoutedEventArgs e)
        {
            CloseMenu_BeginStoryboard.Storyboard.Begin();


            PeopleUC peopleUC = new PeopleUC();
            TabItem peopleTab = new TabItem { Header = "People" };
            peopleTab.Content = peopleUC;
            MainTab.Items.Add(peopleTab);
        }

        private void PriceListViewItem_Selected(object sender, RoutedEventArgs e)
        {
            CloseMenu_BeginStoryboard.Storyboard.Begin();


            PriceListUC.PriceListUC priceListUC = new PriceListUC.PriceListUC();
            TabItem priceListTab = new TabItem { Header = "Price List" };
            priceListTab.Content = priceListUC;
            MainTab.Items.Add(priceListTab);


        }

        /// <summary>
        /// To move the MainForm Around the screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void NotificationsButton_Click(object sender, RoutedEventArgs e)
        {
            if(MainGrid.Visibility == Visibility.Visible)
            {
                MainGrid.Visibility = Visibility.Collapsed;
                NotificationGrid.Visibility = Visibility.Visible;
            }
            else
            {
                MainGrid.Visibility = Visibility.Visible;
                NotificationGrid.Visibility = Visibility.Collapsed;
            }
        }









        #endregion


    }
}
