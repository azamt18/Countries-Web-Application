using AutoMapper;
using Catalog.Infrastructure.Entities;
using Catalog.Web.Dtos;

namespace Catalog.Web.Helpers
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