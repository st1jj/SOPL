using AutoMapper;
using SOPL.DTO;
using SOPL.Models;

namespace SOPL.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Pacjent, PacjentDTO>().ReverseMap();
            CreateMap<Lekarz, LekarzDTO>().ReverseMap();
            CreateMap<Wizyta, WizytaDTO>().ReverseMap();
            CreateMap<HistoriaChoroby, HistoriaChorobyDTO>().ReverseMap();
            CreateMap<Recepta, ReceptaDTO>().ReverseMap();
            CreateMap<Lek, LekDTO>().ReverseMap();
        }

    }
}
