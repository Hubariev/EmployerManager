using EmployerManager.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployerManager.Repository.Database
{
    public interface ILiteDbContext
    {
        Task<List<Employer>> GetEmployers();
        Task AddEmployer(Employer employer);
        Task UpdateEmployer(Employer employer);
        Task<Employer> GetEmployerById(Guid id);
        Task DeleteEmployer(Guid id);
    }
}
