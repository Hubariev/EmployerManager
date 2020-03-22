using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using EmployerManager.Services.Validations;

namespace EmployerManager.Services.Services
{
    public class ServiceBase
    {
        protected void HandleValidation(IValidationResult result)
        {
            if(!result.IsValid) throw new ValidationException($"{string.Join(",",result.ResultParameters.Select(r => r.ToString()))}");
        }
    }
}
