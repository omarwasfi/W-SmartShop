using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class Revenue
    {
        public static OwnerModel GetTheOwner(RevenueModel revenue)
        {
            RevenueModel revenueModel;

            foreach (OwnerModel ownerModel in PublicVariables.Owners)
            {
                revenueModel = ownerModel.Revenues.Find(x => x == revenue);
                if (revenueModel != null)
                {
                    return ownerModel;
                }
            }

            return null;

        }
    }
}
