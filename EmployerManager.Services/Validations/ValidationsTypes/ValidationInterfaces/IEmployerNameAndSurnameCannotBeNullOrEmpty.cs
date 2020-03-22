using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployerManager.Services.Validations.ValidationsTypes.ValidationInterfaces
{
    public interface IEmployerNameAndSurnameCannotBeNullOrEmpty
    {
        Task<IValidationResult> Validate(string employerName, string employerSurname);
    }
}
