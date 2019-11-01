using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    /// <summary>
    /// Permisson model hold the permission that the user has .
    /// each permission is boolen value for a UC , says if the user can open or not.
    /// Edit spStaff_GetPermissionByStaffId Store procedure and permission table  each time adding new permission 
    /// </summary>
    public class PermissionModel
    {
        public int Id { get; set; }

        /// <summary>
        /// Name of the permission
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Boolean value says if the user can Open SellUC or not
        /// </summary>
        public Boolean CanSellUC { get; set; }

        /// <summary>
        /// Boolean value says if the user can Open InventoryUC or not
        /// </summary>
        public Boolean CanInventoryUC { get; set; }


        // TODO - Add this option in the database
        /// <summary>
        /// Boolean value says if the user can open the GlobalInventoryUC
        /// </summary>
        public Boolean CanGlobalInventory { get; set; }

        /// <summary>
        /// Boolean value says if the user can Open ProductManager or not
        /// </summary>
        public Boolean CanProductManagerUC { get; set; }

        /// <summary>
        /// Boolean value says if the user can Open StaffsManagerUC or not
        /// </summary>
        public Boolean CanStaffsManagerUC { get; set; }

        // TODO - Add this option in the database
        /// <summary>
        /// Boolean value says if the user can open the CanIncomeOrderUC
        /// </summary>
        public Boolean CanIncomeOrderUC { get; set; }

        // TODO - Add this option in the database
        /// <summary>
        /// Boolean value says if the user can open the CanInstallmentOrderUC
        /// </summary>
        public Boolean CanInstallmentOrderUC { get; set; }

        // TODO - Add this option in the database
        /// <summary>
        /// Boolean value says if the user can open the CanInstallmentOrderUC
        /// </summary>
        public Boolean CanSellingOrdersManagerUC { get; set; }

        // TODO - Add this option in the database
        /// <summary>
        /// Boolean value says if the user can open the CanInstallmentOrderUC
        /// </summary>
        public Boolean CanCashFlowUC { get; set; }

        // TODO - Add this option in the database
        /// <summary>
        /// Boolean value says if the user can open the CanBillManagerUC
        /// </summary>
        public Boolean CanBillManagerUC { get; set; }


        // TODO - Add this option in the database
        /// <summary>
        /// Boolean value says if the user can open the CanPriceListUC
        /// </summary>
        public Boolean CanPriceListUC { get; set; }


    }
}
