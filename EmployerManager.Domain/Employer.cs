using System;
using System.Collections.Generic;
using System.Text;

namespace EmployerManager.Domain
{
    public class Employer
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public Position Position { get; private set; }
        public Guid ManagerId { get; private set; }
        public int MaxVacationDays { get; private set; }
        public List<Vacation> Vacations { get; private set; }

        public Employer() { } // parameterless constructor for LiteDb

        public Employer(string name, string surname, Position position, Guid managerId, int maxVacationDays)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Surname = surname;
            this.Position = position;
            this.ManagerId = managerId;
            this.MaxVacationDays = maxVacationDays;
            this.Vacations = new List<Vacation>();
        }

        public void SetEmployerProperties(string name, string surname, Position position, Guid managerId,
            int maxVacationDays)
        {
            this.Name = name;
            this.Surname = surname;
            this.Position = position;
            this.ManagerId = managerId;
            this.MaxVacationDays = maxVacationDays;
        }

        public void AddVacation(DateTime dayFrom, DateTime dayTo)
        {
            this.Vacations.Add(new Vacation(dayFrom, dayTo));
        }
    }
}
