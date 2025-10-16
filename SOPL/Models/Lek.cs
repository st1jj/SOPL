namespace SOPL.Models
{
    public class Lek
    {
        public Guid Id { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public int StanMagazynowy { get; set; }


        public ICollection<PozycjaRecepty> PozycjeRecept { get; set; }
    }
}
