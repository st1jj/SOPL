using AutoMapper;
using SOPL.Models;
using SOPL.Repository;

namespace SOPL.Services
{
    public class ReceptaService
    {
        private readonly IGenericRepository<Recepta> _repo;
        private readonly IMapper _mapper;

        public ReceptaService(IGenericRepository<Recepta> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
    }
}
