using AutoMapper;
using SOPL.Models;
using SOPL.Repository;

namespace SOPL.Services
{
    public class HistoriaChorobyService
    {
        private readonly IGenericRepository<HistoriaChoroby> _repo;
        private readonly IMapper _mapper;

        public HistoriaChorobyService(IGenericRepository<HistoriaChoroby> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
    }
}
