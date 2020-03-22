using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EmployerManager.Services.Validations.ExceptionMessages;
using EmployerManager.Services.Validations.ValidationsTypes.ValidationInterfaces;

namespace EmployerManager.Services.Validations.ValidationsTypes
{
    public class EmployerMaxVacationDaysIsCorrect: IEmployerMaxVacationDaysIsCorrect
    {
        public async Task<IValidationResult> Validate(int employerMaxVacationDays)
        {
            IValidationResult result = ValidationResult.CreateEmpty();

            if(employerMaxVacationDays < 0 || employerMaxVacationDays > 24)
                result.ResultParameters.Add(ExceptionMessage.NotValidCountOfMaxVacationDays);

            result.IsValid = result.ResultParameters.Count == 0;

            return result;
        }
    }
}
