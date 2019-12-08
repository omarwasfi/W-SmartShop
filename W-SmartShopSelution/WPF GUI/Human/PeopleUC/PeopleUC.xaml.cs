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

using Syncfusion.Windows.Shared;

namespace WPF_GUI
{
    /// <summary>
    /// Interaction logic for PeopleUC.xaml
    /// </summary>
    public partial class PeopleUC : UserControl
    {
        public PeopleUC()
        {
           

            InitializeComponent();
            SetInitialValues();

        }

        private void SetInitialValues()
        {

            PeopleList.ItemsSource = null;
            PeopleList.ItemsSource = PublicVariables.People;        

        }



        private void CreatePerson_Click(object sender, RoutedEventArgs e)
        {
            MainGrid_PeopleUC.Visibility = Visibility.Collapsed;
            CreatePersonGrid.Visibility = Visibility.Visible;
        }

       
        private void PeopleList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            PersonModel person = (PersonModel)PeopleList.SelectedItem;
            if(person != null)
            {
                PersonUC personUC = new PersonUC(person);
                PersonGrid.Visibility = Visibility.Visible;
                MainGrid_PeopleUC.Visibility = Visibility.Collapsed;
                PersonContentControl.Content = personUC;
            }
        }

        private void BackToNormalGridButton_SellUC_Click(object sender, RoutedEventArgs e)
        {
            CreatePersonGrid.Visibility = Visibility.Collapsed;
            MainGrid_PeopleUC.Visibility = Visibility.Visible;
            SetInitialValues();
        }
        private void BackToNormalGridButton_FromPersonGrid_Click(object sender, RoutedEventArgs e)
        {
            PersonGrid.Visibility = Visibility.Collapsed;
            MainGrid_PeopleUC.Visibility = Visibility.Visible;
        }
    }
}
