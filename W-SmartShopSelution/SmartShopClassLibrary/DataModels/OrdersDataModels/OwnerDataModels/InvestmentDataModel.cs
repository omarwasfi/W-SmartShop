using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class InvestmentDataModel
    {
        /// <summary>
        /// The id of the Investment record
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The dataTime of the investment
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The money Owner paid at this investment
        /// </summary>
        public decimal TotalMoney { get; set; }

        

    }
}
