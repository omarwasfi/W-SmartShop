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
using WPF_GUI.CreateProduct;

namespace WPF_GUI.CreateCutomer
{
    //  class event publisher inherits the CustomerCreated Interface
    /// <summary>
    /// Interaction logic for CreateCustomerUC.xaml
    /// </summary>
    public partial class CreateCustomerUC : UserControl 
    {
        ICustomerRequester customerRequester;

        
        

        /// <summary>
        /// Equal the customerRequester to the callingUC
        /// </summary>
        /// <param name="CallingUC"></param>
        public CreateCustomerUC(ICustomerRequester CallingUC)
        {
            InitializeComponent();

            customerRequester = CallingUC;
        }

        /// <summary>
        /// Create Customer Clicked
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateButton_CreateCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (IsValid())
            {
                CustomerModel customer = new CustomerModel();
                PersonModel person = new PersonModel();
                customer.Person = person;

                customer.Person.FirstName = (string)CustomerFirstNameValue_CreateCustomer.Text;
                if(CustomerLastNameValue_CreateCustomer.Text.Length > 0)
                {
                    customer.Person.LastName = CustomerLastNameValue_CreateCustomer.Text;
                }
                if (CustomerPhoneNumberValue_CreateCustomer.Text.Length >  0)
                {
                    customer.Person.PhoneNumber = CustomerPhoneNumberValue_CreateCustomer.Text;
                }
                if(CustomerNationalNumberValue_CreateCustomer.Text.Length > 0)
                {
                    customer.Person.NationalNumber = CustomerNationalNumberValue_CreateCustomer.Text;
                }
                if (CustomerEmailValue_CreateCustomer.Text.Length > 0)
                {
                    customer.Person.Email = CustomerEmailValue_CreateCustomer.Text;
                }
                if(CustomerAddressValue_CreateCustomer.Text.Length > 0)
                {
                    customer.Person.Address = CustomerAddressValue_CreateCustomer.Text;
                }
                if (CustomerCityValue_CreateCustomer.Text.Length > 0)
                {
                    customer.Person.City = CustomerCityValue_CreateCustomer.Text;
                }
                if (CustomerCountryValue_CreateCutomer.Text.Length > 0)
                {
                    customer.Person.Country = CustomerCountryValue_CreateCutomer.Text;
                }


                

                if (GlobalConfig.Connection.CreateCustomer(customer).Id == -1 )
                {
                    MessageBox.Show("This Person is exist OR This National number is exist");
                }
                else
                {
                    customerRequester.CustomerComplete(customer);
                   
                    Close();
                }

                
                


     
                
            }
        }

        /// <summary>
        /// Check If The info is valid or not
        /// </summary>
        /// <returns></returns>
        private bool IsValid()
        {
            bool isValid = true;
            if(CustomerFirstNameValue_CreateCustomer.Text == "")
            {
                isValid = false;
                MessageBox.Show("First Name Required");
            }


            return isValid;
        }

        /// <summary>
        /// Close the Window
        /// source : https://stackoverflow.com/questions/1262115/how-do-you-display-a-custom-usercontrol-as-a-dialog
        /// </summary>
        private void Close()
        {
            var parent = this.Parent as Window;
            if (parent != null) { parent.DialogResult = true; parent.Close(); }
        }

        private void CloseButton_CreateCustomer_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
