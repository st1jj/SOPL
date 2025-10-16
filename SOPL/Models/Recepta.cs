namespace SOPL.Models
{
    public class Recepta
    {
        public Guid Id { get; set; }
        public Guid HistoriaChorobyId { get; set; }
        public DateTime DataWystawienia { get; set; }
        public string Uwagi { get; set; }


        public HistoriaChoroby HistoriaChoroby { get; set; }
        public ICollection<PozycjaRecepty> Pozycje { get; set; }
    }
}
