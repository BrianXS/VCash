using System.Collections.Generic;
using API.Entities;
using API.Resources.Incoming;
using API.Resources.Outgoing;

namespace API.Repositories.Interfaces
{
    public interface ICustomerFundRepository
    {
        CustomerFundResponse FindCustomerFundResponseById(int id);
        CustomerFund FindCustomerFundById(int id);
        List<CustomerFundResponse> GetAllCustomerFunds();
        void CreateCustomerFund(CustomerFundCreateRequest customerFund);
        CustomerFundResponse UpdateCustomerFund(int id, CustomerFundUpdateRequest customerFund);
        void DeleteCustomerFund(CustomerFund customerFund);
    }
}