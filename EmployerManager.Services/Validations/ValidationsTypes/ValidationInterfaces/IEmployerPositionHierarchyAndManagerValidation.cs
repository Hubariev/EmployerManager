using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EmployerManager.Services.DTO;

namespace EmployerManager.Services.Validations.ValidationsTypes.ValidationInterfaces
{
    public interface IEmployerPositionHierarchyAndManagerValidation
    {
        Task<IValidationResult> Validate(IEmployerPositionHierarchy employerPosition);
    }
}
