using Catalog.Infrastructure.Entities;
using Catalog.Web.Dtos;

namespace Catalog.Web.Helpers
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
                CountryId = region.Country?.Id.ToString(),
                Country = region.Country?.AsDto()
            };
        }
    }
}