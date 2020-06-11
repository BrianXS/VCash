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
    public class CustomerFundRepository : ICustomerFundRepository
    {
        private readonly VcashDbContext _dbContext;
        private readonly IMapper _mapper;

        public CustomerFundRepository(VcashDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public CustomerFundResponse FindCustomerFundResponseById(int customerId, int officeId)
        {
            var customerFund = _dbContext
                .OfficesAndFunds.Where(x => x.CustomerId.Equals(customerId)
                                            && x.OfficeId.Equals(officeId))
                .Include(x => x.Customer)
                .Include(x => x.Office)
                .FirstOrDefault();

            return _mapper.Map<CustomerFundResponse>(customerFund);
        }

        public CustomerFund FindCustomerFundByCustomerAndOffice(int customerId, int officeId)
        {
            var customerFund = _dbContext
                .OfficesAndFunds.FirstOrDefault(x => x.CustomerId.Equals(customerId) 
                                                     && x.OfficeId.Equals(officeId));
            return customerFund;
        }

        public List<CustomerFundResponse> GetAllCustomerFunds()
        {
            var funds = _dbContext.OfficesAndFunds
                .Include(x => x.Customer)
                .Include(x => x.Office)
                .ToList();

            return _mapper.Map<List<CustomerFundResponse>>(funds);
        }

        public List<CustomerFundResponse> GetAllCustomerFundsByClient(int customerId)
        {
            var funds = _dbContext
                .OfficesAndFunds.Where(x => x.CustomerId.Equals(customerId))
                .Include(x => x.Customer)
                .Include(x => x.Office)
                .ToList();
            
            return _mapper.Map<List<CustomerFundResponse>>(funds);
        }

        public void CreateCustomerFund(CustomerFundCreateRequest customerFund)
        {
            if (FindCustomerFundByCustomerAndOffice(customerFund.CustomerId, customerFund.OfficeId) == null)
            {
                _dbContext.OfficesAndFunds.Add(_mapper.Map<CustomerFund>(customerFund));
                _dbContext.SaveChanges();   
            }
        }

        public void CreateCustomerFund(List<CustomerFundCreateRequest> customerFunds)
        {
            _dbContext.OfficesAndFunds.AddRange(_mapper.Map<List<CustomerFund>>(customerFunds));
            _dbContext.SaveChanges();
        }

        public CustomerFundResponse UpdateCustomerFund(int customerId, int officeId, CustomerFundUpdateRequest customerFund)
        {
            var fundToUpdate = _dbContext.OfficesAndFunds
                .FirstOrDefault(x => x.CustomerId.Equals(customerId) 
                                     && x.OfficeId.Equals(officeId));
            
            _mapper.Map(customerFund, fundToUpdate);
            
            _dbContext.OfficesAndFunds.Update(fundToUpdate);
            _dbContext.SaveChanges();
            
            return _mapper.Map<CustomerFundResponse>(fundToUpdate);
        }

        public void DeleteCustomerFund(CustomerFund customerFund)
        {
            _dbContext.OfficesAndFunds.Remove(customerFund);
            _dbContext.SaveChanges();
        }

        public int CountFunds()
        {
            return _dbContext.OfficesAndFunds.Count();
        }
    }
}