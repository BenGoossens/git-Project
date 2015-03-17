using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using System.Web;
using MySql.Data.Entity;
using Project_Krekelhof.Models.DAL.Mapper;
using Project_Krekelhof.Models.Domain;

namespace Project_Krekelhof.Models.DAL
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class KrekelschoolContext : DbContext
    {
        public KrekelschoolContext() : base("krekelschool")
        {
            
        }
        //public KrekelschoolContext(string connStringName) : base(connStringName) { }
        public DbSet<Item> Items { get; set; }
        public DbSet<Boek> Boeken { get; set; }
        public DbSet<Dvd> Dvds { get; set; }
        public DbSet<Leerling> Leerlingen { get; set; }
        public DbSet<Uitlening> Uitleningen { get; set; }
        public DbSet<Categorie> Categorieen { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //modelBuilder.Configurations.Add(new BoekMap());
            //modelBuilder.Configurations.Add(new CategorieMap());
            //modelBuilder.Configurations.Add(new DvdMap());
            //modelBuilder.Configurations.Add(new ItemMap());
            //modelBuilder.Configurations.Add(new UitleningMap());
            //modelBuilder.Configurations.Add(new VerteltasMap());


            //base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
            //modelBuilder.Ignore<Item>();
            base.OnModelCreating(modelBuilder);
        }
    }
}