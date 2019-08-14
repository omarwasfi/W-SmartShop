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
using Library;


namespace WPF_GUI
{
    /// <summary>
    /// Interaction logic for CreateSupplierUC.xaml
    /// </summary>
    public partial class CreateSupplierUC : UserControl
    {
        #region Main Variables

        /// <summary>
        /// The new supplier model
        /// </summary>
        SupplierModel Supplier = new SupplierModel();


        #endregion

        #region New Person  Variables



        private PersonModel NewPerson = new PersonModel();


        #endregion


        #region Old Customer
        /// <summary>
        /// The selected Customer
        /// </summary>
        private CustomerModel Customer { get; set; }

        /// <summary>
        /// All person models in the customers 
        /// set when first init get all person model that in the customers by Update_CustomerNamesVariablesAndEvents()
        /// </summary>
        private List<PersonModel> People { get; set; } = new List<PersonModel>();

        /// <summary>
        /// All Customers in the database
        /// </summary>
        private List<CustomerModel> Customers { get; set; }
        private List<string> CustomersFullNames { get; set; } = new List<string>();
        private List<string> CustomersPhoneNumbers { get; set; } = new List<string>();
        private List<string> CustomersNationalNumbers { get; set; } = new List<string>();



        #endregion




        #region set the initianl values

        public CreateSupplierUC()
        {
            InitializeComponent();

            SetInitialValues();

        }


        private void SetInitialValues()
        {
            OldCustomerRadioButton_CreateSupplierUC.IsChecked = true;
            InProg_CustomerNameValue_CreateSupplierUC = false;
            InProg_PhoneNumberValue_CreateSupplierUC = false;
            InProg_NationalNumberValue_CreateSupplierUC = false;

            PersonFirstNameValue_CreateSupplierUC.Text = "";
            PersonLastNameValue_CreateSupplierUC.Text = "";
            PersonPhoneNumberValue_CreateSupplierUC.Text = "";
            PersonNationalNumberValue_CreateSupplierUC.Text = "";
            PersonEmailValue_CreateSupplierUC.Text = "";
            PersonAddressValue_CreateSupplierUC.Text = "";
            PersonCityValue_CreateSupplierUC.Text = "";
            PersonCountryValue_CreateSupplierUC.Text = "";
            SupplierCompanyValue_CreateSupplierUC.Text = "";



            ClearCustomerInfo();

            Update_CustomerNamesVariablesAndEvents();


            
        }


        /// <summary>
        /// Add The person model in each customer in the people list
        /// Add Customers full Names into 1 list 
        /// Add customers PhoneNumbers into 1 list
        /// Add Customers NationalNumbers into 1 list
        /// Add delete pressed events
        /// </summary>
        private void Update_CustomerNamesVariablesAndEvents()
        {
            GetCustomersFromPublicVariables();
            foreach (CustomerModel customer in Customers)
            {

                People.Add(customer.Person);

                CustomersFullNames.Add(customer.Person.FullName);

                if (customer.Person.PhoneNumber != null)
                    CustomersPhoneNumbers.Add(customer.Person.PhoneNumber);

                if (customer.Person.NationalNumber != null)
                    CustomersNationalNumbers.Add(customer.Person.NationalNumber);

            }
            CustomerNameValue_CreateSupplierUC.PreviewKeyDown += DelPressed_CustomerNameValue_CreateSupplierUC;
            PhoneNumberValue_CreateSupplierUC.PreviewKeyDown += DelPressed_PhoneNumberValue_CreateSupplierUC;
            NationalNumberValue_CreateSupplierUC.PreviewKeyDown += DelPressed_NationalNumberValue_CreateSupplierUC;



        }


        /// <summary>
        /// Update and Get All Customers from the PublicVariables
        /// </summary>
        private void GetCustomersFromPublicVariables()
        {
            PublicVariables.Customers = null;
            PublicVariables.Customers = GlobalConfig.Connection.GetCustomers();
            Customers = null;
            Customers = PublicVariables.Customers;
        }




        #endregion




        #region Hole From Events

        /// <summary>
        /// When oldCustomerRadioButton Checked enable oldCustomerGB and disable NewPersonGB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OldCustomerRadioButton_CreateSupplierUC_Checked(object sender, RoutedEventArgs e)
        {
            OldCustomerGB_CreateSupplierUC.IsEnabled = true;
            NewPersonGB_CreateSupplierUC.IsEnabled = false;
        }

        /// <summary>
        /// When oldCustomerRadioButton Checked enable NewPersonGB and disable oldCustomerGB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewPersonRadioButton_CreateSupplierUC_Checked(object sender, RoutedEventArgs e)
        {
            OldCustomerGB_CreateSupplierUC.IsEnabled = false;
            NewPersonGB_CreateSupplierUC.IsEnabled = true;
        }

        /// <summary>
        /// check if everything correct then add the supplier to the database , Update the suppliers pulbic variables
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfirmButton_CreateSupplierUC_Click(object sender, RoutedEventArgs e)
        {
            

                if (OldCustomerRadioButton_CreateSupplierUC.IsChecked == true)
                {
                    if (Customer != null)
                    {
                    bool confirm = true;
                    foreach (SupplierModel supplier in PublicVariables.Suppliers)
                    {
                        if (Customer.Person.Id == supplier.Person.Id)
                        {
                            confirm = false;
                            break;
                        }
                    }

                    if (confirm)
                    {
                        Supplier.Person = Customer.Person;
                        Supplier.Company = SupplierCompanyNameValue_CreateSupplierUC.Text;


                        GlobalConfig.Connection.CreateSupplier(Supplier);

                        PublicVariables.Suppliers = GlobalConfig.Connection.GetSuppliers();

                        var parent = this.Parent as Window;
                        if (parent != null) { parent.DialogResult = true; parent.Close(); }
                    }
                    else
                    {
                        MessageBox.Show("This Cusomer is an old Supplier !! ");
                    }

                }
                else
                    {
                        MessageBox.Show("Search for a customer first Then press enter to confirm");
                    }

                    


                }
                else if (NewPersonRadioButton_CreateSupplierUC.IsChecked == true)
                {
                    bool confirm = new bool();
                    confirm = true;

                    if (PersonFirstNameValue_CreateSupplierUC.Text.Length > 0)
                    {
                        Supplier.Person = new PersonModel();
                        Supplier.Person.FirstName = (string)PersonFirstNameValue_CreateSupplierUC.Text;
                        if (PersonLastNameValue_CreateSupplierUC.Text.Length > 0)
                        {
                            Supplier.Person.LastName = PersonLastNameValue_CreateSupplierUC.Text;
                        }
                        if (PersonPhoneNumberValue_CreateSupplierUC.Text.Length > 0)
                        {
                            Supplier.Person.PhoneNumber = PersonPhoneNumberValue_CreateSupplierUC.Text;
                        }
                        if (PersonNationalNumberValue_CreateSupplierUC.Text.Length > 0)
                        {
                            if (GlobalConfig.Connection.CheckIfTheNationalNumberUnique(PersonNationalNumberValue_CreateSupplierUC.Text))
                            {
                                Supplier.Person.NationalNumber = PersonNationalNumberValue_CreateSupplierUC.Text;
                            }
                            else
                            {
                                MessageBox.Show("This national is used before with other person");
                                confirm = false;
                            }
                        }
                        if (PersonEmailValue_CreateSupplierUC.Text.Length > 0)
                        {
                            Supplier.Person.Email = PersonEmailValue_CreateSupplierUC.Text;
                        }
                        if (PersonAddressValue_CreateSupplierUC.Text.Length > 0)
                        {
                            Supplier.Person.Address = PersonAddressValue_CreateSupplierUC.Text;
                        }
                        if (PersonCityValue_CreateSupplierUC.Text.Length > 0)
                        {
                            Supplier.Person.City = PersonCityValue_CreateSupplierUC.Text;
                        }
                        if (PersonCountryValue_CreateSupplierUC.Text.Length > 0)
                        {
                            Supplier.Person.Country = PersonCountryValue_CreateSupplierUC.Text;
                        }
                        if (SupplierCompanyValue_CreateSupplierUC.Text.Length > 0)
                        {
                            Supplier.Company = SupplierCompanyValue_CreateSupplierUC.Text;
                        }

                    }
                    else
                    {
                        MessageBox.Show("First Name Value can't be empty !");
                    confirm = false;

                }

                if (confirm)
                    {


                        Supplier.Person = GlobalConfig.Connection.CreatePerson(Supplier.Person);

                        CustomerModel customer = new CustomerModel() { Person = Supplier.Person };

                        GlobalConfig.Connection.CreateCustomer_NoReturn(customer);

                        GlobalConfig.Connection.CreateSupplier(Supplier);

                        PublicVariables.Customers = GlobalConfig.Connection.GetCustomers();
                        PublicVariables.Suppliers = GlobalConfig.Connection.GetSuppliers();


                        var parent = this.Parent as Window;
                        if (parent != null) { parent.DialogResult = true; parent.Close(); }

                    }
                }
            
           

        }

        private void ClearButton_CreateSupplierUC_Click(object sender, RoutedEventArgs e)
        {
            SetInitialValues();
        }

        private void CloseButton_CreateSupplierUC_Click(object sender, RoutedEventArgs e)
        {
            var parent = this.Parent as Window;
            if (parent != null) { parent.DialogResult = true; parent.Close(); }
        }


        #endregion

        #region NewPersonGB Events

        /// <summary>
        /// Clear new person data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearPersonButton_CreateSupplierUC_Click(object sender, RoutedEventArgs e)
        {
            PersonFirstNameValue_CreateSupplierUC.Text = "";
            PersonLastNameValue_CreateSupplierUC.Text = "";
            PersonPhoneNumberValue_CreateSupplierUC.Text = "";
            PersonNationalNumberValue_CreateSupplierUC.Text = "";
            PersonEmailValue_CreateSupplierUC.Text = "";
            PersonAddressValue_CreateSupplierUC.Text = "";
            PersonCityValue_CreateSupplierUC.Text = "";
            PersonCountryValue_CreateSupplierUC.Text = "";
            SupplierCompanyValue_CreateSupplierUC.Text = "";
        }


        #endregion

        #region OldCustomerGB Events

        // Customer Name Events & Search Functions

        private bool InProg_CustomerNameValue_CreateSupplierUC;
        /// <summary>
        /// Events for CustomerValue changes to auto complete
        /// source : https://stackoverflow.com/questions/950770/autocomplete-textbox-in-wpf
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomerNameValue_CreateSupplierUC_TextChanged(object sender, TextChangedEventArgs e)
        {
            var change = e.Changes.FirstOrDefault();
            if (!InProg_CustomerNameValue_CreateSupplierUC)
            {
                InProg_CustomerNameValue_CreateSupplierUC = true;
                var culture = new CultureInfo(CultureInfo.CurrentCulture.Name);
                var source = ((TextBox)sender);
                if (((change.AddedLength - change.RemovedLength) > 0 || source.Text.Length > 0) && !DelKeyPressed_CustomerNameValue_CreateSupplierUC)
                {
                    if (CustomersFullNames.Where(x => x.IndexOf(source.Text, StringComparison.CurrentCultureIgnoreCase) == 0).Count() > 0)
                    {
                        var _appendtxt = CustomersFullNames.FirstOrDefault(ap => (culture.CompareInfo.IndexOf(ap, source.Text, CompareOptions.IgnoreCase) == 0));
                        _appendtxt = _appendtxt.Remove(0, change.Offset + 1);
                        source.Text += _appendtxt;
                        source.SelectionStart = change.Offset + 1;
                        source.SelectionLength = source.Text.Length;
                    }
                }
                InProg_CustomerNameValue_CreateSupplierUC = false;
            }
        }
        private static bool DelKeyPressed_CustomerNameValue_CreateSupplierUC;
        internal static void DelPressed_CustomerNameValue_CreateSupplierUC(object sender, KeyEventArgs e)
        { if (e.Key == Key.Back) { DelKeyPressed_CustomerNameValue_CreateSupplierUC = true; } else { DelKeyPressed_CustomerNameValue_CreateSupplierUC = false; } }

        /// <summary>
        ///  Trigers when enter key down while selecting customerNameValue
        /// Compares the current value of the customerNameValue with customers list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomerNameValue_CreateSupplierUC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {

                foreach (CustomerModel c in Customers)
                {
                    if (c.Person.FullName.Equals(CustomerNameValue_CreateSupplierUC.Text, StringComparison.OrdinalIgnoreCase))
                    {
                        UpdateCustomerInfo(c);

                    }

                }
            }
        }

        // Customer Phone Number Events & Search Functions



        /// <summary>
        /// Events for PhoneNumberValue_CreateSupplierUC changes to auto complete
        /// source : https://stackoverflow.com/questions/950770/autocomplete-textbox-in-wpf
        /// </summary>
        private bool InProg_PhoneNumberValue_CreateSupplierUC;
        private void PhoneNumberValue_CreateSupplierUC_TextChanged(object sender, TextChangedEventArgs e)
        {
            var change = e.Changes.FirstOrDefault();
            if (!InProg_PhoneNumberValue_CreateSupplierUC)
            {
                InProg_PhoneNumberValue_CreateSupplierUC = true;
                var culture = new CultureInfo(CultureInfo.CurrentCulture.Name);
                var source = ((TextBox)sender);
                if (((change.AddedLength - change.RemovedLength) > 0 || source.Text.Length > 0) && !DelKeyPressed_PhoneNumberValue_CreateSupplierUC)
                {
                    if (CustomersPhoneNumbers.Where(x => x.IndexOf(source.Text, StringComparison.CurrentCultureIgnoreCase) == 0).Count() > 0)
                    {
                        var _appendtxt = CustomersPhoneNumbers.FirstOrDefault(ap => (culture.CompareInfo.IndexOf(ap, source.Text, CompareOptions.IgnoreCase) == 0));
                        _appendtxt = _appendtxt.Remove(0, change.Offset + 1);
                        source.Text += _appendtxt;
                        source.SelectionStart = change.Offset + 1;
                        source.SelectionLength = source.Text.Length;
                    }
                }
                InProg_PhoneNumberValue_CreateSupplierUC = false;
            }
        }
        private static bool DelKeyPressed_PhoneNumberValue_CreateSupplierUC;
        internal static void DelPressed_PhoneNumberValue_CreateSupplierUC(object sender, KeyEventArgs e)
        { if (e.Key == Key.Back) { DelKeyPressed_PhoneNumberValue_CreateSupplierUC = true; } else { DelKeyPressed_PhoneNumberValue_CreateSupplierUC = false; } }


        /// <summary>
        /// Trigers when enter key down while selecting PhoneNumberValue_CreateSupplierUC
        /// Compares the current value of the PhoneNumberValue_CreateSupplierUC with customersPhones  list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PhoneNumberValue_CreateSupplierUC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {

                foreach (CustomerModel customer in Customers)
                {
                    if (customer.Person.PhoneNumber != null)
                    {
                        if (customer.Person.PhoneNumber.Equals(PhoneNumberValue_CreateSupplierUC.Text))
                        {
                            UpdateCustomerInfo(customer);

                        }
                    }

                }
            }
        }



        // Customer National Number Events & Search Functions



        /// <summary>
        /// Events for PhoneNumberValue_Sell changes to auto complete
        /// source : https://stackoverflow.com/questions/950770/autocomplete-textbox-in-wpf
        /// </summary>
        private bool InProg_NationalNumberValue_CreateSupplierUC;
        private void NationalNumberValue_CreateSupplierUC_TextChanged(object sender, TextChangedEventArgs e)
        {
            var change = e.Changes.FirstOrDefault();
            if (!InProg_NationalNumberValue_CreateSupplierUC)
            {
                InProg_NationalNumberValue_CreateSupplierUC = true;
                var culture = new CultureInfo(CultureInfo.CurrentCulture.Name);
                var source = ((TextBox)sender);
                if (((change.AddedLength - change.RemovedLength) > 0 || source.Text.Length > 0) && !DelKeyPressed_NationalNumberValue_CreateSupplierUC)
                {
                    if (CustomersNationalNumbers.Where(x => x.IndexOf(source.Text, StringComparison.CurrentCultureIgnoreCase) == 0).Count() > 0)
                    {
                        var _appendtxt = CustomersNationalNumbers.FirstOrDefault(ap => (culture.CompareInfo.IndexOf(ap, source.Text, CompareOptions.IgnoreCase) == 0));
                        _appendtxt = _appendtxt.Remove(0, change.Offset + 1);
                        source.Text += _appendtxt;
                        source.SelectionStart = change.Offset + 1;
                        source.SelectionLength = source.Text.Length;
                    }
                }
                InProg_NationalNumberValue_CreateSupplierUC = false;
            }
        }
        private static bool DelKeyPressed_NationalNumberValue_CreateSupplierUC;
        internal static void DelPressed_NationalNumberValue_CreateSupplierUC(object sender, KeyEventArgs e)
        { if (e.Key == Key.Back) { DelKeyPressed_NationalNumberValue_CreateSupplierUC = true; } else { DelKeyPressed_NationalNumberValue_CreateSupplierUC = false; } }


        /// <summary>
        /// Trigers when enter key down while selecting NationalNumberValue_Sell
        /// Compares the current value of the NationalNumberValue_Sell with customersNationalNumbers  list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NationalNumberValue_CreateSupplierUC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {

                foreach (CustomerModel customer in Customers)
                {
                    if (customer.Person.NationalNumber != null)
                    {
                        if (customer.Person.NationalNumber.Equals(NationalNumberValue_CreateSupplierUC.Text))
                        {
                            UpdateCustomerInfo(customer);

                        }
                    }

                }
            }
        }



        // UpdateCustmerInfo & ClearCustomerInfo



        /// <summary>
        /// Called when customer changes to update his info
        /// </summary>
        /// <param name="customer"></param>
        private void UpdateCustomerInfo(CustomerModel customer)
        {
            Customer = customer;
            ClearCustomerInfo();
            InProg_CustomerNameValue_CreateSupplierUC = true;
            InProg_PhoneNumberValue_CreateSupplierUC = true;
            InProg_NationalNumberValue_CreateSupplierUC = true;

            CustomerNameValue_CreateSupplierUC.Text = customer.Person.FullName;

            if (customer.Person.PhoneNumber != null)
                PhoneNumberValue_CreateSupplierUC.Text = customer.Person.PhoneNumber;
            if (customer.Person.NationalNumber != null)
                NationalNumberValue_CreateSupplierUC.Text = customer.Person.NationalNumber;

            InProg_CustomerNameValue_CreateSupplierUC = false;
            InProg_PhoneNumberValue_CreateSupplierUC = false;
            InProg_NationalNumberValue_CreateSupplierUC = false;

        }

        /// <summary>
        /// Cleare customer  Customer data from the customer groupbox
        /// </summary>
        private void ClearCustomerInfo()
        {
            InProg_CustomerNameValue_CreateSupplierUC = true;
            InProg_PhoneNumberValue_CreateSupplierUC = true;
            InProg_NationalNumberValue_CreateSupplierUC = true;

            CustomerNameValue_CreateSupplierUC.Text = "";
            PhoneNumberValue_CreateSupplierUC.Text = "";
            NationalNumberValue_CreateSupplierUC.Text = "";
            SupplierCompanyNameValue_CreateSupplierUC.Text = "";

            InProg_CustomerNameValue_CreateSupplierUC = false;
            InProg_PhoneNumberValue_CreateSupplierUC = false;
            InProg_NationalNumberValue_CreateSupplierUC = false;

        }



        private void SelectedCustomerLogButton_CreateSupplierUC_Click(object sender, RoutedEventArgs e)
        {
            if (Customer != null )
            {
                CustomerLogUC.CustomerLogUC customerLogUC = new CustomerLogUC.CustomerLogUC(Customer);
                Window window = new Window
                {
                    Title = "Customer Log",
                    Content = customerLogUC,
                    SizeToContent = SizeToContent.WidthAndHeight,
                    ResizeMode = ResizeMode.NoResize
                };
                window.ShowDialog();
                SetInitialValues();
            }
            else
            {
                MessageBox.Show("Search For a customer");
            }
            
        }

        private void ClearCustomerButton_CreateSupplierUC_Click(object sender, RoutedEventArgs e)
        {
            ClearCustomerInfo();
        }

      

        #endregion


    }
}
