using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Text.RegularExpressions;

namespace Library
{
    public static class Staff
    {
        /// <summary>
        /// Filter all staff
        /// </summary>
        /// <param name="staff"></param>
        /// <returns></returns>
      public static List<OperationModel> FilterOperationsByStaff(StaffModel staff)
      {
         return PublicVariables.Operations.FindAll(x => x.GetStaff == staff);
      }

        /// <summary>
        /// Get the Staffs whoes works in store
        /// get list of all staffs and store model
        /// return the staffs that works in the store model
        /// </summary>
        /// <param name="staffs"></param>
        /// <param name="store"></param>
        /// <returns></returns>
        public static List<StaffModel> FilterStaffsByStore(List<StaffModel> staffs , StoreModel store)
        {
            List<StaffModel> FStaffs = new List<StaffModel>();
            foreach (StaffModel staff in staffs)
            {
                foreach(StoreModel storeModel in staff.Stores)
                {
                    if(storeModel.Id == store.Id)
                    {
                        FStaffs.Add(staff);
                        break;
                    }
                }
            }
            return FStaffs;
        }
        

        /// <summary>
        /// Filter staffs by person name 
        /// get list of staffs and fullName 
        /// return list of staffs if the personName matches
        /// </summary>
        /// <param name="staffs"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public static List<StaffModel> FilterSatffsByPersonFullName(List<StaffModel> staffs , string fullName)
        {
            List<StaffModel> FStaffs = new List<StaffModel>();
            foreach(StaffModel staff in staffs)
            {
                if (Regex.IsMatch(staff.Person.FullName, Regex.Escape(fullName), RegexOptions.IgnoreCase))
                {
                    FStaffs.Add(staff);
                }
            }
            return FStaffs;
        }

        /// <summary>
        /// Filter staffs by username 
        /// get list of staffs and userName 
        /// return list of staffs if the personName matches
        /// </summary>
        /// <param name="staffs"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public static List<StaffModel> FilterSatffsByUsername(List<StaffModel> staffs, string username)
        {
            List<StaffModel> FStaffs = new List<StaffModel>();
            foreach (StaffModel staff in staffs)
            {
                if (Regex.IsMatch(staff.Username, Regex.Escape(username), RegexOptions.IgnoreCase))
                {
                    FStaffs.Add(staff);
                }
            }
            return FStaffs;
        }


        /// <summary>
        /// Check if the user name unique 
        /// If unique return true
        /// if NOT return false
        /// </summary>
        /// <param name="staffs"></param>
        /// <param name="newUsername"></param>
        /// <returns></returns>
        public static bool CheckIfTheUsernameUnique(List<StaffModel> staffs , string newUsername)
        {
            foreach(StaffModel staff in staffs)
            {
                if(staff.Username == newUsername)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Get All The staff Salaries models 
        /// </summary>
        public static List<StaffSalaryModel> GetStaffSalaries(StaffModel staff)
        {
            return PublicVariables.StaffSalaries.FindAll(x => x.ToStaff == staff);
        }

        /// <summary>
        /// Get how much money the Staff Member should receive this month
        /// </summary>
        public static decimal GetStaffShouldReceiveThisMonth(StaffModel staff)
        {
            decimal totalReceivedThisMonth = new decimal();

            totalReceivedThisMonth += StaffSalary.TotalReceivedByMonth(staff.GetStaffSalaries, DateTime.Now);
            
            if (totalReceivedThisMonth < staff.Salary)
            {
                return staff.Salary - totalReceivedThisMonth;
            }
            else
            {
                return 0;
            }
        }

    }
}
