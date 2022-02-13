using AutoMapper;
using System.Linq;
using Catalog.API.Dtos;
using Catalog.API.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Catalog.Infrastructure.Entities;
using Catalog.Infrastructure.Services;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;

        public CountriesController(IMapper mapper, ICountryService countryService)
        {
            _mapper = mapper;
            _countryService = countryService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var countries = _countryService.Get().Select(c => c.AsDto());
            return Ok(countries);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var country = _countryService.GetById(id).AsDto();
            if (country == null)
                throw new KeyNotFoundException("Country not found");

            return Ok(country);
        }

        [HttpPost]
        public IActionResult Create(CountryDto requestModel)
        {
            // validate 
            {
                if (!ModelState.IsValid)
                    return BadRequest("Bad request");

                var countries = _countryService.Get();
                if (countries?.Any(c => c.Name == requestModel.Name) != null)
                    throw new AppException("Country with the name '" + requestModel.Name + "' already exists");
            }

            // map country to new country object
            var country = _mapper.Map<Country>(requestModel);
            
            _countryService.Create(country);

            return Ok(new { message = "Country created" });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CountryDto requestModel)
        {
            // validate
            {
                if (!ModelState.IsValid)
                    return BadRequest("Bad request");

                var item = _countryService.GetById(id);
                if (item == null)
                    throw new KeyNotFoundException("Country not found");
            }
            
            
            // map country to new country object
            var country = _mapper.Map<Country>(requestModel);
            _countryService.Update(id, country);

            return Ok(new { message = "Country updated" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // validate
            var country = _countryService.GetById(id);
            if (country == null)
                throw new KeyNotFoundException("Country not found");

            _countryService.Delete(id);
            
            return Ok(new { message = "Country deleted" });
        }
    }
}
