using AutoMapper;
using Catalog.API.Dtos;
using Catalog.Infrastructure.Entities;

namespace Catalog.API.Helpers
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            // Country <-> CountryDto
            CreateMap<Country, CountryDto>();
            CreateMap<CountryDto, Country>();

            // Region <-> RegionDto
            CreateMap<Region, RegionDto>();
            CreateMap<RegionDto, Region>();
        }
    }
}