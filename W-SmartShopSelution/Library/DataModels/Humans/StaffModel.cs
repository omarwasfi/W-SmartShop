using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataModels
{
    /// <summary>
    /// Staff model contain the staff member details 
    /// Id, Username, Password, Person model, List of Stores He works on Or have Access to Login there
    /// </summary>
    public class StaffModel
    {
        /// <summary>
        /// Staff member Id in the Database
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// A unique Username for the staff member
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// A password for the staff member should be at least 8 numbers
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// A person model identify the staff member
        /// The person model describe everything about this person
        /// </summary>
        public PersonModel Person { get; set; }

        /// <summary>
        /// List Of Store model that the staff member works In
        /// </summary>
        public List<StoreModel> Stores { get; set; }

        /// <summary>
        /// The permissions That the staff member can have
        /// the permission model identify the forms that the customer can use 
        /// </summary>
        public List<PermissionModel> Permissions { get; set; }



    }
}
