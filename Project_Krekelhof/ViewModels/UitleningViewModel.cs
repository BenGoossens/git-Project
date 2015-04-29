using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project_Krekelhof.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace Project_Krekelhof.ViewModels
{
    public class UitleningViewModel
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Einde uitlening")]
        public DateTime EindeUitlening { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Start uitlening")]
        public DateTime StartUitlening { get; set; }
        [Display(Name = "Is terug")]
        public bool IsTerug { get; set; }
        [Display(Name = "Item")]
        public string Item { get; set; } 
        [Display(Name= "Leerling")]
        //public string LeerlingVoornaam { get; set; }
        //public string LeerlingFamilienaam { get; set; }
        public string volledigeNaam { get; set; }

        public UitleningViewModel()
        {

        }

        public UitleningViewModel(Uitlening u)
        {
            Id = u.Id;
            Item = (u.Item == null) ? null : u.Item.Naam;
            //LeerlingVoornaam = (u.Leerling == null) ? null : u.Leerling.Voornaam;
            //LeerlingFamilienaam = (u.Leerling == null) ? null : u.Leerling.Familienaam;
            volledigeNaam = (u.Leerling == null) ? null : u.Leerling.VolledigeNaam;
            EindeUitlening = u.EindDatum;
            //StartUitlening = u.BeginDatumUitlening;
            //IsTerug = u.IsTerug;
        }   
    }

    public class UitleningIndexViewModel
    {
        public IEnumerable<UitleningViewModel> Uitleningen { get; set; }

        public UitleningIndexViewModel(IEnumerable<Uitlening> uitleningen)
        {
            Uitleningen = uitleningen.Select(u => new UitleningViewModel(){
                Id = u.Id,
                Item = u.Item.Naam,
                volledigeNaam = u.Leerling.VolledigeNaam,
                EindeUitlening = u.EindDatum,
                StartUitlening = u.BeginDatumUitlening,
                IsTerug = u.IsTerug
            });
        }
    }
}
