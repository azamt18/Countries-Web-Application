using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalog.Infrastructure.Entities
{
    public class Region
    {
        [Key]
        public long Id { get; set; }

        public string Name { get; set; }

        public string ShortName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime FinishDate { get; set; }

        [ForeignKey(nameof(Country))]
        public long CountryId { get; set; }

        public virtual Country Country { get; set; }
    }
}