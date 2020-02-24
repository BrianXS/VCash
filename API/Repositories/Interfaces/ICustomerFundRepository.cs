using System.Collections.Generic;
using API.Entities;
using API.Resources.Incoming;
using API.Resources.Outgoing;

namespace API.Repositories.Interfaces
{
    public interface ICustomerFundRepository
    {
        CustomerFundResponse FindCustomerFundResponseById(int customerId, int officeId);
        CustomerFund FindCustomerFundByCustomerAndOffice(int customerId, int officeId);
        
        List<CustomerFundResponse> GetAllCustomerFunds();
        List<CustomerFundResponse> GetAllCustomerFundsByClient(int customerId);
        void CreateCustomerFund(CustomerFundCreateRequest customerFund);
        CustomerFundResponse UpdateCustomerFund(int customerId, int officeId, CustomerFundUpdateRequest customerFund);
        void DeleteCustomerFund(CustomerFund customerFund);
    }
}