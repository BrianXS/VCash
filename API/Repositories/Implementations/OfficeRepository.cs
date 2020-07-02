using System;
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
    public class OfficeRepository : IOfficeRepository
    {
        private readonly VcashDbContext _dbContext;
        private readonly ICustomerFundRepository _customerFundRepository;
        private readonly IMapper _mapper;

        public OfficeRepository(VcashDbContext dbContext, 
            ICustomerFundRepository customerFundRepository, 
            IMapper mapper)
        {
            _dbContext = dbContext;
            _customerFundRepository = customerFundRepository;
            _mapper = mapper;
        }
        
        public OfficeResponse FindOfficeResourceById(int id)
        {
            var office = _dbContext.Offices
                .Include(x => x.Customer)
                .FirstOrDefault(x => x.Id.Equals(id));
            
            return _mapper.Map<OfficeResponse>(office);
        }

        public Office FindOfficeById(int id)
        {
            return _dbContext.Offices.FirstOrDefault(x => x.Id.Equals(id));
        }

        public List<OfficeResponse> FindAllFundsByClientId(int id)
        {
            var results = _dbContext.Offices
                .Where(x => x.CustomerId.Equals(id) && x.IsFund);
            
            return _mapper.Map<List<OfficeResponse>>(results);
        }

        public List<OfficeResponse> FindAllOfficesByClientIdAndBranchId(int clientId, int branchId)
        {
            var results = _dbContext.Offices
                .Include(x => x.City)
                .Where(x => x.CustomerId.Equals(clientId)
                            && x.City.BranchId == branchId
                            && !x.IsFund);
            
            return _mapper.Map<List<OfficeResponse>>(results);
        }

        public List<OfficeResponse> GetAllOffices()
        {
            var offices = _dbContext.Offices
                .Include(x => x.Customer)
                .ToList();
            
            return _mapper.Map<List<OfficeResponse>>(offices);
        }

        public void CreateOffice(OfficeCreateRequest office)
        {
            _dbContext.Offices.Add(_mapper.Map<Office>(office));
            _dbContext.SaveChanges();
        }

        public void CreateOfficesRange(List<OfficeCreateRequest> office)
        {
            var requestsToItems = _mapper.Map<List<Office>>(office);
            _dbContext.Offices.AddRange(requestsToItems);
            _dbContext.SaveChanges();

            var funds = requestsToItems.Where(x => x.IsFund);
            foreach (var item in funds)
            {
                _customerFundRepository.CreateCustomerFund(new CustomerFundCreateRequest
                {
                    CustomerId = item.CustomerId,
                    OfficeId = item.Id
                });
            }
        }

        public OfficeResponse UpdateOffice(int id, OfficeUpdateRequest updatedOffice)
        {
            var officeToUpdate = _dbContext.Offices.FirstOrDefault(x => x.Id.Equals(id));
            _mapper.Map(updatedOffice, officeToUpdate);

            _dbContext.Offices.Update(officeToUpdate);
            _dbContext.SaveChanges();
            
            return _mapper.Map<OfficeResponse>(officeToUpdate);
        }

        public void DeleteOffice(Office office)
        {
            _dbContext.Offices.Remove(office);
            _dbContext.SaveChanges();
        }

        public int CountOffices()
        {
            return _dbContext.Offices.Count();
        }
    }
}