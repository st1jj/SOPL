namespace SOPL.Models
{
    public class PozycjaRecepty
    {
        public Guid Id { get; set; }
        public Guid ReceptaId { get; set; }
        public Guid LekId { get; set; }
        public int Ilosc { get; set; }


        public Recepta Recepta { get; set; }
        public Lek Lek { get; set; }
    }
}
