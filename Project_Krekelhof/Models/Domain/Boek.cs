namespace Project_Krekelhof.Models.Domain
{
    public class Boek : Item
    {
        public int Isbn { get; set; }

        public string Auteur { get; set; }

        public string Uitgeverij { get; set; }
    }
}
