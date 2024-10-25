namespace JobOpenings.API.Models.Domain
{
    public class Location
    {
        public int LocationId { get; set; }
        public string LocationTitle { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Zipcode { get; set; }
    }
}
