using AutoMapper;
using SOPL.Models;
using SOPL.Repository;

namespace SOPL.Services
{
    public class LekarzService
    {
        private readonly IGenericRepository<Lekarz> _repo;
        private readonly IMapper _mapper;

        public LekarzService(IGenericRepository<Lekarz> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
    }
}
