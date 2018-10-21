using EH.DAL.Context;
using EH.Entity;
using System;
using System.Data.Entity.Migrations;
using System.Linq;

namespace EH.DAL.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        /*  Migration Command
         *  -------------------------
         *  Add-Migration -configuration EH.DAL.Migrations.Configuration InitDB
         *  Update-Database -configuration EH.DAL.Migrations.Configuration -Verbose
         * 
         */
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            try
            {
                if (!context.Status.Any(r => r.Type == "Active"))
                {
                    var objStatus = new Status { Type = "Active" };
                    context.Status.Add(objStatus);
                }

                if (!context.Status.Any(r => r.Type == "Inactive"))
                {
                    var objStatus = new Status { Type = "Inactive" };
                    context.Status.Add(objStatus);
                }

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(string.Format("The database could not be initialized at Seed method"), ex);
            }
        }
        
    }
}
