using System;
using System.ComponentModel.DataAnnotations;

namespace Catalog.Infrastructure.Entities
{
    public class Country
    {
        [Key]
        public long Id { get; set; }

        public string Name { get; set; }

        public string ShortName { get; set; }

        public string Code { get; set; }

        public bool IsSchengen { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime FinishDate { get; set; }
    }
}