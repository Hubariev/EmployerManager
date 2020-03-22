using EmployerManager.Domain;
using System;

namespace EmployerManager.Services.DTO
{
    public interface IEmployerPositionHierarchy
    {
        Position Position { get; set; }
        Guid ManagerId { get; set; }
    }
}
