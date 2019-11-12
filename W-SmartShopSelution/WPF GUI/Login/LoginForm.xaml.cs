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
using System.Management; //Need to manually add to the References
using Library;
using System.IO;

namespace WPF_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginForm : Window
    {

        #region Main Variabels

        /// <summary>
        /// Contain the current store 
        /// </summary>
        public StoreModel Store { get; set; } 


        public  StaffModel Staff { get; set; }

        #endregion

        #region Fist Step in the program

        /// <summary>
        /// InitializeConnection database connection
        /// </summary>
        public LoginForm()
        {
            
            InitializeComponent();
            GlobalConfig.InitializeConnection();
            
            GetStore();
        }


        #region GetUniquerID

        private string getUniqueID(string drive)
        {
            if (drive == string.Empty)
            {
                //Find first drive
                foreach (DriveInfo compDrive in DriveInfo.GetDrives())
                {
                    if (compDrive.IsReady)
                    {
                        drive = compDrive.RootDirectory.ToString();
                        break;
                    }
                }
            }

            if (drive.EndsWith(":\\"))
            {
                //C:\ -> C
                drive = drive.Substring(0, drive.Length - 2);
            }

            string volumeSerial = getVolumeSerial(drive);
            string cpuID = getCPUID();

            //Mix them up and remove some useless 0's
            return cpuID.Substring(13) + cpuID.Substring(1, 4) + volumeSerial + cpuID.Substring(4, 4);
        }

        private string getVolumeSerial(string drive)
        {
            ManagementObject disk = new ManagementObject(@"win32_logicaldisk.deviceid=""" + drive + @":""");
            disk.Get();

            string volumeSerial = disk["VolumeSerialNumber"].ToString();
            disk.Dispose();

            return volumeSerial;
        }

        private string getCPUID()
        {
            string cpuInfo = "";
            ManagementClass managClass = new ManagementClass("win32_processor");
            ManagementObjectCollection managCollec = managClass.GetInstances();

            foreach (ManagementObject managObj in managCollec)
            {
                if (cpuInfo == "")
                {
                    //Get only the first CPU's ID
                    cpuInfo = managObj.Properties["processorID"].Value.ToString();
                    break;
                }
            }

            return cpuInfo;
        }

        #endregion

        /// <summary>
        /// Get the Store if the store is not in the database the program will close after message box 
        /// Set the LoginStoreStocks in the public variables class
        /// set the Categories in the public variables class
        /// set the brands in the public variables class
        /// </summary>
        private void GetStore()
        {
            /*
             Wasfi Lab 6E9FEBFAA624579FBFF
             ALI 6EBFEBF76E9173AFBFF
             gohary lab 6C4FEBF86BD55BAFBFF
             */

            if (getUniqueID("C") == "6E9FEBFAA624579FBFF")
            {
                Store = GlobalConfig.GetTheStoreFromTheDatabase();
                if (Store.Id == -1)
                {
                    MessageBox.Show("Program Need Lisence To work");
                    this.Close();
                }
                else
                {
                    // Stimulsoft Report licence
                    Stimulsoft.Base.StiLicense.Key = "6vJhGtLLLz2GNviWmUTrhSqnOItdDwjBylQzQcAOiHl2AD0gPVknKsaW0un+3PuM6TTcPMUAWEURKXNso0e5OFPaZYasFtsxNoDemsFOXbvf7SIcnyAkFX/4u37NTfx7g+0IqLXw6QIPolr1PvCSZz8Z5wjBNakeCVozGGOiuCOQDy60XNqfbgrOjxgQ5y/u54K4g7R/xuWmpdx5OMAbUbcy3WbhPCbJJYTI5Hg8C/gsbHSnC2EeOCuyA9ImrNyjsUHkLEh9y4WoRw7lRIc1x+dli8jSJxt9C+NYVUIqK7MEeCmmVyFEGN8mNnqZp4vTe98kxAr4dWSmhcQahHGuFBhKQLlVOdlJ/OT+WPX1zS2UmnkTrxun+FWpCC5bLDlwhlslxtyaN9pV3sRLO6KXM88ZkefRrH21DdR+4j79HA7VLTAsebI79t9nMgmXJ5hB1JKcJMUAgWpxT7C7JUGcWCPIG10NuCd9XQ7H4ykQ4Ve6J2LuNo9SbvP6jPwdfQJB6fJBnKg4mtNuLMlQ4pnXDc+wJmqgw25NfHpFmrZYACZOtLEJoPtMWxxwDzZEYYfT";

                    /*PublicVariables.OrganizationName = "";
                    PublicVariables.OrganizationAddress = "Egypt,Ismailia";
                    PublicVariables.OrganizationPhoneNumber = "01555707375";

                    PublicVariables.Store = Store;
                    PublicVariables.Stores = GlobalConfig.Connection.GetAllStores();
                    PublicVariables.LoginStoreStocks = GlobalConfig.Connection.FilterStocksByStore(Store);
                    PublicVariables.Products = GlobalConfig.Connection.GetProducts();
                    PublicVariables.Stocks = GlobalConfig.Connection.GetStocks();
                    PublicVariables.Categories = GlobalConfig.Connection.GetCategories();
                    PublicVariables.Brands = GlobalConfig.Connection.GetBrands();
                    PublicVariables.Customers = GlobalConfig.Connection.GetCustomers();
                    PublicVariables.Orders = GlobalConfig.Connection.GetOrders();
                    PublicVariables.Suppliers = GlobalConfig.Connection.GetSuppliers();
                    PublicVariables.IncomeOrders = GlobalConfig.Connection.GetIncomeOrders();
                    PublicVariables.ShopBills = GlobalConfig.Connection.GetShopBills();
                    PublicVariables.Operations = GlobalConfig.Connection.GetOperations();

                    PublicVariables.RecentlyAddProducts = new List<ProductModel>();*/

                    GlobalConfig.Connection.SetThePublicVariables();

                }
            }
            else
            {
                MessageBox.Show("Program Need Lisence To work");
                this.Close();
            }


         
        }


        #endregion

        #region UserLogin

        private void UsernameValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (VerifyTheIncomeUser())
                {

                    OpenMainForm();

                }
                else
                {
                    MessageBox.Show("Username Or Password is wrong");
                }
            }
        }

        private void PasswordValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (VerifyTheIncomeUser())
                {

                    OpenMainForm();

                }
                else
                {
                    MessageBox.Show("Username Or Password is wrong");
                }
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {

            
            if (VerifyTheIncomeUser())
            {

                OpenMainForm();

            }
            else
            {
                MessageBox.Show("Username Or Password is wrong");
            }
            
        }

        /// <summary>
        /// Check the staff username and password and if he can login in this store or not
        /// if staff valid set the staff public variable to this staff memeber
        /// </summary>
        /// <returns></returns>
        private bool VerifyTheIncomeUser()
        {
            StaffModel staff = new StaffModel { Username = UsernameValue.Text, Password = PasswordValue.Password };
            StaffModel outStaff = GlobalConfig.Connection.CheckIfStaffValid(staff,Store);
            if(outStaff.Id == -1)
            {
                return false;
            }
            else
            {
                Staff = outStaff;
                PublicVariables.Staff = Staff;
                return true;
            }
        }

        /// <summary>
        /// Opens Main Form after user login 
        /// </summary>
        private void OpenMainForm()
        {
            MainForm mainForm = new MainForm();
            mainForm.Title = Store.Name;
            mainForm.Show();

            this.Close();
        }

        /// <summary>
        /// Close The Program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        #endregion

      
    }
}
