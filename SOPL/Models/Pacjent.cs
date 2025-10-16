namespace SOPL.Models
{
    public class Pacjent
    {
        public Guid Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Pesel { get; set; }
        public DateTime DataUrodzenia { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }


        public ICollection<Wizyta> Wizyty { get; set; }
        public ICollection<HistoriaChoroby> HistorieChorob { get; set; }

    }
}
