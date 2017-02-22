using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercasuusREST.Models
{
    public class Product
    {
        public int productID { get; set; }
        public String productName { get; set; }
        public String productDesc { get; set; }
        public int storeID { get; set; }
        public int beaconID { get; set; }
        public int categoryID { get; set; }
    }

    public class ProductDBContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
