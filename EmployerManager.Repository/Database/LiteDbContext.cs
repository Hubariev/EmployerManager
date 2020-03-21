using EmployerManager.Domain;
using LiteDB;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployerManager.Repository.Database
{
    public class LiteDbContext: ILiteDbContext
    {
        private static IConfiguration Configuration;

        public LiteDatabase LiteDatabase { get; set; }

        public LiteDbContext(IConfiguration configuration) 
        {
            Configuration = configuration;
            var databasePath = GetDataBasePath(Configuration);
            LiteDatabase = new LiteDatabase(databasePath);
        }

        public async Task<List<Employer>> GetEmployers()
        {
            return this.LiteDatabase.GetCollection<Employer>("Employer").FindAll().ToList();
        }

        public async Task AddEmployer(Employer employer)
        {
            this.LiteDatabase.GetCollection<Employer>("Employer").Insert(employer);
        }

        public async Task UpdateEmployer(Employer employer)
        {
            this.LiteDatabase.GetCollection<Employer>("Employer").Update(employer);
        }

        public async Task<Employer> GetEmployerById(Guid id)
        {
            return this.LiteDatabase.GetCollection<Employer>("Employer").Find(x => x.Id == id).FirstOrDefault();
        }

        public async Task DeleteEmployer(Guid id)
        {
            this.LiteDatabase.GetCollection<Employer>("Employer").Delete(id);
        }

        private string GetDataBasePath(IConfiguration config)
        {
            return config.GetSection("LiteDbOption").GetSection("DatabaseLocation").Value;
        }
    }
}
