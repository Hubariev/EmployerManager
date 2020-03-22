using System;
using System.Collections.Generic;
using System.Text;

namespace EmployerManager.Services.DTO
{
    public class EmployerVacationDTO
    {
        public Guid EmployerId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
