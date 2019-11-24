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
using ValidationResult = FluentValidation.Results.ValidationResult;
using Library;

namespace WPF_GUI
{
    /// <summary>
    /// Interaction logic for RevenueUC.xaml
    /// </summary>
    public partial class RevenueUC : UserControl
    {
        #region Main Variables

        /// <summary>
        /// The New Revenue
        /// </summary>
        RevenueModel Revenue { get; set; }

        #endregion

        #region Set Inital Values

        public RevenueUC()
        {
            InitializeComponent();
            SetInitialValues();
        }

        private void SetInitialValues()
        {
            OwnerList.ItemsSource = null;
            OwnerList.ItemsSource = PublicVariables.Owners;
            RevenueValue.Value = 0;
        }



        #endregion

        #region Hole Form Events and Functions
        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            OwnerModel owner = (OwnerModel)OwnerList.SelectedItem;
            if (owner != null)
            {

                Revenue = new RevenueModel();
                Revenue.Staff = PublicVariables.Staff;
                Revenue.Store = PublicVariables.Store;
                Revenue.Date = DateTime.Now;
                Revenue.TotalMoney = (decimal)RevenueValue.Value;

                GlobalConfig.RevenueValidator = new RevenueValidator();
                ValidationResult result = GlobalConfig.RevenueValidator.Validate(Revenue);

                if (result.IsValid == false)
                {
                    MessageBox.Show(result.Errors[0].ErrorMessage);
                }
                else
                {
                    GlobalConfig.Connection.AddRevenueToTheDatabase(Revenue, owner);
                    SetInitialValues();
                }
            }
            else
            {
                MessageBox.Show("Select Owner Please");
            }
        }
        #endregion

       
    }
}
