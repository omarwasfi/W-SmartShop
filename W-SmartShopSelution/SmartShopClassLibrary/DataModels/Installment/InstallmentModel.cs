using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class InstallmentModel
    {
        public int Id { get; set; }

        public CustomerModel Customer { get; set; }

        public DateTime DateTime { get; set; }

        public StoreModel Store { get; set; }

        public StaffModel Staff { get; set; }

        public List<InstallmentProductModel> Products { get; set; }

        public InstallmentDetailsModel InstallmentDetails { get; set; }
    }
}
