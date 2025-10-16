namespace SOPL.Models
{
    public class HistoriaChoroby
    {
        public Guid Id { get; set; }
        public Guid PacjentId { get; set; }
        public Guid LekarzId { get; set; }
        public DateTime DataWizyty { get; set; }
        public string Diagnoza { get; set; }
        public string Zalecenia { get; set; }


        public Pacjent Pacjent { get; set; }
        public Lekarz Lekarz { get; set; }
        public ICollection<Recepta> Recepty { get; set; }
    }
}
