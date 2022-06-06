using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewerlyShop
{
     public class ProductView
    {
        public int id { get; set; }
        public string Provider { get; set; }
        public string TypeProducts { get; set; }
        public string Material { get; set; }
        public string Name { get; set; }
        public decimal Weight  { get; set; }
        public int Proba { get; set; }
        public long PurchasePrice { get; set; }
        public long Price { get; set; }
        public string ImageProduct { get; set; }
        public decimal Size { get; set; }
        public int Volume { get; set; }
    }
}
