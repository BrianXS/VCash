using System.Collections.Generic;
using API.Entities;
using API.Entities.Administrative;
using API.Resources.Incoming;
using API.Resources.Incoming.AdministrativeResources;
using API.Resources.Outgoing;
using API.Resources.Outgoing.AdministrativeResources;

namespace API.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        CustomerResponse FindCustomerResponseById(int id);
        Customer FindCustomerById(int id);
        List<CustomerResponse> GetAllCustomers();
        List<CustomerResponse> GetAllCustomersWithoutRelationships();
        void CreateCustomer(CustomerCreateRequest customer);
        void CreateCustomerRange(List<CustomerCreateRequest> customers);
        CustomerResponse UpdateCustomer(int id, CustomerUpdateRequest updatedCustomer);
        void DeleteCustomer(Customer customer);
        int CountCusdtomers();
    }
}