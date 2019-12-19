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
    /// Interaction logic for StaffSalaryManagerUC.xaml
    /// </summary>
    public partial class StaffSalaryManagerUC : UserControl
    {
        #region set the initianl values

        public StaffSalaryManagerUC()
        {
            InitializeComponent();
            SetInitialValues();
        }
        private void SetInitialValues()
        {
            UserGrid.Visibility = Visibility.Visible;
            PaySalaryGrid.Visibility = Visibility.Collapsed;

            StaffsList.ItemsSource = null;
            StaffsList.ItemsSource = PublicVariables.Staffs;

            StaffSalaryList.ItemsSource = null;
            TotalReceivedThisMonthValue.Value =0;
            StaffShouldReceiveThisMonthValue.Value =0;

            SelectedDateValue.SelectedDate = DateTime.Now;
        }

        #endregion

        #region Hole Form

        private void UpdateSelectedStaff()
        {
            StaffModel staff = (StaffModel)StaffsList.SelectedItem;
            if (staff != null)
            {
                StaffFullNameValue.Text = staff.Person.FullName;

                StaffSalaryList.ItemsSource = null;
                StaffSalaryList.ItemsSource = StaffSalary.FilterStaffSalariesByMonth(staff.GetStaffSalaries, (DateTime)SelectedDateValue.SelectedDate);

                TotalReceivedThisMonthValue.Value = StaffSalary.TotalReceivedByMonth(staff.GetStaffSalaries, (DateTime)SelectedDateValue.SelectedDate);
                StaffShouldReceiveThisMonthValue.Value = staff.GetStaffShouldReceiveThisMonth;
            }
        }

        #region Events
        private void StaffsList_SelectionChanged(object sender, Syncfusion.UI.Xaml.Grid.GridSelectionChangedEventArgs e)
        {
                UpdateSelectedStaff();    
        }
        private void SelectedDateValue_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateSelectedStaff();
        }

        #endregion
        #endregion

        #region Grid Switch


        private void PaySalaryButton_Click(object sender, RoutedEventArgs e)
        {
            StaffModel staff = (StaffModel)StaffsList.SelectedItem;
            if(staff != null)
            {
                UserGrid.Visibility = Visibility.Collapsed;
                PaySalaryGrid.Visibility = Visibility.Visible;

                PaySalaryUC paySalaryUC = new PaySalaryUC(staff);
                PaySalaryContentControl.Content = paySalaryUC;
            }

           
        }

        private void BackToNormalGridButton_FromPaySalary_Click(object sender, RoutedEventArgs e)
        {
            PaySalaryGrid.Visibility = Visibility.Collapsed;
            UserGrid.Visibility = Visibility.Visible;

            SetInitialValues();
        }

        private void SelectedPersonButton_Click(object sender, RoutedEventArgs e)
        {
            StaffModel staff = (StaffModel)StaffsList.SelectedItem;
            if (staff != null)
            {
                UserGrid.Visibility = Visibility.Collapsed;
                PersonLogGrid.Visibility = Visibility.Visible;

                PersonUC personUC = new PersonUC(staff.Person);
                PersonLogContentControl.Content = personUC;
            }
        }

        private void BackToNormalGridButton_FromPersonLog_Click(object sender, RoutedEventArgs e)
        {
            UserGrid.Visibility = Visibility.Visible;
            PersonLogGrid.Visibility = Visibility.Collapsed;
        }


        #endregion

       
    }
}
