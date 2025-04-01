using AutoMapper;
using Domain.Entities;
using Application.DTOs;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Country, CountryDTO>().ReverseMap();
        CreateMap<Region, RegionDTO>().ReverseMap();
        CreateMap<City, CityDTO>().ReverseMap();
    }
}
