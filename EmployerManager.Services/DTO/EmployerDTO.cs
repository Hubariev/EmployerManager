using EmployerManager.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployerManager.Services.DTO
{
    public class EmployerDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Position Position { get; set; }
        public string ManagerName { get; set; }
        public string ManagerSurname { get; set; }
        public Guid ManagerId { get; set; }
        public int MaxVacationDays { get; set; }
        public List<Vacation> Vacations { get; set; }
    }
}
