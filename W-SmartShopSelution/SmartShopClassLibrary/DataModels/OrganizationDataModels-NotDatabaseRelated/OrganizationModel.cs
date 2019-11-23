using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class OrganizationModel
    {
        /// <summary>
        /// The Organization Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The Orgnization Address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// The Organization PhoneNumber
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// All the Investments that the owners Made
        /// </summary>
        public List<InvestmentModel> Investments { set; get; }

        /// <summary>
        /// All the Revenues that the Owners Made
        /// </summary>
        public List<RevenueModel> Revenues { get; set; }

        /// <summary>
        /// Get all the stores Of this Orgnization
        /// </summary>
        public List<StoreModel> GetStores { get { return PublicVariables.Stores; } }


        public List<StaffModel> GetStaffs { get { return PublicVariables.Staffs; } }

        /// <summary>
        /// Get Owners
        /// </summary>
        public List<OwnerModel> GetOwners { get { return PublicVariables.Owners; }  }


        /// <summary>
        /// Get the FreeMoney that is not in any store
        /// </summary>
        public decimal GetFreeMoney 
        { 
            get
            {
                return Organization.GetFreeMoney(this);
            }
        }

        /// <summary>
        /// All the Loans of the Organization
        /// </summary>
        public decimal GetLoans 
        {
            get
            {
                return Organization.GetLoans(this);
            }
        }

        /// <summary>
        /// All Not Pain orders Value of the Organzation
        /// </summary>
        public decimal GetNotPaidOrdersValue 
        { 
            get
            { 
                return Organization.GetNotPaidOrderValue(this);
            } 
        }
        /// <summary>
        /// The Value of the stocks as cash (the total IncomePrice Of All Stocks)
        /// </summary>
        public decimal GetStockValue 
        {
            get
            {
               return Organization.GetStockValue(this);
            }
        }

        /// <summary>
        /// All the shopeeWalletValue (the total ShopeeWallet of all stores)
        /// </summary>
        public decimal GetShopeeWalletValue 
        {
            get
            {
                return Organization.GetShopeeWalletValue(this);
            }
        }


        /// <summary>
        /// Return The calculation of over all capital (FreeMoney + Stocks Value + ShopeeWallet Value)
        /// </summary>
        public decimal GetCapital { get;}
    }
}
