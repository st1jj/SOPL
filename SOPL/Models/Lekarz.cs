namespace SOPL.Models
{
    public class Lekarz
    {
        public Guid Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Specjalizacja { get; set; }
        public string Email { get; set; }


        public ICollection<Wizyta> Wizyty { get; set; }
        public ICollection<HistoriaChoroby> HistorieChorob { get; set; }

    }
}
