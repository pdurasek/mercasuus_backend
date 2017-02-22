using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercasuusREST.Models
{
    public class Store
    {
        public int storeID { get; set; }
        public int companyID { get; set; }
        public String username { get; set; }
        public String password { get; set; }
        public String storeAddress { get; set; }
    }

    public class StoreDBContext : DbContext
    {
        public DbSet<Store> Stores { get; set; }
    }
}
