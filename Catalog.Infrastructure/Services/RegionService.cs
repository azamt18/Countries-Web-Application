using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Catalog.Infrastructure.Entities;
using Catalog.Infrastructure.DbContexts;

namespace Catalog.Infrastructure.Services
{
    public interface IRegionService
    {
        IEnumerable<Region> Get();
        Region GetById(long id);
        void Create(Region model);
        void Update(long id, Region model);
        void Delete(long id);
        void Save(Region region);
    }

    public class RegionService : IRegionService
    {
        private readonly DatabaseContext _context;

        public RegionService(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Region> Get()
        {
            var res = _context.Regions.ToList();
            return res;
        }

        public Region GetById(long id)
        {
            return _context.Regions.Find(id);
        }

        public void Create(Region model)
        {
            // save
            _context.Regions?.Add(model);

            _context.SaveChanges();
        }

        public void Update(long id, Region model)
        {
            // save
            _context.Regions.Update(model);

            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var country = _context.Regions.Find(id);

            _context.Regions.Remove(country);

            _context.SaveChanges();
        }

        public void Save(Region region)
        {
            var item = _context.Countries.Find(region.Id);
            if (item == null)
                Create(region);
            else
                Update(region.Id, region);
        }
    }
}