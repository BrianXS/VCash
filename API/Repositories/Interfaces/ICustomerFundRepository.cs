using System.Collections.Generic;
using API.Entities;
using API.Entities.Administrative;
using API.Resources.Incoming;
using API.Resources.Incoming.AdministrativeResources;
using API.Resources.Outgoing;
using API.Resources.Outgoing.AdministrativeResources;

namespace API.Repositories.Interfaces
{
    public interface ICustomerFundRepository
    {
        CustomerFundResponse FindCustomerFundResponseById(int customerId, int officeId);
        CustomerFund FindCustomerFundByCustomerAndOffice(int customerId, int officeId);
        
        List<CustomerFundResponse> GetAllCustomerFunds();
        List<CustomerFundResponse> GetAllCustomerFundsByClient(int customerId);
        void CreateCustomerFund(CustomerFundCreateRequest customerFund);
        void CreateCustomerFundRange(List<CustomerFundCreateRequest> customerFunds);
        CustomerFundResponse UpdateCustomerFund(int customerId, int officeId, CustomerFundUpdateRequest customerFund);
        void DeleteCustomerFund(CustomerFund customerFund);
        int CountFunds();
    }
}