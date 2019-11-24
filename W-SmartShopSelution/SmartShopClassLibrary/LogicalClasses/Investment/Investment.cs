using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Library
{
    public static class Investment
    {
        public static OwnerModel GetTheOwner(InvestmentModel investment)
        {
            InvestmentModel investmentModel;

            foreach(OwnerModel ownerModel in PublicVariables.Owners)
            {
                investmentModel = ownerModel.Investments.Find(x => x == investment);
                if(investmentModel != null)
                {
                    return ownerModel;
                }
            }

            return null;

        }
    }
}
