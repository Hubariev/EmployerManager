using EmployerManager.Repository.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployerManager.Domain;
using EmployerManager.Services.DTO;
using EmployerManager.Services.Validations.ValidationsTypes.ValidationInterfaces;

namespace EmployerManager.Services.Services
{
    public class EmployerService: ServiceBase, IEmployerService
    {
        private readonly IRepository<Employer, Guid> employerRepository;
        private readonly IEmployerVacationIsCorrect employerVacationIsCorrect;
        private readonly IEmployerMaxVacationDaysIsCorrect employerMaxVacationDaysIsCorrect;
        private readonly IEmployerPositionHierarchyAndManagerValidation employerPositionHierarchyAndManagerValidation;
        private readonly IEmployerNameAndSurnameCannotBeNullOrEmpty employerNameAndSurnameCannotBeNullOrEmpty;

        public EmployerService(IRepository<Employer, Guid> employerRepository, IEmployerVacationIsCorrect employerVacationIsCorrect, 
                               IEmployerNameAndSurnameCannotBeNullOrEmpty employerNameAndSurnameCannotBeNullOrEmpty,
                               IEmployerMaxVacationDaysIsCorrect employerMaxVacationDaysIsCorrect,
                               IEmployerPositionHierarchyAndManagerValidation employerPositionHierarchyAndManagerValidation)
        {
            this.employerRepository = employerRepository;
            this.employerVacationIsCorrect = employerVacationIsCorrect;
            this.employerMaxVacationDaysIsCorrect = employerMaxVacationDaysIsCorrect;
            this.employerPositionHierarchyAndManagerValidation = employerPositionHierarchyAndManagerValidation;
            this.employerNameAndSurnameCannotBeNullOrEmpty = employerNameAndSurnameCannotBeNullOrEmpty;
        }

        public async Task<List<EmployerDTO>> GetAllEmployers()
        {
            var employersDataBase = await this.employerRepository.GetAllAsync();
            var employersResult = new List<EmployerDTO>();

            foreach (var employer in employersDataBase)
            {
                var manager = employersDataBase.FirstOrDefault(m => m.Id == employer.ManagerId);

                employersResult.Add(new EmployerDTO
                {
                    Id = employer.Id,
                    Name = employer.Name,
                    Surname = employer.Surname,
                    Position = employer.Position,
                    ManagerName = manager != null? manager.Name: null,
                    ManagerSurname = manager != null? manager.Surname: null,
                    ManagerId = manager != null ? manager.Id: Guid.Empty,
                    MaxVacationDays = employer.MaxVacationDays,
                    Vacations = employer.Vacations
                });
            }

            return employersResult;
        }

        public async Task AddEmployer(AddEmployerDTO employerDTO)
        {
            //ToDo: refactoring -> Make Validations Generic(double code in add and edit employer)
            var validationNameAndSurname =
                await this.employerNameAndSurnameCannotBeNullOrEmpty.Validate(employerDTO.Name, employerDTO.Surname);
            this.HandleValidation(validationNameAndSurname);

            var validationMaxVacationDays =
                await this.employerMaxVacationDaysIsCorrect.Validate(employerDTO.MaxVacationDays);
            this.HandleValidation(validationMaxVacationDays);

            var validationPositionHierarchy = await this.employerPositionHierarchyAndManagerValidation.
                Validate(employerDTO);
            this.HandleValidation(validationPositionHierarchy);

            var employer = new Employer(
                employerDTO.Name,
                employerDTO.Surname,
                employerDTO.Position,
                employerDTO.ManagerId,
                employerDTO.MaxVacationDays
                );

            await this.employerRepository.Add(employer);
        }

        public async Task EditEmployer(EditEmployerDTO employerDTO)
        {
            var validationNameAndSurname =
                await this.employerNameAndSurnameCannotBeNullOrEmpty.Validate(employerDTO.Name, employerDTO.Surname);
            this.HandleValidation(validationNameAndSurname);

            var validationMaxVacationDays =
                await this.employerMaxVacationDaysIsCorrect.Validate(employerDTO.MaxVacationDays);
            this.HandleValidation(validationMaxVacationDays);

            var validationPositionHierarchy = await this.employerPositionHierarchyAndManagerValidation.
                Validate(employerDTO);
            this.HandleValidation(validationPositionHierarchy);

            var employer = await this.employerRepository.GetById(employerDTO.Id);

            employer.SetEmployerProperties(
                employerDTO.Name,
                employerDTO.Surname,
                employerDTO.Position,
                employerDTO.ManagerId,
                employerDTO.MaxVacationDays
                );
            await this.employerRepository.Update(employer);
        }

        public async Task SetEmployerVacation(EmployerVacationDTO employerVacationDTO)
        {
            var employer = await this.employerRepository.GetById(employerVacationDTO.EmployerId);

            var validation = await this.employerVacationIsCorrect.Validate(employer,
                employerVacationDTO.DateFrom, employerVacationDTO.DateTo);
            this.HandleValidation(validation);

            employer.AddVacation(employerVacationDTO.DateFrom, employerVacationDTO.DateTo);

            await this.employerRepository.Update(employer);
        }

        public async Task DeleteEmployer(Guid id)
        {
            var employer = await this.employerRepository.GetById(id);

            if (employer != null)
                await this.employerRepository.Delete(id);
        }
    }
}
