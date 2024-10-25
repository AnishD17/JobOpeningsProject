namespace JobOpenings.API.Models.Domain
{
    public class JobOpening
    {
        public int Id { get; set; }
        public string JobCode { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public DateTime? JobPostedDate { get; set; }
        public DateTime? JobClosingDate { get; set; }
        public int DepartmentId { get; set; }
        public int LocationId { get; set; }

        //Navigation properties
        public Department Department { get; set; }
        public Location Location { get; set; }
    }
}
