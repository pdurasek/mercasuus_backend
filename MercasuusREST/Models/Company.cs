using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercasuusREST.Models
{
    public class Company
    {
        public int companyID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string companyName { get; set; }
        public string contactMail { get; set; }
        public string contactNumber { get; set; }
        public string companyLogo { get; set; }
    }

    public class CompanyDBContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
    }
}
