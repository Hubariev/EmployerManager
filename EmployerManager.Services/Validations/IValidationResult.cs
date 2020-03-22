using System;
using System.Collections.Generic;
using System.Text;
using EmployerManager.Services.Validations.ExceptionMessages;

namespace EmployerManager.Services.Validations
{
    public interface IValidationResult
    {
        bool IsValid { get; set; }
        List<ExceptionMessage> ResultParameters { get; set; }
    }
}
