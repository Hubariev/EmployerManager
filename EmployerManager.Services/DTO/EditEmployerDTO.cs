using EmployerManager.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployerManager.Services.DTO
{
    public class EditEmployerDTO: IEmployerPositionHierarchy
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Position Position { get; set; }
        public Guid ManagerId { get; set; }
        public int MaxVacationDays { get; set; }
    }
}
