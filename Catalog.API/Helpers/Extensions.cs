using Catalog.API.Dtos;
using Catalog.Infrastructure.Entities;

namespace Catalog.API.Helpers
{
    public static class Extensions
    {
        public static CountryDto AsDto(this Country country)
        {
            return new CountryDto()
            {
                Id = country.Id,
                Name = country.Name,
                ShortName = country.ShortName,
                Code = country.Code,
                IsSchengen = country.IsSchengen,
                StartDate = country.StartDate.ToString("dd-MM-yyyy"),
                FinishDate = country.FinishDate.ToString("dd-MM-yyyy")
            };
        }
        public static RegionDto AsDto(this Region region)
        {
            return new RegionDto()
            {
                Id = region.Id,
                Name = region.Name,
                ShortName = region.ShortName,
                StartDate = region.StartDate.ToString("dd-MM-yyyy"),
                FinishDate = region.FinishDate.ToString("dd-MM-yyyy"),
                Country = region.Country.AsDto()
            };
        }
    }
}