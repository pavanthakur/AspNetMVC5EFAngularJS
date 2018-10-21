using EH.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EH.DAL.Context
{
    public class ApplicationDbContext : DbContext
    {
        System.Data.Entity.Migrations.DbMigrationsConfiguration dbmigration = new System.Data.Entity.Migrations.DbMigrationsConfiguration();

        public ApplicationDbContext() : base("ApplicationDbConnection")
        {
            SetConfigurationOptions();
        }

        private void SetConfigurationOptions()
        {
            dbmigration.AutomaticMigrationsEnabled = false;
            Configuration.AutoDetectChangesEnabled = true;
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false; //change tracking 
        }

        public DbSet<Contact> Contact { get; set; }
        public DbSet<Status> Status { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ForeignKeyIndexConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
