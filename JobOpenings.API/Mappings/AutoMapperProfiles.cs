using AutoMapper;
using JobOpenings.API.Models.Domain;
using JobOpenings.API.Models.DTO;
using System.Text;

namespace JobOpenings.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<Department, DepartmentRequest>().ReverseMap();
            CreateMap<Department, DepartmentResponse>().ReverseMap();
            CreateMap<Location, LocationResponse>().ReverseMap();
            CreateMap<Location, LocationRequest>().ReverseMap();
            CreateMap<JobOpening, JobOpeningsRequest>().ReverseMap();
            CreateMap<JobOpening, JobOpeningsResponse>().ReverseMap();
        }
    }
}
