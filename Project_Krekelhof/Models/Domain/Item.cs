using System;

namespace Project_Krekelhof.Models.Domain
{
    public abstract class Item
    {
        public Item() { }
        public int Id { get; set; }
        public string Omschrijving { get; set; }
        public string Naam { get; set; }
        public int Beschikbaar { get; set; }

        public String IsBeschikbaar()
        {
            if (Beschikbaar == 0)
            {
                return "No";
            } else
            {
                return "Yes";
            }
        }
        public Categorie Categorie {  get; set; }
    }
}
