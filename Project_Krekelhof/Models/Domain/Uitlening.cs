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
        public Item Item { get; set; }

        public Uitlening()
        {
            
        }

        public Uitlening(int id, bool isterug, DateTime van, DateTime tot, Item item)
        {
            Id = id;
            IsTerug = isterug;
            BeginDatumUitlening = van;
            EindDatumUitlening = tot;
            Item = item;
        }

        public Uitlening(Item item, DateTime eind)
        {
            Item = item;
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