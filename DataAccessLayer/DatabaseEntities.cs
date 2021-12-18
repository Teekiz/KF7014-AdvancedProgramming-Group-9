using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    //enable-migrations –EnableAutomaticMigration:$true -force

    public partial class DatabaseEntities : DbContext
    {
        public DatabaseEntities() : base("connection") { }

        public DbSet<Enquiry> Enquiries { get; set; } //Enquiry
        public DbSet<OrderItems> OrderItems { get; set; } //OrderItems
        public DbSet<Customer> Customers { get; set; } //Customer

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
