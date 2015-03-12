using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project_Krekelhof.Models.Domain;

namespace Project_Krekelhof.ViewModels
{
    public class UitleningViewModel
    {
        public UitleningViewModel()
        {
            
        }
        public UitleningViewModel(Uitlening u)
        {
            Id = u.Id;
            EindeUitlening = u.EindeUitlening;
            IsTerug = u.IsTerug;
            Item = u.Item;
            StartUitlening = u.StartUitlening;
            
            
        }
        public int Id { get;  set; }
        public DateTime EindeUitlening { get;  set; }

        public DateTime StartUitlening { get;  set; }

        public  bool IsTerug {get;set;}
        
        public  Item Item {get;set;}       

    }

    public class UitleningIndexViewModel
    {
        public UitleningIndexViewModel(Uitlening u)
        {
            Id = u.Id;
            EindeUitlening = u.EindeUitlening;
            IsTerug = u.IsTerug;
            Item = u.Item;
            StartUitlening = u.StartUitlening;


        }
        public int Id { get; set; }
        public DateTime EindeUitlening { get; set; }

        public DateTime StartUitlening { get; set; }

        public bool IsTerug { get; set; }

        public Item Item { get; set; }     
    }



    }
