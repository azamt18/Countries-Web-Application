using System.ComponentModel.DataAnnotations;

namespace Catalog.Web.Models.RequestModels
{
    public class CountryRequestModel
    {
        [Required]
        public string Name { get; set; }

        public string ShortName { get; set; }

        [Required]
        public string Code { get; set; }

        public string StartDate { get; set; }

        public string FinishDate { get; set; }
    }
}