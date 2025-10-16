namespace SOPL.Models
{
    public enum StatusWizyty { Zaplanowana, Zakonczona, Anulowana }
    public class Wizyta
    {
        public Guid Id { get; set; }
        public Guid LekarzId { get; set; }
        public Guid PacjentId { get; set; }
        public DateTime DataRozpoczecia { get; set; }
        public DateTime DataZakonczenia { get; set; }
        public StatusWizyty Status { get; set; }


        public Lekarz Lekarz { get; set; }
        public Pacjent Pacjent { get; set; }
    }
}
