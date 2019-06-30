using HumansModel;
using SmartShopLibraryEntityFramework.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShopLibraryEntityFramework
{

        class Program
        {
            static void Main(string[] args)
            {

                using (var ctx = new EntityContext())
                {
                    var person = new PersonModel() { FirstName = "Bill" };

                    ctx.people.Add(person);
                    ctx.SaveChanges();
                }
            }
        }
    
}
