using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace Project_Krekelhof.Models.Domain
{
    public class Leerling
    {
        public int Id { get; set; }
        public string Voornaam { get; set; }
        public string Familienaam { get; set; }
        public string Straat { get; set; }
        public int Huisnummer { get; set; }
        public string Gemeente { get; set; }
        public int Postcode { get; set; }
        public string StamBoekNummer { get; set; }
        public virtual Collection<Uitlening> Uitleningen { get; set; }

        public Leerling()
        {
            
        }

        public Leerling(int id, string voornaam, string familienaam, string straat, int huisnummer, string gemeente, int postcode, string stamBoekNummer)
        {
            this.Id = id;
            this.Voornaam = voornaam;
            this.Familienaam = familienaam;
            this.Straat = straat;
            this.Huisnummer = huisnummer;
            this.Gemeente = gemeente;
            this.Postcode = postcode;
            this.StamBoekNummer = stamBoekNummer;
        }

        public Leerling(string voornaam, string familienaam, string straat, int huisnummer, string gemeente, int postcode, string stamBoekNummer)
        {
            this.Voornaam = voornaam;
            this.Familienaam = familienaam;
            this.Straat = straat;
            this.Huisnummer = huisnummer;
            this.Gemeente = gemeente;
            this.Postcode = postcode;
            this.StamBoekNummer = stamBoekNummer;
        }

        public void KrijgLening(Uitlening uitlening)
        {
            if (Uitleningen.Count >= 3)
            {
                throw new ApplicationException("Lener mag maar 3 uitleningen hebben!");
            }

            Uitleningen.Add(uitlening);

        }

        public void CheckLeningUit(Uitlening uitlening)
        {
            Uitleningen.Remove(uitlening);
        }
    }
}