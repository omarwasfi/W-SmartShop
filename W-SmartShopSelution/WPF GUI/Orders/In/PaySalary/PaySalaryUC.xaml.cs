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
using ValidationResult = FluentValidation.Results.ValidationResult;


namespace WPF_GUI
{
    /// <summary>
    /// Interaction logic for PaySalaryUC.xaml
    /// </summary>
    public partial class PaySalaryUC : UserControl
    {
        #region Main Variables

        public StaffModel Staff { get; set; }

        #endregion

        #region set the initianl values

        public PaySalaryUC(StaffModel staff)
        {
            InitializeComponent();
            Staff = staff;
            SetInitialValues();
        }
        private void SetInitialValues()
        {
            StaffFullNameValue.Text = Staff.Person.FullName;
            StoreShoppeWallet.Value = PublicVariables.Store.GetShopeeWallet;
            PayNowValue.Value = 0;
            StaffSalaryDetailsValue.Text = "";
        }

        #endregion

        #region Hole From



        #region Events

        private void PayNowValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            decimal payNow = PayNowValue.Value.Value;

            if (payNow > StoreShoppeWallet.Value)
            {
                PayNowValue.Value = StoreShoppeWallet.Value;
            }
        }

        private void ReloadTabButton_Click(object sender, RoutedEventArgs e)
        {
            SetInitialValues();
        }

        private void ConfitmButton_Click(object sender, RoutedEventArgs e)
        {
            StaffSalaryModel staffSalary = new StaffSalaryModel();
            staffSalary.Store = PublicVariables.Store;
            staffSalary.Staff = PublicVariables.Staff;
            staffSalary.Date = DateTime.Now;
            staffSalary.Salary = PayNowValue.Value.Value;
            staffSalary.Details = StaffSalaryDetailsValue.Text;
            staffSalary.ToStaff = Staff;
            // validation

            GlobalConfig.StaffSalaryValidator = new StaffSalaryValidator();

            ValidationResult result = GlobalConfig.StaffSalaryValidator.Validate(staffSalary);

            if (result.IsValid == false)
            {

                MessageBox.Show(result.Errors[0].ErrorMessage);

            }
            else
            {
                GlobalConfig.Connection.AddStaffSalaryToTheDatabase(staffSalary);
                SetInitialValues();
            }
        }

        #endregion

        #endregion


    }
}
