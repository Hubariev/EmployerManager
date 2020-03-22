using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmployerManager.Services.DTO;

namespace EmployerManager.Services.Services
{
    public interface IEmployerService
    {
        Task<List<EmployerDTO>> GetAllEmployers();
        Task AddEmployer(AddEmployerDTO employerDTO);
        Task EditEmployer(EditEmployerDTO employerDTO);
        Task SetEmployerVacation(EmployerVacationDTO employerVacationDTO);
        Task DeleteEmployer(Guid id);
    }
}
