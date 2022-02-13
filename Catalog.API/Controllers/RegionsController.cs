using AutoMapper;
using System.Linq;
using Catalog.API.Helpers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Catalog.Infrastructure.Entities;
using Catalog.Infrastructure.Services;
using Catalog.API.Models.RequestModels;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRegionService _regionService;

        public RegionsController(IRegionService regionService, IMapper mapper)
        {
            _regionService = regionService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var regions = _regionService.Get().Select(r => r.AsDto());
            return Ok(regions);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var region = _regionService.GetById(id).AsDto();
            if (region == null)
                throw new KeyNotFoundException("Region not found");

            return Ok(region);
        }

        [HttpPost]
        public IActionResult Create(RegionRequestModel requestModel)
        {
            // validate
            {
                if (!ModelState.IsValid)
                    return BadRequest("Bad request");

                var countries = _regionService.Get();
                if (countries?.Any(c => c.Name == requestModel.Name) != null)
                    throw new AppException("Region with the name '" + requestModel.Name + "' already exists");
            }
            
            // map region to new country object
            var region = _mapper.Map<Region>(requestModel);

            _regionService.Create(region);

            return Ok(new { message = "Region created" });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, RegionRequestModel requestModel)
        {
            // validate
            {
                if (!ModelState.IsValid)
                    return BadRequest("Bad request");

                var item = _regionService.GetById(id);
                if (item == null)
                    throw new KeyNotFoundException("Country not found");
            }
            
            // map region to new country object
            var region = _mapper.Map<Region>(requestModel);
            _regionService.Update(id, region);

            return Ok(new { message = "Region updated" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // validate
            var country = _regionService.GetById(id);
            if (country == null)
                throw new KeyNotFoundException("Region not found");

            _regionService.Delete(id);

            return Ok(new { message = "Region deleted" });
        }
    }
}
