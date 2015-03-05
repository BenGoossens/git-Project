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
            this.HasOptional(t => t.Items)
                .WithMany()
                .Map(m => m.MapKey("Item"))
                .WillCascadeOnDelete(false);
        }
    }
}