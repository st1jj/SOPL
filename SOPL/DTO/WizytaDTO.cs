namespace SOPL.DTO
{
    public class WizytaDTO
    {
        public Guid Id { get; set; }
        public Guid LekarzId { get; set; }
        public Guid PacjentId { get; set; }
        public DateTime DataRozpoczecia { get; set; }
        public DateTime DataZakonczenia { get; set; }
        public string Status { get; set; }
    }
}
