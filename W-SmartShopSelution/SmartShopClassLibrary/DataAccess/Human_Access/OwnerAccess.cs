using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class OwnerAccess
    {
        /// <summary>
        /// Get all Owners From the database Without set the personModel  , InvesmentModels , RevenuesModels
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<OwnerModel> GetOwnersFromTheDatabae(string db)
        {
            List<OwnerModel> owners = new List<OwnerModel>();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                owners = connection.Query<OwnerModel>("dbo.spOwner_GetAll").ToList();
            }

            foreach (OwnerModel owner in owners)
            {
                owner.Person = new PersonModel();
                owner.Investments = new List<InvestmentModel>();
                owner.Revenues = new List<RevenueModel>();
            }
            return owners;
        }

        /// <summary>
        /// Match the personModels with Each Owner From the database
        /// </summary>
        /// <param name="owners"></param>
        /// <param name="people"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<OwnerModel> SetThePersonModelForEachOwnerFromTheDatabase(List<OwnerModel>owners,List<PersonModel> people, string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                foreach (OwnerModel owner in owners)
                {
                    var p = new DynamicParameters();
                    p.Add("@OwnerId", owner.Id);
                    owner.Person.Id = connection.QuerySingle<int>("spOwner_GetPersonIdByOwnerId", p, commandType: CommandType.StoredProcedure);
                }
            }

            foreach (OwnerModel ownerModel in owners)
            {
                ownerModel.Person = people.Find(x => x.Id == ownerModel.Person.Id);
            }

            return owners;
        }

        /// <summary>
        /// Match the investments with Each Owner From the database
        /// </summary>
        /// <param name="owners"></param>
        /// <param name="investments"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<OwnerModel> SetTheInvestmentsForEachOwnerFromTheDatabase(List<OwnerModel>owners,List<InvestmentModel>investments,string db)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                foreach (OwnerModel owner in owners)
                {
                    List<int> investmentsIds = new List<int>();

                    var p = new DynamicParameters();
                    p.Add("@OwnerId", owner.Id);

                    investmentsIds = connection.Query<int>("dbo.spOwner_GetInstallmentIdByOwnerId", p, commandType: CommandType.StoredProcedure).ToList();

                    foreach (int id in investmentsIds)
                    {
                        owner.Investments.Add(new InvestmentModel { Id = id });
                    }

                }

            }

            foreach (OwnerModel ownerModel in owners)
            {
                List<int> investmentIds = new List<int>();
                foreach (InvestmentModel investmentModel in ownerModel.Investments)
                {
                    investmentIds.Add(investmentModel.Id);
                }

                ownerModel.Investments = new List<InvestmentModel>();

                foreach (int id in investmentIds)
                {
                    ownerModel.Investments.Add(investments.Find(x => x.Id == id));
                }

            }

            return owners;
        }

        /// <summary>
        /// Match the revenues with Each Owner From the database
        /// </summary>
        /// <param name="owners"></param>
        /// <param name="revenues"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<OwnerModel> SetTheRevenuesForEachOwnerFromTheDatabase(List<OwnerModel> owners, List<RevenueModel>revenues, string db)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                foreach (OwnerModel owner in owners)
                {
                    List<int> revenuesIds = new List<int>();

                    var p = new DynamicParameters();
                    p.Add("@OwnerId", owner.Id);

                    revenuesIds = connection.Query<int>("dbo.spOwner_GetRevenueIdByOwner", p, commandType: CommandType.StoredProcedure).ToList();

                    foreach (int id in revenuesIds)
                    {
                        owner.Revenues.Add(new RevenueModel { Id = id });
                    }

                }

            }

            foreach (OwnerModel ownerModel in owners)
            {
                List<int> revenuesIds = new List<int>();
                foreach (RevenueModel revenue in ownerModel.Revenues)
                {
                    revenuesIds.Add(revenue.Id);
                }

                ownerModel.Revenues = new List<RevenueModel>();

                foreach (int id in revenuesIds)
                {
                    ownerModel.Revenues.Add(revenues.Find(x => x.Id == id));
                }

            }

            return owners;
        }
    }
}
 