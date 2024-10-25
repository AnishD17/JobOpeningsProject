using AutoMapper;
using JobOpenings.API.Models.Domain;
using JobOpenings.API.Models.DTO;
using JobOpenings.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobOpenings.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationRepository locationRepository;
        private readonly IMapper mapper;

        public LocationController(ILocationRepository locationRepository,IMapper mapper)
        {
            this.locationRepository=locationRepository;
            this.mapper=mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetLocationRecords()
        {
            var locationRecords = await locationRepository.GetAllLocationAsync();

            var locationResponse = mapper.Map<List<LocationResponse>>(locationRecords);

            return Ok(locationResponse);
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetLocationRecordById([FromRoute] int id)
        {
            var locationRecords = await locationRepository.GetLocationByIdAsync(id);

            var locationResponse = mapper.Map<LocationResponse>(locationRecords);
            return Ok(locationResponse);

        }
        [HttpPost]
        public async Task<IActionResult> CreateLocationRecord([FromBody] LocationRequest locationRequest)
        {
            var locationDomainRecord = mapper.Map<Location>(locationRequest);

            locationDomainRecord = await locationRepository.CreateLocationRecordAsync(locationDomainRecord);

            var locationResponse = mapper.Map<LocationResponse>(locationDomainRecord);

            return CreatedAtAction(nameof(GetLocationRecordById), new { id =locationResponse.LocationId }, locationResponse);
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateDepartmentRecord([FromRoute] int id, [FromBody] LocationRequest locationRequest)
        {
            var locationDomainRecords = mapper.Map<Location>(locationRequest);

            locationDomainRecords = await locationRepository.UpdateLocationRecordAsync(id, locationDomainRecords);

            if (locationDomainRecords == null)
            {
                return NotFound();
            }

            var locationResponse = mapper.Map<LocationResponse>(locationDomainRecords);
            return Ok(locationResponse);
        }

    }
}
