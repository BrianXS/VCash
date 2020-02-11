using System.Collections.Generic;
using System.Linq;
using API.Entities;
using API.Repositories.Interfaces;
using API.Resources.Incoming;
using API.Resources.Outgoing;
using API.Services.Database;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Implementations
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly VcashDbContext _dbContext;
        private readonly IMapper _mapper;

        public CustomerRepository(VcashDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        
        public CustomerResponse FindCustomerResponseById(int id)
        {
            var customer = _dbContext.Customers.Where(x => x.Id.Equals(id))
                .Include(x => x.Headquarters)
                .Include(x => x.InvoicingCity)
                .Include(x => x.Cashiers)
                .Include(x => x.Offices)
                .FirstOrDefault();
            
            return _mapper.Map<CustomerResponse>(customer);
        }

        public Customer FindCustomerById(int id)
        {
            return _dbContext.Customers.FirstOrDefault(x => x.Id.Equals(id));
        }

        public List<CustomerResponse> GetAllCustomers()
        {
            var customers = _dbContext.Customers
                .Include(x => x.Headquarters)
                .Include(x => x.InvoicingCity)
                .Include(x => x.Cashiers)
                .Include(x => x.Offices)
                .ToList();
            
            return _mapper.Map<List<CustomerResponse>>(customers);
        }

        public void CreateCustomer(CustomerCreateRequest customer)
        {
            _dbContext.Customers.Add(_mapper.Map<Customer>(customer));
            _dbContext.SaveChanges();
        }

        public CustomerResponse UpdateCustomer(int id, CustomerUpdateRequest updatedCustomer)
        {
            var customerToBeUpdated = _dbContext.Customers.FirstOrDefault(x => x.Id.Equals(id));
            _mapper.Map(updatedCustomer, customerToBeUpdated);

            _dbContext.Customers.Update(customerToBeUpdated);
            _dbContext.SaveChanges();
            return _mapper.Map<CustomerResponse>(customerToBeUpdated);
        }

        public void DeleteCustomer(Customer customer)
        {
            _dbContext.Customers.Remove(customer);
            _dbContext.SaveChanges();
        }
    }
}