using System;
using System.Threading.Tasks;
using EmployerManager.Domain;
using EmployerManager.Repository.Abstractions;
using EmployerManager.Services.DTO;
using EmployerManager.Services.Validations.ExceptionMessages;
using EmployerManager.Services.Validations.ValidationsTypes.ValidationInterfaces;

namespace EmployerManager.Services.Validations.ValidationsTypes
{
    public class EmployerPositionHierarchyAndManagerValidation: IEmployerPositionHierarchyAndManagerValidation
    {
        private IRepository<Employer, Guid> EmployersRepository;

        public EmployerPositionHierarchyAndManagerValidation(IRepository<Employer, Guid> employersRepository)
        {
            this.EmployersRepository = employersRepository;
        }
        public async Task<IValidationResult> Validate(IEmployerPositionHierarchy employer)
        {
            IValidationResult result = ValidationResult.CreateEmpty();

            if (employer.Position != Position.CEO)
            {

                var manager = await this.EmployersRepository.GetById(employer.ManagerId);

                if(employer.Position > manager.Position)
                    result.ResultParameters.Add(ExceptionMessage.PositionHierarchicalIsNotValid);

                if(employer.ManagerId == Guid.Empty)
                    result.ResultParameters.Add(ExceptionMessage.ManagerIdIsNull);

            }

            result.IsValid = result.ResultParameters.Count == 0;

            return result;
        }
    }
}
