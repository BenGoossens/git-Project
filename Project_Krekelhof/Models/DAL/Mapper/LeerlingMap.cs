using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Project_Krekelhof.Models.Domain;

namespace Project_Krekelhof.Models.DAL.Mapper
{
    public class LeerlingMap : EntityTypeConfiguration<Leerling>
    {
        public LeerlingMap()
        {
            this.ToTable("Leerlingen");


            this.HasKey(l => l.Id);

            //HasMany(l => l.Uitleningen)
            //    .WithRequired()
            //    .Map(m => m.MapKey("Uitlening"))
            //    .WillCascadeOnDelete(false);
        }
    }
}