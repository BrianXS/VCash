using System.Collections.Generic;
using System.Linq;
using API.Entities;
using API.Repositories.Interfaces;
using API.Resources.Incoming;
using API.Resources.Outgoing;
using API.Services.Database;
using AutoMapper;

namespace API.Repositories.Implementations
{
    public class OfficeRepository : IOfficeRepository
    {
        private readonly VcashDbContext _dbContext;
        private readonly IMapper _mapper;

        public OfficeRepository(VcashDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        
        public OfficeResponse FindOfficeResourceById(int id)
        {
            var office = _dbContext.Offices.FirstOrDefault(x => x.Id.Equals(id));
            return _mapper.Map<OfficeResponse>(office);
        }

        public Office FindOfficeById(int id)
        {
            return _dbContext.Offices.FirstOrDefault(x => x.Id.Equals(id));
        }

        public List<OfficeResponse> GetAllOffices()
        {
            var offices = _dbContext.Offices.ToList();
            return _mapper.Map<List<OfficeResponse>>(offices);
        }

        public void CreateOffice(OfficeCreateRequest office)
        {
            _dbContext.Offices.Add(_mapper.Map<Office>(office));
            _dbContext.SaveChanges();
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
    }
}