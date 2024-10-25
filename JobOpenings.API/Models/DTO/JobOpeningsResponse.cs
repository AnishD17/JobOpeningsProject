using JobOpenings.API.Models.Domain;

namespace JobOpenings.API.Models.DTO
{
    public class JobOpeningsResponse
    {
        public int Id { get; set; }
        public string JobCode { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public DateTime? JobPostedDate { get; set; }
        public DateTime? JobClosingDate { get; set; }
        public Location Location { get; set; }
        public Department Department { get; set; }
    }
}
