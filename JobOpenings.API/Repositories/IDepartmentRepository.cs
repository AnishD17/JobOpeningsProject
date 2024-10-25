using JobOpenings.API.Models.Domain;
using System.Diagnostics;

namespace JobOpenings.API.Repositories
{
    public interface IDepartmentRepository
    {
        Task<List<Department?>> GetAllDepartmentAsync();
        Task<Department?> GetDepartmentByIdAsync(int id);
        Task<Department> CreateDepartmentRecordAsync(Department department);
        Task<Department?> UpdateDepartmentRecordAsync(int id, Department department);
    }
}
