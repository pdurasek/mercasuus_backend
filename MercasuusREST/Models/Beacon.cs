using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercasuusREST.Models
{
    public class Beacon
    {
        public int beaconID { get; set; }
        public String uuid { get; set; }
        public int major { get; set; }
        public int minor { get; set; }
        public int storeID { get; set; }
    }

    public class BeaconDBContext : DbContext
    {
        public DbSet<Beacon>  Beacons { get; set; }
    }
}
