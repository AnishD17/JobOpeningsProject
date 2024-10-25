using JobOpenings.API.Models.Domain;

namespace JobOpenings.API.Models.DTO
{
    public class JobOpeningsRequest
    {
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public DateTime? JobPostedDate { get; set; }
        public DateTime? JobClosingDate { get; set; }
        public int DepartmentId { get; set; }
        public int LocationId { get; set; }

    }
}
