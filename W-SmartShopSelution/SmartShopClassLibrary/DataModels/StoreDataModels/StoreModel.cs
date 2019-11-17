using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class StoreModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        #region non dataBase related

        /// <summary>
        /// -Need Update- All the Transforms that this store got ( The Money that the store Got From The Capital)
        /// </summary>
        public List<TransformModel> GetTransforms { get; }

        /// <summary>
        /// -Need Update- All The DeTransforms That this store did (The money that Got back to the Capital From this store)
        /// </summary>
        public List<DeTransformModel> GetDeTransforms { get;}

        /// <summary>
        /// -Need Update- All orders done by this store
        /// </summary>
        public List<OrderModel> GetAllOrder { get; }

        /// <summary>
        /// -Need Update- All IncomeOrders Done by this store
        /// </summary>
        public List<IncomeOrderModel> GetIncomeOrder { get; }

        /// <summary>
        /// -Need Update- all the shopBills by this store
        /// </summary>
        public List<ShopBillModel> GetShopBills { get;}

        /// <summary>
        /// -need update- all The StaffSalaries by this store
        /// </summary>
        public List<StaffSalaryModel> GetStaffSalaries { get; }

        /// <summary>
        /// -Need Update- Get the total money exist in the store Now
        /// </summary>
        public decimal GetShopeeWallet { get;}

        #endregion
    }
}
