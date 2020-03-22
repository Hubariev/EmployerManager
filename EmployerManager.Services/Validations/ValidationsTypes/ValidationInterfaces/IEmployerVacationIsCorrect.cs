using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EmployerManager.Domain;

namespace EmployerManager.Services.Validations.ValidationsTypes.ValidationInterfaces
{
    public interface IEmployerVacationIsCorrect
    {
        Task<IValidationResult> Validate(Employer employer, DateTime dayFrom, DateTime dayTo);
    }
}
