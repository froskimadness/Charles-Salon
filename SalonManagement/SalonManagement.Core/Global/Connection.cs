using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonManagement.Core.Global
{
    public class Connection
    {
        public static string ConnectionString
        {
            get
            {
                //return @"Server = ADMIN-PC\SQLEXPRESS;Database = ManagementSystem;Trusted_Connection = True; ";
                return @"Server = DESKTOP-EXZYVYR\SQLEXPRESS; Database = ManagementSystem; User Id = kuhaku; Password = #pw;";
            }
        }
    }
}
