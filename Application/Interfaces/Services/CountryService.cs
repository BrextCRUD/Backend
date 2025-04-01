using AutoMapper;
using Application.DTOs;
using Domain.Entities;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services.Base;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public class CountryService : BaseService<Country, CountryDTO>, ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        public CountryService(ICountryRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
            _countryRepository = repository;
        }
        
    }
}