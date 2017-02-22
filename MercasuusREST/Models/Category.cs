using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercasuusREST.Models
{
    public class Category
    {
        public int categoryID { get; set; }
        public String categoryName { get; set; }
        public String categoryDesc { get; set; }
    }

    public class CategoryDBContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
    }
}
