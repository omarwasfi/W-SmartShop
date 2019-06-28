using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataModels
{
    public class StaffModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public PersonModel Person { get; set; }
        public StoreModel Store { get; set; }
        public List<PermissionModel> Permissions { get; set; }



    }
}
