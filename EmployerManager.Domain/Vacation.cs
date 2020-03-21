using System;
using System.Collections.Generic;
using System.Text;

namespace EmployerManager.Domain
{
    public class Vacation
    {
        public DateTime StartVacation { get; }
        public DateTime EndVacation { get; }

        public Vacation(DateTime startVacation, DateTime endVacation)
        {
            this.StartVacation = startVacation;
            this.EndVacation = endVacation;
        }
    }
}
