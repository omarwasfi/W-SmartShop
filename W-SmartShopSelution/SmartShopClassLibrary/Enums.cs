﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{

    /// <summary>
    /// Store Names 
    /// Fill Manuly 
    /// StoreNames is unique in the storetabele
    /// </summary>
    public enum StoreName
    {
      EMG
    }

    public enum OperationType
    {
        Transform,
        DeTransform,
        OrderPayment,
        IncomeOrderPayment,
        ShopBill,
        StaffSalary
        
    }
}
