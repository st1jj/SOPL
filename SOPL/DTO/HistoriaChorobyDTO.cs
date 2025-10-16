namespace SOPL.DTO
{
    public class HistoriaChorobyDTO
    {
        public Guid Id { get; set; }
        public Guid PacjentId { get; set; }
        public Guid LekarzId { get; set; }
        public DateTime DataWizyty { get; set; }
        public string Diagnoza { get; set; }
        public string Zalecenia { get; set; }
    }
}
