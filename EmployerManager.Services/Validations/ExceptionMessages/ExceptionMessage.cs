using System;
using System.Collections.Generic;
using System.Text;

namespace EmployerManager.Services.Validations.ExceptionMessages
{
    public enum ExceptionMessage
    {
        TooLongVacation,
        TooLongVacationInPriviousYear,
        TooLongVacationInNextYear,
        IncorrectDatesOfVacation,

        EmployerNameIsNullOrEmpty,
        EmployerSurnameIsNullOrEmpty,
        PositionHierarchicalIsNotValid,
        EmployerGuidIsEmpty,

        ManagerIdIsNull,
        EmployerAlreadyExist,
        NotValidCountOfMaxVacationDays

    }
}
