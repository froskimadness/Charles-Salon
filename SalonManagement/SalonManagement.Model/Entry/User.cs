using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonManagement.Model.Entry
{
    public class User
    {
        public int user_id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string usertype { get; set; }
        public string status { get; set; }
    }
}
