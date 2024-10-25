using JobOpenings.API.Data;
using JobOpenings.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace JobOpenings.API.Repositories
{
    public class SQLLocationRepository : ILocationRepository
    {
        private readonly JobopeningsDbContext dbContext;

        public SQLLocationRepository(JobopeningsDbContext dbContext)
        {
            this.dbContext=dbContext;
        }
        public async Task<Location> CreateLocationRecordAsync(Location location)
        {
            await dbContext.Locations.AddAsync(location);
            await dbContext.SaveChangesAsync();
            return location;

        }

        public async Task<List<Location?>> GetAllLocationAsync()
        {
            return await dbContext.Locations.ToListAsync();
        }

        public async Task<Location?> GetLocationByIdAsync(int id)
        {
            return await dbContext.Locations.FirstOrDefaultAsync(x =>x.LocationId == id);
        }

        public async Task<Location?> UpdateLocationRecordAsync(int id, Location location)
        {
            var existingLocationRecord = await dbContext.Locations.FirstOrDefaultAsync(x => x.LocationId == id);

            if (existingLocationRecord == null)
            {
                return null;
            }

            existingLocationRecord.LocationTitle = location.LocationTitle;
            existingLocationRecord.State = location.State;
            existingLocationRecord.City = location.City;
            existingLocationRecord.Country = location.Country;
            existingLocationRecord.Zipcode = location.Zipcode;

            await dbContext.SaveChangesAsync();
            return existingLocationRecord;
        }
    }
}
