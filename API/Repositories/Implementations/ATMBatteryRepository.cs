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
    public class ATMBatteryRepository : IATMBatteryRepostiory
    {
        private readonly VcashDbContext _dbContext;
        private readonly IMapper _mapper;

        public ATMBatteryRepository(VcashDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        
        public ATMBatteryResponse FindATMBatteryResponseById(int id)
        {
            var battery = _dbContext.AtmBatteries.Where(x => x.Id.Equals(id))
                .Include(x => x.Atms).FirstOrDefault();

            return _mapper.Map<ATMBatteryResponse>(battery);
        }

        public ATMBattery FindATMBatteryById(int id)
        {
            return _dbContext.AtmBatteries.FirstOrDefault(x => x.Id.Equals(id));
        }

        public List<ATMBatteryResponse> GetAllATMBatteries()
        {
            var batteries = _dbContext.AtmBatteries.ToList();
            return _mapper.Map<List<ATMBatteryResponse>>(batteries);
        }

        public void CreateATMBattery(ATMBatteryCreateRequest battery)
        {
            _dbContext.AtmBatteries.Add(_mapper.Map<ATMBattery>(battery));
            _dbContext.SaveChanges();
        }

        public ATMBatteryResponse UpdateATMBattery(int id, ATMBatteryUpdateRequest updatedBattery)
        {
            var atmBatteryToUpdate = _dbContext.AtmBatteries.FirstOrDefault(x => x.Id.Equals(id));
            _mapper.Map(updatedBattery, atmBatteryToUpdate);

            _dbContext.AtmBatteries.Update(atmBatteryToUpdate);
            _dbContext.SaveChanges();
            
            return _mapper.Map<ATMBatteryResponse>(atmBatteryToUpdate);
        }

        public void DeleteATMBattery(ATMBattery branch)
        {
            _dbContext.AtmBatteries.Remove(branch);
            _dbContext.SaveChanges();
        }
    }
}