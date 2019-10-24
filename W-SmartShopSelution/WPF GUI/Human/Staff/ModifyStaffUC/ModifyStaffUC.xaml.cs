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

namespace WPF_GUI.Staff.ModifyStaffUC
{
    /// <summary>
    /// Interaction logic for ModifyStaffUC.xaml
    /// </summary>
    public partial class ModifyStaffUC : UserControl
    {

        #region Main veriables
        /// <summary>
        /// the person that we need to modify
        /// </summary>
        private StaffModel Staff { get; set; }

        /// <summary>
        /// all staffs in the database
        /// </summary>
        private List<StaffModel> Staffs { get; set; }

        /// <summary>
        /// All stores in the database
        /// </summary>
        private List<StoreModel> Stores { get; set; }

        #endregion


        #region Set the Initial Values

        public ModifyStaffUC(StaffModel staff )
        {
            InitializeComponent();

            Staff = staff;

            SetInitialValues();

        }


        private void SetInitialValues()
        {

            SetGuiDefaultValues();
            UpdateTheStaffsFromTheDatabase();
            UpdateTheStoresFromTheDatabase();

        }

        private void UpdateTheStaffsFromTheDatabase()
        {
            Staffs = null;
            Staffs = GlobalConfig.Connection.GetStaffs();
            PublicVariables.Staffs = null;
            PublicVariables.Staffs = Staffs;
                
        }

        private void UpdateTheStoresFromTheDatabase()
        {
            Stores = null;
            Stores = GlobalConfig.Connection.GetAllStores();
            PublicVariables.Stores = null;
            PublicVariables.Stores = Stores;

        }

        /// <summary>
        /// Set the staff values in the gui 
        /// Set all stores that he can access
        /// Set all permission that he has
        /// Set all username and password
        /// </summary>
        private void SetGuiDefaultValues()
        {
            SellCheckBox_ModifyStaffUC.IsChecked = false;
            InventoryCheckBox_ModifyStaffUC.IsChecked = false;
            ProductManagerCheckBox_ModifyStaffUC.IsChecked = false;
            StaffsManagerCheckBox_ModifyStaffUC.IsChecked = false;
            FayedStoreCheckBox_ModifyStaffUC.IsChecked = false;
            CairoStoreCheckBox_ModifyStaffUC.IsChecked = false;
            Ma3adiStoreCheckBox_ModifyStaffUC.IsChecked = false;

            ManagerRadioButton_ModifyStaffUC.IsChecked = false;
            SellOnlyRadioButton_ModifyStaffUC.IsChecked = false;
            SellAndInventoryRadioButton_ModifyStaffUC.IsChecked = false;
            SellInventoryProdcutManagerRadioButton_ModifyStaffUC.IsChecked = false;



            UsernameValue_ModifyStaffUC.Text = Staff.Username;
            PasswordValue_ModifyStaffUC.Text = Staff.Password;

            if (Staff.Permission.Name == "Manager")
            {
                ManagerRadioButton_ModifyStaffUC.IsChecked = true;
            }
            if (Staff.Permission.Name == "SellUser")
            {
                SellOnlyRadioButton_ModifyStaffUC.IsChecked = true;
            }
            if (Staff.Permission.Name == "SellAndInventory")
            {
                SellAndInventoryRadioButton_ModifyStaffUC.IsChecked = true;
            }
            if (Staff.Permission.Name == "Sell,Inventory,ProductManager")
            {
                SellInventoryProdcutManagerRadioButton_ModifyStaffUC.IsChecked = true;
            }
          
            foreach(StoreModel store in Staff.Stores)
            {
                if(store.Id == 501)
                {
                    FayedStoreCheckBox_ModifyStaffUC.IsChecked = true;
                }
                if(store.Id == 502)
                {
                    CairoStoreCheckBox_ModifyStaffUC.IsChecked = true;
                }
                if(store.Id == 503)
                {
                    Ma3adiStoreCheckBox_ModifyStaffUC.IsChecked = true;
                }
            }

        }
        #endregion

        #region Hole form events

        /// <summary>
        /// if the user click to check or uncheck the SellCheckBox_ModifyStaffUC
        /// it doesn't resbone , with a messageBox that he can't do it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SellCheckBox_ModifyStaffUC_Click(object sender, RoutedEventArgs e)
        {
            if(SellCheckBox_ModifyStaffUC.IsChecked == true)
            {
                SellCheckBox_ModifyStaffUC.IsChecked = false;
            }
            else
            {
                SellCheckBox_ModifyStaffUC.IsChecked = true;

            }
            MessageBox.Show("You can't choose from here");

        }


        /// <summary>
        /// if the user click to check or uncheck the InventoryCheckBox_ModifyStaffUC
        /// it doesn't resbone , with a messageBox that he can't do it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InventoryCheckBox_ModifyStaffUC_Click(object sender, RoutedEventArgs e)
        {
            if (InventoryCheckBox_ModifyStaffUC.IsChecked == true)
            {
                InventoryCheckBox_ModifyStaffUC.IsChecked = false;
            }
            else
            {
                InventoryCheckBox_ModifyStaffUC.IsChecked = true;

            }
            MessageBox.Show("You can't choose from here");
        }

        /// <summary>
        /// if the user click to check or uncheck the ProductManagerCheckBox_ModifyStaffUC
        /// it doesn't resbone , with a messageBox that he can't do it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProductManagerCheckBox_ModifyStaffUC_Click(object sender, RoutedEventArgs e)
        {
            if (ProductManagerCheckBox_ModifyStaffUC.IsChecked == true)
            {
                ProductManagerCheckBox_ModifyStaffUC.IsChecked = false;
            }
            else
            {
                ProductManagerCheckBox_ModifyStaffUC.IsChecked = true;

            }
            MessageBox.Show("You can't choose from here");
        }

        /// <summary>
        /// if the user click to check or uncheck the StaffsManagerCheckBox_ModifyStaffUC
        /// it doesn't resbone , with a messageBox that he can't do it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StaffsManagerCheckBox_ModifyStaffUC_Click(object sender, RoutedEventArgs e)
        {
            if (StaffsManagerCheckBox_ModifyStaffUC.IsChecked == true)
            {
                StaffsManagerCheckBox_ModifyStaffUC.IsChecked = false;
            }
            else
            {
                StaffsManagerCheckBox_ModifyStaffUC.IsChecked = true;

            }
            MessageBox.Show("You can't choose from here");
        }


        /// <summary>
        /// if any radio button changed this updates all the checkBoxs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PermissionTypeRadioButton_ModifyStaffUC_Checked(object sender, RoutedEventArgs e)
        {
            if (ManagerRadioButton_ModifyStaffUC.IsChecked == true)
            {
                SellCheckBox_ModifyStaffUC.IsChecked = true;
                InventoryCheckBox_ModifyStaffUC.IsChecked = true;
                ProductManagerCheckBox_ModifyStaffUC.IsChecked = true;
                StaffsManagerCheckBox_ModifyStaffUC.IsChecked = true;
            }
            else if(SellOnlyRadioButton_ModifyStaffUC.IsChecked == true)
            {
                SellCheckBox_ModifyStaffUC.IsChecked = true;
                InventoryCheckBox_ModifyStaffUC.IsChecked = false;
                ProductManagerCheckBox_ModifyStaffUC.IsChecked = false;
                StaffsManagerCheckBox_ModifyStaffUC.IsChecked = false;
            }
            else if(SellAndInventoryRadioButton_ModifyStaffUC.IsChecked == true)
            {
                SellCheckBox_ModifyStaffUC.IsChecked = true;
                InventoryCheckBox_ModifyStaffUC.IsChecked = true;
                ProductManagerCheckBox_ModifyStaffUC.IsChecked = false;
                StaffsManagerCheckBox_ModifyStaffUC.IsChecked = false;
            }
            else if(SellInventoryProdcutManagerRadioButton_ModifyStaffUC.IsChecked == true)
            {
                SellCheckBox_ModifyStaffUC.IsChecked = true;
                InventoryCheckBox_ModifyStaffUC.IsChecked = true;
                ProductManagerCheckBox_ModifyStaffUC.IsChecked = true;
                StaffsManagerCheckBox_ModifyStaffUC.IsChecked = false;
            }

        }

        /// <summary>
        /// Clear the window by set the initial values again
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetButton_ModifyStaffUC_Click(object sender, RoutedEventArgs e)
        {
            SetInitialValues();
        }

        /// <summary>
        /// Close the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_ModifyStaffUC_Click(object sender, RoutedEventArgs e)
        {
            var parent = this.Parent as Window;
            if (parent != null) { parent.DialogResult = true; parent.Close(); }
        }



        private void ConfirmButton_ModifyStaffUC_Click(object sender, RoutedEventArgs e)
        {
            bool confirm = true;
            if(UsernameValue_ModifyStaffUC.Text.Length > 3)
            {
                if(PasswordValue_ModifyStaffUC.Text.Length > 7)
                {
                    if ( UsernameValue_ModifyStaffUC.Text == Staff.Username || GlobalConfig.Connection.CheckIfTheUsernameUnique(Staffs, UsernameValue_ModifyStaffUC.Text))
                    {

                    }
                    else
                    {
                        MessageBox.Show("This username is user with other staff member");
                        confirm = false;
                    }
                }
                else
                {
                    MessageBox.Show("The Password has to 8 chars or more");
                    confirm = false;
                }
            }
            else
            {
                MessageBox.Show("The user name has to be 4 chars or more ");
                confirm = false;
            }

            if (confirm)
            {

                Staff.Username = UsernameValue_ModifyStaffUC.Text;
                Staff.Password = PasswordValue_ModifyStaffUC.Text;
                
                // set the staff permission
                if(ManagerRadioButton_ModifyStaffUC.IsChecked == true)
                {
                    Staff.Permission = new PermissionModel() { Id = 300001  };
                }
                else if (SellOnlyRadioButton_ModifyStaffUC.IsChecked == true)
                {
                    Staff.Permission = new PermissionModel() { Id = 300002 };
                }
                else if (SellAndInventoryRadioButton_ModifyStaffUC.IsChecked == true)
                {
                    Staff.Permission = new PermissionModel() { Id = 300003 };
                }
                else if (SellInventoryProdcutManagerRadioButton_ModifyStaffUC.IsChecked == true)
                {
                    Staff.Permission = new PermissionModel() { Id = 300004 };
                }

                GlobalConfig.Connection.UpdateStaffData(Staff);


                /*
                // ma3adi store
                if(Ma3adiStoreCheckBox_ModifyStaffUC.IsChecked == true && Staff.AllStores.Contains("Ma3adiStore"))
                {

                }
                else if(Ma3adiStoreCheckBox_ModifyStaffUC.IsChecked == true && Staff.AllStores.Contains("Ma3adiStore") == false)
                {
                    // create staffStore
                    StoreModel cStore = new StoreModel();
                    foreach(StoreModel store in Stores)
                    {
                        if(store.Name == "Ma3adiStore")
                        {
                            cStore = store;
                            break;

                        }
                    }
                    GlobalConfig.Connection.AddStoreStaffToTheDatabase(cStore,Staff);
                }
                else if(Ma3adiStoreCheckBox_ModifyStaffUC.IsChecked == false && Staff.AllStores.Contains("Ma3adiStore"))
                {
                    // remove staffStore

                    StoreModel cStore = new StoreModel();
                    foreach (StoreModel store in Stores)
                    {
                        if (store.Name == "Ma3adiStore")
                        {
                            cStore = store;
                            break;

                        }
                    }
                    GlobalConfig.Connection.RemoveStoreStaffToTheDatabase(cStore, Staff);
                }

                
                // Fayed store
                if (FayedStoreCheckBox_ModifyStaffUC.IsChecked == true && Staff.AllStores.Contains("Ma3adiStore"))
                {

                }
                else if (FayedStoreCheckBox_ModifyStaffUC.IsChecked == true && Staff.AllStores.Contains("FayedStore") == false)
                {
                    // create staffStore
                    StoreModel cStore = new StoreModel();
                    foreach (StoreModel store in Stores)
                    {
                        if (store.Name == "FayedStore")
                        {
                            cStore = store;
                            break;

                        }
                    }
                    GlobalConfig.Connection.AddStoreStaffToTheDatabase(cStore, Staff);
                }
                else if (FayedStoreCheckBox_ModifyStaffUC.IsChecked == false && Staff.AllStores.Contains("FayedStore"))
                {
                    // remove staffStore

                    StoreModel cStore = new StoreModel();
                    foreach (StoreModel store in Stores)
                    {
                        if (store.Name == "FayedStore")
                        {
                            cStore = store;
                            break;
                        }
                    }
                    GlobalConfig.Connection.RemoveStoreStaffToTheDatabase(cStore, Staff);
                }

                // Cairo store
                if (CairoStoreCheckBox_ModifyStaffUC.IsChecked == true && Staff.AllStores.Contains("CairoStore"))
                {

                }
                else if (CairoStoreCheckBox_ModifyStaffUC.IsChecked == true && Staff.AllStores.Contains("CairoStore") == false)
                {
                    // create staffStore
                    StoreModel cStore = new StoreModel();
                    foreach (StoreModel store in Stores)
                    {
                        if (store.Name == "CairoStore")
                        {
                            cStore = store;
                            break;

                        }
                    }
                    GlobalConfig.Connection.AddStoreStaffToTheDatabase(cStore, Staff);
                }
                else if (CairoStoreCheckBox_ModifyStaffUC.IsChecked == false && Staff.AllStores.Contains("CairoStore"))
                {
                    // remove staffStore

                    StoreModel cStore = new StoreModel();
                    foreach (StoreModel store in Stores)
                    {
                        if (store.Name == "CairoStore")
                        {
                            cStore = store;
                            break;
                        }
                    }
                    GlobalConfig.Connection.RemoveStoreStaffToTheDatabase(cStore, Staff);
                }

                */

                if (Staff.Id == PublicVariables.Staff.Id)
                {
                    PublicVariables.Staff = Staff;
                    MessageBox.Show("Changes Will apply after Logout and Login again");
                }

                var parent = this.Parent as Window;
                if (parent != null) { parent.DialogResult = true; parent.Close(); }
            }
        }

        /// <summary>
        /// Open modifyPersonUC to edit the person data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditPersonButton_ModifyStaffUC_Click(object sender, RoutedEventArgs e)
        {
            ModifyPersonUC.ModifyPersonUC modifyPersonUC = new ModifyPersonUC.ModifyPersonUC(Staff.Person);
            Window window = new Window
            {
                Title = "Modify Person",
                Content = modifyPersonUC,
                SizeToContent = SizeToContent.WidthAndHeight,
                ResizeMode = ResizeMode.NoResize
            };
            window.ShowDialog();
            SetInitialValues();
        }

        #endregion


    }
}
