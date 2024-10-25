using JobOpenings.API.Models.Domain;

namespace JobOpenings.API.Repositories
{
    public interface IJobOpeningRepository
    {
        Task<List<JobOpening?>> GetAllJobOpeningsAsync(string? filterOn = null, string? filterQuery = null,
                                                       int pageNumber = 1, int pageSize = 10);
        Task<JobOpening?> GetJobOpeningByIdAsync(int id);
        Task<JobOpening> CreateJobOpeningRecordAsync(JobOpening jobOpening);
        Task<JobOpening?> UpdateJobOpeningRecordAsync(int id, JobOpening jobOpening);
    }
}
