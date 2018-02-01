using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonManagement.Model.Entry
{
   public class EProduct
    {
       public int product_id { get; set; }
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
    }
}
