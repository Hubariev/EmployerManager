using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployerManager.Domain;
using EmployerManager.Services.Validations.ExceptionMessages;
using EmployerManager.Services.Validations.ValidationsTypes.ValidationInterfaces;

namespace EmployerManager.Services.Validations.ValidationsTypes
{
    public class EmployerVacationIsCorrect: IEmployerVacationIsCorrect
    {
        public async Task<IValidationResult> Validate(Employer employer, DateTime dayFrom, DateTime dayTo)
        {
            IValidationResult result = ValidationResult.CreateEmpty();

            var availableCountOfVacationDays = employer.MaxVacationDays - GetVacationsFromCurrentYear(employer);

            if (dayFrom.Year == dayTo.Year && dayFrom.DayOfYear <= dayTo.DayOfYear)
            {
                var choosedVacationDaysCurrentYear = GetDatesInSameYear(dayFrom, dayTo);

                if (availableCountOfVacationDays < choosedVacationDaysCurrentYear.Count())
                {
                    result.ResultParameters.Add(ExceptionMessage.TooLongVacation);
                }
            }
            else if (dayFrom.Year < dayTo.Year)
            {
                var choosedVacationDaysPriviousYear = GetDatesInPriviousYear(dayFrom, dayTo);

                if (availableCountOfVacationDays < choosedVacationDaysPriviousYear.Count())
                {
                    result.ResultParameters.Add(ExceptionMessage.TooLongVacationInPriviousYear);
                }

                availableCountOfVacationDays = employer.MaxVacationDays - GetVacationsFromCurrentYear(employer);

                var choosedVacationDaysNextYear = GetDatesInNextYear(dayFrom, dayTo);

                if (availableCountOfVacationDays < choosedVacationDaysNextYear.Count())
                {
                    result.ResultParameters.Add(ExceptionMessage.TooLongVacationInNextYear);
                }
            }
            else
            {
                result.ResultParameters.Add(ExceptionMessage.IncorrectDatesOfVacation);
            }

            result.IsValid = result.ResultParameters.Count == 0;

            return result;
        }

        private IEnumerable<DateTime> GetDatesInSameYear(DateTime fromDate, DateTime toDate)
        {
            return Enumerable.Range(0, toDate.Subtract(fromDate).Days + 1).
                Select(d => fromDate.AddDays(d)).
                Where(d => d.DayOfWeek != DayOfWeek.Saturday && d.DayOfWeek != DayOfWeek.Sunday);
        }

        private IEnumerable<DateTime> GetDatesInPriviousYear(DateTime fromDate, DateTime toDate)
        {
            return Enumerable.Range(0, new DateTime(toDate.Year, 1, 1).Subtract(fromDate).Days).
                Select(d => fromDate.AddDays(d)).
                Where(d => d.DayOfWeek != DayOfWeek.Saturday && d.DayOfWeek != DayOfWeek.Sunday);
        }

        private IEnumerable<DateTime> GetDatesInNextYear(DateTime fromDate, DateTime toDate)
        {
            return Enumerable.Range(0, toDate.DayOfYear).
                Select(d => new DateTime(toDate.Year, 1, 1).AddDays(d)).
                Where(d => d.DayOfWeek != DayOfWeek.Saturday && d.DayOfWeek != DayOfWeek.Sunday);
        }

        private int GetVacationsFromCurrentYear(Employer employer)
        {
            var vacations = employer.Vacations
                .Where(d => (d.StartVacation.Year == DateTime.Now.Year &&
                             d.EndVacation.Year == DateTime.Now.Year)).ToList();

            var counter = 0;

            foreach (var vacation in vacations)
            {
                counter += GetDatesInSameYear(vacation.StartVacation, vacation.EndVacation).Count();
            }

            return counter;
        }
    }
}
