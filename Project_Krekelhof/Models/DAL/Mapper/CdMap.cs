using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using Project_Krekelhof.Models.Domain;

namespace Project_Krekelhof.Models.DAL.Mapper
{
    public class CdMap : EntityTypeConfiguration<Cd>
    {
        public CdMap()
        {
            this.Property(c => c.ArtiestNaam).IsRequired().HasMaxLength(50);

            HasRequired(t => t.Categorie)
                .WithMany()
                .Map(m => m.MapKey("CdCategorie"))
                .WillCascadeOnDelete(false);
        }
    }
}