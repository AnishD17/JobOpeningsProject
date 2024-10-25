namespace JobOpenings.API.Models.DTO
{
    public class LocationRequest
    {
        public string LocationTitle { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Zipcode { get; set; }
    }
}
