using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonManagement.Model.Entry
{
   public class EService
    {
        public int serviceid { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Status { get; set; }
            
        public int qty { get; set; }

        public string employee { get; set; }
    }
}
