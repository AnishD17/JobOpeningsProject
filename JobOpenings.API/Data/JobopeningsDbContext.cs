using JobOpenings.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace JobOpenings.API.Data
{
    public class JobopeningsDbContext : DbContext
    {
        public JobopeningsDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
                    
        }

        public DbSet<JobOpening> JobOpenings { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
