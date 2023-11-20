using Microsoft.EntityFrameworkCore;
using PayCore.DAL.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PayCore.DAL.ORM.Context
{
    public class PayCoreContext : DbContext
    {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-EET2RGT;Database=PayCoreECommerce;trusted_connection=true");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<WebUser> WebUsers { get; set; }
    }
}
