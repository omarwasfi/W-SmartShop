using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class PersonAccess
    {

        /// <summary>
        /// Get all people from the database
        /// </summary>
        /// <returns> list of person model </returns>
        public static List<PersonModel> GetPeopleFromTheDatabase(string db)
        {
            List<PersonModel> people = new List<PersonModel>();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                people = connection.Query<PersonModel>("spPerson_GetAll").ToList();
            }

            return people;
        }


        /// <summary>
        /// Get person model 
        /// Add to the person table in the database 
        /// Get the Id of this Person
        /// </summary>
        public static PersonModel AddPersonToTheDatabase(PersonModel person, string db)
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

                p.Add("@BirthDate",person.BirthDate);

                if (!string.IsNullOrWhiteSpace(person.JopTitle))
                {
                    p.Add("@JopTitle", person.JopTitle);
                }
                else
                {
                    p.Add("@JopTitle", null);
                }

                if (!string.IsNullOrWhiteSpace(person.JopAddress))
                {
                    p.Add("@JopAddress", person.JopAddress);
                }
                else
                {
                    p.Add("@JopAddress", null);
                }

                p.Add("@GradutionDate", person.GraduationDate);


                if (!string.IsNullOrWhiteSpace(person.Qualification))
                {
                    p.Add("@Qualification", person.Qualification);
                }
                else
                {
                    p.Add("@Qualification", null);
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
                if (!string.IsNullOrWhiteSpace(person.Details))
                {
                    p.Add("@Details", person.Details);
                }
                else
                {
                    p.Add("@Details", null);

                }
                p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spPerson_CreatePerson", p, commandType: CommandType.StoredProcedure);
                person.Id = p.Get<int>("@Id");
            }
            return person;
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
                if (!string.IsNullOrWhiteSpace(person.Details))
                {
                    p.Add("@Details", person.Details);
                }
                else
                {
                    p.Add("@Details", null);

                }
                connection.Execute("dbo.spPerson_Update", p, commandType: CommandType.StoredProcedure);
            }
        }


    }
}
