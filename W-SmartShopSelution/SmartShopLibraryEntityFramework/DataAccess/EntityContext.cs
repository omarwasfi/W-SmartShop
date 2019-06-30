using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using HumansModel;


namespace SmartShopLibraryEntityFramework.DataAccess
{
    public class EntityContext : DbContext
    {
        public DbSet<PersonModel> people { get; set; }
    }
}
