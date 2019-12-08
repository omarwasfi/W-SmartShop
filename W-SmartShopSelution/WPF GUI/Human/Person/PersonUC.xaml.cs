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
    /// Interaction logic for PersonUC.xaml
    /// </summary>
    public partial class PersonUC : UserControl
    {

        public PersonModel Person { get; set; }

        #region Set the initial values
        public PersonUC(PersonModel person)
        {
            InitializeComponent();
            Person = person;
            SetInitialValues();
        }

        private void SetInitialValues()
        {
            PersonFullNameValue.Text = Person.FullName;
            PersonProperties.Text = Person.GetThePersonProperties;

            OrdersList.ItemsSource = null;
            OrdersList.ItemsSource = Person.GetAsACustomer.GetOrders;
        }

        #endregion

        #region Grid Switch
        private void EditTabButton_Click(object sender, RoutedEventArgs e)
        {
            UserGrid.Visibility = Visibility.Collapsed;
            EditGrid.Visibility = Visibility.Visible;

            ModifyPersonUC.ModifyPersonUC modifyPerson = new ModifyPersonUC.ModifyPersonUC(Person);
            EditPersonContentControl.Content = modifyPerson;
        }

        private void BackToNormalGridButton_FromEditPersonGrid_Click(object sender, RoutedEventArgs e)
        {
            UserGrid.Visibility = Visibility.Visible;
            EditGrid.Visibility = Visibility.Collapsed;

            SetInitialValues();
        }

        private void ReloadTabButton_Click(object sender, RoutedEventArgs e)
        {
            SetInitialValues();
        }
        #endregion

      
    }
}
