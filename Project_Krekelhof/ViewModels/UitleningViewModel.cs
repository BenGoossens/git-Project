using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project_Krekelhof.Models.Domain;

namespace Project_Krekelhof.ViewModels
{
    public class UitleningViewModel
    {
        //public UitleningViewModel()
        //{
            
        //}
        public UitleningViewModel(Uitlening u)
        {
            Id = u.Id;
            //EindeUitlening = u.EindeUitlening;
            IsTerug = u.IsTerug;
            //Postcode = (b.Gemeente == null) ? null : b.Gemeente.Postcode;
            Naam = (u.Item == null) ? null : u.Item.Naam;
           // StartUitlening = u.StartUitlening;
            
            
        }
        public int Id { get;  set; }
        public DateTime EindeUitlening { get;  set; }

        public DateTime StartUitlening { get;  set; }

        public  bool IsTerug {get;set;}
        
        public  string Naam {get;set;}       

    }

    public class UitleningIndexViewModel
    {
        public UitleningIndexViewModel(Uitlening u)
        {
            Id = u.Id;
            //EindeUitlening = u.EindeUitlening;
            IsTerug = u.IsTerug;
            if (u.Item != null)
            {
                Naam = u.Item.Naam;
            }
            //StartUitlening = u.StartUitlening;


        }
        public int Id { get; set; }
        public DateTime EindeUitlening { get; set; }

        public DateTime StartUitlening { get; set; }

        public bool IsTerug { get; set; }

        public string Naam { get; set; }
    }
}
