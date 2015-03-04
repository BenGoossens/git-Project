using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Project_Krekelhof.Models.Domain;

namespace Project_Krekelhof.Models.DAL.Mapper
{
    public class VerteltasMap : EntityTypeConfiguration<Verteltas>
    {
        public VerteltasMap()
        {
            //Properties
            this.Property(t => t.BeschrijvingItems).IsRequired().HasMaxLength(150);
        }
    }
}