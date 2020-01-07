using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class Organization
    {

        /// <summary>
        /// Calculate investments - revenus + all stores transforms - all stores detransforms
        /// Add the 
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        public static decimal GetFreeMoney(OrganizationModel organization)
        {
            decimal freeMoney = new decimal();
            foreach (InvestmentModel investment in organization.Investments) 
            {
                freeMoney += investment.TotalMoney;
            }
            foreach (RevenueModel revenue in organization.Revenues)
            {
                freeMoney -= revenue.TotalMoney;
            }
            foreach (StoreModel store in organization.GetStores)
            {
                freeMoney -= store.GetTransformsValue;
            }
            foreach (StoreModel store in organization.GetStores)
            {
                freeMoney += store.GetDeTransformsValue;
            }
            return freeMoney;
        }

        /// <summary>
        /// Get all not paid orders value in all stores
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        public static decimal GetNotPaidOrderValue(OrganizationModel organization)
        {
            decimal totalNotPaid = new decimal();
            foreach(StoreModel store in organization.GetStores)
            {
                totalNotPaid += store.GetNotPaidOrdersValue;
            }
            return totalNotPaid;
        }

        /// <summary>
        /// Get the number of the orders happend in the organization(the count of orders of all stores)
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        public static int GetOrderCount(OrganizationModel organization)
        {
            int ordersCount = new int();
            foreach(StoreModel store in organization.GetStores)
            {
                ordersCount += store.GetOrdersCount;
            }
            return ordersCount;
        }

        public static decimal GetLoans(OrganizationModel organization)
        {
            decimal totalLoans = new decimal();
            foreach (StoreModel store in organization.GetStores)
            {
                totalLoans += store.GetLoans;
            }
            return totalLoans;
        }

        public static decimal GetStockValue(OrganizationModel organization)
        {
            decimal stockValue = new decimal();

            foreach(StoreModel store in organization.GetStores)
            {
                stockValue += store.GetStocksIncomeValue;
            }

            return stockValue;
        }

        public static decimal GetShopeeWalletValue(OrganizationModel organization)
        {
            decimal shopeeWallet = new decimal();

            foreach (StoreModel store in organization.GetStores)
            {
                shopeeWallet += store.GetShopeeWallet;
            }

            return shopeeWallet;
        }
        public static decimal GetCapital(OrganizationModel organization)
        {
            decimal capital = new decimal();

            capital = organization.GetFreeMoney  + organization.GetStockValue + organization.GetShopeeWalletValue - organization.GetLoans + organization.GetNotPaidOrdersValue;

            return capital;
        }

        public static List<PersonModel> GetPeopleNotSuppliers(OrganizationModel organization)
        {
            return PublicVariables.People.FindAll(x => x.GetAsASupplier == null);
        }
    }
}
