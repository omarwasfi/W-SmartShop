using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    /// <summary>
    /// Person model cotain details about the person 
    /// Database Id, FirstName , LastName , PhoneNumber OR Numbers , Email Or Emails , Address , Ciry , Country
    /// </summary>
    public class PersonModel
    {
        /// <summary>
        /// Database Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The FirstName of the person
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// the lastName For the person
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        ///  the PhoneNumber of the person
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The NationalNumber of the person (Rkm el beta2a)
        /// </summary>
        public string NationalNumber { get; set; }

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

        

    }
}
