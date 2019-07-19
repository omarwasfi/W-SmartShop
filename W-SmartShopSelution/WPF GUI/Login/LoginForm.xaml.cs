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

        /// <summary>
        /// Get the Store if the store is not in the database the program will close after message box 
        /// Set the LoginStoreStocks in the public variables class
        /// set the Categories in the public variables class
        /// set the brands in the public variables class
        /// </summary>
        private void GetStore()
        {
            Store = GlobalConfig.GetTheStoreFromTheDatabase();
            if(Store.Id == -1)
            {
                MessageBox.Show("Program Need Lisence To work");
                this.Close();
            }

            else
            {
                PublicVariables.Store = Store;
                PublicVariables.LoginStoreStocks = GlobalConfig.Connection.FilterStocksByStore(Store);
                PublicVariables.Categories = GlobalConfig.Connection.GetCategories();
                PublicVariables.Brands = GlobalConfig.Connection.GetBrands();
            }
        }


        #endregion

        #region UserLogin

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
