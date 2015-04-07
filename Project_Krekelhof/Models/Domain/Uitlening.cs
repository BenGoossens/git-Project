using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Krekelhof.Models.Domain
{
    public class Uitlening
    {
        public int Id { get; set; }
        public DateTime BeginDatumUitlening { get; set; }
        public DateTime EindDatumUitlening { get; set; }
        public bool IsTerug { get; set; }
        public virtual Item Item { get; set; }
        public virtual Leerling Leerling { get; set; }

        public Uitlening()
        {
            
        }

        public Uitlening(int id, bool isterug, DateTime van, DateTime tot, Item item, Leerling leerling)
        {
            Id = id;
            IsTerug = isterug;
            BeginDatumUitlening = van;
            EindDatumUitlening = tot;
            Item = item;
            Leerling = leerling;
        }

        public Uitlening(int id, Item item, Leerling leerling, DateTime eind)
        {
            Id = id;
            Item = item;
            Leerling = leerling;
            BeginDatumUitlening = DateTime.Today;
            EindDatumUitlening = eind;
            IsTerug = false;
        }

        public DateTime EindDatum
        {
            get { return EindDatumUitlening; }
            set
            {
                if (value <= DateTime.Today)
                    throw new ArgumentException("Eind datum mag niet vroeger zijn dan begin datum!");
                EindDatumUitlening = value;
            }
        }

        public Project_Krekelhof.Models.Domain.Item item
        {
            get { return Item; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Ongeldig Item!");
                if (!item.Beschikbaar)
                    throw new ArgumentException("Item is niet beschikbaar!");
                Item = value;
            }
        }

        public void WordTerugGebracht()
        {
            if (IsTerug)
            {
                throw new ApplicationException("Deze uitlening is al terug in de Lettertuin!");
            }
            IsTerug = true;
        }
    }
}