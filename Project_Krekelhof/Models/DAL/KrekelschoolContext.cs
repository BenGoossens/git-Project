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
    public class KrekelschoolContext : DbContext
    {
        public KrekelschoolContext() : base("krekelschool")
        {
            
        }
        //public KrekelschoolContext(string connStringName) : base(connStringName) { }

        public virtual DbSet<Boek> Boeken { get; set; }
        public virtual DbSet<Dvd> Dvds { get; set; }
        public virtual DbSet<Cd> Cds { get; set; }
        public virtual DbSet<Spel> Spellen { get; set; }
        public virtual DbSet<Verteltas> Verteltassen { get; set; }

        public virtual DbSet<Leerling> Leerlingen { get; set; }
        public virtual DbSet<Uitlening> Uitleningen { get; set; }
        public virtual DbSet<Categorie> Categorieen { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
            //modelBuilder.Ignore<Item>();
            modelBuilder.Configurations.Add(new BoekMap());
            modelBuilder.Configurations.Add(new CategorieMap());
            modelBuilder.Configurations.Add(new DvdMap());
            modelBuilder.Configurations.Add(new ItemMap());
            modelBuilder.Configurations.Add(new VerteltasMap());
            modelBuilder.Configurations.Add(new UitleningMap());
            modelBuilder.Configurations.Add(new LeerlingMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}