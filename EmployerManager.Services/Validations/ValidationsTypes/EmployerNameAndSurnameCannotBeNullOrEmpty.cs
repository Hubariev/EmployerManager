using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EmployerManager.Services.Validations.ExceptionMessages;
using EmployerManager.Services.Validations.ValidationsTypes.ValidationInterfaces;

namespace EmployerManager.Services.Validations.ValidationsTypes
{
    public class EmployerNameAndSurnameCannotBeNullOrEmpty: IEmployerNameAndSurnameCannotBeNullOrEmpty
    {
        public async Task<IValidationResult> Validate(string employerName, string employerSurname)
        {
            IValidationResult result = ValidationResult.CreateEmpty();

            if(string.IsNullOrEmpty(employerName))
                result.ResultParameters.Add(ExceptionMessage.EmployerNameIsNullOrEmpty);

            if(string.IsNullOrEmpty(employerSurname))
                result.ResultParameters.Add(ExceptionMessage.EmployerSurnameIsNullOrEmpty);

            result.IsValid = result.ResultParameters.Count == 0;

            return result;
        }
    }
}
