using System;
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
            //this.Property(t => t.Regiseur).HasMaxLength(100);
        }
    }
}