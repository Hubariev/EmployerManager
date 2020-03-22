using EmployerManager.Services.Validations.ExceptionMessages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployerManager.Services.Validations
{
    public class ValidationResult: IValidationResult
    {
        public bool IsValid { get; set; }
        public List<ExceptionMessage> ResultParameters { get; set; }

        public ValidationResult()
        {
            this.IsValid = true;
            this.ResultParameters = new List<ExceptionMessage>();
        }

        public static IValidationResult CreateEmpty()
        {
            IValidationResult result = new ValidationResult();
            return result;
        }
    }
}
