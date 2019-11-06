using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;

namespace Library
{
    public static class Store
    {

      
        /// <summary>
        /// Check if this store exist in the list of the stores By Name
        /// </summary>
        /// <param name="store"></param>
        /// <param name="stores"></param>
        /// <returns></returns>
        public static bool IsThisStoreExist(StoreModel store , List<StoreModel> stores)
        {
            foreach(StoreModel s in stores)
            {
                if(store.Name
                    == s.Name)
                {
                    store.Id = s.Id;
                    store.PhoneNumber = s.PhoneNumber;
                    store.Address = s.Address;
                    store.City = s.City;
                    store.Country = s.Country;
                    return true;
                }
            }
            return false;
        }

        
    }
}
