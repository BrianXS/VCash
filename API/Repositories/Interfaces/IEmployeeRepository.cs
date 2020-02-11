using System.Collections.Generic;
using API.Entities;
using API.Resources.Incoming;
using API.Resources.Outgoing;

namespace API.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        EmployeeResponse FindEmployeeResponseById(int id);
        Employee FindEmployeeById(int id);
        List<EmployeeResponse> GetAllEmployees();
        void CreateEmployee(EmployeeCreateRequest employee);
        EmployeeResponse UpdateEmployee(int id, EmployeeUpdateRequest employee);
        void DeleteEmployee(Employee employee);
    }
}