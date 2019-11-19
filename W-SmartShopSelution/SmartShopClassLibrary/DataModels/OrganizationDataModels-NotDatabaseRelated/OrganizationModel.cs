using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class OrganizationModel
    {
        /// <summary>
        /// The Organization Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The Orgnization Address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// The Organization PhoneNumber
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The Stores that this orginzation Had
        /// </summary>
        public List<StoreModel>Stores { get; set; }

        /// <summary>
        /// The Owners who's invested in this Organization
        /// </summary>
        public List<OwnerModel> Owners { get; set; }



        /// <summary>
        /// Return The calculation of over all capital
        /// </summary>
        public decimal GetCapital { get; set; }
    }
}
