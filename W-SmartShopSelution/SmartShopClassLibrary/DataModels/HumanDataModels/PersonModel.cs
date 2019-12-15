using System;
using System.ComponentModel;

namespace Library
{
    [Serializable]
    /// <summary>
    /// Person model cotain details about the person
    /// Database Id, FirstName , LastName , PhoneNumber OR Numbers , Email Or Emails , Address , Ciry , Country
    /// </summary>
    public class PersonModel
    {
        private int id;

        /// <summary>
        /// Database Id
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string firstName;

        /// <summary>
        /// The FirstName of the person
        /// </summary>
        public string FirstName
        {
            get { return firstName; }
            set 
            { 
                firstName = value; 
              

            }
        }

        private string lastName;

        /// <summary>
        /// the lastName For the person
        /// </summary>
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value; 
        

            }
        }

        /// <summary>
        /// Get Full Name For the person
        /// </summary>
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }



        /// <summary>
        ///  the PhoneNumber of the person
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The NationalNumber of the person (Rkm el beta2a)
        /// </summary>
        public string NationalNumber { get; set; }

        /// <summary>
        /// The Date of birth of the person
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// The Jop Title Of the person
        /// </summary>
        public string JopTitle { get; set; }

        /// <summary>
        /// The address of the Jop of the person
        /// </summary>
        public string JopAddress { get; set; }

        /// <summary>
        /// The graduation date of the person
        /// </summary>
        public DateTime GraduationDate { get; set; }

        /// <summary>
        /// The qualification of the person
        /// </summary>
        public string Qualification { get; set; }

        /// <summary>
        /// The Eamils of the person
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The Address Or Addresses of the person
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// The City That the person lives in
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// the country that the person lives in
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Any details needs to be known about the Person
        /// </summary>
        public string Details { get; set; }

        #region Not Database related

     

        /// <summary>
        /// Get the Person as a customer if he is
        /// </summary>
        public CustomerModel GetAsACustomer 
        {
            get { return Person.GetPersonAsACustomer(this); }
        }



        /// <summary>
        /// Get the Person as a Supplier if he is
        /// </summary>
        public SupplierModel GetAsASupplier
        {
            get { return Person.GetPersonAsASupplier(this); } }



        /// <summary>
        /// Get the Person as a Supplier if he is
        /// </summary>
        public StaffModel GetAsAStaff { get { return Person.GetPersonAsAStaff(this); } }



        /// <summary>
        ///  Get the Person as a Supplier if he is
        /// </summary>
        public OwnerModel GetAsOwner { get { return Person.GetPersonAsAOwner(this); } }

        /// <summary>
        /// Get Person Properties in the Program(Customer,staff,supplier,Owner)
        /// </summary>
        public string GetThePersonProperties 
        { get 
            {
                string properties = "";
                if(GetAsACustomer!= null)
                {
                    properties += "Customer";
                }
                if (GetAsASupplier != null)
                {
                    properties += " , Supplier";
                }
                if (GetAsAStaff != null)
                {
                    properties += " , Staff";
                }
                if(GetAsOwner!= null)
                {
                    properties += " , Owner";
                }
                return properties; 
            } 
        }

        #endregion

    }
}