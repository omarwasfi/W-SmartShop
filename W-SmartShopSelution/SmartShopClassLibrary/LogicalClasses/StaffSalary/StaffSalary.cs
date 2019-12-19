using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class StaffSalary
    {
        /// <summary>
        /// Get all the staffSalaries in the selected month
        /// </summary>
        /// <returns></returns>
        public static List<StaffSalaryModel> FilterStaffSalariesByMonth(List<StaffSalaryModel> staffSalaries,DateTime dateTime)
        {
            return staffSalaries.FindAll(x => x.Date.Year == dateTime.Year && x.Date.Month == dateTime.Month);
        }

        /// <summary>
        /// Calulate total Salary Received at the given month
        /// </summary>
        /// <param name="staffSalaries"></param>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static decimal TotalReceivedByMonth(List<StaffSalaryModel> staffSalaries ,DateTime dateTime)
        {
            List<StaffSalaryModel> fStaffSalary = staffSalaries.FindAll(x => x.Date.Year == dateTime.Year && x.Date.Month == dateTime.Month);

            decimal totalReceivedThisMonth = new decimal();

            foreach (StaffSalaryModel staffSalary in fStaffSalary)
            {
                totalReceivedThisMonth += staffSalary.Salary;
            }
            return totalReceivedThisMonth;
        }

           
}
}
