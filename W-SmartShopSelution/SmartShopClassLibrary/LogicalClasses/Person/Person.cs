using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class Person
    {


        /// <summary>
        ///  Get Customer by PesonModel by searching in the publicVariables.Customers
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public static CustomerModel  GetPersonAsACustomer(PersonModel person)
        {
            return PublicVariables.Customers.Find(x => x.Person.Id == person.Id);
           
        }

        /// <summary>
        ///  Get Supplier by PesonModel in the publicvariables.Suppliers
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public static SupplierModel GetPersonAsASupplier(PersonModel person)
        {
            return PublicVariables.Suppliers.Find(x => x.Person.Id == person.Id);

        }

        /// <summary>
        /// Get Staff by PesonModel - Searching in the publicvariables.staffs
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public static StaffModel GetPersonAsAStaff(PersonModel person)
        {
            return PublicVariables.Staffs.Find(x => x.Person.Id == person.Id);

        }

        /// <summary>
        /// Get Staff by PesonModel - Searching in the publicvariables.Owners
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public static OwnerModel GetPersonAsAOwner(PersonModel person)
        {
            return PublicVariables.Owners.Find(x => x.Person.Id == person.Id);

        }

        /// <summary>
        /// Checks if the national number unique
        /// - Unique = true
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public static bool IsTheNationalNumberUnique(PersonModel person)
        {
            if (String.IsNullOrWhiteSpace(person.NationalNumber))
            {
                return true;
            }
            person = PublicVariables.People.Find(x => x.NationalNumber == person.NationalNumber);
            if(person == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Used when adding new person to the database 
        /// check if this person in the database With the NationalNumber ONLY
        /// </summary>
        /// <returns> true OR false </returns>
        public static bool IsThisPersonInTheDataBase(PersonModel person,List<PersonModel> people) 
        {
            foreach(PersonModel p in people)
            {
                if(!String.IsNullOrWhiteSpace(p.NationalNumber) && !String.IsNullOrWhiteSpace(person.NationalNumber))
                {
                    if (person.NationalNumber == p.NationalNumber)
                    {
                        return true;
                    }
                }
                
            }

            return false;
        }

        /// <summary>
        /// Check if the national number used before If It is return false
        /// If it is unique OR null Or White space return true
        /// </summary>
        /// <param name="people"></param>
        /// <param name="nationalNumber"></param>
        /// <returns></returns>
        public static bool CheckIfTheNationalNumberUnique(List<PersonModel> people , string nationalNumber)
        {
            if (String.IsNullOrWhiteSpace(nationalNumber))
            {
                return true;
            }

            foreach(PersonModel person in people)
            {
                if(person.NationalNumber == nationalNumber)
                {
                    return false;
                }
            }
            return true;

        }

    }
}
