using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Project_Krekelhof.Models.DAL
{
    public class KrekelschoolContext : DbContext
    {
        public KrekelschoolContext() : base("krekelschool")
        {
            
        }

        public DbSet<IItem> items { get; set; }
        public DbSet<Leerling> leerlingen { get; set; }
        public DbSet<Uitlening> uitleningen { get; set; }
        public DbSet<Categorie> categorieen { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}