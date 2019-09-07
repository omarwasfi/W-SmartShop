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
                // Stimulsoft Report licence
                Stimulsoft.Base.StiLicense.Key = "6vJhGtLLLz2GNviWmUTrhSqnOItdDwjBylQzQcAOiHl2AD0gPVknKsaW0un+3PuM6TTcPMUAWEURKXNso0e5OJN40hxJjK5JbrxU+NrJ3E0OUAve6MDSIxK3504G4vSTqZezogz9ehm+xS8zUyh3tFhCWSvIoPFEEuqZTyO744uk+ezyGDj7C5jJQQjndNuSYeM+UdsAZVREEuyNFHLm7gD9OuR2dWjf8ldIO6Goh3h52+uMZxbUNal/0uomgpx5NklQZwVfjTBOg0xKBLJqZTDKbdtUrnFeTZLQXPhrQA5D+hCvqsj+DE0n6uAvCB2kNOvqlDealr9mE3y978bJuoq1l4UNE3EzDk+UqlPo8KwL1XM+o1oxqZAZWsRmNv4Rr2EXqg/RNUQId47/4JO0ymIF5V4UMeQcPXs9DicCBJO2qz1Y+MIpmMDbSETtJWksDF5ns6+B0R7BsNPX+rw8nvVtKI1OTJ2GmcYBeRkIyCB7f8VefTSOkq5ZeZkI8loPcLsR4fC4TXjJu2loGgy4avJVXk32bt4FFp9ikWocI9OQ7CakMKyAF6Zx7dJF1nZw";


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
