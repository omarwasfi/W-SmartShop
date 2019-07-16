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

        private StoreModel Store { get; set; } 

        #endregion

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
        /// </summary>
        private void GetStore()
        {
            Store = GlobalConfig.GetTheStoreFromTheDatabase();
            if(Store.Id == -1)
            {
                MessageBox.Show("Program Need Lisence To work");
                this.Close();
            }
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

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            
            MainForm mainForm = new MainForm();
            mainForm.Show();

            this.Close();
        }
    }
}
