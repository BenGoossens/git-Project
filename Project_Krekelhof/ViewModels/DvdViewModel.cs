using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project_Krekelhof.Models.Domain;

namespace Project_Krekelhof.ViewModels
{
    public class DvdViewModel
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Omschrijving { get; set; }
        public bool Beschikbaar { get; set; }
        public string Regisseur { get; set; }
        public string Categorie { get; set; }
    }

    public class DvdIndexViewModel
    {
        public IEnumerable<DvdViewModel> Dvds { get; set; }

        public DvdIndexViewModel(IEnumerable<Dvd> dvds)
        {
            Dvds = dvds.Select(d => new DvdViewModel()
            {
                Id = d.Id,
                Naam = d.Naam,
                Omschrijving = d.Omschrijving,
                Beschikbaar = d.Beschikbaar,
                Regisseur = d.Regisseur,
                Categorie = d.Categorie.Naam
            });
        }
    }
}