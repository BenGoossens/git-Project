using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project_Krekelhof.Models.Domain;

namespace Project_Krekelhof.ViewModels
{
    public class CdViewModel
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Omschrijving { get; set; }
        public bool Beschikbaar { get; set; }
        public string ArtiestNaam { get; set; }
        public string Categorie { get; set; }
    }

    public class CdIndexViewModel
    {
        public IEnumerable<CdViewModel> Cds { get; set; }

        public CdIndexViewModel(IEnumerable<Cd> cds)
        {
            Cds = cds.Select(c => new CdViewModel()
            {
                Id = c.Id,
                Naam = c.Naam,
                Omschrijving = c.Omschrijving,
                Beschikbaar = c.Beschikbaar,
                ArtiestNaam = c.ArtiestNaam,
                Categorie = c.Categorie.Naam
            });
        }
    }
}