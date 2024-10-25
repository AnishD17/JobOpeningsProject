using JobOpenings.API.Data;
using JobOpenings.API.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace JobOpenings.API.Repositories
{
    public class SQLJobOpeningRepository : IJobOpeningRepository
    {
        private readonly JobopeningsDbContext dbContext;

        public SQLJobOpeningRepository(JobopeningsDbContext dbContext)
        {
            this.dbContext=dbContext;
        }
        public async Task<JobOpening> CreateJobOpeningRecordAsync(JobOpening jobOpening)
        {
            jobOpening.JobCode = await GenerateJobCodeAsync();

            await dbContext.JobOpenings.AddAsync(jobOpening);
            await dbContext.SaveChangesAsync();
            return jobOpening;

        }

        public async Task<List<JobOpening?>> GetAllJobOpeningsAsync(string? filterOn = null, string? filterQuery = null,
            int pageNumber = 1, int pageSize = 1000)
        {
           // return await dbContext.JobOpenings.Include("Location").Include("Department").ToListAsync();

            var jobOpenings = dbContext.JobOpenings.Include("Location").Include("Department").AsQueryable();

            // Filtering
            //if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            //{
            //    if (filterOn.Equals("LocationId", StringComparison.OrdinalIgnoreCase))
            //    {
            //        jobOpenings = jobOpenings.Where(x => x.LocationId.Contains(filterQuery));
            //    }
            //    else if (filterOn.Equals("DepartmentId", StringComparison.OrdinalIgnoreCase))
            //    {
            //        jobOpenings = jobOpenings.Where(x => x.DepartmentId.Contains(filterQuery));
            //    }
            //}
            if (!string.IsNullOrWhiteSpace(filterOn) && !string.IsNullOrWhiteSpace(filterQuery))
            {
                if (filterOn.Equals("LocationId", StringComparison.OrdinalIgnoreCase))
                {
                    if (int.TryParse(filterQuery, out int locationId))
                    {
                        jobOpenings = jobOpenings.Where(x => x.LocationId == locationId);
                    }
                }
                else if (filterOn.Equals("DepartmentId", StringComparison.OrdinalIgnoreCase))
                {
                    if (int.TryParse(filterQuery, out int departmentId))
                    {
                        jobOpenings = jobOpenings.Where(x => x.DepartmentId == departmentId);
                    }
                }
            }

            var skipResults = (pageNumber - 1) * pageSize;

            return await jobOpenings.Skip(skipResults).Take(pageSize).ToListAsync();
        }

        public async Task<JobOpening?> GetJobOpeningByIdAsync(int id)
        {
            return await dbContext.JobOpenings.Include("Location").Include("Department").FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<JobOpening?> UpdateJobOpeningRecordAsync(int id, JobOpening jobOpening)
        {
            var existingJobRecord = await dbContext.JobOpenings.FirstOrDefaultAsync(x => x.Id == id);

            if (existingJobRecord == null)
            {
                return null;
            }
            existingJobRecord.JobTitle = jobOpening.JobTitle;
            existingJobRecord.JobDescription = jobOpening.JobDescription;
            existingJobRecord.JobPostedDate = jobOpening.JobPostedDate;
            existingJobRecord.JobClosingDate = jobOpening.JobClosingDate;
            existingJobRecord.DepartmentId = jobOpening.DepartmentId;
            existingJobRecord.LocationId = jobOpening.LocationId;


            await dbContext.SaveChangesAsync();
            return existingJobRecord;
        }
        private async Task<string> GenerateJobCodeAsync()
        {
            var maxJobCode = await dbContext.JobOpenings
                .Select(j => j.JobCode)
                .OrderByDescending(j => j)
                .FirstOrDefaultAsync();

            int newJobNumber = 1;

            if (!string.IsNullOrEmpty(maxJobCode))
            {
                var numberPart = maxJobCode.Split('-').Last();
                if (int.TryParse(numberPart, out int currentMax))
                {
                    newJobNumber = currentMax + 1;
                }
            }

            return $"JOB-{newJobNumber:D2}";
        }
    }
}
