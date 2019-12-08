using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class Supplier
    {
        

        /// <summary>
        /// Get all the incomeorders That the supplier in
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public static List<IncomeOrderModel> GetIncomeOrders(SupplierModel supplier)
        {
            return PublicVariables.IncomeOrders.FindAll(x => x.Supplier == supplier);
        }

    }
}
