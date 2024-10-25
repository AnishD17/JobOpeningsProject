using JobOpenings.API.Data;
using JobOpenings.API.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace JobOpenings.API.Repositories
{
    public class SQLDepartmentRepository : IDepartmentRepository
    {
        private readonly JobopeningsDbContext dbContext;

        public SQLDepartmentRepository(JobopeningsDbContext dbContext)
        {
            this.dbContext=dbContext;
        }
        public async Task<Department> CreateDepartmentRecordAsync(Department department)
        {
            await dbContext.Departments.AddAsync(department);
            await dbContext.SaveChangesAsync();
            return department;
        }

        public Task<List<Department?>> GetAllDepartmentAsync()
        {
            return dbContext.Departments.ToListAsync();
        }

        public async Task<Department?> GetDepartmentByIdAsync(int id)
        {
            return await dbContext.Departments.FirstOrDefaultAsync(x => x.DepartmentId == id);
        }

        public async Task<Department?> UpdateDepartmentRecordAsync(int id, Department department)
        {            
            var existingDepartmentRecord = await dbContext.Departments.FirstOrDefaultAsync(x => x.DepartmentId == id);

            if (existingDepartmentRecord == null)
            {
                return null;
            }

            existingDepartmentRecord.DepartmentTitle= department.DepartmentTitle;

            await dbContext.SaveChangesAsync();
            return existingDepartmentRecord;
        }
    }
}
