using EmployerManager.Domain;
using EmployerManager.Repository.Abstractions;
using EmployerManager.Repository.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployerManager.Repository.Repositories
{
    public class EmployersRepository: IRepository<Employer, Guid>
    {
        private ILiteDbContext database;

        public EmployersRepository(ILiteDbContext db)
        {
            this.database = db;
        }

        public async Task<List<Employer>> GetAllAsync()
        {
            return await this.database.GetEmployers();
        }

        public async Task Add(Employer employer)
        {
            await this.database.AddEmployer(employer);
        }

        public async Task Update(Employer employer)
        {
            await this.database.UpdateEmployer(employer);
        }

        public async Task Delete(Guid id)
        {
            await this.database.DeleteEmployer(id);
        }

        public async Task<Employer> GetById(Guid employerId)
        {
            if(employerId == Guid.Empty && employerId == null)
            {
                throw new Exception("No such employer.");
            }

            var employer = await this.database.GetEmployerById(employerId);

            if (employer == null)
                throw new Exception("No employer with this Id.");
            else
                return employer;
        }
    }
}
