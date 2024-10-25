using JobOpenings.API.Models.Domain;

namespace JobOpenings.API.Repositories
{
    public interface ILocationRepository
    {
        Task<List<Location?>> GetAllLocationAsync();
        Task<Location?> GetLocationByIdAsync(int id);
        Task<Location> CreateLocationRecordAsync(Location location);
        Task<Location?> UpdateLocationRecordAsync(int id, Location location);
    }
}
