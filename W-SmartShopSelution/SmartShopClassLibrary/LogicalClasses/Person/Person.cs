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

    }
}
