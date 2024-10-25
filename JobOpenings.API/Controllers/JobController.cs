using AutoMapper;
using JobOpenings.API.Models.Domain;
using JobOpenings.API.Models.DTO;
using JobOpenings.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace JobOpenings.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobOpeningRepository jobOpeningRepository;
        private readonly IMapper mapper;

        public JobController(IJobOpeningRepository jobOpeningRepository,IMapper mapper)
        {
            this.jobOpeningRepository=jobOpeningRepository;
            this.mapper=mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetJobOpeningsRecords([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var jobOpeningRecords = await jobOpeningRepository.GetAllJobOpeningsAsync(filterOn,filterQuery,pageNumber,pageSize);

            var jobOpeningResponse = mapper.Map<List<JobOpeningsResponse>>(jobOpeningRecords);

            return Ok(jobOpeningResponse);
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetJobOpeningRecordById([FromRoute] int id)
        {
            var jobOpeningRecord = await jobOpeningRepository.GetJobOpeningByIdAsync(id);

            var jobOpeningResponse = mapper.Map<JobOpeningsResponse>(jobOpeningRecord);
            return Ok(jobOpeningResponse);

        }
        [HttpPost]
        public async Task<IActionResult> CreateJobOpeningRecord([FromBody] JobOpeningsRequest jobOpeningsRequest)
        {
            var jobOpeningRecord = mapper.Map<JobOpening>(jobOpeningsRequest);

            jobOpeningRecord= await jobOpeningRepository.CreateJobOpeningRecordAsync(jobOpeningRecord);

            var jobOpeningResponse = mapper.Map<JobOpeningsResponse>(jobOpeningRecord);

            return CreatedAtAction(nameof(GetJobOpeningRecordById), new { id = jobOpeningRecord.Id }, jobOpeningRecord);
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateDepartmentRecord([FromRoute] int id, [FromBody] JobOpeningsRequest jobOpeningsRequest)
        {
            var jobOpeningRecords = mapper.Map<JobOpening>(jobOpeningsRequest);

            jobOpeningRecords = await jobOpeningRepository.UpdateJobOpeningRecordAsync(id, jobOpeningRecords);

            if (jobOpeningRecords == null)
            {
                return NotFound();
            }

            var jobOpeningResponse = mapper.Map<JobOpeningsResponse>(jobOpeningRecords);
            return Ok(jobOpeningResponse);
        }
    }
}
