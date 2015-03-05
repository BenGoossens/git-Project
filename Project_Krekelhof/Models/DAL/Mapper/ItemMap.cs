using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using Project_Krekelhof.Models.Domain;

namespace Project_Krekelhof.Models.DAL.Mapper
{
    public class ItemMap : EntityTypeConfiguration<Item>
    {
        ////Key
        //    this.HasKey(t => t.CursusId);

        //    //Properties
        //    this.Property(t => t.Titel).HasMaxLength(100);
           
        //    //Inheritance : TPH, and renaming the discriminator
        //    this.Map<OnlineCursus>(m => m.Requires("Type").HasValue("OL"));
        //    this.Map<OnsiteCursus>(m => m.Requires("Type").HasValue("OS"));
        public ItemMap()
        {
             //Key
            this.HasKey(t => t.Id);

            //Properties
            this.Property(t => t.Naam).HasMaxLength(100);

            //Inheritance
            this.Map<Boek>(m => m.Requires("Type").HasValue("Boek"));
            this.Map<Spel>(m => m.Requires("Type").HasValue("Spel"));
            this.Map<Verteltas>(m => m.Requires("Type").HasValue("Verteltas"));
            this.Map<Cd>(m => m.Requires("Type").HasValue("Cd"));
            this.Map<Dvd>(m => m.Requires("Type").HasValue("Dvd"));

        }
       
    }
}