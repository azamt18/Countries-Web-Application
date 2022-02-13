namespace Catalog.Web.Dtos
{
    public class CountryDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string ShortName { get; set; }

        public string Code { get; set; }

        public bool IsSchengen { get; set; }

        public string StartDate { get; set; }

        public string FinishDate { get; set; }
    }
}