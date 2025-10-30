using AutoMapper;
using SOPL.Models;
using SOPL.Repository;

namespace SOPL.Services
{
    public class PacjentService
    {
        private readonly IGenericRepository<Pacjent> _repo;
        private readonly IMapper _mapper;

        public PacjentService(IGenericRepository<Pacjent> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
    }
}
