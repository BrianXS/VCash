using System.Collections.Generic;
using System.Linq;
using API.Entities;
using API.Entities.Administrative;
using API.Enums;
using API.Repositories.Interfaces;
using API.Resources.Incoming;
using API.Resources.Incoming.AdministrativeResources;
using API.Resources.Outgoing;
using API.Resources.Outgoing.AdministrativeResources;
using API.Services.Database;
using AutoMapper;

namespace API.Repositories.Implementations
{
    public class DenominationTypeRepository : IDenominationTypeRepository
    {
        private readonly VcashDbContext _dbContext;
        private readonly IMapper _mapper;

        public DenominationTypeRepository(VcashDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public DenominationTypeResponse FindDenominationTypeResponseById(int id)
        {
            var denominationType = _dbContext.DenominationTypes.FirstOrDefault(x => x.Id.Equals(id));
            return _mapper.Map<DenominationTypeResponse>(denominationType);
        }

        public List<DenominationTypeResponse> FindDenominationsByCurrency(Currency currency)
        {
            var denominations = _dbContext.DenominationTypes.Where(x => x.Currency.Equals(currency)).ToList();
            return _mapper.Map<List<DenominationTypeResponse>>(denominations);
        }

        public DenominationType FindDenominationTypeById(int id)
        {
            return _dbContext.DenominationTypes.FirstOrDefault(x => x.Id.Equals(id));
        }

        public List<DenominationTypeResponse> GetAllDenominationTypes()
        {
            var denominationTypes = _dbContext.DenominationTypes.ToList();
            return _mapper.Map<List<DenominationTypeResponse>>(denominationTypes);
        }

        public void CreateDenominationType(DenominationTypeCreateRequest denominationType)
        {
            _dbContext.DenominationTypes.Add(_mapper.Map<DenominationType>(denominationType));
            _dbContext.SaveChanges();
        }

        public void CreateDenominationTypeRange(List<DenominationTypeCreateRequest> denominations)
        {
            _dbContext.DenominationTypes.AddRange(_mapper.Map<List<DenominationType>>(denominations));
            _dbContext.SaveChanges();
        }

        public DenominationTypeResponse UpdateDenominationType(int id, DenominationTypeUpdateRequest updatedDenominationType)
        {
            var denominationTypeToUpdate = _dbContext.DenominationTypes.FirstOrDefault(x => x.Id.Equals(id));
            _mapper.Map(updatedDenominationType, denominationTypeToUpdate);

            _dbContext.DenominationTypes.Update(denominationTypeToUpdate);
            _dbContext.SaveChanges();
            
            return _mapper.Map<DenominationTypeResponse>(denominationTypeToUpdate);
        }

        public void DeleteDenominationType(DenominationType denominationType)
        {
            _dbContext.DenominationTypes.Remove(denominationType);
            _dbContext.SaveChanges();
        }

        public int CountDenominationTypes()
        {
            return _dbContext.DenominationTypes.Count();
        }
    }
}