using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class Person
    {
        /// <summary>
        /// Get person model 
        /// Add to the person table in the database 
        /// Get the Id of this Person
        /// </summary>
        public static PersonModel CreatePerson(PersonModel person , string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {

               var p = new DynamicParameters();
                p.Add("@FirstName", person.FirstName);
                if (!string.IsNullOrWhiteSpace(person.LastName))
                {
                    p.Add("@LastName", person.LastName);
                }
                else
                {
                    p.Add("@LastName", null);
                }
                if (!string.IsNullOrWhiteSpace(person.PhoneNumber))
                {
                    p.Add("@PhoneNumber", person.PhoneNumber);
                }
                else
                {
                    p.Add("@PhoneNumber", null);
                    
                }
                if (!string.IsNullOrWhiteSpace(person.NationalNumber))
                {
                    p.Add("@NationalNumber", person.NationalNumber);
                }
                else
                {
                    p.Add("@NationalNumber", null);

                }
                if (!string.IsNullOrWhiteSpace(person.Email))
                {
                    p.Add("@Email", person.Email);
                }
                else
                {
                    p.Add("@Email", null);

                }
                if (!string.IsNullOrWhiteSpace(person.Address))
                {
                    p.Add("@Address", person.Address);
                }
                else
                {
                   p.Add("@Address", null);

                }
                if (!string.IsNullOrWhiteSpace(person.City))
                {
                    p.Add("@City", person.City);
                }
                else
                {
                    p.Add("@City", null);

                }
                if (!string.IsNullOrWhiteSpace(person.Country))
                {
                    p.Add("@Country", person.Country);
                }
                else
                {
                   p.Add("@Country", null);

                }
                p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spPerson_CreatePerson", p, commandType: CommandType.StoredProcedure);
                person.Id = p.Get<int>("@Id");
            }
            return person;
        }

        /// <summary>
        /// Get all people from the database
        /// </summary>
        /// <returns> list of person model </returns>
        public static List<PersonModel> GetAllPeople(string db)
        {
            List<PersonModel> people = new List<PersonModel>();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                people = connection.Query<PersonModel>("spPerson_GetAll").ToList();
            }

            return people;
        }

        /// <summary>
        /// Used when adding new person to the database 
        /// check if this person in the database With the NationalNumber ONLY
        /// </summary>
        /// <returns> true OR false </returns>
        public static bool IsThisPersonInTheDataBase(PersonModel person,List<PersonModel> people) 
        {
            foreach(PersonModel p in people)
            {
                if(!String.IsNullOrWhiteSpace(p.NationalNumber) && !String.IsNullOrWhiteSpace(person.NationalNumber))
                {
                    if (person.NationalNumber == p.NationalNumber)
                    {
                        return true;
                    }
                }
                
            }

            return false;
        }

        /// <summary>
        /// Check if the national number used before If It is return false
        /// If it is unique OR null Or White space return true
        /// </summary>
        /// <param name="people"></param>
        /// <param name="nationalNumber"></param>
        /// <returns></returns>
        public static bool CheckIfTheNationalNumberUnique(List<PersonModel> people , string nationalNumber)
        {
            if (String.IsNullOrWhiteSpace(nationalNumber))
            {
                return true;
            }

            foreach(PersonModel person in people)
            {
                if(person.NationalNumber == nationalNumber)
                {
                    return false;
                }
            }
            return true;

        }

        /// <summary>
        /// Update person data with the database
        /// </summary>
        /// <param name="person"></param>
        /// <param name="db"></param>
        public static void UpdatePersonData(PersonModel person, string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {

                var p = new DynamicParameters();
                p.Add("@Id", person.Id);
                p.Add("@FirstName", person.FirstName);
                if (!string.IsNullOrWhiteSpace(person.LastName))
                {
                    p.Add("@LastName", person.LastName);
                }
                else
                {
                    p.Add("@LastName", null);
                }
                if (!string.IsNullOrWhiteSpace(person.PhoneNumber))
                {
                    p.Add("@PhoneNumber", person.PhoneNumber);
                }
                else
                {
                    p.Add("@PhoneNumber", null);

                }
                if (!string.IsNullOrWhiteSpace(person.NationalNumber))
                {
                    p.Add("@NationalNumber", person.NationalNumber);
                }
                else
                {
                    p.Add("@NationalNumber", null);

                }
                if (!string.IsNullOrWhiteSpace(person.Email))
                {
                    p.Add("@Email", person.Email);
                }
                else
                {
                    p.Add("@Email", null);

                }
                if (!string.IsNullOrWhiteSpace(person.Address))
                {
                    p.Add("@Address", person.Address);
                }
                else
                {
                    p.Add("@Address", null);

                }
                if (!string.IsNullOrWhiteSpace(person.City))
                {
                    p.Add("@City", person.City);
                }
                else
                {
                    p.Add("@City", null);

                }
                if (!string.IsNullOrWhiteSpace(person.Country))
                {
                    p.Add("@Country", person.Country);
                }
                else
                {
                    p.Add("@Country", null);

                }
                connection.Execute("dbo.spPerson_Update", p, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
