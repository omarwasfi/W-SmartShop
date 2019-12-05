using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Library
{
    public class OrderProductRecordModel
    {
        /// <summary>
        /// The choosen stock 
        /// </summary>
        public StockModel Stock { get; set; }

        public OrderProductModel OrderProduct { get; set; }

        
    }
}
