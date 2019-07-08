using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    /// <summary>
    /// Customer model contain the customer details
    /// Database Id, Person model
    /// </summary>
    public class CustomerModel
    {
        /// <summary>
        /// Database Id 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// A person model identify the customer 
        /// The person model describe everything about this person
        /// </summary>
        public PersonModel  Person { get; set; }

        
    }
}
