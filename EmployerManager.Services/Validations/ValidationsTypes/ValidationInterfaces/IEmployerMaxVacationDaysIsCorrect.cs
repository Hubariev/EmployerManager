using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployerManager.Services.Validations.ValidationsTypes.ValidationInterfaces
{
    public interface IEmployerMaxVacationDaysIsCorrect
    {
        Task<IValidationResult> Validate(int employerMaxVacationDays);
    }
}
