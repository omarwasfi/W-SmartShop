using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{

    [Serializable]
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
        ///  All the Transforms that this store got ( The Money that the store Got From The Capital)
        /// </summary>
        public List<TransformModel> GetTransforms 
        {
            get
            {
                return Store.GetTransforms(this);
            }
        }
        
        /// <summary>
        /// Get all Transforms Value (all the money that the store recivef from the owners)
        /// </summary>
        public decimal GetTransformsValue
        {
            get
            {
                return Store.GetTransformsValue(this);
            }
        }

        /// <summary>
        /// All The DeTransforms That this store did (The money that Got back to the Capital From this store)
        /// </summary>
        public List<DeTransformModel> GetDeTransforms 
        {
            get
            {
                return Store.GetDeTransforms(this);
            }
        }

        /// <summary>
        /// Get all DeTransforms Value (all the money that the store owners from the store)
        /// </summary>
        public decimal GetDeTransformsValue
        {
            get
            {
                return Store.GetDeTransformsValue(this);
            }
        }

        /// <summary>
        ///  All orders done by this store
        /// </summary>
        public List<OrderModel> GetOrders 
        {
            get
            {
                return Store.GetOrders(this);
            }
        }

        /// <summary>
        ///  All IncomeOrders Done by this store
        /// </summary>
        public List<IncomeOrderModel> GetIncomeOrders 
        {
            get
            {
               return Store.GetIncomeOrders(this);
            } 
        }

        /// <summary>
        /// all the shopBills by this store
        /// </summary>
        public List<ShopBillModel> GetShopBills
        {
            get
            {
                return Store.GetShopBills(this);
            }
        }

        /// <summary>
        ///  all The StaffSalaries by this store
        /// </summary>
        public List<StaffSalaryModel> GetStaffSalaries 
        {
            get
            {
                return Store.GetStaffSalaries(this);
            }
        }

        /// <summary>
        /// Get all the operations of this store
        /// </summary>
        public List<OperationModel> GetOperations 
        {
            get
            {
               return Store.GetOperations(this);
            }
       }

        /// <summary>
        /// Get the total money exist in the store Now
        /// </summary>
        public decimal GetShopeeWallet
        {
            get
            {
                return Store.GetShopeeWallet(this);
            }
        }

        /// <summary>
        /// Get the stocks in this store
        /// </summary>
        public List<StockModel> GetStocks 
        {
            get
            {
                return Store.GetStocks(this);
            }
        }

        /// <summary>
        /// Get all the products that only exist in the store
        /// </summary>
        public List<ProductModel> GetExistProducts
        {
            get
            {
                return Store.GetExistProducts(this);
            }
        }

        /// <summary>
        /// Get all the categories that only exist in the store
        /// </summary>
        public List<CategoryModel> GetExistCategories
        {
            get
            {
                return Store.GetExistCategories(this);
            }
        }

        /// <summary>
        /// Get all the brands that only exist in the store
        /// </summary>
        public List<BrandModel> GetExistBrands
        {
            get
            {
                return Store.GetExistBrands(this);
            }
        }

        /// <summary>
        /// The Stocks IncomeValue in this store
        /// </summary>
        public decimal GetStocksIncomeValue 
        {
            get
            {
                return Store.GetStocksIncomeValue(this);
            }
        }

        /// <summary>
        /// The Stocks SaleValue in this store
        /// </summary>
        public decimal GetStocksSaleValue 
        {
            get
            {
                return Store.GetStocksSaleValue(this);
            }
        }

        /// <summary>
        /// All the paid amount of money in the incomeOrder
        /// </summary>
        public decimal GetTotalPaidIncomeOrdersValue
        {
            get
            {
                return Store.GetTotalPaidIncomeOrdersValue(this);
            }
        }

        /// <summary>
        /// The Total Loans on this store the IncomeOrders that's not fully paid yet(the amount of money not paid)
        /// </summary>
        public decimal GetLoans
        {
            get
            {
                return Store.GetLoans(this);
            }
        }

      

        /// <summary>
        /// Calculate the Total of Paid Order 
        /// </summary>
        public decimal GetTotalPaidOrders
        {
            get
            {
                return Store.GetTotalPaidOrders(this);
            }
        }

        /// <summary>
        /// The Total Not paid orders value (the amount of money not paid)
        /// </summary>
        public decimal GetNotPaidOrdersValue
        {
            get
            {
                return Store.GetNotPaidOrdersValue(this);
            }
        }

        #endregion
    } 
}
