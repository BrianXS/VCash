using System.Collections.Generic;
using System.Linq;
using API.Entities;
using API.Repositories.Interfaces;
using API.Resources.Incoming;
using API.Resources.Incoming.AdministrativeResources;
using API.Resources.Outgoing;
using API.Resources.Outgoing.AdministrativeResources;
using API.Services.Database;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Implementations
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly VcashDbContext _dbContext;
        private readonly IMapper _mapper;

        public EmployeeRepository(VcashDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        
        public EmployeeResponse FindEmployeeResponseById(int id)
        {
            var employee = _dbContext.Employees.Where(x => x.Id.Equals(id))
                .Include(x => x.Branch).FirstOrDefault();
            
            return _mapper.Map<EmployeeResponse>(employee);
        }

        public Employee FindEmployeeById(int id)
        {
            return _dbContext.Employees.Where(x => x.Id.Equals(id)).Include(x => x.Branch).FirstOrDefault();
        }

        public List<EmployeeResponse> GetAllEmployees()
        {
            var employees = _dbContext.Employees.Include(x => x.Branch)
                .ToList();
            
            return _mapper.Map<List<EmployeeResponse>>(employees);
        }

        public void CreateEmployee(EmployeeCreateRequest employee)
        {
            _dbContext.Employees.Add(_mapper.Map<Employee>(employee));
            _dbContext.SaveChanges();
        }

        public void CreateEmployeeRange(List<EmployeeCreateRequest> employees)
        {
            _dbContext.Employees.AddRange(_mapper.Map<List<Employee>>(employees));
            _dbContext.SaveChanges();
        }

        public EmployeeResponse UpdateEmployee(int id, EmployeeUpdateRequest updatedEmployee)
        {
            var employeeToUpdate = _dbContext.Employees.FirstOrDefault(x => x.Id.Equals(id));
            _mapper.Map(updatedEmployee, employeeToUpdate);

            _dbContext.Employees.Update(employeeToUpdate);
            _dbContext.SaveChanges();

            return _mapper.Map<EmployeeResponse>(employeeToUpdate);
        }

        public void DeleteEmployee(Employee employee)
        {
            _dbContext.Employees.Remove(employee);
            _dbContext.SaveChanges();
        }
    }
}