﻿namespace Catalog.API.Dtos
{
    public class RegionDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string ShortName { get; set; }

        public string StartDate { get; set; }

        public string FinishDate { get; set; }

        public CountryDto Country { get; set; }
    }
}