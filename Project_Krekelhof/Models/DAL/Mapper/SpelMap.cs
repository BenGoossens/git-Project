using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Project_Krekelhof.Models.Domain;

namespace Project_Krekelhof.Models.DAL.Mapper
{
    public class SpelMap : EntityTypeConfiguration<Spel>
    {
        public SpelMap()
        {
            HasRequired(t => t.Categorie)
                .WithMany()
                .Map(m => m.MapKey("SpelCategorie"))
                .WillCascadeOnDelete(false);
        }
    }
}