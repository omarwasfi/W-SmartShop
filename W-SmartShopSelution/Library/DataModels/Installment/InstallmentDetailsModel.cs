using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataModels.Installment
{
    public class InstallmentDetailsModel
    {
        public int Id { get; set; }

        public List<DateTime> DueToPay { get; set; }

        public List<DateTime> PaymentDate { get; set; }
    }
}
