using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewerlyShop
{
    public class SalesView
    {
        public int id { get; set; }
        public string Client { get; set; }
        public string Product { get; set; }
        public DateTime Datetime { get; set; }
        public long Price { get; set; }
        public int Count { get; set; }
    }
}
