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

namespace WPF_GUI.ModifyPersonUC
{
    /// <summary>
    /// Interaction logic for ModifyPersonUC.xaml
    /// </summary>
    public partial class ModifyPersonUC : UserControl
    {

        #region Main veriables



        #endregion


        #region Set the Initial Values

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person">The person model that needs to edit</param>
        public ModifyPersonUC(PersonModel person)
        {
            InitializeComponent();


            SetInitialValues( person);

        }


        private void SetInitialValues(PersonModel person)
        {
            FirstNameValue.Text = person.FirstName;
            LastNameValue.Text = person.LastName;
            PhoneNumberValue.Text = person.PhoneNumber;
            NationalNumberValue.Text = person.NationalNumber;
            EmailValue.Text = person.Email;
            AddressValue.Text = person.Address;
            CityValue.Text = person.City;
            CountryValue.Text = person.Country;
            BirthDateValue.SelectedDate = person.BirthDate;
            JopTitleValue.Text = person.JopTitle;
            JopAddressValue.Text = person.JopAddress;
            GraduationDateValue.SelectedDate = person.GraduationDate;
            QualificationValue.Text = person.Qualification;
            DetailsValue.Text = person.Details;
        }



        #endregion

        #region Hole form events

         private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
        }

        #endregion

       
    }
}
