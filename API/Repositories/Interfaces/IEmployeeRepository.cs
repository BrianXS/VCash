using System.Collections.Generic;
using API.Entities;
using API.Resources.Incoming;
using API.Resources.Incoming.AdministrativeResources;
using API.Resources.Outgoing;
using API.Resources.Outgoing.AdministrativeResources;

namespace API.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        EmployeeResponse FindEmployeeResponseById(int id);
        Employee FindEmployeeById(int id);
        List<EmployeeResponse> GetAllEmployees();
        void CreateEmployee(EmployeeCreateRequest employee);
        void CreateEmployeeRange(List<EmployeeCreateRequest> employees);
        EmployeeResponse UpdateEmployee(int id, EmployeeUpdateRequest employee);
        void DeleteEmployee(Employee employee);
    }
}