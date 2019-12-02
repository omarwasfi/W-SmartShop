using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    /// <summary>
    /// this model is Created to hold the incomeOrder Data while the incomeOrder Operation
    /// 
    /// </summary>
    public class IncomeOrderProductRecordModel
    {
        public IncomeOrderProductModel IncomeOrderProduct { get; set; }

        public StockModel Stock { get; set; }
    }
}
