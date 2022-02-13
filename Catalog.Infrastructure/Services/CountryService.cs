using System.Linq;
using System.Collections.Generic;
using Catalog.Infrastructure.Entities;
using Catalog.Infrastructure.DbContexts;

namespace Catalog.Infrastructure.Services
{
    public interface ICountryService
    {
        IEnumerable<Country> Get();
        Country GetById(long id);
        void Create(Country model);
        void Update(long id, Country model);
        void Delete(long id);
        void Save(Country country);
    }

    public class CountryService : ICountryService
    {
        private readonly DatabaseContext _context;

        public CountryService(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Country> Get()
        {
            var res =  _context.Countries.ToList();
            return res;
        }

        public Country GetById(long id)
        {
            return _context.Countries.Find(id);
        }

        public void Create(Country model)
        {
            // save
            _context.Countries?.Add(model);

            _context.SaveChanges();
        }

        public void Update(long id, Country model)
        {
            // save
            _context.Countries.Update(model);

            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var country = _context.Countries.Find(id);

            _context.Countries.Remove(country);
            
            _context.SaveChanges();
        }

        public void Save(Country country)
        {
            var item = _context.Countries.Find(country.Id);
            if (item == null)
                Create(country);
            else
                Update(country.Id, country);
        }
    }
}