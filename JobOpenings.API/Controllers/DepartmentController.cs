using AutoMapper;
using JobOpenings.API.Models.Domain;
using JobOpenings.API.Models.DTO;
using JobOpenings.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JobOpenings.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository departmentRepository;
        private readonly IMapper mapper;

        public DepartmentController(IDepartmentRepository departmentRepository,IMapper mapper)
        {
            this.departmentRepository=departmentRepository;
            this.mapper=mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetDepartmentRecords()
        {
            var departmentRecords = await departmentRepository.GetAllDepartmentAsync();

            var departmentResponse = mapper.Map<List<DepartmentResponse>>(departmentRecords);

            return Ok(departmentResponse);
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetDepartmentRecordById([FromRoute] int id)
        {
            var departmentRecords = await departmentRepository.GetDepartmentByIdAsync(id);

            var departmentResponse = mapper.Map<DepartmentResponse>(departmentRecords);
            return Ok(departmentResponse);

        }
        [HttpPost]
        public async Task<IActionResult> CreateDepartmentRecord([FromBody] DepartmentRequest departmentRequest)
        {
            var departmentDomainRecord = mapper.Map<Department>(departmentRequest);

            departmentDomainRecord = await departmentRepository.CreateDepartmentRecordAsync(departmentDomainRecord);

            var departmentResponse = mapper.Map<DepartmentResponse>(departmentDomainRecord);

            return CreatedAtAction(nameof(GetDepartmentRecordById), new { id = departmentResponse.DepartmentId }, departmentResponse);
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateDepartmentRecord([FromRoute] int id, [FromBody] DepartmentRequest departmentRequest)
        {
            var departmentDomainRecords = mapper.Map<Department>(departmentRequest);

            departmentDomainRecords = await departmentRepository.UpdateDepartmentRecordAsync(id, departmentDomainRecords);

            if (departmentDomainRecords == null)
            {
                return NotFound();
            }

            var departmentResponse = mapper.Map<DepartmentResponse>(departmentDomainRecords);
            return Ok(departmentResponse);
        }

    }
}
