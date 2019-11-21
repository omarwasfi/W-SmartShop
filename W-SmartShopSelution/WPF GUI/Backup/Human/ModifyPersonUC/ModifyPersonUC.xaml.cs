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

        /// <summary>
        /// The person that we need to edit
        /// </summary>
        private PersonModel Person = new PersonModel();

        #endregion


        #region Set the Initial Values

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person">The person model that needs to edit</param>
        public ModifyPersonUC(PersonModel person)
        {
            InitializeComponent();

            Person = person;

            SetInitialValues();

        }


        private void SetInitialValues()
        {
            SetGuiDefaultValues();
        }

        private void SetGuiDefaultValues()
        {
            FirstNameValue_ModifyPersonUC.Text = Person.FirstName;
            LastNameValue_ModifyPersonUC.Text = Person.LastName;
            PhoneNumberValue_ModifyPersonUC.Text = Person.PhoneNumber;
            NationalNumberValue_ModifyPersonUC.Text = Person.NationalNumber;
            EmailValue_ModifyPersonUC.Text = Person.Email;
            AddressValue_ModifyPersonUC.Text = Person.Address;
            CityValue_ModifyPersonUC.Text = Person.City;
            CountryValue_ModifyPersonUC.Text = Person.Country;

        }

        #endregion

        #region Hole form events

        /// <summary>
        /// Close the Window
        /// source : https://stackoverflow.com/questions/1262115/how-do-you-display-a-custom-usercontrol-as-a-dialog
        /// </summary>
        private void CloseButton_ModifyPersonUC_Click(object sender, RoutedEventArgs e)
        {
            var parent = this.Parent as Window;
            if (parent != null) { parent.DialogResult = true; parent.Close(); }
        }

        /// <summary>
        /// Reset the form 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetButton_ModifyPersonUC_Click(object sender, RoutedEventArgs e)
        {
            SetInitialValues();
        }


        /// <summary>
        /// Check if the first name is not null
        /// check it the national number is not used with other person before
        /// if every thing ok Update the person with the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfirmButton_ModifyPersonUC_Click(object sender, RoutedEventArgs e)
        {
            bool confirm = true;

            if(FirstNameValue_ModifyPersonUC.Text.Length > 0)
            {
                if ( NationalNumberValue_ModifyPersonUC.Text == Person.NationalNumber  || GlobalConfig.Connection.CheckIfTheNationalNumberUnique(NationalNumberValue_ModifyPersonUC.Text))
                {

                }
                else
                {
                    MessageBox.Show("This national Number is used before with other person !");
                    confirm = false;
                }
            }
            else
            {
                MessageBox.Show("First name cant be less than 1 chareter");
                confirm = false;

            }

            if (confirm)
            {
                Person.FirstName = FirstNameValue_ModifyPersonUC.Text;
                Person.LastName = LastNameValue_ModifyPersonUC.Text;
                Person.PhoneNumber = PhoneNumberValue_ModifyPersonUC.Text;
                Person.NationalNumber = NationalNumberValue_ModifyPersonUC.Text;
                Person.Email = EmailValue_ModifyPersonUC.Text;
                Person.Address = AddressValue_ModifyPersonUC.Text;
                Person.City = CityValue_ModifyPersonUC.Text;
                Person.Country = CountryValue_ModifyPersonUC.Text;

                GlobalConfig.Connection.UpdatePersonData(Person);

                var parent = this.Parent as Window;
                if (parent != null) { parent.DialogResult = true; parent.Close(); }
            }
        }

        #endregion
    }
}
