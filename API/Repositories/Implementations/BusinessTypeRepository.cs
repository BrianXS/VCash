using System.Collections.Generic;
using System.Linq;
using API.Entities;
using API.Entities.Administrative;
using API.Repositories.Interfaces;
using API.Resources.Incoming;
using API.Resources.Incoming.AdministrativeResources;
using API.Resources.Outgoing;
using API.Resources.Outgoing.AdministrativeResources;
using API.Services.Database;
using AutoMapper;

namespace API.Repositories.Implementations
{
    public class BusinessTypeRepository : IBusinessTypeRepository
    {
        private readonly VcashDbContext _dbContext;
        private readonly IMapper _mapper;

        public BusinessTypeRepository(VcashDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public BusinessTypeResponse FindBusinessTypeResponseById(int id)
        {
            var businessType = _dbContext.BusinessTypes.FirstOrDefault(x => x.Id.Equals(id));
            return _mapper.Map<BusinessTypeResponse>(businessType);
        }

        public BusinessType FindBusinessTypeById(int id)
        {
            return _dbContext.BusinessTypes.FirstOrDefault(x => x.Id.Equals(id));
        }

        public List<BusinessTypeResponse> GetAllBusinessTypes()
        {
            var businessTypes = _dbContext.BusinessTypes.ToList();
            return _mapper.Map<List<BusinessTypeResponse>>(businessTypes);
        }

        public void CreateBusinessType(BusinessTypeCreateRequest businessType)
        {
            _dbContext.BusinessTypes.Add(_mapper.Map<BusinessType>(businessType));
            _dbContext.SaveChanges();
        }

        public BusinessTypeResponse UpdateBusinessType(int id, BusinessTypeUpdateRequest updatedBusinessType)
        {
            var businessTypeToUpdate = _dbContext.BusinessTypes.FirstOrDefault(x => x.Id.Equals(id));
            _mapper.Map(updatedBusinessType, businessTypeToUpdate);

            _dbContext.BusinessTypes.Update(businessTypeToUpdate);
            _dbContext.SaveChanges();
            
            return _mapper.Map<BusinessTypeResponse>(businessTypeToUpdate);
        }

        public void DeleteBusinessType(BusinessType businessType)
        {
            _dbContext.BusinessTypes.Remove(businessType);
            _dbContext.SaveChanges();
        }
    }
}