using AutoMapper;
using Application.DTOs;
using Domain.Entities;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services.Base;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public class RegionService : BaseService<Region, RegionDTO>, IRegionService
    {
        private readonly IRegionRepository _regionRepository;
        public RegionService(IRegionRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
            _regionRepository = repository;
        }
        
    }
}