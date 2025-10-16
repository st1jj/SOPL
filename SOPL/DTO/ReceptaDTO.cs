namespace SOPL.DTO
{
    public class ReceptaDTO
    {
        public Guid Id { get; set; }
        public Guid HistoriaChorobyId { get; set; }
        public DateTime DataWystawienia { get; set; }
        public string Uwagi { get; set; }
    }
}
