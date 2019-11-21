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
    /// Interaction logic for CreatePersonUC.xaml
    /// </summary>
    public partial class CreatePersonUC : UserControl
    {
        #region Main Variables

        /// <summary>
        /// The New person model
        /// </summary>
        private PersonModel Person { get; set; }

        #endregion

        #region Set the initial values

        public CreatePersonUC()
        {
            InitializeComponent();
            SetInitialValues();
        }

        
        private void SetInitialValues()
        {
            Person = new PersonModel();
            FirstNameValue.Text = "";
            LastNameValue.Text = "";
            PhoneNumberValue.Text = "";
            NationalNumberValue.Text = "";
            EmailValue.Text = "";
            AddressValue.Text = "";
            CityValue.Text = "";
            CountryValue.Text = "";
            BirthDateValue.SelectedDate = new DateTime(1900,1,1);
            JopTitleValue.Text = "";
            JopAddressValue.Text = "";
            GraduationDateValue.SelectedDate = new DateTime(1900, 1, 1);
            QualificationValue.Text = "";
            DetailsValue.Text = "";
        }

        /// <summary>
        /// Called On reloading the form
        /// </summary>
        private void Reload()
        {
            Person = new PersonModel();
            FirstNameValue.Text = "";
            LastNameValue.Text = "";
            PhoneNumberValue.Text = "";
            NationalNumberValue.Text = "";
            EmailValue.Text = "";
            AddressValue.Text = "";
            CityValue.Text = "";
            CountryValue.Text = "";
            BirthDateValue.Text = "";
            JopTitleValue.Text = "";
            JopAddressValue.Text = "";
            GraduationDateValue.Text = "";
            QualificationValue.Text = "";
            DetailsValue.Text = "";
        }

        #endregion

        #region Hole Form Events

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            Reload();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            Person.FirstName = FirstNameValue.Text;
            Person.LastName = LastNameValue.Text;
            Person.PhoneNumber = PhoneNumberValue.Text;
            Person.NationalNumber= NationalNumberValue.Text;
            Person.Email =  EmailValue.Text;
            Person.Address = AddressValue.Text;
            Person.City =  CityValue.Text;
            Person.Country=CountryValue.Text;
            Person.BirthDate = (DateTime)BirthDateValue.SelectedDate;
            Person.JopTitle = JopTitleValue.Text;
            Person.JopAddress = JopAddressValue.Text;
            Person.GraduationDate = (DateTime)GraduationDateValue.SelectedDate;
            Person.Qualification = QualificationValue.Text;
            Person.Details = DetailsValue.Text;

            GlobalConfig.PersonValidator = new PersonValidator();

            ValidationResult result = GlobalConfig.PersonValidator.Validate(Person);

            if (result.IsValid == false)
            {

                MessageBox.Show(result.Errors[0].ErrorMessage);

            }
            else
            {
                GlobalConfig.Connection.AddPersonToTheDatabase(Person);
                SetInitialValues();
            }

        }
        #endregion


    }
}
