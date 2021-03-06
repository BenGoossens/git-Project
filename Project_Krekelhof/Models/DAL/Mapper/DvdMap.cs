﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Project_Krekelhof.Models.Domain;

namespace Project_Krekelhof.Models.DAL.Mapper
{
    public class DvdMap : EntityTypeConfiguration<Dvd>
    {
        public DvdMap()
        {
            //Properties
            this.Property(t => t.Regisseur).HasMaxLength(100);

            HasRequired(t => t.Categorie)
                .WithMany()
                .Map(m => m.MapKey("DvdCategorie"))
                .WillCascadeOnDelete(false);
        }
    }
}