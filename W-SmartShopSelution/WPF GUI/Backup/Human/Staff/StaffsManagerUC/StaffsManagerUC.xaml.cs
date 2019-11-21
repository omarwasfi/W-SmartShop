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
using WPF_GUI.Staff.ModifyStaffUC;

namespace WPF_GUI.Staff.StaffsManagerUC
{
    /// <summary>
    /// Interaction logic for StaffsManagerUC.xaml
    /// </summary>
    public partial class StaffsManagerUC : UserControl
    {
        #region Main Variables

        private List<StaffModel> Staffs { get; set; }

        private List<StoreModel> Stores { get; set; }

        /// <summary>
        /// The Search types list of strings
        /// </summary>
        private List<string> StaffsSearchType { get; set; } = new List<string>() { "Username", "Full Name" };

        #endregion

        #region Help veriables

        private List<StaffModel> FStaffs { get; set; }

        #endregion

        #region set the initianl values

        public StaffsManagerUC()
        {
            InitializeComponent();

            SetInitialValues();

        }

        /// <summary>
        /// set the initial values for the hole form , update the main veriables from the database
        /// </summary>
        private void SetInitialValues()
        {
            ShowPasswordCheckBox_StaffsManagerUC.IsChecked = false;
            PasswordDataGrid.Visibility = Visibility.Collapsed;

            StaffSearchValue_StaffsManagerUC.Text = "Search...";
            StaffSearchType_StaffsManagerUC.ItemsSource = null;
            StaffSearchType_StaffsManagerUC.ItemsSource = StaffsSearchType;

            UpdateTheStaffsFromTheDatabase();
            StaffsList_StaffsManagerUC.ItemsSource = null;
            StaffsList_StaffsManagerUC.ItemsSource = Staffs;

            UpdateStoresFromTheDatabase();
            StoreValue_StaffsManagerUC.ItemsSource = null;
            StoreValue_StaffsManagerUC.ItemsSource = Stores;
            StoreValue_StaffsManagerUC.DisplayMemberPath = "Name";


        }

        /// <summary>
        /// get the staffs from the database and set the staffs  in the public variables
        /// </summary>
        private void UpdateTheStaffsFromTheDatabase()
        {
            Staffs = null;
            Staffs = GlobalConfig.Connection.GetStaffs();
            PublicVariables.Staffs = null;
            PublicVariables.Staffs = Staffs;
            Staffs.RemoveAt(0);
        }

        /// <summary>
        /// Get all stores from the database , set the stores in the public variables
        /// </summary>
        private void UpdateStoresFromTheDatabase()
        {
            Stores = null;
            Stores = GlobalConfig.Connection.GetAllStores();
            PublicVariables.Stores = null;
            PublicVariables.Stores = Stores;
            Stores.RemoveAt(0);
        }
           

        #endregion

        #region Hole Form Events

        /// <summary>
        /// Show and Hide the ShowPasswordCheckBox_StaffsManagerUC after checking the showPassword CheckBox 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowPasswordCheckBox_StaffsManagerUC_Click(object sender, RoutedEventArgs e)
        {
            if(ShowPasswordCheckBox_StaffsManagerUC.IsChecked == true)
            {
                PasswordDataGrid.Visibility = Visibility.Visible;
            }
            else
            {
                PasswordDataGrid.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// every selection change Filters the staffs list by the new store 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StoreValue_StaffsManagerUC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StoreModel selectedStore = new StoreModel();
            selectedStore =  (StoreModel)StoreValue_StaffsManagerUC.SelectedItem;
            if (selectedStore != null)
            {
                FStaffs = GlobalConfig.Connection.FilterStaffsByStore(Staffs, selectedStore);
                StaffsList_StaffsManagerUC.ItemsSource = null;
                StaffsList_StaffsManagerUC.ItemsSource = FStaffs;

                    
            }
            else
            {
                StaffsList_StaffsManagerUC.ItemsSource = null;
                StaffsList_StaffsManagerUC.ItemsSource = Staffs;
            }
           
        }

        /// <summary>
        /// Reset the initial values 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetStaffsResultsButton_StaffsManagerUC_Click(object sender, RoutedEventArgs e)
        {
            SetInitialValues();
        }

        #endregion

        private void StaffSearchButton_StaffsManagerUC_Click(object sender, RoutedEventArgs e)
        {
            if(StaffSearchType_StaffsManagerUC.Text.Length > 0)
            {
                if(StaffSearchType_StaffsManagerUC.Text == "Username")
                {
                    FStaffs = null;
                    FStaffs = GlobalConfig.Connection.FilterSatffsByUsername(Staffs, StaffSearchValue_StaffsManagerUC.Text);
                    StaffsList_StaffsManagerUC.ItemsSource = null;
                    StaffsList_StaffsManagerUC.ItemsSource = FStaffs;
                }
                if(StaffSearchType_StaffsManagerUC.Text == "Full Name")
                {
                    FStaffs = null;
                    FStaffs = GlobalConfig.Connection.FilterSatffsByPersonFullName(Staffs, StaffSearchValue_StaffsManagerUC.Text);
                    StaffsList_StaffsManagerUC.ItemsSource = null;
                    StaffsList_StaffsManagerUC.ItemsSource = FStaffs;
                }
            }
            else
            {
                MessageBox.Show("Choose a search type please !");
            }
        }

        private void ModifySelectedButton_StaffsManagerUC_Click(object sender, RoutedEventArgs e)
        {
            if(StaffsList_StaffsManagerUC.SelectedItem != null)
            {
                StaffModel selectedStaff = new StaffModel();
                selectedStaff = (StaffModel)StaffsList_StaffsManagerUC.SelectedItem;
                ModifyStaffUC.ModifyStaffUC modifyStaffUC = new ModifyStaffUC.ModifyStaffUC(selectedStaff);
                Window window = new Window
                {
                    Title = "Modify Staff",
                    Content = modifyStaffUC,
                    SizeToContent = SizeToContent.WidthAndHeight,
                    ResizeMode = ResizeMode.NoResize
                };
                window.ShowDialog();
                SetInitialValues();
            }
            else
            {
                MessageBox.Show("Select staff !");
            }
        }
    }
}
