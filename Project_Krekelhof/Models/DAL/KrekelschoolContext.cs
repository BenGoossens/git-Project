using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using System.Web;
using Project_Krekelhof.Models.Domain;

namespace Project_Krekelhof.Models.DAL
{
    public class KrekelschoolContext : DbContext
    {
        public KrekelschoolContext() : base("krekelschool")
        {
            
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Leerling> Leerlingen { get; set; }
        public DbSet<Uitlening> Uitleningen { get; set; }
        public DbSet<Categorie> Categorieen { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}