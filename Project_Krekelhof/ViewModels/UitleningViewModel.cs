using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project_Krekelhof.Models.Domain;

namespace Project_Krekelhof.ViewModels
{
    public class UitleningViewModel
    {
        public int Id { get; set; }
        public DateTime EindeUitlening { get; set; }
        public DateTime StartUitlening { get; set; }
        public bool IsTerug { get; set; }
        public string ItemNaam { get; set; } 
        public string LeerlingVoornaam { get; set; }
        public string LeerlingFamilienaam { get; set; }

        public UitleningViewModel()
        {

        }

        public UitleningViewModel(Uitlening u)
        {
            Id = u.Id;
            ItemNaam = (u.Item == null) ? null : u.Item.Naam;
            LeerlingVoornaam = (u.Leerling == null) ? null : u.Leerling.Voornaam;
            LeerlingFamilienaam = (u.Leerling == null) ? null : u.Leerling.Familienaam;
            EindeUitlening = u.EindDatum;
            StartUitlening = u.BeginDatumUitlening;
            IsTerug = u.IsTerug;
            
            
        }   
    }

    public class UitleningIndexViewModel
    {
        public IEnumerable<UitleningViewModel> Uitleningen { get; set; }

        public UitleningIndexViewModel(IEnumerable<Uitlening> uitleningen)
        {
            Uitleningen = uitleningen.Select(u => new UitleningViewModel(){
                Id = u.Id,
                ItemNaam = (u.Item == null) ? null : u.Item.Naam,
                LeerlingVoornaam = (u.Leerling == null) ? null : u.Leerling.Voornaam,
                LeerlingFamilienaam = (u.Leerling == null) ? null : u.Leerling.Familienaam,
                EindeUitlening = u.EindDatum,
                StartUitlening = u.BeginDatumUitlening,
                IsTerug = u.IsTerug
            });
        }
    }
}
