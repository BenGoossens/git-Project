﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Project_Krekelhof.Models.Domain;

namespace Project_Krekelhof.Models.DAL.Mapper
{
    public class BoekMap : EntityTypeConfiguration<Boek>
    {
        public BoekMap()
        {
            //Properties
            this.Property(t => t.Auteur).HasMaxLength(100);
            this.Property(t => t.Uitgeverij).HasMaxLength(100);
            //this.Property(t => t.Isbn).HasMaxLength(13);

            //HasMany(t => t.Categories)
            //    .WithRequired()
            //    .Map(m => m.MapKey("BoekId"))
            //    .WillCascadeOnDelete(false);
            HasRequired(t => t.Categorie)
                .WithMany()
                .Map(m => m.MapKey("CategorieNaam"))
                .WillCascadeOnDelete(false);
        }
    }
}