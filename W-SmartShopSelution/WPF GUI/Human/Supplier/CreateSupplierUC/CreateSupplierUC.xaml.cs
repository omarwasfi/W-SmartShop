using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for CreateSupplierUC.xaml
    /// </summary>
    public partial class CreateSupplierUC : UserControl
    {
        #region Main Variables




        #endregion

        #region New Person  Variables



       


        #endregion


        #region Old Customer
       


        #endregion




        #region set the initianl values

        public CreateSupplierUC()
        {
            InitializeComponent();

            SetInitialValues();

        }


        private void SetInitialValues()
        {



            FirstNameValue.Text = "";
            LastNameValue.Text = "";
            PhoneNumberValue.Text = "";
            NationalNumberValue.Text = "";
            EmailValue.Text = "";
            AddressValue.Text = "";
            CityValue.Text = "";
            CountryValue.Text = "";
            BirthDateValue.SelectedDate = new DateTime(1900, 1, 1);
            JopTitleValue.Text = "";
            JopAddressValue.Text = "";
            GraduationDateValue.SelectedDate = new DateTime(1900, 1, 1);
            QualificationValue.Text = "";
            DetailsValue.Text = "";
            CompanyValue.Text = "";




            OldPersonRadioButton.IsChecked = true;
            NewPersonRadioButton.IsChecked = false;

            PersonSearchValue.ItemsSource = null;
            PersonSearchValue.ItemsSource = PublicVariables.Organization.GetPeopleNotSuppliers;
            PersonSearchValue.SearchCondition = Syncfusion.UI.Xaml.Grid.SearchCondition.Contains;
            PersonSearchValue.DisplayMember = "FullName";

            CompanyValue_OldCustomer.Text = "";
        }







        #endregion

        #region Hole From Events
        private void OldPersonRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            OldPersonGB.IsEnabled = true;
            NewPersonGB.IsEnabled = false;
        }

        private void NewPersonRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            OldPersonGB.IsEnabled = false;
            NewPersonGB.IsEnabled = true;
        }

        private void ReloadTabButton_Click(object sender, RoutedEventArgs e)
        {
            SetInitialValues();
        }

        private void ConfitmButton_Click(object sender, RoutedEventArgs e)
        {
            if(OldPersonRadioButton.IsChecked == true)
            {
                PersonModel person = (PersonModel)PersonSearchValue.SelectedItem;
               
                    SupplierModel supplier = new SupplierModel();
                    supplier.Person = person;
                    supplier.Company = CompanyValue_OldCustomer.Text;

                    GlobalConfig.SupplierValidator = new SupplierValidator();

                    ValidationResult result = GlobalConfig.SupplierValidator.Validate(supplier);

                    if (result.IsValid == false)
                    {

                        MessageBox.Show(result.Errors[0].ErrorMessage);

                    }
                    else
                    {
                    GlobalConfig.Connection.AddSupplierWithOldPersonToTheDatabase(supplier);
                    SetInitialValues();
                    }
                
            }
            else
            {
                PersonModel person = new PersonModel();
                person.FirstName = FirstNameValue.Text;
                person.LastName = LastNameValue.Text;
                person.PhoneNumber = PhoneNumberValue.Text;
                person.NationalNumber = NationalNumberValue.Text;
                person.Email = EmailValue.Text;
                person.Address = AddressValue.Text;
                person.City = CityValue.Text;
                person.Country = CountryValue.Text;
                person.BirthDate = (DateTime)BirthDateValue.SelectedDate;
                person.JopTitle = JopTitleValue.Text;
                person.JopAddress = JopAddressValue.Text;
                person.GraduationDate = (DateTime)GraduationDateValue.SelectedDate;
                person.Qualification = QualificationValue.Text;
                person.Details = DetailsValue.Text;

                GlobalConfig.PersonValidator = new PersonValidator();

                ValidationResult result = GlobalConfig.PersonValidator.Validate(person);

                if (result.IsValid == false)
                {

                    MessageBox.Show(result.Errors[0].ErrorMessage);

                }
                else
                {
                    GlobalConfig.Connection.AddPersonToTheDatabase(person);
                    SupplierModel supplier = new SupplierModel();
                    supplier.Person = person;
                    supplier.Company = CompanyValue.Text;
                    GlobalConfig.Connection.AddSupplierWithOldPersonToTheDatabase(supplier);

                    SetInitialValues();
                }
            }
        }


        #endregion

        #region NewPersonGB Events



        #endregion

        #region OldCustomerGB Events





        #endregion

       
    }
}
