using AutoMapper;
using Application.DTOs;
using Domain.Entities;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services.Base;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public class CityService : BaseService<City, CityDTO>, ICityService
    {
        private readonly ICityRepository _cityRepository;
        public CityService(ICityRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
            _cityRepository = repository;
        }
        
    }
}