﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    [Serializable]
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
        /// The permission That the staff member can have
        /// the permission model identify the forms(UC) that the customer can use 
        /// </summary>
        public PermissionModel Permission { get; set; }

        /// <summary>
        /// The Salary Of the staff Member
        /// </summary>
        public decimal Salary { get; set; }



        #region non database related

        /// <summary>
        /// Get all the orders that this staff did
        /// </summary>
        public List<OrderModel> GetOrders
        {
            get
            {
              return  Staff.GetOrders(this);
            }
        }

        /// <summary>
        /// Get All The staff Salaries models 
        /// </summary>
        public List<StaffSalaryModel> GetStaffSalaries 
        {
            get
            {
                return Staff.GetStaffSalaries(this);
            }
                
        }

        /// <summary>
        /// Get how much money the Staff Member should receive this month
        /// </summary>
        public decimal GetStaffShouldReceiveThisMonth 
        {
            get
            {
              return  Staff.GetStaffShouldReceiveThisMonth(this);
            }
        }


        /// <summary>
        /// Get all stores names in one string subrate with space
        /// </summary>
        public string AllStores
        {
            get
            {
                string allStores = "";
                foreach(StoreModel store in Stores)
                {
                    allStores += " ";
                    allStores += store.Name ;
                }
                return allStores;
                
            }
        }

        /// <summary>
        /// Get all Avalible permissions Name in one string with space and ','
        /// </summary>
        public string AllTruePermissions
        {
            get
            {
                string allTruePermissions = "";

                if (Permission.CanSellUC)
                {
                    allTruePermissions += " ";
                    allTruePermissions += "Selling";
                }
                if (Permission.CanInventoryUC)
                {
                    allTruePermissions += " ,";
                    allTruePermissions += "Inventory";
                }
                if (Permission.CanProductManagerUC)
                {
                    allTruePermissions += " ,";
                    allTruePermissions += "Prodcut Manager";
                }
                if (Permission.CanStaffsManagerUC)
                {
                    allTruePermissions += " ,";
                    allTruePermissions += "Staffs Manager";
                }

                return allTruePermissions;
            }
        }

        /// <summary>
        /// Get all the operations that this staff did
        /// </summary>
        public List<OperationModel> GetOperations 
        {
            get
            {
                return Staff.FilterOperationsByStaff(this);
            }
        }

        #endregion
    }
}
