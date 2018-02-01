using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonManagement.Model.Binder
{
   public class ViewEmployee
    {
        public int employee_id { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public string Status { get; set; }
    }
}
