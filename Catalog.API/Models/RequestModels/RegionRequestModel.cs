using System.ComponentModel.DataAnnotations;

namespace Catalog.API.Models.RequestModels
{
    public class RegionRequestModel
    {
        [Required]
        public string Name { get; set; }

        public string ShortName { get; set; }

        [Required]
        public long CountryId { get; set; }
    }
}