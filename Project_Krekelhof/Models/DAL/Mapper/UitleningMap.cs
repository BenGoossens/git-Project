using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Project_Krekelhof.Models.Domain;

namespace Project_Krekelhof.Models.DAL.Mapper
{
    public class UitleningMap : EntityTypeConfiguration<Uitlening>
    {
        public UitleningMap()
        {
            //Key
            this.HasKey(t => t.Id);

            //Properties
            
            //Relationships
            //this.HasOptional(t => t.Item)
            //    .WithMany()
            //    .Map(m => m.MapKey("Item"))
            //    .WillCascadeOnDelete(false);
            this.HasRequired(t => t.Item)
                .WithOptional()
                .Map(m => m.MapKey("Item"))
                .WillCascadeOnDelete(false);
            //this.HasOptional(t => t.Leerling)
            //    .WithMany()
            //    .Map(m => m.MapKey("Leerling"))
            //    .WillCascadeOnDelete(false);
            this.HasRequired(t => t.Leerling)
                .WithMany()
                .Map(m => m.MapKey("Leerling"))
                .WillCascadeOnDelete(false);
        }
    }
}