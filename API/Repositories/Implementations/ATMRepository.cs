using System.Collections.Generic;
using System.Linq;
using API.Entities;
using API.Repositories.Interfaces;
using API.Resources.Incoming;
using API.Resources.Outgoing;
using API.Services.Database;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Implementations
{
    public class ATMRepository : IATMRepository
    {
        private readonly VcashDbContext _dbContext;
        private readonly IMapper _mapper;

        public ATMRepository(VcashDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public ATMResponse FindATMResponseById(int id)
        {
            var atm = _dbContext.ATMs.Where(x => x.Id.Equals(id))
                .Include(x => x.Office)
                .Include(x => x.AtmBattery)
                .FirstOrDefault();

            return _mapper.Map<ATMResponse>(atm);
        }

        public ATM FindATMById(int id)
        {
            return _dbContext.ATMs.FirstOrDefault(x => x.Id.Equals(id));
        }

        public List<ATMResponse> GetAllATM()
        {
            var atms = _dbContext.ATMs.ToList();
            return _mapper.Map<List<ATMResponse>>(atms);
        }

        public void CreateATM(ATMCreateRequest atm)
        {
            throw new System.NotImplementedException();
            _dbContext.SaveChanges();
        }

        public ATMResponse UpdateATM(int id, ATMUpdateRequest updatedATM)
        {
            var atmToUpdate = _dbContext.ATMs.FirstOrDefault(x => x.Id.Equals(id));
            _mapper.Map(updatedATM, atmToUpdate);

            _dbContext.ATMs.Update(atmToUpdate);
            _dbContext.SaveChanges();
            
            return _mapper.Map<ATMResponse>(atmToUpdate);
        }

        public void DeleteATM(ATM atm)
        {
            _dbContext.ATMs.Remove(atm);
            _dbContext.SaveChanges();
        }
    }
}