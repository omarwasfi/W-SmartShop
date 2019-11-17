using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class OwnerModel
    {
        /// <summary>
        /// The Id of the Owner
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The person model of this Owner
        /// </summary>
        public PersonModel Person { get; set; }

        /// <summary>
        /// All The investments that the Owner Made (the money that he invested in the project)
        /// </summary>
        public List<InvestmentModel> Investments { get; set; }

        /// <summary>
        /// All The revenues that the owner made(the money that he took from the project)
        /// </summary>
        public List<RevenueModel> Revenues { get; set; }
    }
}
