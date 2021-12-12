using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedProgrammingGroup9
{
    //enable-migrations –EnableAutomaticMigration:$true -force

    public partial class DatabaseEntities : DbContext
    {
        public DatabaseEntities() : base("connection") { }

        public DbSet<Enquiry> Enquiry { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
