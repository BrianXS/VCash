using System.Collections.Generic;
using API.Entities;
using API.Resources.Incoming;
using API.Resources.Outgoing;

namespace API.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        CustomerResponse FindCustomerResponseById(int id);
        Customer FindCustomerById(int id);
        List<CustomerResponse> GetAllCustomers();
        void CreateCustomer(CustomerCreateRequest customer);
        CustomerResponse UpdateCustomer(int id, CustomerUpdateRequest updatedCustomer);
        void DeleteCustomer(Customer customer);
    }
}